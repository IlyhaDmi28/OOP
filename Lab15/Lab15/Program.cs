using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab15
{
    internal class Program
    {
        private static object locker = new object();
        private static int[] Eratosthen()
        {
            int n = 300;

            int[] arr = new int[n+1];

            for (var i = 2; i < n; i++) arr[i] = 1;

            for (var i = 2; i * i <= n; i++)
            {
                if (arr[i] == 1)
                {
                    for (var j = i * i; j <= n; j += i)
                    {
                        arr[j] = 0;
                    }
                }
            }

            return arr;
        }

        private static int[] EratosthenCancellationToken(object cancel)
        {
            int n = 300;
            var token = (CancellationToken)cancel;

            int[] arr = new int[n + 1];

            for (var i = 2; i < n; i++) arr[i] = 1;

            for (var i = 2; i * i <= n; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"Таск №{Task.CurrentId} прерван токеном");
                    return null;
                }
                if (arr[i] == 1)
                {
                    for (var j = i * i; j <= n; j += i)
                    {
                        arr[j] = 0;
                    }
                }
            }

            return arr;
        }

        private static void StoragePrint(BlockingCollection<string> stor)
        {
            lock(locker)
            {
                Console.WriteLine("\nСклад: ");

                foreach (var item in stor)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\n");
            }
            
        }

        private static async void PrintResult()
        {
            long sum = 0;
            await Task.Run(() =>
            {
                for (var i = 0; i < 1000000000; i++)
                {
                    if (i % 2 == 0) sum += i;
                }
            });
            Console.WriteLine("Результат: " + sum);
        }

        static void Main(string[] args)
        {
            //1

            var watcher = new Stopwatch();
            var task = new Task<int[]>(Eratosthen);

            Console.WriteLine("Task id: " + task.Id);
            Console.WriteLine("Task status: " + task.Status);

            task.Start();
            watcher.Start();

            Console.WriteLine("Task id: " + task.Id);
            Console.WriteLine("Task status: " + task.Status);

            task.Wait();
            watcher.Stop();


            Console.WriteLine($"\nВремя выполнения задачи: {watcher.ElapsedMilliseconds} мс");

            //2

            var tokenSource = new CancellationTokenSource();
            var task2 = new Task<int[]>(EratosthenCancellationToken, tokenSource.Token);

            task2.Start();
            tokenSource.Cancel();

            //3, 4

            int a = 3;
            int b = 14;
            int c = 6;

            var first = Task.Run(() => a + b);
            var second = Task.Run(() => a * c);
            var third = Task.Run(() => b - c);

            Task.WhenAll(first, second, third).ContinueWith(res => Console.WriteLine("Result:" + first.Result + second.Result + third.Result));

            var awaiter = first.GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                Task.Run(() => Console.WriteLine("Квадрат из первого числа: " + Math.Pow(first.Result, 2)));
            });

            //5

            var arr1 = new int[1000000];
            var arr2 = new int[1000000];
            var arr3 = new int[1000000];

            var sw = new Stopwatch();

            var forResult = Parallel.For(1, 1000000, i =>
            {
                sw.Start();
                arr1[i] = i;
                arr2[i] = i;
                arr3[i] = i;
            });

            sw.Stop();

            Console.WriteLine($"Parallel for заполнил массивы за: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                arr1[i] = i;
                arr2[i] = i;
                arr3[i] = i;
            }
            sw.Stop();

            Console.WriteLine($"For заполнил массивы за {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            var foreachResult = Parallel.ForEach(arr1, el => arr2[el] = 0);
            sw.Stop();

            Console.WriteLine($"Parallel foreach заполнил массив нулями за {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            foreach (var i in arr3)
            {
                arr3[i] = 0;
            }
            sw.Stop();

            Console.WriteLine($"Foreach заполнил массив нулями за {sw.ElapsedMilliseconds} мс");

            //6

            Parallel.Invoke(
                () =>
                {
                    for (var i = 0; i < 1000000; i++)
                    {
                        arr1[i] = i;
                    }
                },

                () => {
                    for (var i = 0; i < 1000000; i++)
                    {
                        arr2[i] = i;
                    }
                },

                () => {
                    for (var i = 0; i < 1000000; i++)
                    {
                        arr3[i] = i;
                    }
                });

            //7, 8

            var storage = new BlockingCollection<string>(5);

            Task provider1 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1500);
                    if(storage.TryAdd("Холодильник")) StoragePrint(storage);
                }
            });

            Task provider2 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1500);
                    if(storage.TryAdd("Стиральная машина")) StoragePrint(storage);
                }
            });

            Task provider3 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1500);
                    if(storage.TryAdd("Видеокарта")) StoragePrint(storage);
                }
            });

            Task provider4 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1500);
                    if(storage.TryAdd("Ноутбук")) StoragePrint(storage);
                }
            });

            Task provider5 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1500);
                    if(storage.TryAdd("Наушники")) StoragePrint(storage);
                }
            });

            Task[] Buyers = new Task[10]
            {
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                }),
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                }),
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                }),
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                }),
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                }),
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                }),
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                }),
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                }),
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                }),
                Task.Run(() =>
                {
                    for(int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(900);
                        storage.Take();
                    }
                })
            };

            PrintResult();

            Console.WriteLine("Ожидаем расчета: ");

            Console.ReadKey();
        }
    }
}
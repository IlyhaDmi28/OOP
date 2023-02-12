using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;

namespace Lab17_18
{
    public interface IBrigade
    {
        IBrigade Clone();
        object DeepCopy();

        void PrintNames();
    }

    public interface IWorkingBrigade
    {
        void Update();
    }

    public class Dispetcher
    {
        UnemployedHistory history = new UnemployedHistory();
        [Serializable]
        private class Brigade : IBrigade, IWorkingBrigade
        {
            public string WorkType { get; set; }
            public int Time { get; set; }
            public int Size { get; set; }

            public List<string> Names = new List<string>();
            IWork work;
            public Brigade(string type, int time, int size, string name)
            {
                Size = size;
                WorkType = type;
                Time = time;
                Names.Add(name);
            }

            public void AddWork (IWork w)
            {
                work = w;
                work.Reg(this);
            }

            public void StopWork()
            {
                work.Remove(this);
                work = null;
            }
            public void AddTeanet(string name)
            {
                Names.Add(name);
            }
            public void PrintNames()
            {
                foreach (string name in Names)
                {
                    Console.Write(name + ", ");
                }

            }

            public void Update()
            {
                Console.Write("Бригада из "); PrintNames(); Console.WriteLine(" отработала!");
            }

            public IBrigade Clone()
            {
                return this.MemberwiseClone() as IBrigade;
            }
            public object DeepCopy()
            {
                object figure = null;
                using (MemoryStream tempStream = new MemoryStream())
                {
                    BinaryFormatter binFormatter = new BinaryFormatter(null,
                        new StreamingContext(StreamingContextStates.Clone));

                    binFormatter.Serialize(tempStream, this);
                    tempStream.Seek(0, SeekOrigin.Begin);

                    figure = binFormatter.Deserialize(tempStream);
                }
                return figure;
            }
        }

        interface IUnemployed
        {
            void OutNames();
        }
        private class Unemployed : Brigade, IUnemployed
        { 
            public Unemployed(string type, int time, int size, string name) : base(type, time, size, name)
            {

            }
            public void OutNames() 
            {
                foreach (string name in Names)
                {
                    Console.Write(name + ", ");
                }
            }

            public UnemployedMemento SaveState()
            {
                UnemployedMemento memento = new UnemployedMemento();
                foreach (string name in Names)
                {
                    memento.Names.Add(name);
                }
                return memento;
            }

            public void RestoreState(UnemployedHistory history)
            {
                Console.WriteLine("История зполнения тунеядцев!");
                for (int i = 0; i < history.History.Count; i++)
                {
                    
                    Console.Write($"{i} Запись: ");
                    foreach (string name in history.History.ElementAt(i).Names)
                    {
                        Console.Write(name + ", ");
                    }
                    Console.WriteLine();
                }
            }
        }
        private class UnemAdapter : IBrigade
        {
            protected Unemployed unemployed;

            public UnemAdapter(Unemployed un)
            {
                this.unemployed = un;
            }

            public void PrintNames()
            {
                unemployed.OutNames();
            }

            public IBrigade Clone()
            {
                return this.MemberwiseClone() as IBrigade;
            }
            public object DeepCopy()
            {
                object figure = null;
                using (MemoryStream tempStream = new MemoryStream())
                {
                    BinaryFormatter binFormatter = new BinaryFormatter(null,
                        new StreamingContext(StreamingContextStates.Clone));

                    binFormatter.Serialize(tempStream, this);
                    tempStream.Seek(0, SeekOrigin.Begin);

                    figure = binFormatter.Deserialize(tempStream);
                }
                return figure;
            }
        }
        private class BrigadeNames
        {
            public void ShowNames(IBrigade brigade)
            {
                brigade.PrintNames();
            }
        }

        private Unemployed unemployed;
        private BrigadeNames Names = new BrigadeNames();
        private UnemAdapter unAdapter;
        private Work work = new Work();


        private List<Brigade> BrigadeList = new List<Brigade>();
        public void PrintBrigades()
        {
            int i = 1;
            Console.WriteLine("\n\nCФОРМОРОВАНЫЕ БРИГАДЫ");
            foreach (Brigade brigade in BrigadeList)
            {
                Console.WriteLine($"---------------------- Бригада {i} ---------------------");
                Console.WriteLine($"Вид работы: {brigade.WorkType}");
                Console.WriteLine($"Масштаб работы: {brigade.Size}");
                Console.WriteLine($"Время работы: {brigade.Time}");
                //Console.Write($"Имена квартиросъёмщиков: "); brigade.PrintNames(); 
                Names.ShowNames(brigade);
                Console.WriteLine("\n------------------------------------------------------");
                i++;
            }

            if (unemployed != null)
            {
                Console.WriteLine($"---------------------- Тунеядцы ---------------------");
                unAdapter = new UnemAdapter(unemployed);
                Names.ShowNames(unAdapter);
                Console.WriteLine();
            }
        }

        public void HistoryUnemployed()
        {
            //unemployed.RestoreState(history);
            Console.WriteLine("История зполнения тунеядцев!");
            for (int i = 0; i < history.History.Count; i++)
            {

                Console.Write($"{i} Запись: ");
                foreach (string name in history.History.ElementAt(i).Names)
                {
                    Console.Write(name + ", ");
                }
                Console.WriteLine();
            }
        }

        public void PushHistory()
        {
            history.History.Add(unemployed.SaveState());
        }
        public void SentApplication(Builder build, Tenant tenat)
        {
            Application Form = build.CreateApplication(tenat);
            //Console.Write("Введите ваше имя: ");
            //string Name = Console.ReadLine();
            //Console.WriteLine("----------- Ваши данные сохранены! -----------\n");

            foreach (Brigade brigade in BrigadeList)
            {
                if (Form.WorkType == brigade.WorkType && Form.Time == brigade.Time && Form.Size == brigade.Size)
                {
                    brigade.AddTeanet(tenat.Name);
                    return;
                }
            }

            BrigadeList.Add(new Brigade(Form.WorkType, Form.Time, Form.Size, tenat.Name)); 
        }

        public void SentEmptyApplication(Builder build)
        {
            Application Form = build.CreateEmptyApplication();
            Console.Write("Введите ваше имя: ");
            string Name = Console.ReadLine();
            Console.WriteLine("----------- Ваши данные сохранены! -----------\n");

            if (unemployed == null) unemployed = new Unemployed(Form.WorkType, Form.Time, Form.Size, Name);
            else unemployed.Names.Add(Name);
        }

        public void CopyBrigade(int i)
        {
            Brigade CloneBrigade = BrigadeList.ElementAt(i);
            BrigadeList.Add(CloneBrigade.DeepCopy() as Brigade);

        }

        public void AddBrigadeWork(int i)
        {
            BrigadeList.ElementAt(i).AddWork(work);
        }

        public void RemoveBrigadeWork(int i)
        {
            BrigadeList.ElementAt(i).StopWork();
        }

        public void GoToWork()
        {
            work.Working();
        }

        //Singelton
        private static Dispetcher instance;
        private Dispetcher() { }
        public static Dispetcher getInstance()
        {
            if (instance == null)
                instance = new Dispetcher();
            return instance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace Lab12
{
    public static class LogInfo
    {
        public static void WriteLogInfo()
        {
            string logPath = Path.GetFullPath("D:/ididirinfo.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, false, Encoding.Default))
                {
                    sw.WriteLine("<=========================================== iDILog ===================================================>");
                    sw.WriteLine($"Имя файла лога: {Path.GetFileName(logPath)}");
                    sw.WriteLine($"Полный путь лога: {logPath}");
                    sw.WriteLine($"Время записи лога: {DateTime.Now}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteInLog(string message)
        {
            string logPath = Path.GetFullPath("D/ididirinfo.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true, Encoding.Default))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string ReadLog()
        {
            string logPath = Path.GetFullPath("D/ididirinfo.txt");
            try
            {
                StreamReader sr = new StreamReader(logPath);
                return sr.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return String.Empty;
            }
        }



    }
    static class IDILog
    {
        public static void WriteInfo(string info)
        {
            StreamWriter sw = File.AppendText("D:/лабы ООП/Lab12/idilogfile.txt");

            sw.WriteLine(info);
            sw.WriteLine();
            sw.Close();


        }


    }

    class IDIDiskInfo
    {
        DriveInfo[] drivers = DriveInfo.GetDrives();

         
        public void DriversInfo()
        {
            try
            {
                foreach (DriveInfo drive in drivers)
                {
                    Console.WriteLine(drive.Name);
                    Console.WriteLine(drive.TotalSize / 1024 / 1024 / 1024 + "Гб");
                    Console.WriteLine(drive.AvailableFreeSpace / 1024 / 1024 / 1024 + "Гб");
                    Console.WriteLine(drive.DriveFormat);

                }
            }
            catch
            {

            }
            
        }
    }
    class IDIFileInfo
    {
        string dirname = "D:/лабы ООП/Lab12/Test.txt";

        public void FileInformation()
        {

            FileInfo file = new FileInfo(dirname);
            Console.WriteLine(file.FullName);
            Console.WriteLine(file.Name);
            Console.WriteLine(file.Length);
            Console.WriteLine(file.CreationTime);
            IDILog.WriteInfo("Просотрен файл: " + file.Name + ", Путь: " + file.FullName + ", Размер: " + file.Length + ", Время создания: " + file.CreationTime);
        }
    }

    class IDIDirInfo
    {
        string dirname = "D:/лабы ООП/Lab12/TestFolder/MyFiles";

        public void DirInformation()
        {
            Console.WriteLine("Директории:");
            string[] dirs = Directory.GetDirectories(dirname);
            
            foreach (string dir in dirs)
            {
                DirectoryInfo CurrentDir = new DirectoryInfo(dir);
                Console.WriteLine(CurrentDir.Name);
            }

            Console.WriteLine();


            Console.WriteLine("Файлы: ");
            string[] files = Directory.GetFiles(dirname);
            foreach (string file in files)
            {
                FileInfo CurrentFile = new FileInfo(file);
                Console.WriteLine(file);
                Console.WriteLine(CurrentFile.Name);
                Console.WriteLine(CurrentFile.Length);
                Console.WriteLine(CurrentFile.CreationTime);
                Console.WriteLine();
            }
        }
    }

    class IDIFileManager
    {
        string DirPath = "D:/лабы ООП/Lab12/TestFolder";
        string DiskPath = "D:/";

        public void SaveInfoInTxt()
        {
            string[] dirs = Directory.GetDirectories(DiskPath);
            DirectoryInfo dirInfo = new DirectoryInfo(DirPath);

            dirInfo.CreateSubdirectory("IDIInspect");
            dirInfo = new DirectoryInfo(DirPath + "/IDIInspect");


            string logPath = Path.GetFullPath("D:/лабы ООП/Lab12/TestFolder/IDIInspect");
            try
            {
                using (StreamWriter sw = new StreamWriter(DirPath + "/ididirinfo.txt"))
                {
                    sw.WriteLine("<=========================================== iDILog ===================================================>");
                    sw.WriteLine($"Имя директории: {dirInfo.Name}");
                    sw.WriteLine($"Полный путь директории: {logPath}");
                    sw.WriteLine($"Время создания директории: {dirInfo.CreationTime}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            try
            {
                File.Copy(DirPath + "/ididirinfo.txt", DirPath + "/ididirinfo2.txt");
            }
            catch
            {

            }

            File.Delete(DirPath + "/ididirinfo.txt");
        }

        public void MoveDir()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(DirPath);
            dirInfo.CreateSubdirectory("IDIFiles");

            string[] txtList = Directory.GetFiles("D:/лабы ООП/Lab12/TestFolder/MyFiles", "*.txt");
            FileInfo FileInf;
            foreach (string file in txtList)
            {
                FileInf = new FileInfo(file);
                
                File.Copy(file, Path.Combine(DirPath + "/IDIFiles", FileInf.Name), true);
                IDILog.WriteInfo("Создан файл: " + FileInf.Name + ", Путь: " + file + ", Размер: " + FileInf.Length + ", Время создания: " + FileInf.CreationTime);
            }

            Directory.Move(DirPath + "/IDIFiles", DirPath + "/IDIInspect/IDIFiles");
        }


        public void Compress()
        {
            string sourseFile = "D:/лабы ООП/Lab12/TestFolder/IDIInspect/IDIFiles";
            string compressedFile = "D:/лабы ООП/Lab12/TestFolder/IDIInspect/AR.rar";

            ZipFile.CreateFromDirectory(sourseFile, compressedFile);
            ZipFile.ExtractToDirectory(compressedFile, "D:/лабы ООП/Lab12/TestFolder/IDIInspect/UnAr");
            
        }

    }

    class ReadIdiLog
    {
        public void FindWrite (string day)
        {
            string[] FileText = File.ReadAllLines("D:/лабы ООП/Lab12/idilogfile.txt");

            foreach (string str in FileText)
            {
                if(str.Contains("Время создания: " + day)) Console.WriteLine(str);
            }
        }

        public void CountWrite()
        {
            int count = 0;
            string[] FileText = File.ReadAllLines("D:/лабы ООП/Lab12/idilogfile.txt");
            foreach (string str in FileText)
            {
                if (str != "") count++;
            }
            Console.WriteLine("Количество записей: " + count);
        }

        public void DelPart (string time)
        {
            string[] FileText = File.ReadAllLines("D:/лабы ООП/Lab12/idilogfile.txt");
            string newInfo = "";
            foreach (string str in FileText)
            {
                if (str.Contains(time + ":")) newInfo += str + "\n\n";
            }
            StreamWriter sw = new StreamWriter("D:/лабы ООП/Lab12/idilogfile.txt");
            sw.WriteLine(newInfo);
            sw.Close();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            IDIDiskInfo drivers = new IDIDiskInfo();
            drivers.DriversInfo();
            Console.ReadKey();

            IDIFileInfo file = new IDIFileInfo();
            file.FileInformation();
            Console.ReadKey();

            IDIDirInfo dirs = new IDIDirInfo();
            dirs.DirInformation();
            Console.ReadKey();

            IDIFileManager manager = new IDIFileManager();
            manager.SaveInfoInTxt();
            manager.MoveDir();
            manager.Compress();

            ReadIdiLog lg = new ReadIdiLog();
            lg.FindWrite("29");
            lg.CountWrite();
            lg.DelPart("14");
        }
    }
}

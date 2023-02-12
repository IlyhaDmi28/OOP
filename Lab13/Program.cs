using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.ConstrainedExecution;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.ComTypes;

namespace Lab13
{
    static class CustomSerializer
    {
        public static void XmlSer(Lion[] an)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Lion[]));

            using (FileStream fs = new FileStream("Animal.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, an);
                Console.WriteLine("Объект успешно сериализован в XML файл!");
            }

            using (FileStream fs = new FileStream("Animal.xml", FileMode.OpenOrCreate))
            {
                Lion[] lions = (Lion[])xml.Deserialize(fs);

                Console.WriteLine("Объект десериализован с XML файла!");

                foreach (Lion lion in lions)
                {
                    Console.WriteLine($"Имя: {lion.Name} --- здоровье: {lion.HP}");
                }
            }

            Console.WriteLine();
        }

        public static void BinSer(Lion[] an)
        {
            BinaryFormatter Bin = new BinaryFormatter();

            using (FileStream fs = new FileStream("Animal.dat", FileMode.OpenOrCreate))
            {
                Bin.Serialize(fs, an);
                Console.WriteLine("Объект успешно сериализован в BIN!");
            }

            using (FileStream fs = new FileStream("Animal.dat", FileMode.OpenOrCreate))
            {
                Lion[] lions = (Lion[])Bin.Deserialize(fs);

                Console.WriteLine("Объект десериализован с BIN!");

                foreach (Lion lion in lions)
                {
                    Console.WriteLine($"Имя: {lion.Name} --- здоровье: {lion.HP}");
                }
            }

            Console.WriteLine();
        }

 
        public static void SoapSer(Lion[] an)
        {
            SoapFormatter Soap = new SoapFormatter();

            using (FileStream fs = new FileStream("Animal.soap", FileMode.OpenOrCreate))
            {
                Soap.Serialize(fs, an);
                Console.WriteLine("Объект успешно сериализован в SOAP файл!");
            }

            using (FileStream fs = new FileStream("Animal.soap", FileMode.OpenOrCreate))
            {
                Lion[] lions = (Lion[])Soap.Deserialize(fs);

                Console.WriteLine("Объект десериализован с SOAP файла!");

                foreach (Lion lion in lions)
                {
                    Console.WriteLine($"Имя: {lion.Name} --- здоровье: {lion.HP}");
                }
            }

            Console.WriteLine();
        }

        public static void JSONser(Lion[] an)
        {
            string json = JsonConvert.SerializeObject(an);
            Console.WriteLine("Объект успешно сериализован в JSON!");

            Lion[] restoredPerson = JsonConvert.DeserializeObject<Lion[]>(json);
            Console.WriteLine("Объект десериализован с JSON!");

            foreach (Lion lion in restoredPerson)
            {
                Console.WriteLine($"Имя: {lion.Name} --- здоровье: {lion.HP}");
            }

            Console.WriteLine();
        }
    }

    static class XmlSelectors
    {
        public static void Do()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Animal.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("Lion");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            Console.ReadLine();
        }

    }


    static class LINQtoXML
    {
        public static void Do(Lion[] lions)
        {
            #region linq to xml

            XDocument anything = new XDocument();
            XElement Root = new XElement("Lions");

            foreach (Lion lion in lions)
            {
                XElement El = new XElement("Lion");
                XAttribute xAttribute = new XAttribute("Name", lion.Name);
                XElement Health = new XElement("Name", lion.HP);

                El.Add(xAttribute);
                El.Add(Health);

                Root.Add(El);
            }

            anything.Add(Root);
            anything.Save("Anything.xml");
            #endregion

   
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
           
            Lion[] lions = { new Lion("Лёва"), new Lion("Лев Петя"), new Lion("Котик") };

            CustomSerializer.XmlSer(lions);
            CustomSerializer.BinSer(lions);
            CustomSerializer.SoapSer(lions);
            CustomSerializer.JSONser(lions);

            XmlSelectors.Do();
            LINQtoXML.Do(lions);
            
        }
    }
}

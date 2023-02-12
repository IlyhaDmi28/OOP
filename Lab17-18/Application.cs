using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    public class Application
    {
      //  public int Size { get; set; }
        public string WorkType { get; set; }
        public int Time { get; set; }
        public int Size { get; set; }
        public Application(string type, int time, int size)
        {
             Size = size;
             WorkType = type;
             Time = time;
        }
        public Application()
        {
            Size = 0;
            WorkType = "Нет работы";
            Time = 0;    
        }
    }
}

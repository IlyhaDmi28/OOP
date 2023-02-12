using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    public interface IWork
    {
        void Reg(IWorkingBrigade b);
        void Remove(IWorkingBrigade b);
        void NotifyObservers();
    }
    public class Work : IWork
    {
        public int WorkProc;

        List<IWorkingBrigade> brigades;

        public Work ()
        {
            brigades = new List<IWorkingBrigade>();
            WorkProc = 0;
        }

        public void Reg(IWorkingBrigade b)
        {
            brigades.Add(b);
        }

        public void Remove(IWorkingBrigade b)
        {
            brigades.Remove(b);
        }

        public void NotifyObservers()
        {
            foreach (IWorkingBrigade b in brigades)
            {
                b.Update();
            }
        }

        public void Working()
        {
            WorkProc += 10 * brigades.Count;
            NotifyObservers();
            Console.WriteLine($"Работа выполнена на {WorkProc}%!");
        }
    }
}

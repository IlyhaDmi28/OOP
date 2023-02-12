using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab17_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dispetcher Disp = Dispetcher.getInstance();

            Tenant tenant1 = new Cleaner("Игорь", TenantState.GO_TO_GYM);
            tenant1 = new AM(tenant1);
            Tenant tenant2 = new Cleaner("Лёша", TenantState.GO_TO_GYM);
            tenant2 = new AM(tenant2);
            tenant1.Training();
            tenant1.Training();
            tenant2.Training();
            tenant2.Training();

            Tenant tenant3 = new Painter("Дима", TenantState.LAYING_ON_SOFA);
            tenant3 = new PM(tenant3);
            
            Tenant tenant4 = new Painter("Кирил", TenantState.LAYING_ON_SOFA);
            tenant4 = new PM(tenant4);
            tenant3.Training();
            tenant3.Training();
            tenant3.Training();
            tenant3.Relax();
            tenant4.Training();
            tenant4.Training();
            tenant4.Training();
            tenant4.Relax();

            Disp.SentApplication(new Builder(), tenant1);
            Disp.SentApplication(new Builder(), tenant2);
            Disp.SentApplication(new Builder(), tenant3);
            Disp.SentApplication(new Builder(), tenant4);

            Disp.SentEmptyApplication(new Builder());
            Disp.PushHistory();
            Disp.SentEmptyApplication(new Builder());
            Disp.PushHistory();
            Disp.SentEmptyApplication(new Builder());
            Disp.PushHistory();

            Disp.CopyBrigade(0);

            Disp.PrintBrigades();
            Console.WriteLine();

            Disp.HistoryUnemployed();
            Console.WriteLine();

            Disp.AddBrigadeWork(0);
            Disp.AddBrigadeWork(1);

            Disp.GoToWork();
            Console.WriteLine();
            Disp.RemoveBrigadeWork(0);
            Disp.GoToWork();
        }
    }
}

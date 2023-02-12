using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    public interface IFactory
    {
        Application CreateApplication(Tenant tenant);
    }
    public class Builder : IFactory
    {
        public Application CreateApplication(Tenant tenant)
        {

            ////Console.Write("Введите вид работы: ");
            //string WorkType = tenant.Specialization;

            //Console.Write("Введите масштаб работы: ");
            //int WorkSize = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Введите время: ");
            //int Time = Convert.ToInt32(Console.ReadLine());

            return new Application(tenant.Specialization, tenant.Time, tenant.Size);
        }

        public Application CreateEmptyApplication()
        {

            return new Application();
        }

    }

}

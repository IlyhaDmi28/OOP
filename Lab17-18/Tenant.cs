using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    public abstract class Tenant
    {
        public TenantState lifestyle { get; set; }

        public void Training()
        {
            if (lifestyle == TenantState.GO_TO_GYM) Size += 2; 
            if (lifestyle == TenantState.LAYING_ON_SOFA) Size++; 
        }

        public void Relax()
        {
            if (lifestyle == TenantState.GO_TO_GYM) Size--;
            if (lifestyle == TenantState.LAYING_ON_SOFA) Size -= 2;
        }

        public string Name { get; set; }
        public string Specialization { get; set; }
        public int Size { get; set; }
        public int Time { get; set; }

        public Tenant (string WorkType, string name, TenantState state)
        {
            Specialization = WorkType;
            Name = name;
            lifestyle = state;
            if(lifestyle == TenantState.LAYING_ON_SOFA) Size = 1;
            if(lifestyle == TenantState.GO_TO_GYM) Size = 3;      
        }

        public Tenant(int time, string name, string WorkType, int size, TenantState state)
        {
            Time = time;
            Name = name;
            Specialization = WorkType;
            Size = size;
        }
    }

    public class Cleaner : Tenant
    {
        public Cleaner(string name, TenantState state) : base("Уборка", name, state)
        {

        } 
    }

    public class Painter : Tenant
    {
        public Painter(string name, TenantState state) : base("Красить стены", name, state)
        {

        }
    }

    public abstract class WorkingShift : Tenant
    {
        protected Tenant tenant;
        public WorkingShift(int time, Tenant tenant) : base(time, tenant.Name, tenant.Specialization, tenant.Size, tenant.lifestyle)
        {
            this.tenant = tenant;
        }
    }

    public class AM : WorkingShift
    {
        public AM(Tenant tenant) : base(18, tenant)
        { }
    }

    public class PM : WorkingShift
    {
        public PM(Tenant tenant) : base(9, tenant)
        { }
    }

    public enum TenantState
    {
        LAYING_ON_SOFA,
        GO_TO_GYM
    }


}

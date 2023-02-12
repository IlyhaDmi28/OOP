using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    public class UnemployedMemento
    {
        public List<string> Names = new List<string>();
        
    }

    public class UnemployedHistory
    {
        public List<UnemployedMemento> History;
        public UnemployedHistory()
        {
            History = new List<UnemployedMemento>();
        }
    }
}

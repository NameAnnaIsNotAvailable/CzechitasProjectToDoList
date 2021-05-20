using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace úkolovník
{
    interface IHomeWork
    {
        string Subject { get; set; }  
        DateTime Deadline { get; set; }
        int Marking { get; set; }
        int ID { get; set; }
        string Topic { get; set; }
        
    }
}

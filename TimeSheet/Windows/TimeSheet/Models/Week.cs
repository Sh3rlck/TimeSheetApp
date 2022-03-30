using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Windows.TimeSheet.Models
{
    public class Week
    {
        public TimeLog Sunday { get; set; }
        public TimeLog Monday { get; set; }
        public TimeLog Tuesday { get; set; }
        public TimeLog Wednesday { get; set; }
        public TimeLog Thursday { get; set; }
        public TimeLog Friday { get; set; }
        public TimeLog Saturday { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Windows.TimeSheet.Models
{
    public class TimeLog
    {
        public enum TimeEntry { ClockIn, ClockOut }
        public TimeEntry TimeEntries { get; set; }
        public DateTime TimeStamp { get; set; }

        public override string ToString()
        {
            return TimeEntries + " at " + TimeStamp;
        }
    }
}

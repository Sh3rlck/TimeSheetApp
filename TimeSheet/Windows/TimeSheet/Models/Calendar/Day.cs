using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Windows.TimeSheet.Models.DataQuery;

namespace TimeSheet.Windows.TimeSheet.Models.Calendar
{
    public class Day
    {
        public List<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
        public DateTime DayDate { get; set; } 

        public Day() {}

        public Day(DateTime date)
        {
            DayDate = date;
        }

        public void AddTimeLog(TimeLog timeLog)
        {
            TimeLogs.Add(timeLog);
            DayDate = timeLog.TimeStamp;
        }
    }
}

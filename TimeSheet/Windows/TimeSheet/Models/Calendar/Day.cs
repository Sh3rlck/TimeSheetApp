using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
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
        public ObservableCollection<TimeLog> TimeLogs { get; } = new ObservableCollection<TimeLog>();
        public DateTime Date { get; set; }
        public double TotalHours { get; set; } = 0;

        /// <summary>
        /// Adds time log
        /// </summary>
        /// <param name="timeLog">time log</param>
        public void AddTimeLog(TimeLog timeLog)
        {
            TimeLogs.Add(timeLog); 
            Date = timeLog.TimeStamp;
        }
    }
}

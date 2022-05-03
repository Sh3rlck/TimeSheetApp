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

        public Day() {}
        /// <summary>
        /// Create instance of Day and adds timelog to the list
        /// </summary>
        /// <param name="timeLog"></param>
        public Day(TimeLog timeLog)
        {
            AddTimeLog(timeLog);
        }
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

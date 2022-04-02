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

        /// <summary>
        /// Returns the week number that the time stamp falls into
        /// </summary>
        /// <returns></returns>
        public int GetWeekOfYear()
        {
            Calendar cal = new CultureInfo("en-US").Calendar;
            return cal.GetWeekOfYear(TimeStamp, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public override string ToString()
        {
            return TimeEntries + " at " + TimeStamp;
        }
    }
}

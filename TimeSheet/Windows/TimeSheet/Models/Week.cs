using System;
using System.Collections.Generic;
using System.Globalization;
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

        /// <summary>
        /// Returns the week number that the time stamp falls into
        /// </summary>
        /// <returns></returns>
        public static int GetWeekOfYear(DateTime timeStamp)
        {
            Calendar cal = new CultureInfo("en-US").Calendar;
            return cal.GetWeekOfYear(timeStamp, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public void SetWeekByGroup(TimeLog timeLog, Week weekStamp)
        {
            switch (timeLog.TimeStamp.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    weekStamp.Sunday = timeLog;
                    break;
                case DayOfWeek.Monday:
                    weekStamp.Monday = timeLog;
                    break;
                case DayOfWeek.Tuesday:
                    weekStamp.Tuesday = timeLog;
                    break;
                case DayOfWeek.Wednesday:
                    weekStamp.Wednesday = timeLog;
                    break;
                case DayOfWeek.Thursday:
                    weekStamp.Thursday = timeLog;
                    break;
                case DayOfWeek.Friday:
                    weekStamp.Friday = timeLog;
                    break;
                case DayOfWeek.Saturday:
                    weekStamp.Saturday = timeLog;
                    break;
                default:
                    throw new Exception("invalid week day or timelog");
            }
        }
    }
}

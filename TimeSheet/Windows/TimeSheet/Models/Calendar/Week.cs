using System;
using System.Collections.ObjectModel;
using System.Globalization;
using TimeSheet.Windows.TimeSheet.Models.DataQuery;

namespace TimeSheet.Windows.TimeSheet.Models.Calendar
{
    public class Week
    {
        /// <summary>
        /// 0 -> Sunday
        /// 1 -> Monday
        /// 2 -> Tuesday
        /// 3 -> Wednesday
        /// 4 -> Thursday
        /// 5 -> Friday
        /// 6 -> Saturday
        /// </summary>
        public ObservableCollection<Day> WeekDays { get; set; } = new ObservableCollection<Day>();

        /// <summary>
        /// Returns the week number that the time stamp falls into
        /// </summary>
        /// <returns></returns>
        public static int GetWeekOfYear(DateTime timeStamp)
        {
            System.Globalization.Calendar cal = new CultureInfo("en-US").Calendar;
            return cal.GetWeekOfYear(timeStamp, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }
    }
}

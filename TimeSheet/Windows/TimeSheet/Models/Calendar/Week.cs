using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using TimeSheet.Common.Classes.ObservableDictionaries;
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
        
        public ObservableDictionary<DayOfWeek, Day> WeekDaysTest { get; set; } = new ObservableDictionary<DayOfWeek, Day>
        {
            {DayOfWeek.Sunday, new Day()},
            {DayOfWeek.Monday, new Day()},
            {DayOfWeek.Tuesday, new Day()},
            {DayOfWeek.Wednesday, new Day()},
            {DayOfWeek.Thursday, new Day()},
            {DayOfWeek.Friday, new Day()},
            {DayOfWeek.Saturday, new Day()}
        };

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

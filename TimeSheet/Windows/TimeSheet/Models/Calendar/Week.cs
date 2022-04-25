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
        public ObservableCollection<Day> WeekDays { get; set; } = new ObservableCollection<Day>
        {
            new Day(),
            new Day(),
            new Day(),
            new Day(),
            new Day(),
            new Day(),
            new Day(),
        };

        public static int CurrentWeek { get; set; } = new Week().GetWeekOfYear(DateTime.Today);

        /// <summary>
        /// Returns the week number that the time stamp falls into
        /// </summary>
        /// <returns></returns>
        public int GetWeekOfYear(DateTime timeStamp)
        {
            System.Globalization.Calendar cal = new CultureInfo("en-US").Calendar;
            return cal.GetWeekOfYear(timeStamp, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            
        }

        /// <summary>
        /// Returns the Date of the first day of the week selected 
        /// </summary>
        /// <returns></returns>
        public static DateTime DateOfFirstWeekDay()
        {
            return  DateTime.Today.AddDays(
                (int) CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - 
                (int) DateTime.Today.DayOfWeek);
        }
    }
}

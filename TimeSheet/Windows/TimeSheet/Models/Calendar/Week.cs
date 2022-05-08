using System;
using System.Collections.Generic;
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
        public List<Day> WeekDays { get; } = new List<Day>
        {
            new Day(), new Day(), new Day(), new Day(), new Day(), new Day(), new Day(),
        };

        public int NumWeek { get; set; }

        public int NumYear { get; set; }

        //not implemented yet
        public double TotalHours { get; set; } = 0;

        /// <summary>
        /// Returns the week number that the time stamp falls into
        /// </summary>
        /// <returns></returns>
        public static int GetWeekOfYear(DateTime timeStamp)
        {
            System.Globalization.Calendar cal = new CultureInfo("en-US").Calendar;
            return cal.GetWeekOfYear(timeStamp, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            
        }

        /// <summary>
        /// Returns the Date of the first day of the week selected 
        /// </summary>
        /// <returns></returns>
        public static DateTime DateOfFirstDay(DateTime date)
        {
            return  date.AddDays(
                (int) CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - 
                (int) DateTime.Today.DayOfWeek);
        }

        /// <summary>
        /// Returns the Date of the last day of the week selected 
        /// </summary>
        /// <returns></returns>
        public static DateTime DateOfLastDay(DateTime date)
        {
            return  DateOfFirstDay(date).AddDays(6);
        }
        /// <summary>
        /// Submits clock entry to the current day of the week
        /// </summary>
        /// <param name="timeEntry"></param>
        public void SubmitClockEntry(TimeLog.TimeEntry timeEntry)
        {
            var todayTimeStamp = new TimeLog(timeEntry, DateTime.Now);
            
            WeekDays[(int)todayTimeStamp.TimeStamp.DayOfWeek].TimeLogs.Add(todayTimeStamp);
            WeekDays[(int) todayTimeStamp.TimeStamp.DayOfWeek].Date = todayTimeStamp.TimeStamp;
        }
    }
}

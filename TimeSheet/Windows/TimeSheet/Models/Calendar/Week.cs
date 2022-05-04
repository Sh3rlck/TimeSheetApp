using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using GalaSoft.MvvmLight;
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
        public List<Day> WeekDays { get; } = new List<Day>
        {
            new Day(), new Day(), new Day(), new Day(), new Day(), new Day(), new Day(),
        };

        /// <summary>
        /// Week of the year
        /// </summary>
        public int NumWeek { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        public int NumYear { get; set; }

        /// <summary>
        /// Total Hours worked in a week
        /// </summary>
        public double TotalHours { get; set; } = 0;

        public Week() {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numWeek">week of the year</param>
        /// <param name="numYear">year</param>
        public Week(int numWeek, int numYear)
        {
            NumWeek = numWeek;
            NumYear = numYear;
        }

        /// <summary>
        /// Returns the week number that the time stamp falls into
        /// </summary>
        /// <returns></returns>
        public static int GetWeekOfYear(DateTime timeStamp)
        {
            System.Globalization.Calendar cal = new CultureInfo("en-US").Calendar;
            return cal.GetWeekOfYear(timeStamp, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            
        }

        public static int GetWeekOfYear(Week week, int dayIndex) 
        {
            System.Globalization.Calendar cal = new CultureInfo("en-US").Calendar;
            return cal.GetWeekOfYear(week.WeekDays[dayIndex].TimeLogs[0].TimeStamp, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            
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

        /// <summary>
        /// Adds day to the week list property
        /// </summary>
        /// <param name="day"></param>
        public void AddDay(Day day)
        {
            WeekDays[(int) day.Date.DayOfWeek] = day;
        }
    }
}

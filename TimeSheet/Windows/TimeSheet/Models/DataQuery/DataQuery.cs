﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TimeSheet.Windows.TimeSheet.Models.Calendar;

namespace TimeSheet.Windows.TimeSheet.Models.DataQuery
{
    public class DataQuery
    {
        public static ObservableCollection<TimeLog> Data { get; set; }
        public static int CurrentWeek { get; set; } = Weeks.GetWeekOfYear(DateTime.Today);

        /// <summary>
         /// Groups raw time stamps by weeks of the year
         /// </summary>
         /// <param name="data"></param>
         /// <returns></returns>
         public IEnumerable<IGrouping<int, TimeLog>> GroupDataByWeek(IEnumerable<TimeLog> data)
         {

             IEnumerable<IGrouping<int, TimeLog>> groupByWeek =
                 from timelog in data
                 group timelog by Weeks.GetWeekOfYear(timelog.TimeStamp)
                 into groupedByWeek
                 orderby groupedByWeek.Key
                 select groupedByWeek;

             //pull info from data base 
             return groupByWeek;

         }

        /// <summary>
        /// Returns a Week object with the time stamp information of the week and year specified
        /// </summary>
        /// <param name="group">Data grouped by week number</param>
        /// <param name="numWeek">week to pull records from</param>
        /// <param name="numYear">year to pull records from</param>
        /// <returns></returns>
        public Weeks GetWeekTimeLogs(IEnumerable<IGrouping<int, TimeLog>> group, int numWeek, int numYear)
        {
            Weeks week = new Weeks();

            foreach (var weekGroups in group)
            {
                if (weekGroups.Key != numWeek)
                    continue;

                foreach (var timeLog in weekGroups)
                {
                    if (timeLog.TimeStamp.Year != numYear)
                        continue;

                    week.AddTimeLogByDay(week, timeLog);
                }
            }
            return week;
        }

        /// <summary>
         /// Sample data for testing purposes
         /// </summary>
         /// <returns></returns>
         public void LoadSampleData()
         {
             Data = new ObservableCollection<TimeLog>
             {
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn, 
                     TimeStamp = new DateTime(2022, 04, 01, 9, 0, 0)
                 },
                 
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 01, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn, 
                     TimeStamp = new DateTime(2022, 04, 02, 9, 0, 0)
                 },
                 
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 02, 17, 0, 0)
                 },
                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockIn, 
                         TimeStamp = new DateTime(2022, 04, 03, 9, 0, 0)
                     },
                 
                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockOut,
                         TimeStamp = new DateTime(2022, 04, 03, 12, 0, 0)
                     },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn, 
                     TimeStamp = new DateTime(2022, 04, 03, 13, 0, 0)
                 },
                 
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 03, 17, 0, 0)
                 },

                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockIn,
                         TimeStamp = new DateTime(2022, 04, 04, 9, 0, 0)
                     },
                 
                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockOut,
                         TimeStamp = new DateTime(2022, 04, 04, 17, 0, 0)
                     },
                 
                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockIn,
                         TimeStamp = new DateTime(2022, 04, 05, 9, 0, 0)
                     },

                  
                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockOut,
                         TimeStamp = new DateTime(2022, 04, 05, 17, 0, 0)
                     },
                 
                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockIn,
                         TimeStamp = new DateTime(2022, 04, 06, 9, 0, 0)
                     },

                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockOut,
                         TimeStamp = new DateTime(2022, 04, 06, 17, 0, 0)
                     },

                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockIn,
                         TimeStamp = new DateTime(2022, 04, 07, 9, 0, 0)
                     },

                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockOut,
                         TimeStamp = new DateTime(2022, 04, 07, 17, 0, 0)
                     },

                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockIn,
                         TimeStamp = new DateTime(2022, 04, 08, 9, 0, 0)
                     },

                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockOut,
                         TimeStamp = new DateTime(2022, 04, 08, 17, 0, 0)
                     },

                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockIn,
                         TimeStamp = new DateTime(2022, 04, 9, 9, 0, 0)
                     },
                 
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 9, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 10, 9, 0, 0)
                 },
                 
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 10, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 11, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 11, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 12, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 12, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 13, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 13, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 14, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 14, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 15, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 15, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 16, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 16, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 17, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 17, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 18, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 18, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 19, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 19, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 20, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 20, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 21, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 21, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 22, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 22, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 23, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 23, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 24, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 24, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 25, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 26, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 26, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 26, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 27, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 27, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 28, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 28, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 29, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 29, 17, 0, 0)
                 },new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 30, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockOut,
                     TimeStamp = new DateTime(2022, 04, 30, 17, 0, 0)
                 },
             };
         }
    }
}

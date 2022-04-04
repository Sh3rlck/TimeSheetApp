﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace TimeSheet.Windows.TimeSheet.Models
{
    public class NavigationBar
    {
        //public int CurrentWeek { get; set; }

        /// <summary>
         /// Groups data from the week and year specified in the navigation bar
         /// </summary>
         /// <returns></returns>
         public IEnumerable<IGrouping<bool, TimeLog>> GroupDataFromSelectedDate(ObservableCollection<TimeLog> data, int week, int year)
         {
             IEnumerable<IGrouping<bool, TimeLog>> groupBySpecificDate =
                 from timeLog in data
                 group timeLog by Week.GetWeekOfYear(timeLog.TimeStamp).Equals(week) && timeLog.TimeStamp.Year.Equals(year)
                 into groupedBySpecificWeekAndYear
                 orderby  groupedBySpecificWeekAndYear.Key
                 select groupedBySpecificWeekAndYear;
             
             return groupBySpecificDate;
         }

         /// <summary>
         /// Groups raw time stamps by weeks of the year
         /// </summary>
         /// <param name="data"></param>
         /// <returns></returns>
         public IEnumerable<IGrouping<int, TimeLog>> GroupDataByWeek(ObservableCollection<TimeLog> data)
         {

             IEnumerable<IGrouping<int, TimeLog>> groupByWeek =
                 from timelog in data
                 group timelog by Week.GetWeekOfYear(timelog.TimeStamp)
                 into groupedByWeek
                 orderby groupedByWeek.Key
                 select groupedByWeek;

             //pull info from data base 
             return groupByWeek;

         }

         /// <summary>
         /// Sample data for testing purposes
         /// </summary>
         /// <returns></returns>
         public ObservableCollection<TimeLog> LoadSampleData()
         {
             return new ObservableCollection<TimeLog>
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

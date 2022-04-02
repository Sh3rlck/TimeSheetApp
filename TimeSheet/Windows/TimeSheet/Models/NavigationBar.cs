using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace TimeSheet.Windows.TimeSheet.Models
{
    public class NavigationBar
    {
         private int _week;
         private int _year;

         public NavigationBar(int numWeek, int numYear)
         {
             _week = numWeek;
             _year = numYear;
         }

         public IEnumerable<IGrouping<int, TimeLog>> QueryDate()
         {
             ObservableCollection<TimeLog> sampleData = new ObservableCollection<TimeLog>
             {
                 new TimeLog
                     {
                         TimeEntries = TimeLog.TimeEntry.ClockIn, 
                         TimeStamp = new DateTime(2022, 04, 04, 9, 0, 0)
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
                         TimeStamp = new DateTime(2022, 04, 10, 9, 0, 0)
                     },
                 
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 9, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 11, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 12, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 12, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 13, 17, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 14, 9, 0, 0)
                 },
                 new TimeLog
                 {
                     TimeEntries = TimeLog.TimeEntry.ClockIn,
                     TimeStamp = new DateTime(2022, 04, 15, 17, 0, 0)
                 },
                  
             };

             IEnumerable<IGrouping<int, TimeLog>> groupByWeek =
                 from timelog in sampleData
                 group timelog by timelog.GetWeekOfYear()
                 into groupedByWeek 
                 orderby groupedByWeek.Key
                 select groupedByWeek;

             //pull info from data base 
             return groupByWeek;
         }
    }
}

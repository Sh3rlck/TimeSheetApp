using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

         public ObservableCollection<Week> QueryDate()
         {
             ObservableCollection<Week> sampleData = new ObservableCollection<Week>
             {
                 new Week
                 {
                     Sunday = new TimeLog
                     {
                         TimeEntry = "Clock in",
                         TimeStamp = new DateTime(2022, 04, 03, 9, 0, 0)
                     }
                 },
                 new Week
                 {
                     Sunday = new TimeLog
                     {
                         TimeEntry = "Clock out",
                         TimeStamp = new DateTime(2022, 04, 03, 5, 0, 0)
                     }
                 },
                 new Week
                 {
                     Monday = new TimeLog
                     {
                         TimeEntry = "Clock in",
                         TimeStamp = new DateTime(2022, 04, 03, 9, 0, 0)
                     }
                 },
                 new Week
                 {
                     Monday = new TimeLog
                     {
                         TimeEntry = "Clock out",
                         TimeStamp = new DateTime(2022, 04, 03, 5, 0, 0)
                     }
                 },
                 new Week
                 {
                     Tuesday = new TimeLog
                     {
                         TimeEntry = "Clock in",
                         TimeStamp = new DateTime(2022, 04, 03, 9, 0, 0)
                     }
                 },
                 new Week
                 {
                     Tuesday = new TimeLog
                     {
                         TimeEntry = "Clock out",
                         TimeStamp = new DateTime(2022, 04, 03, 5, 0, 0)
                     }
                 },
                 new Week
                 {
                     Wednesday = new TimeLog
                     {
                         TimeEntry = "Clock in",
                         TimeStamp = new DateTime(2022, 04, 03, 9, 0, 0)
                     }
                 },
                 new Week
                 {
                     Wednesday = new TimeLog
                     {
                         TimeEntry = "Clock out",
                         TimeStamp = new DateTime(2022, 04, 03, 5, 0, 0)
                     }
                 },
                 new Week
                 {
                     Thursday = new TimeLog
                     {
                         TimeEntry = "Clock in",
                         TimeStamp = new DateTime(2022, 04, 03, 9, 0, 0)
                     }
                 },
                 new Week
                 {
                     Thursday = new TimeLog
                     {
                         TimeEntry = "Clock out",
                         TimeStamp = new DateTime(2022, 04, 03, 5, 0, 0)
                     }
                 },
                 new Week
                 {
                     Friday = new TimeLog
                     {
                         TimeEntry = "Clock in",
                         TimeStamp = new DateTime(2022, 04, 03, 9, 0, 0)
                     }
                 },
                 new Week
                 {
                     Friday = new TimeLog
                     {
                         TimeEntry = "Clock out",
                         TimeStamp = new DateTime(2022, 04, 03, 5, 0, 0)
                     }
                 },
                 new Week
                 {
                     Saturday = new TimeLog
                     {
                         TimeEntry = "Clock in",
                         TimeStamp = new DateTime(2022, 04, 03, 9, 0, 0)
                     }
                 },
                 new Week
                 {
                     Saturday = new TimeLog
                     {
                         TimeEntry = "Clock out",
                         TimeStamp = new DateTime(2022, 04, 03, 5, 0, 0)
                     }
                 }
             };

             //pull info from data base 
             return sampleData;
         }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using TimeSheet.Windows.TimeSheet.Models.DataQuery;

namespace TimeSheet.Windows.TimeSheet.Models.Calendar
{
    public class Week
    {
        public ObservableCollection<TimeLog> Sunday { get; } = new ObservableCollection<TimeLog>();
        public ObservableCollection<TimeLog> Monday { get; } = new ObservableCollection<TimeLog>();
        public ObservableCollection<TimeLog> Tuesday { get; } = new ObservableCollection<TimeLog>();
        public ObservableCollection<TimeLog> Wednesday { get; } = new ObservableCollection<TimeLog>(); 
        public ObservableCollection<TimeLog> Thursday { get; } = new ObservableCollection<TimeLog>();
        public ObservableCollection<TimeLog> Friday { get; } = new ObservableCollection<TimeLog>();
        public ObservableCollection<TimeLog> Saturday { get; } = new ObservableCollection<TimeLog>();

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
        /// Sets the observable collection property that correspond to the day of the time log
        /// </summary>
        /// <param name="week">week oject</param>
        /// <param name="timeLog">time log object containing day information</param>
        public void AddTimeLogByDay(Week week, TimeLog timeLog)
        {
            switch (timeLog.TimeStamp.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    week.Sunday.Add(timeLog);
                    break;
                case DayOfWeek.Monday:
                    week.Monday.Add(timeLog);
                    break;
                case DayOfWeek.Tuesday:
                    week.Tuesday.Add(timeLog);
                    break;
                case DayOfWeek.Wednesday:
                    week.Wednesday.Add(timeLog);
                    break;
                case DayOfWeek.Thursday:
                    week.Thursday.Add(timeLog);
                    break;
                case DayOfWeek.Friday:
                    week.Friday.Add(timeLog);
                    break;
                case DayOfWeek.Saturday:
                    week.Saturday.Add(timeLog);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

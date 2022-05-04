using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using TimeSheet.Common.Classes.Extensions;
using TimeSheet.Common.Classes.ObservableDictionaries;
using TimeSheet.Windows.TimeSheet.Models.Calendar;
using TimeSheet.Windows.TimeSheet.Models.DataQuery;


namespace TimeSheet.Windows.TimeSheet.View_Models
{

    public class TimeSheetViewModel : ViewModelBase
    {

        #region private fields

        private string _lastActivity = "No activity registered";
        
        private DateTime _firstDateOfCurrentWeek = Week.DateOfFirstWeekDay();
        private DateTime _lastDateOfCurrentWeek = Week.DateOfFirstWeekDay().AddDays(6);

        private string _numWeek;
        private string _numYear;

        private readonly DataQuery _dataQuery = new DataQuery();
        
        private double _totalHours;
        private Week _currentWeek = new Week();

        #endregion private fields

        public DateTime FirstDateOfCurrentWeek
        {
            get => _firstDateOfCurrentWeek;
            private set => Set(ref _firstDateOfCurrentWeek, value);
        }

        public DateTime LastDateOfCurrentWeek
        {
            get => _lastDateOfCurrentWeek;
            private set => Set(ref _lastDateOfCurrentWeek, value);
        }

        public string LastActivity
        {
            get => _lastActivity;
            set => Set(ref _lastActivity, value);
        }

        public string NumWeek
        {
            get => _numWeek;
            set => Set(ref _numWeek, value);
        }

        public string NumYear
        {
            get => _numYear;
            set => Set(ref _numYear, value);
            
        }

        public Week CurrentWeek
        {
            get => _currentWeek;
            set => Set(ref _currentWeek, value);
        }

        public ICommand LoadCommand => new RelayCommand(OnLoadCommand);

        /// <summary>
        /// Loads Current week's time logs
        /// </summary>
        private void OnLoadCommand()
        {
            _dataQuery.LoadSampleData();

            var groupedTimeLogs = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);
            
            SetCurrentWeek(groupedTimeLogs, Week.GetWeekOfYear(DateTime.Now), DateTime.Today.Year);
        }

        public ICommand SearchCommand => new RelayCommand(OnSearchCommand);
        
        /// <summary>
        /// Loads timelogs from the selected week & year
        /// </summary>
        private void OnSearchCommand()
        {
            if(!(NumWeek.IsValidInt() && NumYear.IsValidInt()))
                return;

            var timeLogsGroupedByWeek = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);

            SetCurrentWeek(timeLogsGroupedByWeek, int.Parse(NumWeek), int.Parse(NumYear));

            NumWeek = string.Empty;
            NumYear = string.Empty;
        }

        public ICommand PreviousWeekCommand => new RelayCommand(OnPreviousWeekCommand);

        /// <summary>
        /// Loads previous timelogs from current week
        /// </summary>
        private void OnPreviousWeekCommand()
        {
            var groupedTimeLogs = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);
            
            SetCurrentWeek(groupedTimeLogs, (CurrentWeek.NumWeek -1), CurrentWeek.NumYear);

            FirstDateOfCurrentWeek = FirstDateOfCurrentWeek.AddDays(-7);
            LastDateOfCurrentWeek = LastDateOfCurrentWeek.AddDays(-7);
        }
        
        public ICommand NextWeekCommand => new RelayCommand(OnNextWeekCommand);

        /// <summary>
        /// loads next timelogs from current week
        /// </summary>
        private void OnNextWeekCommand()
        { 
            var groupedTimeLogs = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);

            SetCurrentWeek(groupedTimeLogs, (CurrentWeek.NumWeek + 1), CurrentWeek.NumYear);
            
            FirstDateOfCurrentWeek = FirstDateOfCurrentWeek.AddDays(7);
            LastDateOfCurrentWeek = LastDateOfCurrentWeek.AddDays(7);
        }

        public ICommand ClockInCommand => new RelayCommand(OnClockInCommand);
        
        /// <summary>
        /// Adds Current datetime as a clock in time stamp to the current week 
        /// </summary>
        private void OnClockInCommand()
        {
            var todayTimeStamp = new TimeLog(TimeLog.TimeEntry.ClockIn, DateTime.Now);

            CurrentWeek.SubmitClockEntry(TimeLog.TimeEntry.ClockIn);

            LastActivity = "Clocked in at " + todayTimeStamp.TimeStamp;
        }

        public ICommand ClockOutCommand => new RelayCommand(OnClockOutCommand);

        /// <summary>
        /// Adds Current datetime as a clock out time stamp to the current week 
        /// </summary>
        private void OnClockOutCommand()
        {
            var todayTimeStamp = new TimeLog(TimeLog.TimeEntry.ClockOut, DateTime.Now);

            CurrentWeek.SubmitClockEntry(TimeLog.TimeEntry.ClockOut);
          
            LastActivity = "Clocked in at " + todayTimeStamp.TimeStamp;
        }

        /// <summary>
        /// Sets the week object's properties
        /// </summary>
        /// <param name="groupedData">data for the current week specified</param>
        /// <param name="numWeek">week of the year</param>
        /// <param name="numYear">current year</param>
        private void SetCurrentWeek(IEnumerable<IGrouping<int, IGrouping<DayOfWeek, TimeLog>>> groupedData, int numWeek, int numYear)
         {
            CurrentWeek.NumWeek = numWeek;
            CurrentWeek.NumYear = numYear;

            CurrentWeek = _dataQuery.GetWeekTimeLogs(groupedData, CurrentWeek.NumWeek, CurrentWeek.NumYear);
        }
    }
}

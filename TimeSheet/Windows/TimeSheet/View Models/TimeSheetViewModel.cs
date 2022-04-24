﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        private ObservableCollection<Week> _weekTimeLogs = new ObservableCollection<Week>();
        private DateTime _firstDateOfCurrentWeek = Week.DateOfFirstWeekDay();
        private DateTime _lastDateOfCurrentWeek = Week.DateOfFirstWeekDay().AddDays(6);

        private string _numWeek;
        private string _numYear;

        private readonly DataQuery _dataQuery = new DataQuery();

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

        public ObservableCollection<Week> WeekTimeLogs
        {
            get => _weekTimeLogs;
            private set => Set(ref _weekTimeLogs, value);
        }

        public ICommand LoadCommand => new RelayCommand(OnLoadCommand);

        /// <summary>
        /// Loads Current week's time logs
        /// </summary>
        private void OnLoadCommand()
        {
            _dataQuery.LoadSampleData();

            var groupedTimeLogs = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);

            var currentWeek = _dataQuery.GetWeekTimeLogs(groupedTimeLogs, Week.CurrentWeek, DateTime.Now.Year);

            WeekTimeLogs.Add(currentWeek);
        }

        public ICommand SearchCommand => new RelayCommand(OnSearchCommand);
        
        /// <summary>
        /// Loads timelogs from the selected week & year
        /// </summary>
        private void OnSearchCommand()
        {
            if(!(NumWeek.IsValidInt() && NumYear.IsValidInt()))
                return;

            WeekTimeLogs.Clear();

            var timeLogsGroupedByWeek = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);

            var searchedWeekTimeStamps = _dataQuery.GetWeekTimeLogs(timeLogsGroupedByWeek, int.Parse(NumWeek), int.Parse(NumYear));

            WeekTimeLogs.Add(searchedWeekTimeStamps);

            NumWeek = "";
            NumYear = "";
        }

        public ICommand PreviousWeekCommand => new RelayCommand(OnPreviousWeekCommand);

        /// <summary>
        /// Loads previous timelogs from current week
        /// </summary>
        private void OnPreviousWeekCommand()
        {
            WeekTimeLogs.Clear();
            Week.CurrentWeek -= 1;
            var groupedTimeLogs = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);
            
            var previousWeekTimeLogs = _dataQuery.GetWeekTimeLogs(groupedTimeLogs, Week.CurrentWeek, DateTime.Now.Year);
            
            WeekTimeLogs.Add(previousWeekTimeLogs);
            FirstDateOfCurrentWeek = FirstDateOfCurrentWeek.AddDays(-7);
            LastDateOfCurrentWeek = LastDateOfCurrentWeek.AddDays(-7);
        }
        
        public ICommand NextWeekCommand => new RelayCommand(OnNextWeekCommand);

        /// <summary>
        /// loads next timelogs from current week
        /// </summary>
        private void OnNextWeekCommand()
        {
            WeekTimeLogs.Clear();
            Week.CurrentWeek += 1;

            var groupedTimeLogs = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);
            
            var nextWeekTimeLogs = _dataQuery.GetWeekTimeLogs(groupedTimeLogs, Week.CurrentWeek, DateTime.Now.Year);
            
            WeekTimeLogs.Add(nextWeekTimeLogs);
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
            Week week = new Week();
            Day day = new Day();
            day.AddTimeLog(todayTimeStamp);
            week.WeekDays.Add(day);
            WeekTimeLogs.Add(week);
            LastActivity = "Clocked in at " + todayTimeStamp.TimeStamp;
        }

        public ICommand ClockOutCommand => new RelayCommand(OnClockOutCommand);

        /// <summary>
        /// Adds Current datetime as a clock out time stamp to the current week 
        /// </summary>
        private void OnClockOutCommand()
        {
            var todayTimeStamp = new TimeLog(TimeLog.TimeEntry.ClockOut, DateTime.Now);
            Week week = new Week();
            Day day = new Day();
            day.AddTimeLog(todayTimeStamp);
            week.WeekDays.Add(day);
            WeekTimeLogs.Add(week);
            LastActivity = "Clocked out at " + todayTimeStamp.TimeStamp;
        }
    }


}

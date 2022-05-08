using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using TimeSheet.Common.Classes.Extensions;
using TimeSheet.Windows.TimeSheet.Models.Calendar;
using TimeSheet.Windows.TimeSheet.Models.DataQuery;


namespace TimeSheet.Windows.TimeSheet.View_Models
{

    public class TimeSheetViewModel : ViewModelBase
    {
        private string _lastActivity = "No activity registered";
        private Week _weekTimeStamps;
        private DateTime _firstDateOfCurrentWeek = Week.DateOfFirstDay(DateTime.Today);
        private DateTime _lastDateOfCurrentWeek = Week.DateOfLastDay(DateTime.Today);

        private string _numWeek;
        private string _numYear;

        private readonly DataQuery _dataQuery = new DataQuery();

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

        public Week WeekTimeStamps
        {
            get => _weekTimeStamps;
            private set => Set(ref _weekTimeStamps, value);
        }

        public ICommand LoadCommand => new RelayCommand(OnLoadCommand);

        private void OnLoadCommand()
        {
            WeekTimeStamps = new Week();
            _dataQuery.LoadSampleData();

            var timeLogsGroupedByWeek = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);

            WeekTimeStamps = _dataQuery.GetWeekTimeLogs(timeLogsGroupedByWeek, Week.CurrentWeek, DateTime.Now.Year);;
        }

        public ICommand SearchCommand => new RelayCommand(OnSearchCommand);

        private void OnSearchCommand()
        {
            if(!(NumWeek.IsValidInt() && NumYear.IsValidInt()))
                return;

            WeekTimeStamps = new Week();

            var timeLogsGroupedByWeek = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);

            WeekTimeStamps = _dataQuery.GetWeekTimeLogs(timeLogsGroupedByWeek, int.Parse(NumWeek), int.Parse(NumYear));;
            
        }

        public ICommand PreviousWeekCommand => new RelayCommand(OnPreviousWeekCommand);

        private void OnPreviousWeekCommand()
        {
            WeekTimeStamps = new Week();
            Week.CurrentWeek -= 1;
            var timeLogsGroupedByWeek = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);

            WeekTimeStamps = _dataQuery.GetWeekTimeLogs(timeLogsGroupedByWeek, Week.CurrentWeek, DateTime.Now.Year);;
            FirstDateOfCurrentWeek = FirstDateOfCurrentWeek.AddDays(-7);
            LastDateOfCurrentWeek = LastDateOfCurrentWeek.AddDays(-7);
        }
        
        public ICommand NextWeekCommand => new RelayCommand(OnNextWeekCommand);

        private void OnNextWeekCommand()
        {
            WeekTimeStamps = new Week();
            Week.CurrentWeek += 1;

            var timeLogsGroupedByWeek = _dataQuery.GroupDataByWeekAndDay(DataQuery.Data);

            WeekTimeStamps = _dataQuery.GetWeekTimeLogs(timeLogsGroupedByWeek, Week.CurrentWeek, DateTime.Now.Year);;
            FirstDateOfCurrentWeek = FirstDateOfCurrentWeek.AddDays(7);
            LastDateOfCurrentWeek = LastDateOfCurrentWeek.AddDays(7);
        }

        public ICommand ClockInCommand => new RelayCommand(OnClockInCommand);

        private void OnClockInCommand()
        {
            WeekTimeStamps.SubmitClockEntry(TimeLog.TimeEntry.ClockIn);

            LastActivity = "Clocked in at " + DateTime.Now;
        }

        public ICommand ClockOutCommand => new RelayCommand(OnClockOutCommand);

        private void OnClockOutCommand()
        {
            WeekTimeStamps.SubmitClockEntry(TimeLog.TimeEntry.ClockOut);

            LastActivity = "Clocked out at " + DateTime.Now;
        }
    }
}

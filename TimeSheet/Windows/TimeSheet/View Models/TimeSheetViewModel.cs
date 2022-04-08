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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TimeSheet.Windows.TimeSheet.Models;
using TimeSheet.Common.Classes.Extensions;
using TimeSheet.Windows.TimeSheet.Models.Calendar;
using TimeSheet.Windows.TimeSheet.Models.DataQuery;


namespace TimeSheet.Windows.TimeSheet.View_Models
{

    public class TimeSheetViewModel : ViewModelBase
    {
        private string _lastActivity = "No activity registered";
        private ObservableCollection<Week> _weekTimeStamps = new ObservableCollection<Week>();
        private DateTime _firstDateOfCurrentWeek = DateTime.Today.AddDays(
            (int) CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - 
            (int) DateTime.Today.DayOfWeek);
        private DateTime _lastDateOfCurrentWeek = DateTime.Today.AddDays(
            (int) CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - 
            (int) DateTime.Today.DayOfWeek + 6);

        private string _numWeek;
        private string _numYear;

        public DateTime FirstDateOfCurrentWeek
        {
            get => _firstDateOfCurrentWeek;
            set => Set(ref _firstDateOfCurrentWeek, value);
        }

        public DateTime LastDateOfCurrentWeek
        {
            get => _lastDateOfCurrentWeek;
            set => Set(ref _lastDateOfCurrentWeek, value);
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

        public ObservableCollection<Week> WeekTimeStamps
        {
            get => _weekTimeStamps;
            private set => Set(ref _weekTimeStamps, value);
        }

        public ICommand LoadCommand => new RelayCommand(OnLoadCommand);

        private void OnLoadCommand()
        {
            DataQuery currentWeekData = new DataQuery();

            currentWeekData.LoadSampleData();

            var timeLogsGroupedByWeek = currentWeekData.GroupDataByWeek(DataQuery.Data);

            var currentWeekTimeStamps = currentWeekData.GetWeekTimeLogs(timeLogsGroupedByWeek, DataQuery.CurrentWeek, DateTime.Now.Year);
           
            WeekTimeStamps.Add(currentWeekTimeStamps);
        }

        public ICommand SearchCommand => new RelayCommand(OnSearchCommand);

        private void OnSearchCommand()
        {
            WeekTimeStamps.Clear();
            if(!(NumWeek.IsValidInt() && NumYear.IsValidInt()))
                return;

            DataQuery dataFromSearchedWeek = new DataQuery();

            var timeLogsGroupedByWeek = dataFromSearchedWeek.GroupDataByWeek(DataQuery.Data);

            var searchedWeekTimeStamps = dataFromSearchedWeek.GetWeekTimeLogs(timeLogsGroupedByWeek, int.Parse(NumWeek), int.Parse(NumYear));

            WeekTimeStamps.Add(searchedWeekTimeStamps);
            
        }

        public ICommand PreviousWeekCommand => new RelayCommand(OnPreviousWeekCommand);

        private void OnPreviousWeekCommand()
        {
            WeekTimeStamps.Clear();
            DataQuery previousWeekData = new DataQuery();
            DataQuery.CurrentWeek -= 1;
            var timeLogsGroupedByWeek = previousWeekData.GroupDataByWeek(DataQuery.Data);

            var previousWeekTimeStamps = previousWeekData.GetWeekTimeLogs(timeLogsGroupedByWeek, DataQuery.CurrentWeek, DateTime.Now.Year);
            
            WeekTimeStamps.Add(previousWeekTimeStamps);
        }
        
        public ICommand NextWeekCommand => new RelayCommand(OnNextWeekCommand);

        private void OnNextWeekCommand()
        {
            WeekTimeStamps.Clear();
            DataQuery nextWeekData = new DataQuery();
            DataQuery.CurrentWeek += 1;

            var timeLogsGroupedByWeek = nextWeekData.GroupDataByWeek(DataQuery.Data);

            var nextWeekTimeStamps = nextWeekData.GetWeekTimeLogs(timeLogsGroupedByWeek, DataQuery.CurrentWeek , DateTime.Now.Year);
            
            WeekTimeStamps.Add(nextWeekTimeStamps);
        }

        public ICommand ClockInCommand => new RelayCommand(OnClockInCommand);

        private void OnClockInCommand()
        {
            MessageBox.Show("Works");
        }

        public ICommand ClockOutCommand => new RelayCommand(OnClockOutCommand);

        private void OnClockOutCommand()
        {
            MessageBox.Show("Works");
        }
    }
}

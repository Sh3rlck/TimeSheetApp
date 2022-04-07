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

        public bool IsListItemSelected { get; set; } 
        public ObservableCollection<WeekDates> WeekDates = new ObservableCollection<WeekDates>();

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

        public ICommand SearchCommand => new RelayCommand(OnSearchCommand);

        private void OnSearchCommand()
        {
            if(!(NumWeek.IsValidInt() && NumYear.IsValidInt()))
                return;

            DataQuery dataQuery = new DataQuery();
            var sampleData = dataQuery.LoadSampleData();

            var timeLogsGroupedByWeek = dataQuery.GroupDataByWeek(sampleData);

            var weekTimeStamps = dataQuery.GetWeekTimeStamps(timeLogsGroupedByWeek, NumWeek, NumYear);

            WeekTimeStamps.Add(weekTimeStamps);
            
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

        public ICommand PreviousWeekCommand => new RelayCommand(OnPreviousWeekCommand);

        private void OnPreviousWeekCommand()
        {
            FirstDateOfCurrentWeek = _firstDateOfCurrentWeek.AddDays(-7);
            LastDateOfCurrentWeek = _lastDateOfCurrentWeek.AddDays(-7);
        }

        public ICommand NextWeekCommand => new RelayCommand(OnNextWeekCommand);

        private void OnNextWeekCommand()
        {
            FirstDateOfCurrentWeek = _firstDateOfCurrentWeek.AddDays(7);
            LastDateOfCurrentWeek = _lastDateOfCurrentWeek.AddDays(7);
        }
    }
}

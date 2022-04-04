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


namespace TimeSheet.Windows.TimeSheet.View_Models
{

    public class TimeSheetViewModel : ViewModelBase
    {
        private string _lastActivity = "No activity registered";
        private ObservableCollection<Week> _weekTimeStamps;
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

        public ICommand SearchCommand => new RelayCommand(OnSearchCommand);

        private void OnSearchCommand()
        {
            WeekTimeStamps = new ObservableCollection<Week>();
            WeekTimeStamps.Clear();
            if (!(NumWeek.IsValidInt() && NumYear.IsValidInt()))
                return;

            NavigationBar dateQuery = new NavigationBar();
            var sampleData = dateQuery.LoadSampleData();

            var groupedByWeek = dateQuery.GroupDataByWeek(sampleData);

            foreach (var numWeek in groupedByWeek)
            {
                if (numWeek.Key != int.Parse(NumWeek)) 
                    continue;
                Week weekClockIns = new Week();
                Week weekClockOuts = new Week();
                foreach (var timeLog in numWeek)
                {
                    if (timeLog.TimeStamp.Year != int.Parse(NumYear))
                        continue;
                    if (timeLog.TimeEntries == TimeLog.TimeEntry.ClockIn)
                    {
                        switch (timeLog.TimeStamp.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                weekClockIns.Sunday = timeLog;
                                break;
                            case DayOfWeek.Monday:
                                weekClockIns.Monday = timeLog;
                                break;
                            case DayOfWeek.Tuesday:
                                weekClockIns.Tuesday = timeLog;
                                break;
                            case DayOfWeek.Wednesday:
                                weekClockIns.Wednesday = timeLog;
                                break;
                            case DayOfWeek.Thursday:
                                weekClockIns.Thursday = timeLog;
                                break;
                            case DayOfWeek.Friday:
                                weekClockIns.Friday = timeLog;
                                break;
                            case DayOfWeek.Saturday:
                                weekClockIns.Saturday = timeLog;
                                break;
                            default:
                                throw new Exception("invalid week day or timelog");
                        }
                    } else
                    {
                        switch (timeLog.TimeStamp.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                weekClockOuts.Sunday = timeLog;
                                break;
                            case DayOfWeek.Monday:
                                weekClockOuts.Monday = timeLog;
                                break;
                            case DayOfWeek.Tuesday:
                                weekClockOuts.Tuesday = timeLog;
                                break;
                            case DayOfWeek.Wednesday:
                                weekClockOuts.Wednesday = timeLog;
                                break;
                            case DayOfWeek.Thursday:
                                weekClockOuts.Thursday = timeLog;
                                break;
                            case DayOfWeek.Friday:
                                weekClockOuts.Friday = timeLog;
                                break;
                            case DayOfWeek.Saturday:
                                weekClockOuts.Saturday = timeLog;
                                break;
                            default:
                                throw new Exception("invalid week day or timelog");
                        }
                    }
                } 
                WeekTimeStamps.Add(weekClockIns);
                WeekTimeStamps.Add(weekClockOuts);
            }
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

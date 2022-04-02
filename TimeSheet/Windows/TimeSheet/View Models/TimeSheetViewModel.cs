﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TimeSheet.Windows.TimeSheet.Models;


namespace TimeSheet.Windows.TimeSheet.View_Models
{

    public class TimeSheetViewModel : ViewModelBase
    {
        private string _lastActivity = "No activity registered";
        private int _numWeek;
        private int _numYear;
        private ObservableCollection<Week> _weekTimeStamps = new ObservableCollection<Week>();

        public int NumWeek
        {
            get => _numWeek;
            set => Set(ref _numWeek, value);
        }

        public int  NumYear
        {
            get => _numYear;
            set => Set(ref _numYear, value);
        }

        public ObservableCollection<Week> WeekTimeStamps
        {
            get => _weekTimeStamps;
            private set => Set(ref _weekTimeStamps, value);
        }

        public ICommand PreviousWeekCommand => new RelayCommand(OnPreviousWeekCommand);

        private void OnPreviousWeekCommand()
        {
            MessageBox.Show("Works");
        }

        public ICommand NextWeekCommand => new RelayCommand(OnNextWeekCommand);

        private void OnNextWeekCommand()
        {
            MessageBox.Show("Works");
        }

        public ICommand SearchCommand => new RelayCommand(OnSearchCommand);

        private void OnSearchCommand()
        {
            NavigationBar dateQuery = new NavigationBar(NumWeek, NumYear);
            IEnumerable<IGrouping<int, TimeLog>> groupedByWeek = dateQuery.QueryDate();

            foreach (IGrouping<int, TimeLog> numWeek in groupedByWeek)
            {
                Week week = new Week();
                foreach (var timeLog in numWeek)
                {
                    switch (timeLog.TimeStamp.DayOfWeek)
                    {
                        case DayOfWeek.Sunday:
                            week.Sunday = timeLog;
                            break;
                        case DayOfWeek.Monday:
                            week.Monday = timeLog;
                            break;
                        case DayOfWeek.Tuesday:
                            week.Tuesday = timeLog;
                            break;
                        case DayOfWeek.Wednesday:
                            week.Wednesday = timeLog;
                            break;
                        case DayOfWeek.Thursday:
                            week.Thursday = timeLog;
                            break;
                        case DayOfWeek.Friday:
                            week.Friday = timeLog;
                            break;
                        case DayOfWeek.Saturday:
                            week.Saturday = timeLog;
                            break;
                        default:
                            throw new Exception("invalid week day or timelog");
                    }
                }
                WeekTimeStamps.Add(week);
            }
        }

        public ICommand ClockInCommand => new RelayCommand(OnClockInCommand);

        private void OnClockInCommand()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case  DayOfWeek.Sunday:
                    Week sunday = new Week
                    {
                        Sunday = new TimeLog
                        {
                            TimeEntries = TimeLog.TimeEntry.ClockIn,
                            TimeStamp = DateTime.Now
                        }
                    };
                    
                    WeekTimeStamps.Add(sunday);
                   LastActivity = sunday.Sunday.ToString();
                    break;
                case  DayOfWeek.Monday:
                    Week monday = new Week
                    {
                        Monday = new TimeLog
                        {
                            TimeEntries = TimeLog.TimeEntry.ClockIn,
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekTimeStamps.Add(monday);
                    LastActivity = monday.Monday.ToString();
                    break;
                case  DayOfWeek.Tuesday:
                    Week tuesday = new Week
                    {
                        Tuesday = new TimeLog
                        {
                            TimeEntries = TimeLog.TimeEntry.ClockIn,
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekTimeStamps.Add(tuesday);
                    LastActivity = tuesday.Tuesday.ToString();
                    break;
                case  DayOfWeek.Wednesday:
                    Week wednesday = new Week
                    {
                        Wednesday = new TimeLog
                        {
                            TimeEntries = TimeLog.TimeEntry.ClockIn,
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekTimeStamps.Add(wednesday);
                    LastActivity = wednesday.Wednesday.ToString();
                    break;
                case  DayOfWeek.Thursday:
                    Week thursday = new Week
                    {
                        Thursday = new TimeLog
                        {
                            TimeEntries = TimeLog.TimeEntry.ClockIn,
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekTimeStamps.Add(thursday);
                    LastActivity = thursday.Thursday.ToString();
                    break;
                case  DayOfWeek.Friday:
                    Week friday = new Week
                    {
                        Friday = new TimeLog
                        {
                            TimeEntries = TimeLog.TimeEntry.ClockIn,
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekTimeStamps.Add(friday);
                    LastActivity = friday.Friday.ToString();
                    break;
                case  DayOfWeek.Saturday:
                    Week saturday = new Week
                    {
                        Saturday = new TimeLog
                        {
                            TimeEntries = TimeLog.TimeEntry.ClockIn,
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekTimeStamps.Add(saturday);
                    LastActivity = saturday.Saturday.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ICommand ClockOutCommand => new RelayCommand(OnClockOutCommand);

        private void OnClockOutCommand()
        {
            MessageBox.Show("Works");
        }


        public string LastActivity
        {
            get => _lastActivity;
            set => Set(ref _lastActivity, value);
        }
    }
}

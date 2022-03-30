using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public enum WeekDays
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
    
    public class TimeSheetViewModel : ViewModelBase
    {
        private string _lastActivity = "No activity registered";

        public ObservableCollection<TimeLog> TimeLogs { get; } = new ObservableCollection<TimeLog>();

        public ObservableCollection<Week> WeekDayTimeStamps { get; } = new ObservableCollection<Week>();

        public ICommand ClockInCommand => new RelayCommand(OnClockInCommand);

        private void OnClockInCommand()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case  DayOfWeek.Sunday:
                    Week sunday = new Week
                    {
                        Tuesday = new TimeLog
                        {
                            TimeEntry = "Clock in",
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekDayTimeStamps.Add(sunday);
                    break;
                case  DayOfWeek.Monday:
                    Week monday = new Week
                    {
                        Tuesday = new TimeLog
                        {
                            TimeEntry = "Clock in",
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekDayTimeStamps.Add(monday);
                    break;
                case  DayOfWeek.Tuesday:
                    Week tuesday = new Week
                    {
                        Tuesday = new TimeLog
                        {
                            TimeEntry = "Clock in",
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekDayTimeStamps.Add(tuesday);
                    break;
                case  DayOfWeek.Wednesday:
                    Week wednesday = new Week
                    {
                        Tuesday = new TimeLog
                        {
                            TimeEntry = "Clock in",
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekDayTimeStamps.Add(wednesday);
                    break;
                case  DayOfWeek.Thursday:
                    Week thursday = new Week
                    {
                        Tuesday = new TimeLog
                        {
                            TimeEntry = "Clock in",
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekDayTimeStamps.Add(thursday);
                    break;
                case  DayOfWeek.Friday:
                    Week friday = new Week
                    {
                        Tuesday = new TimeLog
                        {
                            TimeEntry = "Clock in",
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekDayTimeStamps.Add(friday);
                    break;
                case  DayOfWeek.Saturday:
                    Week saturday = new Week
                    {
                        Tuesday = new TimeLog
                        {
                            TimeEntry = "Clock in",
                            TimeStamp = DateTime.Now
                        }
                    };
                    WeekDayTimeStamps.Add(saturday);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            MessageBox.Show("works");
        }

        public ICommand ClockOutCommand => new RelayCommand(OnClockOutCommand);

        private void OnClockOutCommand()
        {
            TimeLog timeLog = new TimeLog
            {
                TimeEntry = "Clock Out",
                TimeStamp = DateTime.Now
            };
            TimeLogs.Add(timeLog);
            MessageBox.Show("Works");
        }


        public string LastActivity
        {
            get => _lastActivity;
            set => Set(ref _lastActivity, value);
        }
    }
}

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

    public class TimeSheetViewModel : ViewModelBase
    {
        private string _lastActivity = "No activity registered";

        public ObservableCollection<Week> WeekTimeStamps { get; } = new ObservableCollection<Week>();

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
                            TimeEntry = "Clock in",
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
                            TimeEntry = "Clock in",
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
                            TimeEntry = "Clock in",
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
                            TimeEntry = "Clock in",
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
                            TimeEntry = "Clock in",
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
                            TimeEntry = "Clock in",
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
                            TimeEntry = "Clock in",
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

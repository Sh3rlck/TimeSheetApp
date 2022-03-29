using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ICommand _clockOutCommand;
        private string _lastActivity = "No activity registered";

        public ICommand ClockInCommand => new RelayCommand(OnClockInCommand);

        private void OnClockInCommand()
        {
            TimeLog timeLog = new TimeLog
            {
                TimeEntry = "Clock In",
                TimeStamp = DateTime.Now
            };

            TimeLogs.Add(timeLog);

            MessageBox.Show("Works");
        }

        public static ObservableCollection<TimeLog> TimeLogs => new ObservableCollection<TimeLog>(); 

        public ICommand ClockOutCommand
        {
            get => _clockOutCommand;
            set => Set(ref _clockOutCommand, value);
        }

        public string LastActivity
        {
            get => _lastActivity;
            set => Set(ref _lastActivity, value);
        }
        //test

    }
}

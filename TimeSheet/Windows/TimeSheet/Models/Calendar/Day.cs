using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Windows.TimeSheet.Models.DataQuery;

namespace TimeSheet.Windows.TimeSheet.Models.Calendar
{
    public class Day
    {
        public ObservableCollection<TimeLog> TimeLogs { get; set; }
        public DayOfWeek DateDayOfWeek { get; set; }

        public Day(DateTime date)
        {
            DateDayOfWeek = date.DayOfWeek;
        }
    }
}

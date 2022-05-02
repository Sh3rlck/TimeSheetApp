using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Data;
using TimeSheet.Windows.TimeSheet.Models.DataQuery;

namespace TimeSheet.Windows.TimeSheet.Converter
{
    public class TotalHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var totalHours = new TimeSpan();

            if (!(value is IEnumerable<object> items))
                return Math.Abs(totalHours.Hours);

            List<object> logs = items.ToList();

            if(logs.Count == 0) 
                return Math.Abs(totalHours.Hours);

            var firstClock = (TimeLog) logs[0];
            var lastClock = (TimeLog) logs[logs.Count - 1];
            totalHours = firstClock.TimeStamp.Subtract(lastClock.TimeStamp);
            //make sure to look for to calculate the difference from clock in to clock out 

            return Math.Abs(totalHours.Hours);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

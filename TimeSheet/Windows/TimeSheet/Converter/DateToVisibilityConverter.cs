using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.TextFormatting;
using TimeSheet.Windows.TimeSheet.Models.Calendar;

namespace TimeSheet.Windows.TimeSheet.Converter
{
    public class DateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Week week))
                return Visibility.Collapsed;

            if (week.WeekDays.Any(day => day.TimeLogs.Count.Equals(0)))
                return Visibility.Collapsed;
            
            var numWeek = Week.GetWeekOfYear(week.WeekDays[0].TimeLogs[0].TimeStamp);
            return numWeek.Equals(week.NumWeek) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

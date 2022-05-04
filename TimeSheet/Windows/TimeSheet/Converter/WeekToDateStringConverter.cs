using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TimeSheet.Windows.TimeSheet.Models.Calendar;

namespace TimeSheet.Windows.TimeSheet.Converter
{
    public class WeekToDateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Week week))
                return Binding.DoNothing;

            return parameter != null ? week.WeekDays[int.Parse(parameter.ToString())].Date.ToString("d") : Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

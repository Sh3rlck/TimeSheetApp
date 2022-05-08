using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using LambdaConverters;
using TimeSheet.Windows.TimeSheet.Models.Calendar;

namespace TimeSheet.Windows.TimeSheet.Converter
{
    public static class Converters
    {
        public static readonly IValueConverter DateToVisibilityConverter =
            ValueConverter.Create<Day, Visibility>(e => (e.Value.TimeLogs.Count == 0) ? Visibility.Collapsed : Visibility.Visible);
            
    }
}

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            if (parameter != null && week.WeekDays[int.Parse(parameter.ToString())].TimeLogs.Count.Equals(0))
                return Visibility.Collapsed;

            Debug.Assert(parameter != null, nameof(parameter) + " != null");
            var numWeek = Week.GetWeekOfYear(week, int.Parse(parameter.ToString()));
            return numWeek.Equals(week.NumWeek) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

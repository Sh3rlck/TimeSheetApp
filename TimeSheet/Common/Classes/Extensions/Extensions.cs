using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Common.Classes.Extensions
{
    internal static class Extensions
    {
        public static bool IsValidInt(this string txt)
        {
            return int.TryParse(Convert.ToString(txt), System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, out int _);
            
        }
    }
}

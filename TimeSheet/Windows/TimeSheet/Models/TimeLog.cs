﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Windows.TimeSheet.Models
{
    public class TimeLog
    {
        public string TimeEntry { get; set; } 
        public DateTime TimeStamp { get; set; }

        public override string ToString()
        {
            return TimeEntry + " at " + TimeStamp;
        }
    }
}

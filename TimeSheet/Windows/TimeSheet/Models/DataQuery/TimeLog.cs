using System;

namespace TimeSheet.Windows.TimeSheet.Models.DataQuery
{
    public class TimeLog
    {
        public enum TimeEntry { ClockIn, ClockOut }

        public TimeEntry TimeEntries { get; set; }
        public DateTime TimeStamp { get; set; }

        public override string ToString()
        {
            return TimeEntries + " at " + TimeStamp;
        }
    }
}

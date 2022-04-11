using System;

namespace TimeSheet.Windows.TimeSheet.Models.DataQuery
{
    public class TimeLog
    {
        public enum TimeEntry { ClockIn, ClockOut }

        public TimeEntry TimeEntries { get; set; }
        public DateTime TimeStamp { get; set; }

        public TimeLog() {}

        public TimeLog(TimeEntry timeEntry, DateTime timeStamp)
        {
            TimeEntries = timeEntry;
            TimeStamp = timeStamp;
        }
    }
}

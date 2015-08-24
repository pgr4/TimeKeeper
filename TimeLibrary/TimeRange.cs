using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public class TimeRange
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double Raw {
            get
            {
                if (EndTime.HasValue)
                {
                    return EndTime.Value.Ticks - StartTime.Ticks;
                }
                else
                {
                    return DateTime.Now.Ticks - StartTime.Ticks;
                }
            }
        }

        public TimeRange(DateTime startTime, DateTime? endTime = null)
        {
            StartTime = startTime;
            EndTime = StartTime.AddHours(1);
        }
    }
}

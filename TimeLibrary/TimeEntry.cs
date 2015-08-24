using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public class TimeEntry
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public bool IsBillable { get; set; }
        public bool IsActive { get; set; }
        
        public List<TimeRange> Times { get; set; }

        public TimeProject Project { get; set; }

        public TimeEntry()
        {
            Name = "Default";
            Times = new List<TimeRange>();
            Times.Add(new TimeRange(DateTime.Now.AddHours(-4)));
            Times.Add(new TimeRange(DateTime.Now.AddHours(-6)));
        }

        public TimeEntry(string name, string company, double time, string note, bool isBillable = true)
        {
            Name = name;
            Note = note;
            IsBillable = isBillable;
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}

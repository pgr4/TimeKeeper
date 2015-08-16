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
        public string Company { get; set; }
        public string Note { get; set; }
        public double Time { get; set; }
        public bool IsBillable { get; set; }

        public TimeEntry()
        {
            Name = "Default";
        }

        public TimeEntry(string name, string company, double time, string note, bool isBillable = true)
        {
            Name = name;
            Company = company;
            Time = time;
            Note = note;
            IsBillable = isBillable;
        }

        public void UpdateDisplayWidth(TimeSpan range, double length)
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}

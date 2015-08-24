using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public class TimeProject
    {
        public List<TimeEntry> Entries{ get; set; }
        
        public List<TimeRange> Times
        {
            get
            {
                List<TimeRange> ret = new List<TimeRange>();

                foreach (var item in Entries)
                {
                    ret.AddRange(item.Times);
                }

                return ret;
            }
        }

        public string Name { get; set; }

        public TimeProject()
        {
            Initialize();
        }

        public TimeProject(string name)
        {
            Name = name;

            Initialize();
        }

        private void Initialize()
        {
            Entries = new List<TimeEntry>();

            Entries.Add(new TimeEntry());
        }
    }
}

using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TimeLibrary;

namespace TimeKeeper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TimeProject> ProjectCollection { get; set; }

        public List<List<TimeRange>> AllTimes
        {
            get
            {
                List<List<TimeRange>> ret = new List<List<TimeLibrary.TimeRange>>();

                foreach (var pItem in ProjectCollection)
                {
                    ret.Add(pItem.Times);

                    foreach (var sItem in pItem.Entries)
                    {
                        ret.Add(sItem.Times);
                    }
                }

                return ret;
            }
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeRange { get { return TimeSpan.FromTicks(EndTime.Ticks - StartTime.Ticks); } }

        public double ListViewWidth { get; set; }

        private double _timeLabelWidth;

        public double TimeLabelWidth
        {
            get { return _timeLabelWidth; }
            set
            {
                _timeLabelWidth = value;
                RaisePropertyChanged("BarMargin");
            }
        }

        public Thickness BarMargin { get { return new Thickness(TimeLabelWidth / 2, 0, 0, 0); } }

        public MainViewModel()
        {
            StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);

            ProjectCollection = new ObservableCollection<TimeProject>();
            ProjectCollection.Add(new TimeProject("Project"));
        }
    }
}
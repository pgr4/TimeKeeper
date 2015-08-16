using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using TimeLibrary;

namespace TimeKeeper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TimeEntry> EntryCollection { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeRange { get { return TimeSpan.FromTicks(EndTime.Ticks - StartTime.Ticks); } }

        private double _listViewWidth;

        public double ListViewWidth
        {
            get { return _listViewWidth; }
            set
            {
                _listViewWidth = value;
                UpdateAllWidths();
            }
        }

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
            EntryCollection = new ObservableCollection<TimeEntry>();
            EntryCollection.Add(new TimeEntry());
            StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
            EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 0);
        }

        private void UpdateAllWidths()
        {
            foreach (var item in EntryCollection)
            {
                item.UpdateDisplayWidth(TimeRange, ListViewWidth);
            }
        }
    }
}
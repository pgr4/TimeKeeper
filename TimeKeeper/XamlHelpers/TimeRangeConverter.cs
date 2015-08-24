using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TimeKeeper.XamlHelpers
{
    class TimeRangeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime startTime = (DateTime)values[0];
            DateTime endTime = (DateTime)values[1];

            long totalTicks = endTime.Ticks - startTime.Ticks;

            //TODO:5 should be a dynamic value
            var interval = totalTicks / 4;

            int index = int.Parse((string)parameter);

            return startTime.AddTicks(totalTicks + (interval * index)).ToString("h:mm");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TimeKeeper.XamlHelpers
{
    public class TimeWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Thickness originalMargin = (Thickness)values[0];
            DateTime entryStartTime = (DateTime)values[1];
            DateTime entryEndTime = (DateTime)values[2];
            DateTime minTime = (DateTime)values[3];
            DateTime maxTime = (DateTime)values[4];
            double containerWidth = (double)values[5];

            var originalMarginLeft = originalMargin.Left;

            var effectiveWidth = containerWidth - originalMarginLeft;

            var totalTime = (entryEndTime - entryStartTime).TotalMilliseconds;

            var viewTime = (maxTime - minTime).TotalMilliseconds;

            var usedTime = totalTime / viewTime;

            return usedTime * effectiveWidth;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

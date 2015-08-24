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
    public class TimeStartConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Thickness originalMargin = (Thickness)values[0];
            DateTime entryStartTime = (DateTime)values[1];
            DateTime minTime = (DateTime)values[2];
            DateTime maxTime = (DateTime)values[3];
            double containerWidth = (double)values[4];
            
            var originalMarginLeft = originalMargin.Left;

            var effectiveContainerWidth = containerWidth - (originalMarginLeft * 2);
            
            var totalDifference = (maxTime - minTime).TotalMilliseconds;
            
            var minDifference = (entryStartTime - minTime).TotalMilliseconds;
            
            var ratio = minDifference / totalDifference;

            var marginlessOffset = ratio * effectiveContainerWidth;

            originalMargin.Left = originalMarginLeft + marginlessOffset;

            return originalMargin;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

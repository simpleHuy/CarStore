using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

namespace CarStore.Helpers;
internal class DateTimeToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var dateTime = (DateTime)value;
        var now = DateTime.Now;
        if (dateTime < now)
        {
            return new SolidColorBrush(Colors.Red);
        }
        else
        {
            // còn x ngày nữa sẽ diễn ra
            var days = (dateTime - now).Days;
            if (days == 0)
            {
                return new SolidColorBrush(Colors.Yellow);
            }
            else if (days == 1)
            {
                return new SolidColorBrush(Colors.Orange);
            }
            else
            {
                return new SolidColorBrush(Colors.Green);
            }
        }
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}

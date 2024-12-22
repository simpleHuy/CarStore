using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Helpers;
internal class DateTimeToScheduleStatus : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var dateTime = (DateTime)value;
        var now = DateTime.Now;
        if (dateTime < now)
        {
            return "Đã qua";
        }
        else
        {
            // còn x ngày nữa sẽ diễn ra
            var days = (dateTime - now).Days;
            if (days == 0)
            {
                return "Hôm nay";
            }
            else if (days == 1)
            {
                return "Ngày mai";
            }
            else
            {
                return $"Còn {days} ngày";
            }
        }
    }
        public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}

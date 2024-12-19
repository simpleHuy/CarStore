using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Helpers;
public class DateTimeToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var dateTime = (DateTime)value;
        // return string: Ngày: dd/MM/yyyy Giờ: HH:mm(AM or PM) 
        var result = $"Vào ngày: {dateTime.ToString("dd/MM/yyyy")}\nVào lúc: {dateTime.ToString("hh:mm tt").Replace("AM", "sáng").Replace("PM", "chiều")}";
        //(AM->sáng, PM->chiều)
        return result;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}

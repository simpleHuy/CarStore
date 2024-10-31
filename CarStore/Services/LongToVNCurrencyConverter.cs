using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;

public class LongToVNCurrencyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var number = (long)value;
        CultureInfo vietnameseCulture = new CultureInfo("vi-VN");
        var formattedAmount = number.ToString("C0", vietnameseCulture);
        return formattedAmount;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

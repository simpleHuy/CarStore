using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using Microsoft.UI;


namespace CarStore.Helpers;

public class ConditionToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is string condition)
        {
            return condition switch
            {
                "Đang diễn ra" => new SolidColorBrush(Colors.Green),
                "Kết thúc" => new SolidColorBrush(Colors.Red),
                _ => new SolidColorBrush(Colors.Black),
            };
        }
        return new SolidColorBrush(Colors.Black);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
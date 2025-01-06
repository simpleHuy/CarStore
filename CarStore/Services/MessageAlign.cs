using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;
public class MessageAlign : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool val)
        {
            if (val)
            {
                return HorizontalAlignment.Right;
            }
        }
        return HorizontalAlignment.Left;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
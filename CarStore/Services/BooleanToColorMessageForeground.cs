using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

namespace CarStore.Services
{
    public class BooleanToColorMessageForeground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool val && val)
            {
                // Return a SolidColorBrush for "Blue"
                return new SolidColorBrush(Colors.White);
            }

            // Return a SolidColorBrush for "White"
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

namespace CarStore.Services
{
    public class BooleanToColorMessage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool val && val)
            {
                // Return a SolidColorBrush for "Blue"
                return new SolidColorBrush(Colors.CornflowerBlue);
            }

            // Return a SolidColorBrush for "White"
            return new SolidColorBrush(Colors.LightGray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

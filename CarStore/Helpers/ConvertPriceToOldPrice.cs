using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Helpers
{
    class ConvertPriceToOldPrice : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var price = (long)value;
            price = price * 100 / 80;
            CultureInfo vietnameseCulture = new CultureInfo("vi-VN");
            var formattedAmount = price.ToString("C0", vietnameseCulture);
            return formattedAmount;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

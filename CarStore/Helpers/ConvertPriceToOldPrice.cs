using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Helpers
{
    class ConvertPriceToOldPrice: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var price = (long)value;
            price = price* 100 / 80;
            return price.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

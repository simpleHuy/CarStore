using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using System.Globalization;
using Windows.Web.Syndication;

namespace CarStore.Helpers;
public class ManufactureConverter : IValueConverter
{
    private readonly Dictionary<int, string> manufacturers = new()
    { 
        // TODO: Implement to get from database
        {1, "Toyota"}, 
        {2, "Ford"}, 
        {3, "Honda"}, 
    };

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int id && manufacturers.TryGetValue(id, out var manufacturer)) { return manufacturer; }
        return "Unknown Manufacturer";
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is int id && manufacturers.TryGetValue(id, out var manufacturer)) { return manufacturer; }
        return "Unknown Manufacturer";
    }
    public object? ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return null;
    }
}

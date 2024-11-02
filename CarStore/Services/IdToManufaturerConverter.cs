using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Models;
using CarStore.Services.DataAccess;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;

public class IdToManufaturerConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var id = (int)value;
        MockDao dao = new MockDao();
        var manufacturers = dao.getAllManufacturers();

        string result = "";

        foreach (var manufacturer in manufacturers)
        {
            if (manufacturer.Id == id)
            {
                result = manufacturer.Name;
            }
        }

        return result;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}

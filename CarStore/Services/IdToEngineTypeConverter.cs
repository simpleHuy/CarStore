using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Services.DataAccess;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;

public class IdToEngineTypeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var id = (int)value;
        MockDao dao = new MockDao();
        var engineTypes = dao.GetEngineTypes();

        string result = "";

        foreach (var enginetype in engineTypes)
        {
            if (enginetype.Id == id)
            {
                result = enginetype.Name;
            }
        }

        return result;

    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;

public class IdToNumberOfSeatsConverter : IValueConverter
{
    private readonly IDao<NumberSeat> _dao;

    public IdToNumberOfSeatsConverter()
    {
        _dao = App.GetService<IDao<NumberSeat>>();
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null)
        {
            return "";
        }
        var id = (int)value;
        var numberOfSeat = new NumberSeat();
        Task.Run(async () => numberOfSeat = await _dao.GetByIdAsync(id)).Wait();

        return numberOfSeat.Name;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}

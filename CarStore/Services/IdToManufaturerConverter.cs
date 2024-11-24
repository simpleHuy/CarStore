using CarStore.Core.Contracts.Services;
using CarStore.Core.Daos;
using CarStore.Core.Data;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;

public class IdToManufaturerConverter : IValueConverter
{
    private readonly IDao<Manufacturer> _dao;

    public IdToManufaturerConverter()
    {
        _dao = App.GetService<IDao<Manufacturer>>();
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null)
        {
            return "";
        }
        var id = (int)value;
        var result = "";
        Task.Run(async () => result = await GetManufacturerNameByIdAsync(id)).Wait();
        return result;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();

    public async Task<string> GetManufacturerNameByIdAsync(int id)
    {
        var manufacturers = await _dao.GetAllAsync();

        var result = manufacturers.FirstOrDefault(m => m.Id == id)?.Name ?? "";

        return result;
    }
}

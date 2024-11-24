using CarStore.Core.Contracts.Services;
using CarStore.Core.Daos;
using CarStore.Core.Data;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;

public class IdToTypeOfCarConverter : IValueConverter
{
    private readonly IDao<TypeOfCar> _dao;

    public IdToTypeOfCarConverter()
    {
        _dao = App.GetService<IDao<TypeOfCar>>();
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null)
        {
            return "";
        }
        var id = (int)value;
        string result = "";
        Task.Run(async () => result = await GetTypeOfCarNameByIdAsync(id)).Wait();
        return result;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();

    public async Task<string> GetTypeOfCarNameByIdAsync(int id)
    {
        var typeOfCars = await _dao.GetAllAsync();

        var result = typeOfCars.FirstOrDefault(m => m.Id == id)?.Name ?? "";

        return result;
    }
}

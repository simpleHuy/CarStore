using CarStore.Core.Contracts.Services;
using CarStore.Core.Daos;
using CarStore.Core.Data;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;

public class IdToTypeOfCarConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var id = (int)value;
        string result = "";
        Task.Run(async () => result = await GetTypeOfCarNameByIdAsync(id)).Wait();
        return result;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();

    public async Task<string> GetTypeOfCarNameByIdAsync(int id)
    {
        var dbContextFactory = new ApplicationDbContextFactory();
        using var context = dbContextFactory.CreateDbContext(null);

        IDao<TypeOfCar> dao = new EfCoreDao<TypeOfCar>(context);

        var typeOfCars = await dao.GetAllAsync();

        var result = typeOfCars.FirstOrDefault(m => m.Id == id)?.Name ?? "";

        return result;
    }
}

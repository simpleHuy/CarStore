using CarStore.Core.Contracts.Services;
using CarStore.Core.Daos;
using CarStore.Core.Data;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;

public class IdToManufaturerConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var id = (int)value;
        var result = "";
        Task.Run(async () => result = await GetManufacturerNameByIdAsync(id)).Wait();
        return result;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();

    public async Task<string> GetManufacturerNameByIdAsync(int id)
    {
        var dbContextFactory = new ApplicationDbContextFactory();
        using var context = dbContextFactory.CreateDbContext(null);

        IDao<Manufacturer> dao = new EfCoreDao<Manufacturer>(context);

        var manufacturers = await dao.GetAllAsync();

        var result = manufacturers.FirstOrDefault(m => m.Id == id)?.Name ?? "";

        return result;
    }
}

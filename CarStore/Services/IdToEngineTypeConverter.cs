using CarStore.Core.Contracts.Services;
using CarStore.Core.Daos;
using CarStore.Core.Data;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using Microsoft.UI.Xaml.Data;

namespace CarStore.Services;

public class IdToEngineTypeConverter : IValueConverter
{

    private readonly IDao<EngineType> _dao;

    public IdToEngineTypeConverter()
    {
        _dao = App.GetService<IDao<EngineType>>();
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var id = (int)value;
        var result = "";
        Task.Run(async () => result = await GetEngineTypeNameByIdAsync(id)).Wait();

        return result;

    }
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();

    public async Task<string> GetEngineTypeNameByIdAsync(int id)
    {

        var engineTypes = await _dao.GetAllAsync();

        var result = engineTypes.FirstOrDefault(m => m.Id == id)?.Name ?? "";

        return result;
    }
}

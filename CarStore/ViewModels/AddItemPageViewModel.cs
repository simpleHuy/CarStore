using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using Supabase;

namespace CarStore.ViewModels;
public class AddItemPageViewModel: ObservableObject
{
    private readonly IDao<Manufacturer> _manufacture;
    private readonly IDao<EngineType> _engineType;
    private readonly IDao<TypeOfCar> _typeOfCar;
    private readonly IDao<Variant> _variant;
    private readonly IDao<Car> _car;
    private readonly IDao<CarDetail> _carDetail;
    private readonly IAuthenticationService authenticationService;
    private readonly string supabaseUrl = "https://qlhadsqzinowxtappxes.supabase.co";
    private readonly string supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9." +
                                            "eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InFsaGFkc3F6aW5vd3h0YXBweGVzIiwicm9sZSI6InNlcnZ" +
                                            "pY2Vfcm9sZSIsImlhdCI6MTczMzQ3MzUzMSwiZXhwIjoyMDQ5MDQ5NTMxfQ." +
                                            "q9LuucC7SvS2CqL9osIr-4EfS66tum-tPA8IA2BUric";
    private readonly string bucket = "CarStore";
    public Client Supabase
    {
        get; set;
    }

    public List<Variant> Colors
    {
        get; set;
    }
    public ObservableCollection<VariantOfCar> Variants { get; set; } = new ObservableCollection<VariantOfCar>();
    public List<Manufacturer> Manufacturers { get; set; }
    public List<EngineType> EngineTypes {get; set;}
    public List<TypeOfCar> TypeOfCars {get; set;}
    public AddItemPageViewModel(IDao<Manufacturer> manufacture, IDao<EngineType> engineType, IDao<TypeOfCar> typeOfCar, 
            IDao<Variant> variant, IAuthenticationService authenticationService, IDao<Car> car, IDao<CarDetail> carDetail)
    {
        this.authenticationService = authenticationService;
        _manufacture = manufacture;
        _engineType = engineType;
        _typeOfCar = typeOfCar;
        _variant = variant;
        _car = car;
        _carDetail = carDetail;
        Supabase = new Client(supabaseUrl, supabaseKey);
        Task.Run(async () =>
        {
            Manufacturers = await _manufacture.GetAllAsync();
            EngineTypes = await _engineType.GetAllAsync();
            TypeOfCars = await _typeOfCar.GetAllAsync();
            Colors = await _variant.GetAllAsync();
            await Supabase.InitializeAsync();
        }).Wait();
    }

    private string GetImageContentType(string fileName)
    {
        return Path.GetExtension(fileName).ToLowerInvariant() switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".webp" => "image/webp",
            _ => "image/jpeg"  // Default to JPEG if unknown
        };
    }


    public async Task AddItemAsync(string carName, string path, Car car, CarDetail detail)
    {
        if (!Directory.Exists(path))
        {
            throw new Exception("Not exist path");
        }

        var storage = Supabase.Storage;
        var unixTimestamp = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        var firstURL = "";
        foreach (var variant in Variants)
        {
            var subPath = Path.Combine(path, variant.Variant.Code);
            string[] files = Directory.GetFiles(subPath, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var subFolderSupaBase = $"{unixTimestamp}_{carName}/{variant.Variant.Code}/{fileName}";
                byte[] data = await File.ReadAllBytesAsync(file);
                var options = new Supabase.Storage.FileOptions
                {
                    CacheControl = "3600",
                    Upsert = true,
                    ContentType = GetImageContentType(fileName)
                };

                await storage
                    .From(bucket)
                    .Upload(data, subFolderSupaBase, options);
                if(firstURL == "")
                {
                    firstURL = storage.From(bucket).GetPublicUrl(subFolderSupaBase);
                }
            }
        }
        car.OwnerId = authenticationService.GetCurrentUser().Id;
        car.supabaseFolder = $"{unixTimestamp}_{carName}";
        car.DefautlImageLocation = firstURL;
        var carPKey = await _car.Insert(car);
        detail.CarId = (int)carPKey;
        _carDetail.Insert(detail);
    }

}

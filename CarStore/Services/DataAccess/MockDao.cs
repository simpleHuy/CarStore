using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Models;
using Windows.Devices.Radios;
using Windows.Storage;

namespace CarStore.Services.DataAccess;
public class MockDao : IDao
{
    public List<Car> getAllCars()
    {
        var result = new List<Car>()
        {
            new(){
                CarId = 1,
                Name = "Honda Accord",
                Manufacturer = 1,
                EngineType = 1,
                TypeOfCar = 1,
                Price = 100000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Trắng ngọc trai", Code = "White" }, new() { Name = "Xám khói", Code = "Grey" }, new() { Name="Đen huyền bí", Code="Black"} },
                Images = "Honda Accord",
                DefautlImageLocation = "../Assets/Cars/Honda Accord/White/1.png"
            },
            new(){
                CarId = 2,
                Name = "Honda Civic City Rs",
                Manufacturer = 1,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đen huyền bí", Code = "Black" }, new() { Name = "Đỏ hoàng hôn", Code = "Red" }, new() { Name="Trắng tuyết", Code="White"} },
                Images = "Honda Civic City Rs",
                DefautlImageLocation = "../Assets/Cars/Honda Civic City Rs/Black/1.png"
            },
            new(){
                CarId= 3,
                Name = "Honda Type R",
                Manufacturer = 1,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đen huyền bí", Code = "Black" }, new() { Name = "Đỏ hoàng hôn", Code = "Red" }, new() { Name="Trắng tuyết", Code="White"}, new() { Name="Xanh thẳm", Code="Blue"} },
                Images = "Honda Type R",
                DefautlImageLocation = "../Assets/Cars/Honda Type R/Black/2.png"
            },
            new(){
                CarId= 4,
                Name = "Porche 992 Carrera Cabriolet",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> {new() { Name = "Đỏ hoàng hôn", Code = "Red" },},
                Images = "Porche 992 Carrera Cabriolet",
                DefautlImageLocation = "../Assets/Cars/Porche 992 Carrera Cabriolet/Red/1.jpg"
            },
            new(){
                CarId= 5,
                Name = "Porche 718 Cayman S",
                Manufacturer = 2,
                EngineType = 3,
                TypeOfCar = 3,
                Price = 300000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đại dương xanh", Code = "Blue" }, },
                Images = "Porche 718 Cayman S",
                DefautlImageLocation = "../Assets/Cars/Porche 718 Cayman S/Blue/1.jpg"
            },
            new(){
                CarId= 6,
                Name = "Porche 992 Carrera GTS",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> {new() { Name = "Đỏ hoàng hôn", Code = "Red" },},
                Images = "Porche 992 Carrera GTS",
                DefautlImageLocation = "../Assets/Cars/Porche 992 Carrera GTS/Red/1.jpg"
            },
            new(){
                CarId= 7,
                Name = "Porche 992 Carrera T",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> {new() { Name = "Xanh đọt chuối", Code = "Green" },},
                Images = "Porche 992 Carrera T",
                DefautlImageLocation = "../Assets/Cars/Porche 992 Carrera T/Green/1.jpg"
            },
            new(){
                CarId= 8,
                Name = "Porche Taycan J1II",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> {new() { Name = "Xanh hy vọng", Code = "Blue" },},
                Images = "Porche Taycan J1II",
                DefautlImageLocation = "../Assets/Cars/Porche Taycan J1II/Blue/1.jpg"
            },
        };

        return result;
    }
    public List<Manufacturer> getAllManufacturers()
    {
        var result = new List<Manufacturer>()
        {
            new()
            {
                Id = 1,
                Name = "Honda",
            },

            new()
            {
                Id = 2,
                Name = "Porche",
            },

            new()
            {
                Id = 3,
                Name = "Mitsubishi",
            },
            new()
            {
                Id = 4,
                Name = "Vinfast",
            },

        };

        return result;
    }

    public List<EngineType> GetEngineTypes()
    {
        var result = new List<EngineType>()
        {
            new()
            {
                Id = 1,
                Name = "Xăng",
            },
            new()
            {
                Id = 2,
                Name = "Điện",
            },
            new()
            {
                Id = 3,
                Name = "Diesel",
            },
            new()
            {
                Id = 4,
                Name = "Hybrid",
            },
        };

        return result;
    }

    public List<TypeOfCar> GetTypeOfCar()
    {
        var list = new List<TypeOfCar>()
        {
            new()
            {
                Id= 1,
                Name = "Sedan",
            },
            new()
            {
                Id= 2,
                Name = "HatchBack",
            },
            new()
            {
                Id= 3,
                Name = "SUV",
            },
            new()
            {
                Id= 4,
                Name = "CUV",
            },
            new()
            {
                Id= 5,
                Name = "Minivan",
            },
            new()
            {
                Id= 6,
                Name = "Coupe",
            },
            new()
            {
                Id= 7,
                Name = "Canbriolet",
            },
            new()
            {
                Id= 8,
                Name = "Cabriolet",
            },
        };

        return list;
    }
    public List<Car> getPopularCars()
    {
        return getAllCars().Take(10).ToList();
    }
    public List<Car> getSuggestCars()
    {
        return getAllCars().Take(10).ToList();
    }

    public User GetUser()
    {
        return new User()
        {
            Id = "1",
            Email = "minhtruc1234@gmail.com",
            Telephone = "0333601234",
            AccountType = "Hội viên tiềm năng",
            firstName = "Minh Trực",
            lastName = "Nguyễn",
        };
    }

}

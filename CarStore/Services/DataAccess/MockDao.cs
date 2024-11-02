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
                Name = "Car1",
                Manufacturer = 1,
                EngineType = 1,
                TypeOfCar = 1,
                Price = 100000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Trắng ngọc trai", Code = "White" }, new() { Name = "Xanh đại dương", Code = "Blue" } },
                Images = "Car1",
                DefautlImageLocation = "../Assets/Cars/Car1/White/1.jpg"
            },
            new(){
                Name = "Car2",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đen huyền bí", Code = "Black" }, new() { Name = "Cam lè", Code = "Orange" } },
                Images = "Car2",
                DefautlImageLocation = "../Assets/Cars/Car2/Black/1.jpg"
            },
            new(){
                Name = "Car3",
                Manufacturer = 3,
                EngineType = 3,
                TypeOfCar = 3,
                Price = 300000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đỏ lửa", Code = "Red" }, new() { Name = "Xanh lá", Code = "Green" } },
                Images = "Car3",
                DefautlImageLocation = "../Assets/Cars/Car3/Orange/1.jpg"
            },
            new(){
                Name = "Car4",
                Manufacturer = 2,
                EngineType = 4,
                TypeOfCar = 4,
                Price = 400000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Vàng nắng", Code = "Yellow" }, new() { Name = "Tím than", Code = "Purple" } },
                Images = "Car4",
                DefautlImageLocation = "../Assets/Cars/Car4/Blue/1.jpg"
            },
            new(){
                Name = "Car1",
                Manufacturer = 1,
                EngineType = 1,
                TypeOfCar = 1,
                Price = 100000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Trắng ngọc trai", Code = "White" }, new() { Name = "Xanh đại dương", Code = "Blue" } },
                Images = "Car1",
                DefautlImageLocation = "../Assets/Cars/Car1/White/1.jpg"
            },
            new(){
                Name = "Car2",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đen huyền bí", Code = "Black" }, new() { Name = "Cam lè", Code = "Orange" } },
                Images = "Car2",
                DefautlImageLocation = "../Assets/Cars/Car2/Black/1.jpg"
            },
            new(){
                Name = "Car3",
                Manufacturer = 3,
                EngineType = 3,
                TypeOfCar = 3,
                Price = 300000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đỏ lửa", Code = "Red" }, new() { Name = "Xanh lá", Code = "Green" } },
                Images = "Car3",
                DefautlImageLocation = "../Assets/Cars/Car3/Orange/1.jpg"
            },
            new(){
                Name = "Car4",
                Manufacturer = 2,
                EngineType = 4,
                TypeOfCar = 4,
                Price = 400000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Vàng nắng", Code = "Yellow" }, new() { Name = "Tím than", Code = "Purple" } },
                Images = "Car4",
                DefautlImageLocation = "../Assets/Cars/Car4/Blue/1.jpg"
            },
             new(){
                Name = "Car1",
                Manufacturer = 1,
                EngineType = 1,
                TypeOfCar = 1,
                Price = 100000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Trắng ngọc trai", Code = "White" }, new() { Name = "Xanh đại dương", Code = "Blue" } },
                Images = "Car1",
                DefautlImageLocation = "../Assets/Cars/Car1/White/1.jpg"
            },
            new(){
                Name = "Car2",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đen huyền bí", Code = "Black" }, new() { Name = "Cam lè", Code = "Orange" } },
                Images = "Car2",
                DefautlImageLocation = "../Assets/Cars/Car2/Black/1.jpg"
            },
            new(){
                Name = "Car3",
                Manufacturer = 3,
                EngineType = 3,
                TypeOfCar = 3,
                Price = 300000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đỏ lửa", Code = "Red" }, new() { Name = "Xanh lá", Code = "Green" } },
                Images = "Car3",
                DefautlImageLocation = "../Assets/Cars/Car3/Orange/1.jpg"
            },
            new(){
                Name = "Car4",
                Manufacturer = 2,
                EngineType = 4,
                TypeOfCar = 4,
                Price = 400000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Vàng nắng", Code = "Yellow" }, new() { Name = "Tím than", Code = "Purple" } },
                Images = "Car4",
                DefautlImageLocation = "../Assets/Cars/Car4/Blue/1.jpg"
            },
            new(){
                Name = "Car1",
                Manufacturer = 1,
                EngineType = 1,
                TypeOfCar = 1,
                Price = 100000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Trắng ngọc trai", Code = "White" }, new() { Name = "Xanh đại dương", Code = "Blue" } },
                Images = "Car1",
                DefautlImageLocation = "../Assets/Cars/Car1/White/1.jpg"
            },
            new(){
                Name = "Car2",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đen huyền bí", Code = "Black" }, new() { Name = "Cam lè", Code = "Orange" } },
                Images = "Car2",
                DefautlImageLocation = "../Assets/Cars/Car2/Black/1.jpg"
            },
            new(){
                Name = "Car3",
                Manufacturer = 3,
                EngineType = 3,
                TypeOfCar = 3,
                Price = 300000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đỏ lửa", Code = "Red" }, new() { Name = "Xanh lá", Code = "Green" } },
                Images = "Car3",
                DefautlImageLocation = "../Assets/Cars/Car3/Orange/1.jpg"
            },
            new(){
                Name = "Car4",
                Manufacturer = 2,
                EngineType = 4,
                TypeOfCar = 4,
                Price = 400000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Vàng nắng", Code = "Yellow" }, new() { Name = "Tím than", Code = "Purple" } },
                Images = "Car4",
                DefautlImageLocation = "../Assets/Cars/Car4/Blue/1.jpg"
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
                Name = "Vinfast",
            },

            new()
            {
                Id = 2,
                Name = "Kia",
            },

            new()
            {
                Id = 3,
                Name = "Mitsubishi",
            },
            new()
            {
                Id = 4,
                Name = "Porsche",
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
}

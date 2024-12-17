using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models;

namespace CarStore.Core.Contracts.Repository;
public interface ICarRepository
{
    Task<CarDetail> GetDetailById(int id);
    Task<List<Car>> GetCarByManufacturer(int ManufacturerId);
    Task<List<Car>> GetCarByEngineType(int EngineTypeId);
    Task<List<Car>> GetCarByTypeOfCar(int TypeOfCarId);
    Task<List<Car>> GetCarByPrice(int minPrice, int maxPrice);
    Task<List<Car>> GetCarByKey(string key);
    Task<List<VariantOfCar>> GetVariantsOfCar(int carId);
    Task<string> GetVariantsCodeByName(string Name);
    Task<Showroom> GetShowroomByCarId(int carId);
}

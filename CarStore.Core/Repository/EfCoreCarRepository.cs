using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Daos;
using CarStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Core.Repository;
public class EfCoreCarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;
    public IDao<Car> CarDao { get; }


    public async Task<List<Car>> GetCarByEngineType(int EngineTypeId)
    {
        return await _context.Cars.Where(c => c.EngineTypeId == EngineTypeId).ToListAsync();
    }

    public async Task<List<Car>> GetCarByKey(string key)
    {
        return await _context.Cars.Where(c =>   c.Name.Contains(key) || 
                                                c.Description.Contains(key) || 
                                                c.TypeOfCar.Name.Contains(key) ||
                                                c.EngineType.Name.Contains(key) ||
                                                c.Manufacturer.Name.Contains(key))
                                  .ToListAsync();
    }

    public async Task<List<Car>> GetCarByManufacturer(int ManufacturerId)
    {
        return await _context.Cars.Where(c => c.ManufacturerId == ManufacturerId).ToListAsync();
    }

    public async Task<List<Car>> GetCarByPrice(int minPrice, int maxPrice)
    {
        return await _context.Cars.Where(c => c.Price >= minPrice && c.Price <= maxPrice).ToListAsync();
    }

    public async Task<List<Car>> GetCarByTypeOfCar(int TypeOfCarId)
    {
        return await _context.Cars.Where(c => c.TypeOfCarId == TypeOfCarId).ToListAsync();
    }

    public async Task<CarDetail> GetDetailById(int id)
    {
        return await _context.Details.FindAsync(id);
    }
}

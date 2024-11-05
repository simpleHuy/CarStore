using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Models;

namespace CarStore.Services.DataAccess;
public interface IDao
{
    List<Car> getAllCars();
    List<Car> getPopularCars();
    List<Car> getSuggestCars();
    List<TypeOfCar> GetTypeOfCar();
    User GetUser();
}

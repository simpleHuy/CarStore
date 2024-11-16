using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Helpers;
using CarStore.Models;

namespace CarStore.Services;
public static class CarFilterExtensions
{
    public static FullObservableCollection<Car> ApplyFilters(this FullObservableCollection<Car> cars, ObservableCollection<SelectedFilter> filters)
    {
        if (filters == null || !filters.Any())
            return new FullObservableCollection<Car>(cars);

        var filteredCars = cars.AsQueryable();

        foreach (var filter in filters)
        {
            switch (filter.Type.ToLower())
            {
                case "manufacturer":
                    filteredCars = filteredCars.Where(c => c.Manufacturer == filter.Id);
                    break;

                case "enginetype":
                    filteredCars = filteredCars.Where(c => c.EngineType == filter.Id);
                    break;

                case "numberofseats":
                    filteredCars = filteredCars.Where(c => c.IdSeats == filter.Id);
                    break;

                case "typeofcar":
                    filteredCars = filteredCars.Where(c => c.TypeOfCar == filter.Id);
                    break;
                case "priceofcar":
                    filteredCars = filteredCars.Where(c => c.PriceOfCarId == filter.Id);
                    break;

                    // Add more cases as needed for other filter types
            }
        }

        return new FullObservableCollection<Car>(filteredCars);
    }
}

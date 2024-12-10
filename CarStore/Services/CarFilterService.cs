 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models;
using CarStore.Helpers;
using CarStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.Services;
public class CarFilterService : ObservableObject
{
    private FullObservableCollection<Car> _allCars;
    private ObservableCollection<SelectedFilter> _selectedFilters;
    private FullObservableCollection<Car> _filteredCars;
    private string _searchQuery;
    private bool _isAscendingSort;

    public CarFilterService()
    {
        _allCars = new FullObservableCollection<Car>();
        _selectedFilters = new ObservableCollection<SelectedFilter>();
        _filteredCars = new FullObservableCollection<Car>();

        // Subscribe to collection changes
        _selectedFilters.CollectionChanged += OnFiltersChanged;
    }
    
    public string SearchQuery
    {

        get => _searchQuery;
        set
        {
            _searchQuery = value;
            OnPropertyChanged(nameof(SearchQuery));
            ApplyFilters();
        }
    }
    public void ApplySearch(string query)
    {
        SearchQuery = query;
    }
    public FullObservableCollection<Car> AllCars
    {
        get => _allCars;
        set
        {
            _allCars = value;
            OnPropertyChanged(nameof(AllCars));
            ApplyFilters();
        }
    }

    public ObservableCollection<SelectedFilter> SelectedFilters
    {
        get => _selectedFilters;
        set
        {
            if (_selectedFilters != null)
            {
                _selectedFilters.CollectionChanged -= OnFiltersChanged;
            }

            _selectedFilters = value;

            if (_selectedFilters != null)
            {
                _selectedFilters.CollectionChanged += OnFiltersChanged;
            }

            OnPropertyChanged(nameof(SelectedFilters));
            ApplyFilters();
        }
    }

    public FullObservableCollection<Car> FilteredCars
    {
        
        get => _filteredCars;
        private set
        {
            _filteredCars = value;
            OnPropertyChanged(nameof(FilteredCars));
        }
    }

    private void OnFiltersChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        ApplyFilters();
    }

    private void ApplyFilters()
    {
        if (_allCars == null || !_allCars.Any())
        {
            FilteredCars = new FullObservableCollection<Car>();
            return;
        }

        // Convert to List first to materialize the query
        var query = _allCars.ToList().AsQueryable();

        // Apply search if there's a search query
        if (!string.IsNullOrWhiteSpace(_searchQuery))
        {
            var searchQueryLower = _searchQuery.ToLower();
            query = query.Where(car =>
                (car.Name != null && car.Name.ToLower().Contains(searchQueryLower)) ||
                (car.Manufacturer != null && car.Manufacturer.Name != null && car.Manufacturer.Name.ToLower().Contains(searchQueryLower)) ||
                (car.TypeOfCar != null && car.TypeOfCar.Name != null && car.TypeOfCar.Name.ToLower().Contains(searchQueryLower))
            );
        }

        // Apply filters if they exist
        if (_selectedFilters != null && _selectedFilters.Any())
        {
            var manufacturerIds = _selectedFilters
                .Where(f => f.Type.ToLower() == "manufacturer")
                .Select(f => f.Id)
                .ToList();

            var engineTypeIds = _selectedFilters
                .Where(f => f.Type.ToLower() == "enginetype")
                .Select(f => f.Id)
                .ToList();

            var typeOfCarIds = _selectedFilters
                .Where(f => f.Type.ToLower() == "typeofcar")
                .Select(f => f.Id)
                .ToList();

            var priceOfCarIds = _selectedFilters
                .Where(f => f.Type.ToLower() == "priceofcar")
                .Select(f => f.Id)
                .ToList();

            if (manufacturerIds.Any())
                query = query.Where(c => manufacturerIds.Contains(c.ManufacturerId));

            if (engineTypeIds.Any())
                query = query.Where(c => engineTypeIds.Contains(c.EngineTypeId));

            if (typeOfCarIds.Any())
                query = query.Where(c => typeOfCarIds.Contains(c.TypeOfCarId));

            if (priceOfCarIds.Any())
                query = query.Where(c => priceOfCarIds.Contains(c.PriceOfCarId));
        }

        // Apply sorting
        var sortedList = _isAscendingSort
            ? query.OrderBy(c => c.PriceOfCarId).ToList()
            : query.OrderByDescending(c => c.PriceOfCarId).ToList();

        FilteredCars = new FullObservableCollection<Car>(sortedList);
    }
}
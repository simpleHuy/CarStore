using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Helpers;
using CarStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.Services;
public class CarFilterService : ObservableObject
{
    private FullObservableCollection<Car> _allCars;
    private ObservableCollection<SelectedFilter> _selectedFilters;
    private FullObservableCollection<Car> _filteredCars;

    public CarFilterService()
    {
        _allCars = new FullObservableCollection<Car>();
        _selectedFilters = new ObservableCollection<SelectedFilter>();
        _filteredCars = new FullObservableCollection<Car>();

        // Subscribe to collection changes
        _selectedFilters.CollectionChanged += OnFiltersChanged;
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
        FilteredCars = AllCars.ApplyFilters(SelectedFilters);
    }
}
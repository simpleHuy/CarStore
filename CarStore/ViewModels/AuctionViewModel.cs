using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CarStore.Models;
using CarStore.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;

namespace CarStore.ViewModels;
public partial class AuctionViewModel: ObservableObject
{
    private readonly IDao<Auction> _sampleDataService;
    public ObservableCollection<Auction> Source { get; } = new ObservableCollection<Auction>();
    public async void LoadData()
    {
        Source.Clear();

        var data = await _sampleDataService.GetAllAsync();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }
    public AuctionViewModel(IDao<Auction> sampleDataService)
    {
        _sampleDataService = sampleDataService;
        LoadData();
    }
    
    public void OnNavigatedFrom()
    {
    }
}

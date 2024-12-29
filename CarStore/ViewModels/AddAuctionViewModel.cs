using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CarStore.Core.Models;
using CarStore.Core.Contracts.Services;
using Windows.Devices.AllJoyn;

namespace CarStore.ViewModels;
public class AddAuctionViewModel: ObservableObject
{
    private readonly IDao<Car> _car;
    private readonly IDao<Auction> _auction;
    private string _selectedCarName;
    private Car _selectedCar;

    public List<Car>? Cars
    {
        get; set;
    }   
    public List<Car>? CarOfAuction
    {
        get; set;
    }

    public string SelectedCarName
    {
        get => _selectedCarName;
        set => SetProperty(ref _selectedCarName, value);
    }

    public Car SelectedCar
    {
        get => _selectedCar;
        set => SetProperty(ref _selectedCar, value);
    }
    public AddAuctionViewModel(IDao<Car> car, IDao<Auction> auction)
    {
        _car = car;
        _auction = auction;
        Initialize();
    }

    private async void Initialize()
    {
        Cars = await _car.GetAllAsync();
        CarOfAuction = Cars.Where(x => x.AuctionId == 0).ToList();
        SelectedCarName = "Chọn xe*";
    }

    public async Task AddAuction(Auction newAuction)
    {
        await _auction.InsertById(newAuction);
        SelectedCar.AuctionId = newAuction.AuctionId;
        await _car.UpdateById(SelectedCar);
    }
}

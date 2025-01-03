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
using System.Diagnostics;

namespace CarStore.ViewModels;
public partial class AuctionViewModel : ObservableObject
{
    private readonly IDao<Auction> _sampleDataService;
    private readonly IDao<Car> _car;
    private readonly IBiddingRepository _bidding;
    private readonly IDao<User> _user;
    public ObservableCollection<Auction> Source { get; } = new ObservableCollection<Auction>();

    public async void LoadData()
    {
        Source.Clear();
        var data = await _sampleDataService.GetAllAsync();
        if (data == null)
        {
            return;
        }
        foreach (var item in data)
        {
            item.condition = GetAuctionCondition(item.StartDate, item.EndDate);
            Source.Add(item);
        }
    }

    private IAuthenticationService AuthenticationService
    {
        get; set;
    }
    public bool IsLoggedIn => AuthenticationService.GetCurrentUser() != null;

    public AuctionViewModel(IDao<Auction> sampleDataService, IDao<Car> car, IDao<User> user , IBiddingRepository biddingRepository ,IAuthenticationService authenticationService)
    {
        _sampleDataService = sampleDataService;
        _car = car;
        _user = user;
        _bidding = biddingRepository;
        AuthenticationService = authenticationService;
        LoadData();
    }

    public string GetAuctionCondition(DateTime startTime, int minutes)
    {
        DateTime currentTime = DateTime.Now;
        Debug.WriteLine("Current time: " + currentTime);
        DateTime endTime = startTime.AddMinutes(minutes);

        if (currentTime < startTime)
        {
            return "Sắp diễn ra";
        }
        else if (currentTime >= startTime && currentTime <= endTime)
        {
            return "Đang diễn ra";
        }
        else
        {
            return "Kết thúc";
        }
    }

    public bool IsTimeInRange(DateTime startTime, int minutes)
    {
        DateTime currentTime = DateTime.UtcNow.ToUniversalTime();
        DateTime endTime = startTime.AddMinutes(minutes);
        return currentTime >= startTime && currentTime <= endTime;
    }

    public async Task DeleteAuction(Auction auction)
    {
        var car = await _car.GetByIdAsync(auction.CarId);
        car.AuctionId = 0;
        await _sampleDataService.DeleteById(auction.AuctionId);
        LoadData();
    }

    public async Task<User?> GetInfor(Auction auction)
    {
        if (auction.condition != "Kết thúc")
        {
            return null;
        }
        var allBid = await _bidding.GetBidsByAuctionIdAsync(auction.AuctionId);

        var winBid = allBid.OrderByDescending(x => x.BidAmount).FirstOrDefault();
        if (winBid == null)
        {
            return null;
        }
        var winner = await _user.GetByIdAsync(winBid.UserId);
        return winner;
    }
}

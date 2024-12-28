using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using CarStore.Core.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CarStore.Core.Dtos;
using CommunityToolkit.Mvvm.Input;
using SocketIOClient;
using System.Net.Http;
using Microsoft.UI.Dispatching;
using System.Diagnostics;

namespace CarStore.ViewModels;
public class DetailAuctionViewModel : ObservableObject, INotifyPropertyChanged, IDisposable
{
    private readonly SocketIOClient.SocketIO _socket;
    private readonly Timer timer;
    private readonly DispatcherQueue _dispatcherQueue;

    private Auction auction;
    public Auction Auction
    {
        get => auction;
        set
        {
            if (auction != value)
            {
                auction = value;
                Task.Run(async () =>
                {
                    await LoadInitialDataAsync();
                    if (_socket.Connected)
                    {
                        await LeaveCurrentAuction();
                        await JoinNewAuction();
                    }
                }).Wait();
            }
        }
    }

    private Car? _selectedCar;
    public Car? SelectedCar
    {
        get => _selectedCar;
        set
        {
            _selectedCar = value;
            OnPropertyChanged(nameof(SelectedCar));
            LoadPictureOfCar();
        }
    }

    private ObservableCollection<string> _selectedCarPictures;
    public ObservableCollection<string>? SelectedCarPictures
    {
        get => _selectedCarPictures;
        set
        {
            _selectedCarPictures = value;
            OnPropertyChanged(nameof(SelectedCarPictures));
        }
    }

    private string _selectedCarColor;
    public string SelectedCarColor
    {
        get => _selectedCarColor;

        set
        {
            _selectedCarColor = value;
            OnPropertyChanged(nameof(_selectedCarColor));
            LoadPictureOfCar();
        }
    }

    private void LoadPictureOfCar()
    {
        if (SelectedCar == null) return;

        var path = AppDomain.CurrentDomain.BaseDirectory;
        path += "Assets\\Cars\\" + SelectedCar.Images;

        if (SelectedCarColor == null)
        {
            List<VariantOfCar> variantOfCars = new List<VariantOfCar>();
            string variantsCode = "";
            Task.Run(async () => variantOfCars = await _carRepository.GetVariantsOfCar(SelectedCar.CarId)).Wait();
            Task.Run(async () => variantsCode = await _carRepository.GetVariantsCodeByName(variantOfCars[0].Name)).Wait();
            SelectedCar.VariantOfCars = variantOfCars;
            path += "\\" + variantsCode;
        }
        else
        {
            string variantsCode = "";
            Task.Run(async () => variantsCode = await _carRepository.GetVariantsCodeByName(SelectedCarColor)).Wait();
            path += "\\" + variantsCode;
        }

        if (Directory.Exists(path))
        {
            // Get all jpg files in the directory
            var imageFiles = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                                      .Where(file => Regex.IsMatch(file, @"\.(jpg|jpeg|png|gif|bmp|tiff)$", RegexOptions.IgnoreCase))
                                      .ToArray();

            // Convert file paths to proper URI format for WinUI
            var imageUris = imageFiles.Select((file, index) =>
                new Uri($"ms-appx:///../{file.Substring(file.IndexOf("Assets"))}").ToString());


            SelectedCarPictures = new ObservableCollection<string>(imageUris);
        }
        else
        {
            SelectedCarPictures = new ObservableCollection<string>();
        }
    }
    private readonly ICarRepository _carRepository;
    private readonly IBiddingRepository _biddingRepository;
    

    private int _selectedImageIndex;
    public int SelectedImageIndex
    {
        get => _selectedImageIndex;
        set
        {
            _selectedImageIndex = value;
            OnPropertyChanged(nameof(SelectedImageIndex));
        }
    }

    private async Task LeaveCurrentAuction()
    {
        if (auction != null)
        {
            await _socket.EmitAsync("leaveAuction", auction.AuctionId);
        }
    }

    private async Task JoinNewAuction()
    {
        if (auction != null)
        {
            await _socket.EmitAsync("joinAuction", auction.AuctionId);
        }
    }

    public ObservableCollection<Bidding>? BidHistory { get; set; }
    
    private long price;
    public long Price
    {
        get => price;
        set
        {
            price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    private string _bidAmountText;
    public string BidAmountText
    {
        get => _bidAmountText;
        set
        {
            _bidAmountText = value;
            OnPropertyChanged(nameof(BidAmountText));

            if (long.TryParse(_bidAmountText, out var parsedValue))
            {
                BidAmount = parsedValue;
                ErrorMessage = string.Empty;
            }
            else
            {
                BidAmount = 0; // Or handle invalid input appropriately
                ErrorMessage = "Invalid input. Please enter a numeric value.";
            }
        }
    }

    private long _bidAmount;
    public long BidAmount
    {
        get => _bidAmount;
        private set
        {
            _bidAmount = value;
            OnPropertyChanged(nameof(BidAmount));
            OnPropertyChanged(nameof(CanPlaceBid));
            ((RelayCommand)PlaceBidCommand).NotifyCanExecuteChanged();
        }
    }

    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }


    public bool CanPlaceBid => BidAmount > 0;

    public ICommand PlaceBidCommand{get;}

    private readonly IDao<Bidding> _bidding;
    private readonly IDao<User> _user;
    private readonly IDao<Auction> _auction;
    private async Task LoadInitialDataAsync()
    {
        var allBid = await _biddingRepository.GetBidsByAuctionIdAsync(auction.AuctionId);
        for (int i = 0; i < allBid.Count; i++)
        {
            var user = await _user.GetByIdAsync(allBid[i].UserId);
            allBid[i].User = user;

        }
        BidHistory = new ObservableCollection<Bidding>(allBid);
        OnPropertyChanged(nameof(BidHistory));
    }
    public DetailAuctionViewModel(ICarRepository carRepository, IBiddingRepository biddingRepository,
        IDao<Bidding> bidding, IDao<User> user, IDao<Auction> auctionRepository)
    {
        _carRepository = carRepository;
        _biddingRepository = biddingRepository;
        _bidding = bidding;
        _auction = auctionRepository;
        _user = user;

        BidAmount = 0;
        PlaceBidCommand = new RelayCommand(PlaceBid, () => CanPlaceBid);

        _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

        _socket = new SocketIOClient.SocketIO("http://localhost:3000");

        SetupSocketEvents();
        ConnectSocket();
    }

    private async void ConnectSocket()
    {
        try
        {
            await _socket.ConnectAsync();
            if (Auction != null)
            {
                await JoinNewAuction();
            }
        }
        catch (Exception ex)
        {
            _dispatcherQueue.TryEnqueue(() =>
            {
                ErrorMessage = $"Socket connection error: {ex.Message}";
            });
        }
    }

    private void SetupSocketEvents()
    {
        _socket.OnConnected += async (sender, e) =>
        {
            _dispatcherQueue.TryEnqueue(() =>
            {
                ErrorMessage = string.Empty;
            });

            if (Auction != null)
            {
                await JoinNewAuction();
            }
        };

        _socket.OnDisconnected += (sender, e) =>
        {
            _dispatcherQueue.TryEnqueue(() =>
            {
                ErrorMessage = "Disconnected from server. Attempting to reconnect...";
            });
        };

        _socket.On("bidPlaced", response =>
        {
            try
            {
                var bid = response.GetValue<Bidding>();
                _dispatcherQueue.TryEnqueue(async () =>
                {
                    // Get user details for the new bid
                    var user = await _user.GetByIdAsync(bid.UserId);
                    bid.User = user;

                    BidHistory?.Add(bid);
                    OnPropertyChanged(nameof(BidHistory));
                });
            }
            catch (Exception ex)
            {
                _dispatcherQueue.TryEnqueue(() =>
                {
                    ErrorMessage = $"Error processing bid: {ex.Message}";
                });
            }
        });
    }

    private async void PlaceBid()
    {
        if (Auction == null) return;
        try
        {
            var newBid = new Bidding
            {
                AuctionId = Auction.AuctionId,
                UserId = 1, // Replace with actual UserId
                BidAmount = BidAmount,
                Time = DateTime.UtcNow
            };

            // Save to database first
            await _bidding.InsertById(newBid);

            // Then emit to socket server
            if (_socket.Connected)
            {
                // Create a simplified anonymous object for serialization
                var bidData = new
                {
                    auctionId = Auction.AuctionId,
                    bid = new
                    {
                        auctionId = newBid.AuctionId,
                        userId = newBid.UserId,
                        bidAmount = newBid.BidAmount,
                        time = newBid.Time
                    }
                };

                // Emit the data directly without manual serialization
                await _socket.EmitAsync("placeBid", bidData);

                BidAmountText = string.Empty;
                BidAmount = 0;
            }
            else
            {
                _dispatcherQueue.TryEnqueue(() =>
                {
                    ErrorMessage = "Socket is not connected. Please wait for reconnection.";
                });
            }
        }
        catch (Exception ex)
        {
            _dispatcherQueue.TryEnqueue(() =>
            {
                ErrorMessage = $"Failed to place bid: {ex.Message}";
            });
        }
    }


    public void Dispose()
    {
        Task.Run(async () =>
        {
            await LeaveCurrentAuction();
            await _socket.DisconnectAsync();
            _socket.Dispose();
        }).Wait();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

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
using CommunityToolkit.WinUI;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace CarStore.ViewModels;
public class DetailAuctionViewModel : ObservableObject, INotifyPropertyChanged, IDisposable
{
    private readonly SocketIOClient.SocketIO _socket;
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

    private long _bidAmount;
    public long BidAmount
    {
        get => _bidAmount;
        set
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
    public bool CanPlaceBid => BidAmount > price && BidAmount > Auction.Price  && IsAuctionEnded == false;
    public ICommand PlaceBidCommand
    {
        get;
    }
    
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

    private int _timeLimit = 1;  
    public int TimeLimit
    {
        get => _timeLimit;
        set
        {
            _timeLimit = value;

            OnPropertyChanged(nameof(TimeLimit));
        }
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
        PlaceBidCommand = new RelayCommand(PlaceBid);

        _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

        _socket = new SocketIOClient.SocketIO("http://localhost:3000");

        SetupSocketEvents();
        ConnectSocket(); 

    }
    private DispatcherQueueTimer _timer;
    private TimeSpan _timeRemaining;
    public TimeSpan TimeRemaining
    {
        get => _timeRemaining;
        set
        {
            _timeRemaining = value;
            InitializeTimer();
            StartCountdown();
            OnPropertyChanged(nameof(TimeRemaining));
        }
    }

    public event EventHandler AuctionEnded;
    public event EventHandler BidFailed;

    public string TimeRemainingText => _timeRemaining.ToString(@"mm\:ss");

    private void InitializeTimer()
    {
        _timer = DispatcherQueue.GetForCurrentThread().CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += TimerElapsed;
    }

    public void StartCountdown()
    {
        if (_timeRemaining > TimeSpan.Zero)
        {
            _timer.Start();
        }
    }
    private void TimerElapsed(object sender, object e)
    {
        if (_timeRemaining > TimeSpan.Zero)
        {
            _timeRemaining = _timeRemaining.Subtract(TimeSpan.FromSeconds(1));
            OnPropertyChanged(nameof(TimeRemainingText));

            if (_timeRemaining == TimeSpan.Zero)
            {
                _timer.Stop();
                AuctionEnded?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public bool IsAuctionEnded => _timeRemaining == TimeSpan.Zero;
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
        };

        _socket.OnDisconnected += (sender, e) =>
        {
            _dispatcherQueue.TryEnqueue(() =>
            {
                ErrorMessage = "Disconnected from server. Attempting to reconnect...";
            });
        };

        _socket.On("bidPlaced", async response =>
        {
            try
            {
                Debug.WriteLine("Received bidPlaced event");
                var data = response.GetValue<JsonElement>();
                var bidData = data.GetProperty("bid");

                // Parse time using ISO 8601 format
                var timeStr = bidData.GetProperty("time").GetString();
                var time = DateTime.Parse(timeStr).ToLocalTime();

                var newBid = new Bidding
                {
                    AuctionId = bidData.GetProperty("auctionId").GetInt32(),
                    UserId = bidData.GetProperty("userId").GetInt32(),
                    BidAmount = bidData.GetProperty("bidAmount").GetInt64(),
                    Time = time.ToUniversalTime().AddHours(7)
                };

                Price = newBid.BidAmount;

                Debug.WriteLine($"Parsed bid data: AuctionId={newBid.AuctionId}, UserId={newBid.UserId}, Amount={newBid.BidAmount}, Time={newBid.Time}");

                await _dispatcherQueue.EnqueueAsync(async () =>
                {
                    try
                    {
                        if (newBid.UserId != 1) 
                        {
                            await _bidding.InsertById(newBid);

                            var user = await _user.GetByIdAsync(newBid.UserId);
                            newBid.User = user;

                            BidHistory ??= new ObservableCollection<Bidding>();

                            _dispatcherQueue.TryEnqueue(() =>
                            {
                                BidHistory.Add(newBid);
                                OnPropertyChanged(nameof(BidHistory));
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing bid: {ex}");
                        ErrorMessage = $"Error processing bid: {ex.Message}";
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error handling bid data: {ex}");
                _dispatcherQueue.TryEnqueue(() =>
                {
                    ErrorMessage = $"Error handling bid data: {ex.Message}";
                });
            }
        });
    }
    private async void PlaceBid()
    {
        if (Auction == null) return;

        if (!CanPlaceBid)
        {
            BidFailed?.Invoke(this, EventArgs.Empty);
            return;
        }

        try
        {
            var currentTime = DateTime.UtcNow;
            Price = BidAmount;

            var newBid = new Bidding
            {
                AuctionId = Auction.AuctionId,
                UserId = 1,
                BidAmount = BidAmount,
                Time = currentTime.ToUniversalTime().AddHours(7)
            };

            await _bidding.InsertById(newBid);

            var user = await _user.GetByIdAsync(newBid.UserId);
            newBid.User = user;

            BidHistory ??= new ObservableCollection<Bidding>();
            BidHistory.Add(newBid);
            OnPropertyChanged(nameof(BidHistory));

            if (_socket.Connected)
            {
                var bidData = new
                {
                    auctionId = newBid.AuctionId,
                    userId = newBid.UserId,
                    bidAmount = newBid.BidAmount,
                    time = currentTime.ToUniversalTime()
                };

                await _socket.EmitAsync("placeBid", new { auctionId = Auction.AuctionId, bid = bidData });

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
            Debug.WriteLine($"Error placing bid: {ex}");
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

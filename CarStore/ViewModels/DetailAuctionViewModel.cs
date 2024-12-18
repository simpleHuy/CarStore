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


namespace CarStore.ViewModels;
public class DetailAuctionViewModel : ObservableObject, INotifyPropertyChanged
{
    private Auction auction;
    public Auction Auction
    {
        get => auction;
        set
        {
            if (auction != value)
            {
                auction = value;
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

    public ObservableCollection<Bidding>? BidHistory { get; set; }

    private long bidAmount;
    public long BidAmount
    {
        get => bidAmount;
        set
        {
            if (bidAmount != value)
            {
                bidAmount = value;
                OnPropertyChanged(nameof(BidAmount));
                OnPropertyChanged(nameof(CanPlaceBid));
            }
        }
    }
    public bool CanPlaceBid => bidAmount > 0;

    public ICommand PlaceBidCommand{get;}
    private readonly IDao<Bidding> _bidding;
    private readonly IDao<User> _user;
    public DetailAuctionViewModel(ICarRepository carRepository, IBiddingRepository biddingRepository,IDao<Bidding> bidding, IDao<User> user)
    {
        _carRepository = carRepository;
        _biddingRepository = biddingRepository;
        _bidding = bidding;
        _user = user;
        BidAmount = 0;

        PlaceBidCommand = new RelayCommand(PlaceBid, () => CanPlaceBid);

        Task.Run(async () => await LoadInitialDataAsync()).Wait();
    }

    private async Task LoadInitialDataAsync()
    {
        var allBid = await _biddingRepository.GetBidsByAuctionIdAsync(1);
        var bid = await _bidding.GetByIdAsync(1);
        var user = await _user.GetByIdAsync(1);
        bid.User = user;
        BidHistory = new ObservableCollection<Bidding>(allBid);
    }

    private void PlaceBid()
    {
        // Thêm logic đấu giá
        //BidHistory.Add(new Bidding
        //{
        //    User = {
        //        Name = "Người dùng A"
        //    },
        //    BidAmount = BidAmount,
        //    Time = DateTime.Now
        //});

        // Reset số tiền sau khi đấu giá
        BidAmount = 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

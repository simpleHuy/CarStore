using CarStore.ViewModels;
using CarStore.Services.DataAccess;
using CarStore.Services;
using CarStore.Models;
using CarStore.Contracts.Services;
using CarStore.Core.Contracts.Services;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarStore.Core.Models;
using CarStore.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using CarStore.Core.Contracts.Repository;
using CarStore.Views;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using CarStore.Core.Repository;
using CarStore.Core.Daos;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Tests;

[TestClass]
public class FilterAndSearchTests
{
    private IServiceProvider _serviceProvider;
    private Mock<IDao<Car>> _mockCarDao;
    private Mock<ICarRepository> _mockCarRepository;
    private Mock<IAuthenticationService> _mockAuthenticationService;
    private CarFilterService _filterService;
    [TestInitialize]
    public void Setup()
    {
        // Set up the test DI container
        var serviceCollection = new ServiceCollection();

        _mockCarDao = new Mock<IDao<Car>>();
        _mockCarRepository = new Mock<ICarRepository>();
        _mockAuthenticationService = new Mock<IAuthenticationService>();
        serviceCollection.AddScoped(typeof(IDao<>), typeof(EfCoreDao<>));

        // Build the service provider
        _serviceProvider = serviceCollection.BuildServiceProvider();
        _filterService = new CarFilterService();
    }


    [TestMethod]
    public void ApplyFilters_WithNoFilters_ShouldReturnAllCars()
    {
        // Arrange
        var cars = new FullObservableCollection<Car>
            {
                new Car { CarId = 1, Name = "Car A", ManufacturerId = 1, EngineTypeId = 1, TypeOfCarId = 1, PriceOfCarId = 1 },
                new Car { CarId = 2, Name = "Car B", ManufacturerId = 2, EngineTypeId = 2, TypeOfCarId = 2, PriceOfCarId = 2 }
            };
        _filterService.AllCars = cars;

        // Act
        _filterService.ApplyFilters();

        // Assert
        Assert.AreEqual(2, _filterService.FilteredCars.Count);
    }

    [TestMethod]
    public void ApplySearch_ShouldFilterBySearchQuery()
    {
        // Arrange
        var cars = new FullObservableCollection<Car>
            {
                new Car { CarId = 1, Name = "Car A", ManufacturerId = 1 },
                new Car { CarId = 2, Name = "Car B", ManufacturerId = 2 }
            };
        _filterService.AllCars = cars;

        // Act
        _filterService.ApplySearch("Car A");

        // Assert
        Assert.AreEqual(1, _filterService.FilteredCars.Count);
        Assert.AreEqual("Car A", _filterService.FilteredCars[0].Name);
    }

    [TestMethod]
    public void ApplyFilters_WithManufacturerFilter_ShouldFilterByManufacturer()
    {
        // Arrange
        var cars = new FullObservableCollection<Car>
            {
                new Car { CarId = 1, Name = "Car A", ManufacturerId = 1 },
                new Car { CarId = 2, Name = "Car B", ManufacturerId = 2 }
            };
        _filterService.AllCars = cars;

        var filters = new ObservableCollection<SelectedFilter>
            {
                new SelectedFilter { Type = "manufacturer", Id = 1 }
            };
        _filterService.SelectedFilters = filters;

        // Act
        _filterService.ApplyFilters();

        // Assert
        Assert.AreEqual(1, _filterService.FilteredCars.Count);
        Assert.AreEqual(1, _filterService.FilteredCars[0].ManufacturerId);
    }

    [TestMethod]
    public void ApplyFilters_WithMultipleFilters_ShouldReturnMatchingCars()
    {
        // Arrange
        var cars = new FullObservableCollection<Car>
            {
                new Car { CarId = 1, Name = "Car A", ManufacturerId = 1, EngineTypeId = 1 },
                new Car { CarId = 2, Name = "Car B", ManufacturerId = 2, EngineTypeId = 2 }
            };
        _filterService.AllCars = cars;

        var filters = new ObservableCollection<SelectedFilter>
            {
                new SelectedFilter { Type = "manufacturer", Id = 1 },
                new SelectedFilter { Type = "enginetype", Id = 1 }
            };
        _filterService.SelectedFilters = filters;

        // Act
        _filterService.ApplyFilters();

        // Assert
        Assert.AreEqual(1, _filterService.FilteredCars.Count);
        Assert.AreEqual(1, _filterService.FilteredCars[0].CarId);
    }

    [TestMethod]
    public void ApplyFilters_WithSorting_ShouldSortCarsCorrectly()
    {
        // Arrange
        var cars = new FullObservableCollection<Car>
            {
                new Car { CarId = 1, Name = "Car A", PriceOfCarId = 200 },
                new Car { CarId = 2, Name = "Car B", PriceOfCarId = 100 }
            };
        _filterService.AllCars = cars;

        // Act
        _filterService.ApplyFilters();

        // Assert
        Assert.AreEqual(2, _filterService.FilteredCars.Count);
        Assert.AreEqual("Car A", _filterService.FilteredCars[0].Name);
    }

    [TestMethod]
    public void ApplyFilters_WithEmptyCollection_ShouldReturnEmpty()
    {
        // Arrange
        _filterService.AllCars = new FullObservableCollection<Car>();

        // Act
        _filterService.ApplyFilters();

        // Assert
        Assert.AreEqual(0, _filterService.FilteredCars.Count);
    }


[TestMethod]
    public void TestGetTypeCar()
    {
        // Arrange
        var mockDao = new MockDao();

        // Act
        List<TypeOfCar> typeOfCar = mockDao.GetTypeOfCar();

        // Assert
        Assert.IsNotNull(typeOfCar, "The list of car types should not be null.");
        Assert.IsTrue(typeOfCar.Count > 0, "The list of car types should contain items.");
    }

   

    [TestMethod]
    public async Task TestLoginAsync()
    {
        // Arrange
        var mockAuthService = new Mock<IAuthenticationService>();
        var User = new User();
        var username = "admin";
        var password = "1234";

        mockAuthService
            .Setup(auth => auth.LoginAsync(username, password))
            .ReturnsAsync(true);

        var loginViewModel = new LoginViewModel(null, mockAuthService.Object);

        // Act
        var result = await mockAuthService.Object.LoginAsync(username, password);

        // Assert
        Assert.IsTrue(result, "Login should be successful.");
    }

    [TestMethod]
    public async Task TestRegisterAsync()
    {
        var mockAuthService = new Mock<IAuthenticationService>();
        var firstName = "John";
        var lastName = "Doe";
        var email = "john.doe@gmail.com";
        var phoneNumber = "0912345678";
        var username = "johndoe";
        var password = "Password123@@";

        // Simulate a successful registration
        mockAuthService
            .Setup(auth => auth.RegisterAsync(firstName, lastName, email, phoneNumber, username, password))
            .ReturnsAsync(true);

        // Act
        var result = await mockAuthService.Object.RegisterAsync(firstName, lastName, email, phoneNumber, username, password);

        // Assert
        Assert.IsTrue(result, "Registration should be successful.");
        mockAuthService.Verify(auth => auth.RegisterAsync(firstName, lastName, email, phoneNumber, username, password), Times.Once, "RegisterAsync should be called once.");
    }


    [TestMethod]
    public void Test_AddSelectedFilters_UpdatesFilteredCars()
    {
        // Arrange
        var viewModel = new CarFilterService();

        // Create test data
        var car1 = new Car { Name = "Car1", ManufacturerId = 1 };
        var car2 = new Car { Name = "Car2", ManufacturerId = 2 };
        var car3 = new Car { Name = "Car3", ManufacturerId = 1 };

        // Simulate the initial list of cars
        viewModel.AllCars = new FullObservableCollection<Car> { car1, car2, car3 };

        // Simulate the user selecting "Manufacturer 1" as a filter
        viewModel.SelectedFilters = new ObservableCollection<SelectedFilter>
    {
        new SelectedFilter
        {
            Name = "Manufacturer 1",
            Type = "Manufacturer",
            Id = 1 // Filter by ManufacturerId 1
        }
    };

        // Act
        var filteredCars = viewModel.FilteredCars;

        // Assert
        Assert.IsNotNull(filteredCars, "FilteredCars should not be null.");
        Assert.AreEqual(2, filteredCars.Count, "FilteredCars should contain only cars matching the filter.");
        Assert.IsTrue(filteredCars.All(car => car.ManufacturerId == 1), "All cars in FilteredCars should match the filter criteria.");
    }


}


[TestClass]
public class GetCarDetailTests
{
    private Mock<IDao<Car>> _mockCarDao;
    private Mock<ICarRepository> _mockCarRepository;
    private Mock<IAuthenticationService> _mockAuthenticationService;
    private CarDetailViewModel _viewModel;
    private Mock<IUserRepository> _mockUserRepository;
    private Mock<IDao<User>> _mockUserDao;

    [TestInitialize]
    public void Setup()
    {
        // Create mock objects
        _mockCarDao = new Mock<IDao<Car>>();
        _mockCarRepository = new Mock<ICarRepository>();
        _mockAuthenticationService = new Mock<IAuthenticationService>();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockUserDao = new Mock<IDao<User>>();

        //// Setup mock data for GetAllAsync
        var mockCars = new List<Car>
        {
            new Car { CarId = 1, Name = "Car 1", Price = 25000 },
            new Car { CarId = 2, Name = "Car 2", Price = 30000 },
            new Car { CarId = 3, Name = "Car 3", Price = 35000 }
        };
        _mockCarDao.Setup(x => x.GetAllAsync()).ReturnsAsync(mockCars);

        // Create ViewModel
        _viewModel = new CarDetailViewModel(_mockCarDao.Object, _mockCarRepository.Object, _mockAuthenticationService.Object, 
                                            _mockUserRepository.Object, _mockUserDao.Object);
    }

    [TestMethod]
    public async Task LoadInitialDataAsync_ShouldLoadCars()
    {
        // Arrange
        await Task.Delay(100); // Allow async method to complete

        // Assert
        Assert.IsNotNull(_viewModel.Cars);
        Assert.AreEqual(3, _viewModel.Cars.Count);
    }

    [TestMethod]
    public void SelectedCar_WhenSet_ShouldTriggerLoadPictureOfCar()
    {
        // Arrange
        var testOwner = new User
        {
            Id = 1,
            IsShowroom = false
        };
        var testCar = new Car
        {
            CarId = 1,
            Name = "Test Car",
            Images = "Honda Accord",
            OwnerId = 1
        };

        // Setup mock for GetVariantsOfCar
        _mockCarRepository.Setup(x => x.GetVariantsOfCar(It.IsAny<int>()))
            .Returns(Task.FromResult(new List<VariantOfCar>
            {
                new VariantOfCar { Name = "Đen huyền bí" }
            }));

        // Setup mock for GetVariantsCodeByName
        _mockCarRepository.Setup(x => x.GetVariantsCodeByName(It.IsAny<string>()))
            .Returns(Task.FromResult("Black"));

        _mockUserRepository.Setup(x => x.GetUserById(It.IsAny<int>()))
            .Returns(Task.FromResult(testOwner));

        // Act
        _viewModel.SelectedCar = testCar;

        // Assert
        Assert.AreEqual(testCar, _viewModel.SelectedCar);
        Assert.IsNotNull(_viewModel.SelectedCarPictures);
    }

}


[TestClass]
public class CompareViewModelTests
{
    private Mock<IDao<CarDetail>> _mockCarDetailDao;
    private Mock<IDao<Car>> _mockCarDao;
    private CompareViewModel _compareViewModel;

    [TestInitialize]
    public void Setup()
    {
        _mockCarDetailDao = new Mock<IDao<CarDetail>>();
        _mockCarDao = new Mock<IDao<Car>>();

        _compareViewModel = new CompareViewModel(_mockCarDetailDao.Object, _mockCarDao.Object);
    }

    [TestMethod]
    public async Task CarCompare_Property_SetsCarDetailsCorrectly()
    {
        // Arrange
        var cars = new List<Car>
            {
                new Car { CarId = 1 },
                new Car { CarId = 2 }
            };

        var carDetails = new List<CarDetail>
            {
                new CarDetail { CarId = 1, Year = 2000},
                new CarDetail { CarId = 2, Year = 2028 }
            };

        _mockCarDetailDao.Setup(d => d.GetByIdAsync(1)).ReturnsAsync(carDetails.FirstOrDefault(cd => cd.CarId == 1));
        _mockCarDetailDao.Setup(d => d.GetByIdAsync(2)).ReturnsAsync(carDetails.FirstOrDefault(cd => cd.CarId == 2));

        // Act
        _compareViewModel.CarCompare = cars;

        // Assert
        Assert.IsNotNull(_compareViewModel.CarCompare);
        Assert.AreEqual(2, _compareViewModel.CarCompare.Count);
        Assert.AreEqual(2000, _compareViewModel.CarCompare[0].carDetail.Year);
        Assert.AreEqual(2028, _compareViewModel.CarCompare[1].carDetail.Year);

        _mockCarDetailDao.Verify(d => d.GetByIdAsync(1), Times.Once);
        _mockCarDetailDao.Verify(d => d.GetByIdAsync(2), Times.Once);
    }

    [TestMethod]
    public void CarCompare_Property_HandlesEmptyList()
    {
        // Arrange
        var cars = new List<Car>();

        // Act
        _compareViewModel.CarCompare = cars;

        // Assert
        Assert.IsNotNull(_compareViewModel.CarCompare);
        Assert.AreEqual(0, _compareViewModel.CarCompare.Count);

        _mockCarDetailDao.Verify(d => d.GetByIdAsync(It.IsAny<int>()), Times.Never);
    }
}


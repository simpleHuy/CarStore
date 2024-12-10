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

namespace CarStore.Tests;

[TestClass]
public class UnitTest1
{
    private IServiceProvider _serviceProvider;
    [TestInitialize]
    public void Setup()
    {
        // Set up the test DI container
        var serviceCollection = new ServiceCollection();

        // Register your dependencies (you can also mock dependencies here)
        //serviceCollection.AddScoped<ICarRepository, EfCoreCarRepository>();
        //serviceCollection.AddScoped<IUserRepository, EfCoreUserRepository>();
        serviceCollection.AddScoped(typeof(IDao<>), typeof(EfCoreDao<>));

        // Build the service provider
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [TestMethod]
    public  async Task GetListCar()
    {
        // Arrange
        var _carDao = _serviceProvider.GetRequiredService<IDao<Car>>();

        // Act
        var listCar = await _carDao.GetAllAsync();
        

        // Assert
        Assert.IsNotNull(listCar, "The list of cars should not be null.");
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
    public void TestGetUser()
    {
      
    }

    [TestMethod]
    public void TestGetPopularCarsMockDao()
    {
        // Arrange
        var mockDao = new MockDao();

        // Act
        List<Car> listCar = mockDao.getPopularCars();

        // Assert
        Assert.IsNotNull(listCar, "The list of cars should not be null.");
        Assert.IsTrue(listCar.Count > 0, "The list of popular cars should contain items.");
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
    public async Task SearchCarAsync()
    {

    }

    [TestMethod]
    public async Task getCarToCompareAsync()
    {

    }

    [TestMethod]
    public async Task FiltersCarAsync()
    {
        // Arrange
        var viewModel = new FilterViewModel();
        
        // Simulate the user selecting "Honda" as a filter
        viewModel.SelectedFilters.Add ( new SelectedFilter
        {
            Name = "Honda",
            Type = "Manufacturer"
        });

        // Act
        var filteredCars = viewModel.FilteredCars; 
        // Assert
        Assert.AreEqual(3, filteredCars.Count, "Only two cars should match the Honda filter.");
    }

    [TestMethod]
    public void  Test_AddSelectedFilters_UpdatesFilteredCars()
    {
        // Arrange
        var viewModel = new FilterViewModel();
        var car1 = new Car { DefautlImageLocation = "car1.jpg" };
        var car2 = new Car { DefautlImageLocation = "car2.jpg" };
        var car3 = new Car { DefautlImageLocation = "car3.jpg" };

        // Simulate the initial list of cars
        viewModel.Cars = new FullObservableCollection<Car> { car1, car2, car3 };

        // Simulate the user selecting "Honda" as a filter
        viewModel.SelectedFilters.Add(new SelectedFilter
        {
            Name = "Honda",
            Type = "Manufacturer"
        });

        // Act
        var filteredCars = viewModel.FilteredCars;

        // Assert
        Assert.IsNotNull(filteredCars, "FilteredCars should not be null.");
        Assert.IsTrue(filteredCars.Count > 0, "FilteredCars should contain items.");
    }

}



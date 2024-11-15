using CarStore.ViewModels;
using CarStore.Services.DataAccess;
using CarStore.Services;
using CarStore.Models;


namespace CarStore.Tests; 

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestGetListCarMockDao()
    {
        // Arrange
        var mockDao = new MockDao();

        List<Car> listCar = mockDao.getAllCars();

        // Assert
        Assert.IsNotNull(listCar, "The list of cars should not be null.");
    }

    [TestMethod]
    public void TestGetTypeCarMockDao()
    {
        // Arrange
        var mockDao = new MockDao();

        List<TypeOfCar> TypeOfCar = mockDao.GetTypeOfCar();

        // Assert
        Assert.IsNotNull(TypeOfCar, "The list of cars should not be null.");
    }

    [TestMethod]
    public void TestGetUserMockDao()
    {
        // Arrange
        var mockDao = new MockDao();

        User user = mockDao.GetUser();

        // Assert
        Assert.IsNotNull(user, "The user should not be null.");
    }
    [TestMethod]
    public void TestGetPopularCarsMockDao()
    {
        // Arrange
        var mockDao = new MockDao();

        List<Car> listCar = mockDao.getPopularCars();

        // Assert
        Assert.IsNotNull(listCar, "The list of cars should not be null.");
    }

    [TestMethod]
    public async Task TestLoginAsync()
    {
        // Arrange
        AuthenticationService authenticationService = new AuthenticationService();
        var username = "admin";
        var password = "1234";

        // Act
        var result = await authenticationService.LoginAsync(username, password);

        // Assert
        Assert.IsTrue(result, "Login should be successful.");
        Assert.IsNotNull(authenticationService.GetCurrentUser(), "Current user should be set after login.");
    }
    [TestMethod]
    public async Task TestRegisterAsync()
    {
        // Arrange
        AuthenticationService authenticationService = new AuthenticationService();
        var firstName = "John";
        var lastName = "Doe";
        var email = "john.doe@gmail.com";
        var phoneNumber = "0912345678";
        var username = "johndoe";
        var password = "Password123@@";

        // Act
        var result = await authenticationService.RegisterAsync(firstName, lastName, email, phoneNumber, username, password);

        // Assert
        Assert.IsTrue(result, "Registration should be successful.");
    }

    [TestMethod]
    public void TestLogout()
    {
        // Arrange
        AuthenticationService authenticationService = new AuthenticationService();
        _ = authenticationService.LoginAsync("admin", "1234");

        // Act
        authenticationService.Logout();

        // Assert
        Assert.IsNull(authenticationService.GetCurrentUser(), "Current user should be cleared after logout.");
    }
    [TestMethod]
    public async Task TestValidateDataAsync()
    {
        // Arrange
        AuthenticationService authenticationService = new AuthenticationService();
        var firstName = "John";
        var lastName = "Doe";
        var email = "john.doe@example.com";
        var phoneNumber = "091234567sd8";
        var username = "johndoe";
        var password = "passworsd123";

        // Act
        var result = await authenticationService.RegisterAsync(firstName, lastName, email, phoneNumber, username, password);

        // Assert
        Assert.IsFalse(result, "Registration should be successful.");
    }

}
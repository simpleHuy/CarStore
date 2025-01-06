using CarStore.Core.Models;

namespace CarStore.Core.Contracts.Repository;
public interface IUserRepository
{
    public Task<User> GetUserByUsername(string username);
    public Task<User> GetUserByEmail(string email);
    public Task<List<Car>> GetWishlist(int userId);
    public Task AddCarToWishlist(int userId, int carId);
    public Task<List<Schedule>> GetSchedule(int userId);
    public Task<List<Car>> GetCarsOfUser(int userId);
    public Task<User> GetUserById(int id);
}

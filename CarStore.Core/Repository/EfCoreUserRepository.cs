using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Core.Repository;
public class EfCoreUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public EfCoreUserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task AddCarToWishlist(int userId, int carId)
    {
        try
        {
            // Check if the car is already in the wishlist
            var wishlist = _dbContext.wishlists.FirstOrDefault(w => w.UserId == userId && w.CarId == carId);
            if (wishlist == null) {
                wishlist = new Wishlist { UserId = userId, CarId = carId };
                _dbContext.wishlists.Add(wishlist);
                return _dbContext.SaveChangesAsync();
            }

            return Task.CompletedTask;
        }
        catch (Exception)
        {
            // Log the exception if necessary
            throw;
        }
    }

    public Task<List<Car>> GetCarsOfUser(int userId)
    {
        return _dbContext.Cars
            .Where(c => c.OwnerId == userId)
            .ToListAsync();
    }

    public Task<List<Schedule>> GetSchedule(int userId)
    {
        // get all shedule of user (userid = customerId or userId = merchantId)
        // sort by date
        return _dbContext.schedules
            .Where(s => s.CustomerId == userId || s.MerchantId == userId)
            .OrderBy(s => s.Date)
            .ToListAsync();
    }

    public Task<User> GetUserByEmail(string email)
    {
        return _dbContext.users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<User> GetUserById(int id)
    {
        return _dbContext.users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public Task<User> GetUserByUsername(string username)
    {
        return _dbContext.users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public Task<List<Car>> GetWishlist(int userId)
    {
        return _dbContext.wishlists
            .Where(w => w.UserId == userId)
            .Select(w => w.Car)
            .ToListAsync();
    }


}

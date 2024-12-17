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

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models;

namespace CarStore.Core.Contracts.Repository;
public interface IUserRepository
{
    public Task<User> GetUserByUsername(string username);
    public Task<User> GetUserByEmail(string email);
    public Task<User> GetUserById(int id);
}

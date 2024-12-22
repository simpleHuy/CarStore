using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Data;
using CarStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Core.Repository;
public class EfCoreShowroomRepository : IShowroomRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EfCoreShowroomRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public Task<Showroom> GetShowroomByUserId(int userId)
    {
        //find showroom having userId = userId
        return _dbContext.showrooms
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.UserId == userId);
    }
}

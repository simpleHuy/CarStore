using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;

namespace CarStore.Core.Repository;
public class EfCoreBiddingRepository: IBiddingRepository
{
    private readonly ApplicationDbContext _context;

    public EfCoreBiddingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Bidding>> GetAllBidsAsync()
    {
        return await _context.Biddings.ToListAsync();
    }

    public async Task<Bidding> GetBidByIdAsync(int id)
    {
        return await _context.Biddings.FindAsync(id);
    }

    public async Task<List<Bidding>> GetBidsByAuctionIdAsync(int AuctionId)
    {
        return await _context.Biddings.Where(b => b.AuctionId == AuctionId).ToListAsync();
    }
}

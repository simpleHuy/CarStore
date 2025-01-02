using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models;

namespace CarStore.Core.Contracts.Repository;
public interface IBiddingRepository
{
    Task<List<Bidding>> GetAllBidsAsync();
    Task<Bidding> GetBidByIdAsync(int id);
    Task<List<Bidding>> GetBidsByAuctionIdAsync(int AuctionId);
}

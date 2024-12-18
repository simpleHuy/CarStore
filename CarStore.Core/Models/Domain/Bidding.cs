using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class Bidding: INotifyPropertyChanged
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BiddingId
    {
        get; set;
    }
    public int AuctionId
    {
        get; set;
    }
    public Auction Auction
    {
        get; set;
    }
    public string UserId
    {
        get; set;
    }
    public User User
    {
        get; set;
    }
    public long BidAmount
    {
        get; set;
    }
    public DateTime Time
    {
        get; set;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

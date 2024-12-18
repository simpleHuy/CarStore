using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarStore.Core.Models;
public class Auction: INotifyPropertyChanged
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuctionId
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public string Description
    {
        get; set;
    }

    public DateTime StartDate
    {
        get; set;
    }
    public DateTime EndDate
    {
        get; set;
    }
    public long? Price
    {
        get; set;
    }
    public int CarId
    {
        get; set;
    }
    public Car Car
    {
        get; set;
    }
    public string condition
    {
        get; set;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


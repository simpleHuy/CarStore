using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.Models;
public class SelectedFilter : ObservableObject
{
    public string Name
    {
        get; set;
    }
    public int Id
    {
        get; set;
    }
    public string Type
    {
        get; set;
    } 
    // e.g., "Manufacturer", "Engine Type", etc.
}

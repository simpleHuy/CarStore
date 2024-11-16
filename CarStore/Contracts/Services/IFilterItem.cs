using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Contracts.Services;
public interface IFilterItem
{
    string Name
    {
        get; set;
    }
    string Type
    {
        get;
    }
    int Id
    {
        get; set;
    }
}

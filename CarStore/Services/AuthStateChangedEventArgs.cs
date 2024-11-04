using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Models;

namespace CarStore.Services;
public class AuthStateChangedEventArgs : EventArgs
{
    public bool IsAuthenticated
    {
        get;
    }


    public AuthStateChangedEventArgs(bool isAuthenticated)
    {
        IsAuthenticated = isAuthenticated;
    }
}
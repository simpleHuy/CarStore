using System.Collections.ObjectModel;

using CarStore.Contracts.ViewModels;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;

using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.ViewModels;

public partial class RegisterDetailViewModel : ObservableRecipient, INavigationAware
{
    public async void OnNavigatedTo(object parameter)
    {

    }

    public void OnNavigatedFrom()
    {
    }
}

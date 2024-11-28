using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CarStore.Contracts.Services;
using CarStore.Core.Models;
using CarStore.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Npgsql;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Account : Page
{
    public AccountPageViewModel ViewModel
    {
        get; set;
    }
    private MainPageViewModel mainPageViewModel
    {
        get; set;
    }

    public Account()
    {
        ViewModel = App.GetService<AccountPageViewModel>();
        this.InitializeComponent();
        mainPageViewModel = App.GetService<MainPageViewModel>();
        this.Loaded += Account_Loaded;
    }

    private void Account_Loaded(object sender, RoutedEventArgs e)
    {
        if (!mainPageViewModel.IsLogin)
        {
            Frame.Navigate(typeof(LoginPage));
        }
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        ViewModel.CurrentUser = e.Parameter as User;
        ViewModel.ViewedUser = ViewModel.CurrentUser;
    }

    private void ListCompettorCars_ItemClick(object sender, ItemClickEventArgs e)
    {
        var car = e.ClickedItem as Car;
        Frame.Navigate(typeof(CarDetailPage), car);
    }

    private void ColorGridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        // Ensure the clicked item is of type Color
        if (e.ClickedItem is VariantOfCar selectedVariant)
        {
            var variantCode = "";
            // Update the big image source based on the selected color
            var currentItem = (sender as GridView).DataContext as Car;
            Task.Run(async () => {
                variantCode = await ViewModel._carRepository.GetVariantsCodeByName(selectedVariant.Name);
            }).Wait();

            if (currentItem != null)
            {
                currentItem.DefautlImageLocation = $"../Assets/Cars/{currentItem.Images}/{variantCode}/1{Path.GetExtension(currentItem.DefautlImageLocation)}";
            }
        }
    }

    private void AddItemBtn_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(AddItemPage));
    }
}

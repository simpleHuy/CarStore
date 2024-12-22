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

    public Account()
    {
        ViewModel = App.GetService<AccountPageViewModel>();
        InitializeComponent();
        DataContext = ViewModel;
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

            var path = AppDomain.CurrentDomain.BaseDirectory;
            path += "Assets\\Cars\\" + currentItem.Images + "\\" + variantCode;
            path = path.Replace("\\bin\\x64\\Debug\\net7.0-windows10.0.19041.0\\AppX", "");
            if (Directory.Exists(path))
            {
                var firstImage = Directory.GetFiles(path).FirstOrDefault();
                if (firstImage != null)
                {
                    currentItem.DefautlImageLocation = firstImage;
                }
            }
        }
    }

    private void AddItemBtn_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(AddItemPage));
    }

    private void ExploreButton(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(MainPage));
    }

    private async void RegisterReputation_click(object sender, RoutedEventArgs e)
    {
        if (ViewModel.CheckReputation())
        {
            var failContent = new ContentDialog
            {
                Title = "Đăng kí không thành công",
                Content = "Bạn đã là 1 showroom uy tín.",
                PrimaryButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await failContent.ShowAsync();
            return;
        }
        var successContent = new ContentDialog
        {
            Title = "Đăng kí thành công",
            Content = "Đơn đăng kí đã được gửi đi, chúng tôi sẽ xem xét và thông báo kết quả cho bạn sau.",
            PrimaryButtonText = "OK",
            XamlRoot = this.XamlRoot
        };

        await successContent.ShowAsync();
    }

    private async void RegisterShowroom_click(object sender, RoutedEventArgs e)
    {
        if(ViewModel.OwnCar.Count < 3)
        {
            var failContent = new ContentDialog
            {
                Title = "Đăng kí không thành công",
                Content = "Bạn cần sở hữu ít nhất 3 xe để đăng kí làm showroom.",
                PrimaryButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await failContent.ShowAsync();
            return;
        }

        var successContent = new ContentDialog
        {
            Title = "Đăng kí thành công",
            Content = "Đơn đăng kí đã được gửi đi, chúng tôi sẽ xem xét và thông báo kết quả cho bạn sau.",
            PrimaryButtonText = "OK",
            XamlRoot = this.XamlRoot
        };

        await successContent.ShowAsync();
    }
}

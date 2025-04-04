﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CarStore.Services.DataAccess;
using CarStore.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CarStore.Services;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.System;
using System.Diagnostics;
using CarStore.Core.Models;
using Microsoft.UI.Xaml.Shapes;
using System.Text.RegularExpressions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class CarDetailPage : Page
{
    public CarDetailViewModel? ViewModel
    {
        get; set;
    }

    public CarDetailPage()
    {
        ViewModel = App.GetService<CarDetailViewModel>();
        this.InitializeComponent();
        DataContext = ViewModel;

    }

    private void SeeThisCar(object sender, ItemClickEventArgs e)
    {
        var selectedCar = e.ClickedItem as Car;
        if (selectedCar != null)
        {
            Frame.Navigate(typeof(CarDetailPage), selectedCar);
        }
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (e.Parameter is Car selectedCar)
        {
            ViewModel.SelectedCar = selectedCar;
        }
    }

    private void ChooseThisPicture(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is string clickedImagePath)
        {
            // Find the index of clicked item
            int index = ViewModel.SelectedCarPictures.IndexOf(clickedImagePath);
            if (index >= 0)
            {
                // Update the FlipView's selected index directly
                Gallery.SelectedIndex = index;
            }
        }
    }

    private async void ClickHomePageButton(object sender, RoutedEventArgs e)
    {
        var homeUrl = ViewModel!.Showroom?.Home;
        if (homeUrl == null)
        {
            return;
        }
        var uri = new Uri(homeUrl);
        await Launcher.LaunchUriAsync(uri);
    }

    private async void ClickFacebookButton(object sender, RoutedEventArgs e)
    {
        var facebookUrl = ViewModel!.Showroom?.Facebook;
        if (facebookUrl == null)
        {
            return;
        }
        var uri = new Uri(facebookUrl);
        await Launcher.LaunchUriAsync(uri);
    }

    private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;

        if (comboBox != null && comboBox.SelectedItem != null)
        {
            var selectedColor = comboBox.SelectedValue as VariantOfCar;

            ViewModel.SelectedCarColor = selectedColor.Name;
        }
    }

    private async void Schedule_btn_click(object sender, RoutedEventArgs e)
    {
        if (!ViewModel.IsLogin)
        {
            await new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Title = "Bạn chưa đăng nhập",
                Content = "Vui lòng đăng nhập để đặt lịch hẹn!",
                CloseButtonText = "OK",
            }.ShowAsync();

            return;
        }

        var scheduleData = Tuple.Create(ViewModel.SelectedCar, ViewModel.Showroom);

        Frame.Navigate(typeof(ScheduleForm), scheduleData);
    }

    private async void Contact_btn_click(object sender, RoutedEventArgs e)
    {
        if (!ViewModel.IsLogin)
        {
            await new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Title = "Bạn chưa đăng nhập",
                Content = "Vui lòng đăng nhập để thêm vào Wishlist!",
                CloseButtonText = "OK",
            }.ShowAsync();

            return;
        }
        Frame.Navigate(typeof(ChatPage), ViewModel.Owner.Id);
    }

    private async void AddWishlist_btn_click(object sender, RoutedEventArgs e)
    {
        if(!ViewModel.IsLogin)
        {
            await new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Title = "Bạn chưa đăng nhập",
                Content = "Vui lòng đăng nhập để thêm vào Wishlist!",
                CloseButtonText = "OK",
            }.ShowAsync();

            return;
        }

        ViewModel.AddToWishlist();

        await new ContentDialog()
        {
            XamlRoot = this.Content.XamlRoot,
            Title = "Thành công",
            Content = "Đã thêm vào Wishlist",
            CloseButtonText = "OK",
        }.ShowAsync();
    }

    private async void SeeMoreProduct_btn_click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(MockAnyCarPage), ViewModel.Owner);
    }

    private async void Compare_btn_click(object sender, RoutedEventArgs e)
    {
        var compareControl = new Compare(ViewModel);
        var dialog = new ContentDialog
        {
            Title = "So sánh xe",
            Content = compareControl,
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = this.XamlRoot,
        };

        dialog.Resources["ContentDialogMaxWidth"] = 1080;

        var result = await dialog.ShowAsync();
    }
}

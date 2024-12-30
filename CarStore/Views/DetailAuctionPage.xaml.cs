using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CommunityToolkit.WinUI.UI.Automation.Peers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CarStore.ViewModels;
using CarStore.Core.Models;

namespace CarStore.Views;
public sealed partial class DetailAuctionPage : Page
{
    public DetailAuctionViewModel ViewModel
    {
        get;
    }
    public DetailAuctionPage()
    {
        ViewModel = App.GetService<DetailAuctionViewModel>();
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
    private void ScrollToLastItem()
    {
        if (ViewModel.BidHistory.Count > 0)
        {
            var lastItem = ViewModel.BidHistory.Last();
            BidListView.ScrollIntoView(lastItem);
        }
    }
    private ContentDialog _currentDialog;

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.Parameter is Auction auction)
        {
            ViewModel.Auction = auction;
            ViewModel.Price = (long)auction.Price;
            DateTime currentTime = DateTime.Now;
            DateTime endTime = auction.StartDate.AddMinutes(auction.EndDate);
            ViewModel.TimeRemaining = endTime - currentTime;
            ViewModel.TimeLimit = auction.EndDate;
            ViewModel.SelectedCar = auction.Car;
            ViewModel.BidHistory.CollectionChanged +=  async(s, args) =>
            {
                ScrollToLastItem();
            };

            ViewModel.AuctionEnded += async (s, args) =>
            {
                if (_currentDialog == null)
                {
                    _currentDialog = new ContentDialog
                    {
                        Title = "Thông báo",
                        Content = "Đấu giá đã kết thúc",
                        CloseButtonText = "OK",
                        XamlRoot = this.Content.XamlRoot
                    };
                    await _currentDialog.ShowAsync();
                    _currentDialog = null;
                }
            };

            ViewModel.BidFailed += async (s, args) =>
            {
                if (_currentDialog == null)
                {
                    _currentDialog = new ContentDialog
                    {
                        Title = "Thông báo",
                        Content = "Giá đấu phải lớn hơn giá hiện tại",
                        CloseButtonText = "OK",
                        XamlRoot = this.Content.XamlRoot
                    };
                    await _currentDialog.ShowAsync();
                    _currentDialog = null;
                }
            };

        }
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        base.OnNavigatedFrom(e);
        ViewModel.TimeRemaining = TimeSpan.Zero;
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

    private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;

        if (comboBox != null && comboBox.SelectedItem != null)
        {
            var selectedColor = comboBox.SelectedValue as VariantOfCar;

            ViewModel.SelectedCarColor = selectedColor.Name;
        }
    }

    private void Color_Loaded(object sender, RoutedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (comboBox != null && comboBox.Items.Count > 0)
        {
            comboBox.SelectedIndex = 0;
        }
    }

}

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
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.Parameter is Auction auction)
        {
            ViewModel.Auction = auction;
            ViewModel.SelectedCar = auction.Car;
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

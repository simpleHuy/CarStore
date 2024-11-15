using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using ListView = Microsoft.UI.Xaml.Controls.ListView;
using CarStore.ViewModels;
using CarStore.Models;
using Windows.System;



// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// 
/// </summary>
public sealed partial class FilterPage : Page
{
    public ObservableCollection<string> Items { get; set; } = new();

    public FilterViewModel ViewModel
    {
        get;
    }

    public CarDetailViewModel CarDetailViewModel
    {
        get;
    }
    public FilterPage()
    {
        CarDetailViewModel = App.GetService<CarDetailViewModel>();
        ViewModel = App.GetService<FilterViewModel>();
        this.DataContext = CarDetailViewModel;
        this.InitializeComponent();
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
            CarDetailViewModel.SelectedCar = selectedCar;
        }
    }

    //private void ChooseThisPicture(object sender, ItemClickEventArgs e)
    //{
    //    if (e.ClickedItem is string clickedImagePath)
    //    {
    //        // Find the index of clicked item
    //        int index = CarDetailViewModel.SelectedCarPictures.IndexOf(clickedImagePath);
    //        if (index >= 0)
    //        {
    //            // Update the FlipView's selected index directly
    //            Gallery.SelectedIndex = index;
    //        }
    //    }
    //}

    private async void ClickHomePageButton(object sender, RoutedEventArgs e)
    {
        var uri = new Uri("https://anycar.vn/");
        await Launcher.LaunchUriAsync(uri);
    }

    private async void ClickFacebookButton(object sender, RoutedEventArgs e)
    {
        var uri = new Uri("https://www.facebook.com/anycar.vn/");
        await Launcher.LaunchUriAsync(uri);
    }


    private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;

        // Lấy giá trị màu sắc đang chọn
        if (comboBox != null && comboBox.SelectedItem != null)
        {
            string selectedColor = comboBox.SelectedValue.ToString();

            CarDetailViewModel.SelectedCarColor = selectedColor;
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

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (Frame.CanGoBack)
        {
            Frame.GoBack();
        }
    }
}


using System;
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
using CarStore.Models;
using Windows.System;
using System.Diagnostics;
using CarStore.Contracts.Services;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class FilterPage: Page
{
    public FilterViewModel? ViewModel
    {
        get; set;
    }

    public MainPageViewModel? MainViewModel
    {
        get; set;
    }

    public FilterPage()
    {
        this.InitializeComponent();
        ViewModel = new FilterViewModel();
        this.DataContext = ViewModel;

        MainViewModel = App.GetService<MainPageViewModel>();
        
    }


    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var selectedItem = (sender as MenuFlyoutItem)?.Text;
        // Handle the selected item
        Debug.WriteLine($"Selected Manufacturer: {selectedItem}");
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

        if (e.Parameter is TypeOfCar typeOfCar)
        {
            // Now you have access to the passed typeOfCar object
            // Store it in a property or use it directly
            this.TypeOfCar = typeOfCar;
            ViewModel.SelectedFilters.Add(new SelectedFilter
            {
                Name = typeOfCar.Name,
                Id = typeOfCar.Id,
                Type = typeOfCar.Type
            });
        }
    }

    // Add a property to store the passed object if needed
    public TypeOfCar TypeOfCar
    {
        get; private set;
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        var checkBox = sender as CheckBox;
        if (checkBox?.DataContext is IFilterItem filterItem && ViewModel != null)
        {
            // Check if the filter is already in the SelectedFilters collection
            if (!ViewModel.SelectedFilters.Any(f => f.Name == filterItem.Name && f.Type == filterItem.Type))
            {
                // Add the filter to SelectedFilters
                ViewModel.SelectedFilters.Add(new SelectedFilter
                {
                    Name = filterItem.Name,
                    Id = filterItem.Id,
                    Type = filterItem.Type
                });
            }
        }
    }

    private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        var checkBox = sender as CheckBox;
        if (checkBox?.DataContext is IFilterItem filterItem && ViewModel != null)
        {
            // Find the corresponding filter in SelectedFilters
            var selectedFilter = ViewModel.SelectedFilters.FirstOrDefault(f =>
                f.Name == filterItem.Name && f.Type == filterItem.Type);

            if (selectedFilter != null)
            {
                // Remove the filter from SelectedFilters
                ViewModel.SelectedFilters.Remove(selectedFilter);
            }
        }
    }
    // Remove filter button
    private void RemoveFilter_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is SelectedFilter selectedFilter)
        {
            ViewModel.SelectedFilters.Remove(selectedFilter);
            UncheckCorrespondingCheckbox(selectedFilter);
        }
        
    }

    // Remove all filters button
    private void RemoveAllFilters_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.SelectedFilters.Clear();

        // Uncheck all checkboxes
        foreach (var itemsControl in new ItemsControl[]
        {
            ManufacturersItemsControl,
            EngineTypesItemsControl,
            SeatsItemsControl,
            TypeCarsItemsControl,
            PriceOfCarsItemsControl
        })
        {
            if (itemsControl != null)
            {
                foreach (var item in itemsControl.Items)
                {
                    var container = itemsControl.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                    if (container != null)
                    {
                        var checkbox = FindVisualChild<CheckBox>(container);
                        if (checkbox != null)
                        {
                            checkbox.IsChecked = false;
                        }
                    }
                }
            }
        }
    }

    // filter button
    private void Filter_Click(object sender, RoutedEventArgs e)
    {
    
    }

    private void UncheckCorrespondingCheckbox(SelectedFilter selectedFilter)
    {
        // Find the ItemsControl/ListBox that contains the checkboxes for this filter type
        var itemsControl = FindFilterItemsControl(selectedFilter.Type);

        if (itemsControl != null)
        {
            // Iterate through the items to find the matching checkbox
            foreach (var item in itemsControl.Items)
            {
                var container = itemsControl.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                if (container != null)
                {
                    // Find the checkbox within the container
                    var checkbox = FindVisualChild<CheckBox>(container);
                    if (checkbox != null &&
                        checkbox.DataContext is IFilterItem filterItem &&
                        filterItem.Name == selectedFilter.Name)
                    {
                        checkbox.IsChecked = false;
                        break;
                    }
                }
            }
        }
    }

    private ItemsControl FindFilterItemsControl(string filterType)
    {
        // Map filter types to their corresponding ItemsControl names
        var controlMap = new Dictionary<string, string>
        {
            { "Manufacturer", "ManufacturersItemsControl" },
            { "EngineType", "EngineTypesItemsControl" },
            { "NumberOfSeats", "SeatsItemsControl" },
            { "TypeOfCar", "TypeCarsItemsControl" },
            { "PriceOfCar", "PriceOfCarsItemsControl" }
        };

        if (controlMap.TryGetValue(filterType, out string controlName))
        {
            return FindName(controlName) as ItemsControl;
        }

        return null;
    }

    // Helper method to find a child control of a specific type
    private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);

            if (child is T foundChild)
            {
                return foundChild;
            }

            var result = FindVisualChild<T>(child);
            if (result != null)
            {
                return result;
            }
        }
        return null;
    }




    //private void ChooseThisPicture(object sender, ItemClickEventArgs e)
    //{
    //    if (e.ClickedItem is string clickedImagePath)
    //    {
    //        // Find the index of clicked item
    //        int index = ViewModel.SelectedCarPictures.IndexOf(clickedImagePath);
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

            ViewModel.SelectedCarColor = selectedColor;
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



    private async void SeeMoreCompetitor_btn_click(object sender, RoutedEventArgs e)
    {
        await new ContentDialog()
        {
            XamlRoot = this.Content.XamlRoot,
            Title = "Tính năng chưa hoàn thiện",
            Content = "Vui lòng chờ đợi các bản cập nhật kế tiếp để có thể sử dụng!",
            CloseButtonText = "OK",
        }.ShowAsync();
    }

    private async void SeeMoreProduct_btn_click(object sender, RoutedEventArgs e)
    {
        await new ContentDialog()
        {
            XamlRoot = this.Content.XamlRoot,
            Title = "Tính năng chưa hoàn thiện",
            Content = "Vui lòng chờ đợi các bản cập nhật kế tiếp để có thể sử dụng!",
            CloseButtonText = "OK",
        }.ShowAsync();
    }
}

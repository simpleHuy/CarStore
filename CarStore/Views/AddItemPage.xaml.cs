using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CarStore.Core.Models;
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
using Windows.Storage.Pickers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class AddItemPage : Page
{
    public AddItemPageViewModel ViewModel { get; set; }
    public AddItemPage()
    {
        ViewModel = App.GetService<AddItemPageViewModel>();
        this.InitializeComponent();
        ColorPicker.ItemsSource = ViewModel.colors;
        ManufactureCbb.ItemsSource = ViewModel.Manufacturers;
        VariantList.ItemsSource = ViewModel.Variants;
        EngineCbb.ItemsSource = ViewModel.EngineTypes;
        CarTypeCbb.ItemsSource = ViewModel.TypeOfCars;
    }

    private void AddVariantBtn_Click(object sender, RoutedEventArgs e)
    {
        AddItemToList();
    }

    private void InputVariantTxt_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter) { AddItemToList(); }
    }

    void AddItemToList()
    {
        var variantString = InputVariantTxt.Text;
        var colorPick = ColorPicker.SelectedItem as string;
        var newVariantOfCar = new VariantOfCar();
        newVariantOfCar.Name = variantString;
        newVariantOfCar.Variant = new Variant();
        newVariantOfCar.Variant.Code = colorPick;

        if (!string.IsNullOrWhiteSpace(variantString) && !string.IsNullOrEmpty(colorPick))
        {
            ViewModel.Variants.Add(newVariantOfCar);
            InputVariantTxt.Text = string.Empty;
            ColorPicker.SelectedIndex = -1; // Reset the ComboBox
        }
        else
        {
            InputVariantTxt.Focus(FocusState.Programmatic);
            ColorPicker.Focus(FocusState.Programmatic);
        }
    }


    void DeleteItemFromList()
    {
        var selectedVariant = VariantList.SelectedItem as VariantOfCar;
        if (selectedVariant != null)
        {
            ViewModel.Variants.Remove(selectedVariant);
        }
    }

    private void DeleteVariantBtn_Click(object sender, RoutedEventArgs e)
    {
        DeleteItemFromList();
    }

    private async void AddFolderBtn_Click(object sender, RoutedEventArgs e)
    {
        var folderPicker = new FolderPicker();
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
        WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);
        var folder = await folderPicker.PickSingleFolderAsync();
        if (folder != null)
        {
            var folderPath = folder.Path;
            FolderPath.Text = folderPath;
        }
    }

    private void AddItemBtn_Click(object sender, RoutedEventArgs e)
    {
        //Compulsory fields
        var CarName = CarNameTxt.Text;
        var CarPrice = CarPriceTxt.Text;
        var CarManufacture = ManufactureCbb.SelectedItem as Manufacturer;
        var CarVariants = ViewModel.Variants;
        var CarFolderPath = FolderPath.Text;
        var Statuscbb = StatusCbb.SelectedItem as ComboBoxItem;
        var Status = Statuscbb?.Content.ToString();
        var NumberOfSeats = NumOfSeatTxt.Text;
        if (string.IsNullOrWhiteSpace(CarName) || string.IsNullOrWhiteSpace(CarPrice) || CarManufacture == null || CarVariants.Count == 0 || string.IsNullOrWhiteSpace(CarFolderPath) || string.IsNullOrWhiteSpace(Status) || string.IsNullOrWhiteSpace(NumberOfSeats))
        {
            ErrorTxt.Visibility = Visibility.Visible;
            return;
        }
        else
        {
            ErrorTxt.Visibility = Visibility.Collapsed;
            ClearInputFields();
        }
            
        //Optional fields
        var CarDescription = DescriptionTxt.Text;
        var TimeToGet100 = TimeGet100Txt.Text;
        var Distance = LongestDistanceTxt.Text;

        var newCar = new Car()
        {
            Name = CarName,
            Price = long.TryParse(CarPrice, out long price) ? price : 0,
            UsageStatus = Status!.ToString(),
            ManufacturerId = CarManufacture!.Id,
            Description = CarDescription,
        };
    }

    private void ClearInputFields()
    {
        CarNameTxt.Text = string.Empty; CarPriceTxt.Text = string.Empty; ManufactureCbb.SelectedItem = null; FolderPath.Text = string.Empty; StatusCbb.SelectedItem = null; NumOfSeatTxt.Text = string.Empty; DescriptionTxt.Text = string.Empty; TimeGet100Txt.Text = string.Empty; LongestDistanceTxt.Text = string.Empty;
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {

    }
}

using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using CarStore.ViewModels;
using CarStore.Core.Models;

namespace CarStore.Views;
public sealed partial class AddAuctionPage : Page
{
    public AddAuctionViewModel ViewModel { get; set;}
    public AddAuctionPage()
    {
        ViewModel = App.GetService<AddAuctionViewModel>();
        this.InitializeComponent();

        StartDatePicker.Date = DateTime.Today;
        StartTimePicker.Time = DateTime.Now.TimeOfDay;
        DurationComboBox.SelectedIndex = 0;
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
        Frame.GoBack();
    }
    private async void AddAuctionBtn_Click(object sender, RoutedEventArgs e)
    {
        if (!ValidateInputs())
        {
            ErrorTxt.Visibility = Visibility.Visible;
            return;
        }

        try
        {
            var startDate = StartDatePicker.Date.Date + StartTimePicker.Time;
            var utcStartDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);

            var auction = new Auction
            {
                Name = AuctionNameTxt.Text,
                Description = AuctionDescriptionTxt.Text,
                StartDate = utcStartDate,
                Price = int.Parse(StartingPriceTxt.Text),
                CarId = ViewModel.SelectedCar.CarId,
                condition = "",
                EndDate = int.Parse((DurationComboBox.SelectedItem as ComboBoxItem).Tag.ToString()),
            };

            await ViewModel.AddAuction(auction);

            // Show success message
            var dialog = new ContentDialog
            {
                Title = "Thành công",
                Content = "Đã thêm cuộc đấu giá mới thành công.",
                CloseButtonText = "OK",
                XamlRoot = this.Content.XamlRoot 
            };
            await dialog.ShowAsync();

            // Navigate back
            Frame.GoBack();
        }
        catch (Exception ex)
        {
            ErrorTxt.Text = "Có lỗi xảy ra: " + ex.Message;
            ErrorTxt.Visibility = Visibility.Visible;
        }
    }

    private void CarItem_Tapped(object sender, TappedRoutedEventArgs e)
    {
        if (sender is StackPanel panel && panel.DataContext is Car selectedCar)
        {
            ViewModel.SelectedCarName = selectedCar.Name;
            ViewModel.SelectedCar = selectedCar;
            CarSelectionButton.Flyout.Hide();
        }
    }

    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(AuctionNameTxt.Text) || string.IsNullOrWhiteSpace(StartingPriceTxt.Text) ||
            DurationComboBox.SelectedItem == null ||
            ViewModel.SelectedCar == null)
        {
            ErrorTxt.Text = "Vui lòng điền đầy đủ thông tin.";
            return false;
        }

        if (!int.TryParse(StartingPriceTxt.Text, out _))
        {
            ErrorTxt.Text = "Giá khởi điểm phải là số.";
            return false;
        }
        return true;
    }
}

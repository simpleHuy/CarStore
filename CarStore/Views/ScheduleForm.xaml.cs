using System;
using System.Collections.Generic;
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
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ScheduleForm : Page
{
    private List<string> TimeSlots = new List<string> { "8:00", "8:30", "9:00", "9:30", "10:00", "10:30", "11:00", "11:30", 
        "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00" };
    public ScheduleFormViewModel ViewModel
    {
        get; set;
    }
    public ScheduleForm()
    {
        ViewModel = App.GetService<ScheduleFormViewModel>();
        this.InitializeComponent();
    }

    private async void Summit_btn_click(object sender, RoutedEventArgs e)
    {
        // time picker is combobox
        var SelectedTime = TimeComboBox.SelectedItem;
        /*temporary control*/
        if (BranchPicker.SelectedItem == null || SelectedTime == null || DatePicker.Date == null)
        {
            await new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Title = "Đặt lịch hẹn",
                Content = "Vui lòng chọn hết tất cả các trường trong thông tin lịch hẹn!",
                CloseButtonText = "Quay lại",
            }.ShowAsync();

            return;
        }

        var today = DateTime.Now;
        today = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
        var date = DatePicker.Date.Value.DateTime;
        var time = new TimeSpan(int.Parse(SelectedTime.ToString().Split(":")[0]), int.Parse(SelectedTime.ToString().Split(":")[1]), 0);
        var dateTime = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);

        if (today.AddDays(2) > dateTime)
        {
            await new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Title = "Đặt lịch hẹn",
                Content = "Thời gian đặt lịch hẹn không hợp lệ!\nVui lòng đặt trước ít nhất 2 ngày",
                CloseButtonText = "Quay lại",
            }.ShowAsync();

            return;
        }

        var address = BranchPicker.SelectedItem.ToString();


        ViewModel.AddSchedule(dateTime, address);

        await new ContentDialog()
        {
            XamlRoot = this.Content.XamlRoot,
            Title = "Đặt lịch hẹn",
            Content = "Đã đặt lịch hẹn thành công",
            CloseButtonText = "OK",
        }.ShowAsync();



        if (Frame.CanGoBack)
        {
            Frame.GoBack();
        }
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (e.Parameter is Tuple<Car, Showroom> schduleData)
        {
            ViewModel.CurrentSelectedCar = schduleData.Item1;
            ViewModel.Showroom = schduleData.Item2;
        }
    }

    private void Back_HomePage(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(MainPage));
    }

    private void TimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}

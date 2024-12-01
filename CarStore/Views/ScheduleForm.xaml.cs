using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ScheduleForm : Page
{

    public ScheduleFormViewModel ViewModel
    {
        get; set;
    }
    public MainPageViewModel mainPageViewModel
    {
        get; set;
    }
    public ScheduleForm()
    {
        this.InitializeComponent();
        ViewModel = App.GetService<ScheduleFormViewModel>();
        mainPageViewModel = App.GetService<MainPageViewModel>();
    }

    private async void Summit_btn_click(object sender, RoutedEventArgs e)
    {
        /*temporary control*/

        if (BranchPicker.SelectedItem == null || TimePicker.SelectedTime == null || DatePicker.Date == null)
        {
            await new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Title = "Đặt lịch hẹn",
                Content = "Vui lòng chọn hết tất cả các trường trong thông tin lịch hẹn!",
                CloseButtonText = "Quay lại",
            }.ShowAsync();

        }
        else
        {
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

    }
}

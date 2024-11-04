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
    public ScheduleForm()
    {
        this.InitializeComponent();
        ViewModel = App.GetService<ScheduleFormViewModel>();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        /*ContentDialog dialog = new ContentDialog
        {
            Title = "Thông báo",
            Content = "Thông tin đặt lịch hẹn đã được gửi đến cửa hàng. Cửa hàng sẽ sớm liên hệ để xác nhận!",
            CloseButtonText = "Ok"
        };
        await dialog.ShowAsync();*/
    }
}

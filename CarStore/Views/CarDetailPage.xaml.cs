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
        this.InitializeComponent();
        ViewModel = new CarDetailViewModel();
    }

    private void ChoosePicture(object sender, TappedRoutedEventArgs e)
    {

    }

    private void GridView_ItemClick(object sender, ItemClickEventArgs e)
    {
    }
}

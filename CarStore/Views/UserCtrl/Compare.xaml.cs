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
public sealed partial class Compare : UserControl
{
    public readonly CarDetailViewModel ViewModel;
    public Compare(CarDetailViewModel VM)
    {
        ViewModel = VM;
        ViewModel.SelectedCar.DefautlImageLocation = "../" + ViewModel.SelectedCar.DefautlImageLocation;
        this.InitializeComponent();
    }

    

    private void OkButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        // Logic cho nút OK (có thể đóng dialog)
    }

    private void CancelButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        // Logic cho nút Cancel (có thể đóng dialog)
    }
}

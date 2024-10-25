using CarStore.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CarStore.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }

    private void GotoCarDetailPage(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Frame.Navigate(typeof(CarDetailPage));
    }
}

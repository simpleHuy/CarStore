using CarStore.Core.Models;
using CarStore.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Devices.Enumeration;

namespace CarStore.Views;

public sealed partial class MainPage : Page
{
    public MainPageViewModel ViewModel
    {
        get; set;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainPageViewModel>();
        InitializeComponent();
        DataContext = ViewModel;
        Loaded += Page_Loaded;
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await ViewModel.LoadCarsAsync();
        await ViewModel.LoadCategoriesAsync();
    }

    private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
    {
        //Frame.Navigate(typeof(LoginPage), name.Text);
    }

    private void BtnLogin_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }

    private void BtnSignup_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }

    //See detail of car
    private void InfoBtn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var selectedCar = (sender as Button).DataContext as Car;

        // Kiểm tra nếu selectedCar không null, sau đó chuyển đến CarDetailPage và truyền xe đã chọn
        if (selectedCar != null)
        {
            Frame.Navigate(typeof(CarDetailPage), selectedCar);
        }
    }

    private void BuyBtn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var selectedCar = (sender as Button).DataContext as Car;

        // Kiểm tra nếu selectedCar không null, sau đó chuyển đến CarDetailPage và truyền xe đã chọn
        if (selectedCar != null)
        {
            Frame.Navigate(typeof(CarDetailPage), selectedCar);
        }
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = (ComboBox)sender;
        if (comboBox?.DataContext is Car currentItem && comboBox.SelectedItem is Variant selectedVariant)
        {
            // Update ImageLocation based on selected Variant
            currentItem.DefautlImageLocation = $"../Assets/Cars/{currentItem.Images}/{selectedVariant.Code}/1{Path.GetExtension(currentItem.DefautlImageLocation)}";
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
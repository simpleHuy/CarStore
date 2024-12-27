using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using CarStore.Core.Models;
using CarStore.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MockAnyCarPage : Page
    {
        private readonly MainPageViewModel mainPageViewModel;
        public MockAnyCarPage()
        {
            this.InitializeComponent();
            ViewModel = App.GetService<MockAnyCarPageViewModel>();
            DataContext = ViewModel;
            mainPageViewModel = App.GetService<MainPageViewModel>();
        }

        public MockAnyCarPageViewModel ViewModel
        {
            get; set;
        }

        private void ListCompettorCars_ItemClick(object sender, ItemClickEventArgs e)
        {
            var car = e.ClickedItem as Car;
            Frame.Navigate(typeof(CarDetailPage), car);
        }

        private void ColorGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Ensure the clicked item is of type Color
            if (e.ClickedItem is VariantOfCar selectedVariant)
            {
                var variantCode = "";
                // Update the big image source based on the selected color
                var currentItem = (sender as GridView).DataContext as Car;
                Task.Run(async () => {
                    variantCode = await ViewModel._carRepository.GetVariantsCodeByName(selectedVariant.Name);
                }).Wait();

                if (currentItem != null)
                {
                    currentItem.DefautlImageLocation = $"../Assets/Cars/{currentItem.Images}/{variantCode}/1{Path.GetExtension(currentItem.DefautlImageLocation)}";
                }
            }
        }

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddItemPage));
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var car = e.ClickedItem as Car;
            Frame.Navigate(typeof(CarDetailPage), car);
        }

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Account));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Owner = e.Parameter as User;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Chat_Trigger(object sender, RoutedEventArgs e)
        {
            if (mainPageViewModel.IsLogin)
            {
                Frame.Navigate(typeof(ChatPage), ViewModel.Owner.Id);
            }
            else
            {
                await new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Title = "Bạn chưa đăng nhập",
                    Content = "Vui lòng đăng nhập để sử dụng tính năng này!",
                    CloseButtonText = "OK",
                }.ShowAsync();

                return;
            }
        }
    }
}

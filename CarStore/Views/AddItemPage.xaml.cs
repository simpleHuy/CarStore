using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    }

    private void AddVariantBtn_Click(object sender, RoutedEventArgs e)
    {
        AddItemToList();
    }

    private void InputVariantTxt_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter) { AddItemToList(); }
    }

    private void AddItemToList()
    {
        var variantString = InputVariantTxt.Text;
        var colorPick = ColorPicker.SelectedItem as Variant;
        var newVariantOfCar = new VariantOfCar();
        newVariantOfCar.Name = variantString;
        newVariantOfCar.Variant = colorPick;
        newVariantOfCar.VariantId = colorPick.Id;

        if (!string.IsNullOrWhiteSpace(variantString))
        {
            ViewModel.Variants.Add(newVariantOfCar);
            InputVariantTxt.Text = string.Empty;
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

    private async void AddItemBtn_Click(object sender, RoutedEventArgs e)
    {
        //Compulsory fields
        var CarName = CarNameTxt.Text;
        var CarPrice = CarPriceTxt.Text.Replace(",", "");
        var CarManufacture = ManufactureCbb.SelectedItem is Manufacturer manufacturer ? manufacturer : null;
        var carType = CarTypeCbb.SelectedItem is TypeOfCar typeOfCar ? typeOfCar : null;
        var carEngine = EngineCbb.SelectedItem is EngineType engineType ? engineType : null;
        var CarVariants = ViewModel.Variants;
        var CarFolderPath = FolderPath.Text;
        var Statuscbb = StatusCbb.SelectedItem as ComboBoxItem;
        var Status = Statuscbb?.Content.ToString();
        var NumberOfSeats = NumOfSeatTxt.Text.Replace(",", "");
        var Year = YearTxt.Text.Replace(",", "");
        if (string.IsNullOrWhiteSpace(CarName) || string.IsNullOrWhiteSpace(CarPrice) || CarManufacture == null 
            || CarVariants.Count == 0 || string.IsNullOrWhiteSpace(CarFolderPath) || string.IsNullOrWhiteSpace(Status) 
            || string.IsNullOrWhiteSpace(NumberOfSeats) || string.IsNullOrWhiteSpace(Year) || carType == null || carEngine == null)
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
            TypeOfCarId = carType!.Id,
            EngineTypeId = carEngine!.Id,
            Description = CarDescription,
            Images = CarName,
            PriceOfCarId = getPriceOfCarId(long.Parse(CarPrice)),
        };

        var newDetail = new CarDetail()
        {
            MaxDistance = int.TryParse(Distance, out var maxDistance) ? maxDistance : 0,
            TimeGet100 = double.TryParse(TimeToGet100, out var timeGet100) ? timeGet100 : 0,
            Year = int.Parse(Year),
            NumberSeatId = getNumberOfSeatId(int.Parse(NumberOfSeats)),
        };

        await ViewModel.AddItemAsync(CarName, CarFolderPath, newCar, newDetail);

        var dialog = new ContentDialog()
        {
            Title = "Thêm thành công",
            Content = "Thông tin xe của bạn đang được kiểm duyệt",
            CloseButtonText = "OK",
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = this.XamlRoot
        };
        var result = await dialog.ShowAsync();

        Frame.GoBack();
    }

    private void ClearInputFields()
    {
        CarNameTxt.Text = string.Empty; CarPriceTxt.Text = string.Empty; ManufactureCbb.SelectedItem = null; FolderPath.Text = string.Empty; StatusCbb.SelectedItem = null; NumOfSeatTxt.Text = string.Empty; DescriptionTxt.Text = string.Empty; TimeGet100Txt.Text = string.Empty; LongestDistanceTxt.Text = string.Empty;
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
        Frame.GoBack();
    }

    private void CarPriceTxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            // Loại bỏ ký tự không phải số
            string digitsOnly = Regex.Replace(textBox.Text, "[^0-9]", "");

            if (string.IsNullOrEmpty(digitsOnly))
            {
                textBox.Text = "";
                return;
            }

            // Thêm dấu phẩy mỗi 3 chữ số
            string formatted = string.Format("{0:N0}", long.Parse(digitsOnly));

            if (formatted != textBox.Text)
            {
                textBox.Text = formatted; // Cập nhật giá trị với định dạng
                textBox.SelectionStart = textBox.Text.Length; // Đặt con trỏ cuối văn bản
            }
        }
    }

    private void Number_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            string newText = Regex.Replace(textBox.Text, "[^0-9]", ""); // Loại bỏ ký tự không phải số
            if (newText != textBox.Text)
            {
                textBox.Text = newText;
                textBox.SelectionStart = newText.Length;
            }
        }
    }

    private async void GuideBtn_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new ContentDialog()
        {
            Title = "Hướng dẫn thêm xe",
            Content = "- Bạn cần điển đủ thông tin bắt buộc (các ô có *).\n\n- Khi thêm màu vui lòng đặt tên cho màu đó (ví dụ: Đỏ đô, trắng tuyết, đen huyền bí,...). " +
                    "Sau Khi thêm màu hãy bấm vào nút \"thêm\" ở dưới ô chọn hình ảnh.\n\n- Khi thêm vào hình ảnh hãy chọn vào thư mục chứa ảnh của bạn (tên thư mục " +
                    "đó tốt nhất là tên của xe bạn định đăng bán). Trong thư mục đó có chứa các thư mục con với màu của bạn đã thêm ở trên (ví dụ như: White, " +
                    "Black, Green,...). Trong mỗi thư mục hãy thêm hình mà bạn muốn Shop hiển thị.\n\n- Vui lòng thực hiện đúng từng bước như trên để xe " +
                    "của bạn có thể được đăng trên Shop của chúng tôi.",
            CloseButtonText = "OK",
            XamlRoot = this.XamlRoot
        };

        await dialog.ShowAsync();
    }

    private int getPriceOfCarId(long price)
    {
        if (price < 500000000)
            return 1;
        if (price < 1000000000)
            return 2;
        if (price < 2000000000)
            return 3;
        if (price < 3000000000)
            return 4;
        return 5;
    }

    private int getNumberOfSeatId(int seat)
    {
        if (seat == 2)
            return 1;
        if(seat == 4)
            return 2;
        if (seat == 5)
            return 3;
        return 4;
    }
}

 

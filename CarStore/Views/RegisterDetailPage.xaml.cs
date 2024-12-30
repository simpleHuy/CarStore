using CarStore.Core.Models;
using CarStore.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CarStore.Views;
// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class RegisterDetailPage : Page
{
    public RegisterDetailViewModel ViewModel
    {
        get;
    }

    public RegisterDetailPage()
    {
        ViewModel = App.GetService<RegisterDetailViewModel>();
        InitializeComponent();
        DataContext = ViewModel;
    }

    private void Accept_Register_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var detail = (sender as Button).DataContext as RegisterDetail;
        ViewModel.AcceptRegister(detail);
    }

    private void Refuse_Register_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var detail = (sender as Button).DataContext as RegisterDetail;
        ViewModel.RefuseRegister(detail);
    }
}

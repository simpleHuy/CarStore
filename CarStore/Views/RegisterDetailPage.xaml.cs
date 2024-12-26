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
    }
}

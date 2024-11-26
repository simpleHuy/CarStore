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
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views
{

    public class ComparisonRow
    {
        public bool IsImageRow
        {
            get; set;
        } // Determines if this row is for images
        public string PropertyName
        {
            get; set;
        }
        public string Value1
        {
            get; set;
        } // Value for Object 1
        public string Value2
        {
            get; set;
        } // Value for Object 2
    }


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ComparePage : Page
    {


        private readonly CompareViewModel ViewModel;
        public List<ComparisonRow> ComparisonData
        {
            get; set;
        }

        public ComparePage()
        {
            ViewModel = App.GetService<CompareViewModel>();
            this.InitializeComponent();

            ComparisonData = new List<ComparisonRow>
            {
                new ComparisonRow
                {
                    IsImageRow = true,
                    PropertyName = "", // Empty for image row
                    Value1 = "ms-appx:///Assets/Object1.png",
                    Value2 = "ms-appx:///Assets/Object2.png"
                },
                new ComparisonRow
                {
                    IsImageRow = false,
                    PropertyName = "Name",
                    Value1 = "Object 1 Name",
                    Value2 = "Object 2 Name"
                },
                new ComparisonRow
                {
                    IsImageRow = false,
                    PropertyName = "Price",
                    Value1 = "$100",
                    Value2 = "$120"
                }
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is List<Car> cars)
            {
                ViewModel.Car1 = cars[0];
                ViewModel.Car2 = cars[1];
            }
        }
    }
}

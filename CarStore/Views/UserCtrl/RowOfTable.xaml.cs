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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views.UserCtrl;


// Usage in XAML:
//<UserControl:RowOfTable Label="" Value1="" Value2=""/>

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class RowOfTable : Page
{
    /// <summary>
    /// Gets or sets the label of the row.
    /// </summary>
    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="Label"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register("Label", typeof(string), typeof(RowOfTable), new PropertyMetadata(""));

    /// <summary>
    /// Gets or sets the first value of the row.
    /// </summary>
    public string Value1
    {
        get => (string)GetValue(Value1Property);
        set => SetValue(Value1Property, value);
    }

    /// <summary>
    /// Identifies the <see cref="Value1"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty Value1Property =
        DependencyProperty.Register("Value1", typeof(string), typeof(RowOfTable), new PropertyMetadata(""));

    /// <summary>
    /// Gets or sets the second value of the row.
    /// </summary>
    public string Value2
    {
        get => (string)GetValue(Value2Property);
        set => SetValue(Value2Property, value);
    }

    /// <summary>
    /// Identifies the <see cref="Value2"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty Value2Property =
        DependencyProperty.Register("Value2", typeof(string), typeof(RowOfTable), new PropertyMetadata(""));

    /// <summary>
    /// Initializes a new instance of the <see cref="RowOfTable"/> class.
    /// </summary>
    public RowOfTable()
    {
        this.InitializeComponent();
    }
}

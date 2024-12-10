using CarStore.Views.ExtensionsExperiment.Samples.ListViewExtensions;
using System.ComponentModel;
using CommunityToolkit.WinUI.Behaviors;
using Microsoft.UI.Xaml.Controls;

namespace CarStore.Views;

//[ToolkitSample(id: nameof(KeyDownTriggerBehaviorSample), nameof(KeyDownTriggerBehavior), description: $"A sample for showing how to use the {nameof(KeyDownTriggerBehavior)}.")]
public sealed partial class SearchingPage : Page, INotifyPropertyChanged
{
    public SearchingPage()
    {
        this.InitializeComponent();
    }

    public int Count
    {
        get; set;
    }

    public void IncrementCount()
    {
        Count++;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
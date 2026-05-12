using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class DiscoverViewModel : ViewModelBase
{
    public DiscoverViewModel()
    {
        DisplayName = "Discover";
        IconData = (StreamGeometry)Application.Current.FindResource("DiscoverIcon"); 
    }
}
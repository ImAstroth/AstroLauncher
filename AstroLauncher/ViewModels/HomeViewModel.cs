using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    public HomeViewModel()
    {
        DisplayName = "Home";
        IconData = (StreamGeometry)Application.Current.FindResource("HomeIcon");
    }
}
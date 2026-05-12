using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels.SettingsPageViewModels;

public partial class GeneralViewModel : ViewModelBase
{
    public GeneralViewModel()
    {
        DisplayName = "General";
        IconData = (StreamGeometry)Application.Current.FindResource("GeneralIcon");
    }
}
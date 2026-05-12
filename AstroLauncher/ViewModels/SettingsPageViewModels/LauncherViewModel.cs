using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels.SettingsPageViewModels;

public partial class LauncherViewModel : ViewModelBase
{
    public LauncherViewModel()
    {
        DisplayName = "Launcher";
        IconData = (StreamGeometry)Application.Current.FindResource("LauncherIcon");
    }
}
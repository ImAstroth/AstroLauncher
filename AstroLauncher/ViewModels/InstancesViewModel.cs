using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class InstancesViewModel : ViewModelBase
{
    public InstancesViewModel()
    {
        DisplayName = "Instances";
        IconData = (StreamGeometry)Application.Current.FindResource("InstancesIcon");
    }

    [RelayCommand]
    private void LaunchMinecraft()
    {
       // add main logic later 
    }
    
    [RelayCommand]
    private void OpenMinecraftFolder()
    {
        Managers.FolderBtnManager.OpenMinecraftFolder();
    }
}
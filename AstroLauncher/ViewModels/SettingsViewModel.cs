using AstroLauncher.ViewModels.SettingsPageViewModels;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty]
    private string _pageTitle = "Settings";
    
    [ObservableProperty]
    private ObservableObject? _currentSettingsPage;

    // RAM values
    [ObservableProperty]
    private double _maxRamValue = 16384;

    public SettingsViewModel()
    {
        CurrentSettingsPage = new GeneralViewModel();
    }

    [RelayCommand]
    private void NavigateToGeneral()
    {
        CurrentSettingsPage =  new GeneralViewModel();
    }

    [RelayCommand]
    private void NavigateToLauncher()
    {
        CurrentSettingsPage = new LauncherViewModel();
    }
}
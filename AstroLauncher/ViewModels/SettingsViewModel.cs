using System.Collections.ObjectModel;
using AstroLauncher.ViewModels.SettingsPageViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase? _selectedCategory;

    public ObservableCollection<ViewModelBase> Categories { get; } = new()
    {
        new GeneralViewModel(),
        new LauncherViewModel(),
    };

    public SettingsViewModel()
    {
        DisplayName = "Settings";
        IconData = (StreamGeometry)Application.Current.FindResource("SettingsIcon"); 
        SelectedCategory = Categories[0];
    }

    [RelayCommand]
    private void NavigateToGeneral()
    {
        SelectedCategory =  new GeneralViewModel();
    }

    [RelayCommand]
    private void NavigateToLauncher()
    {
        SelectedCategory = new LauncherViewModel();
    }
}
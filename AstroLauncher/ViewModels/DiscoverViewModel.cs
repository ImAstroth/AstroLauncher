using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class DiscoverViewModel : ObservableObject
{
    [ObservableProperty] 
    private string _pageTitle = "Discover";
}
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty] 
    private string _pageTitle = "Home";
}
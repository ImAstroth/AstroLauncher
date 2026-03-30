using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;

using MCLauncher.Utils;

namespace MCLauncher;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ExtendClientAreaToDecorationsHint = true;
    }
    
    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
    
    public async void OnLaunchButtonClicked(object sender, RoutedEventArgs e)
    {
        await LaunchMinecraftAsync();
    }

    private async Task LaunchMinecraftAsync()
    {
        try 
        {
            var path = MinecraftPath.GetOSDefaultPath();
            var launcher = new MinecraftLauncher(path);

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                Session = MSession.CreateOfflineSession("User") 
            };

            Console.WriteLine("[CmlLib] Verifying files and launching...");

            var process = await launcher.CreateProcessAsync("1.20.1", launchOption);
            process.Start();
        
            Console.WriteLine("Starting game...");
        }
        catch (Exception ex)
        {
            DebugUtil.Error($"[CmlLib Error]: {ex.Message}");
        }
    }

    private void SetupDrag(object? sender, PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }
}
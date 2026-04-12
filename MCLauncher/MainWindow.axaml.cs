using System;
using System.Diagnostics;
using System.Linq;
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
    private readonly System.Threading.SemaphoreSlim _loadLock = new(1, 1);
    
    public MainWindow()
    {
        InitializeComponent();
        ExtendClientAreaToDecorationsHint = true;
        
        // load on start
        var savedAccount = AccountManager.Load();
        if (savedAccount != null)
        {
            UsernameBox.Text = savedAccount.Username;
        }
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
    
    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        await LoadVersionsAsync();
    }

    public void OnLoginClicked(object sender, RoutedEventArgs e)
    {
        var input = UsernameBox.Text;

        if (string.IsNullOrWhiteSpace(input))
        {
            // dont save garbage.
            return;
        }

        var account = new LauncherAccount 
        { 
            Username = input,
            IsMicrosoft = false
        };

        AccountManager.Save(account);
        
        Debug.WriteLine($"Saved: {account.DisplayName}");
    }
    
    private async Task LoadVersionsAsync()
    {
        await _loadLock.WaitAsync();

        try
        {
            var path = MinecraftPath.GetOSDefaultPath();
            var launcher = new MinecraftLauncher(path);

            var allVersions = await launcher.GetAllVersionsAsync();
        
            var releasesOnly = allVersions
                .Where(v => v.Type == "release")
                .Select(v => v.Name)
                .ToList();
        
            VersionsMenu.ItemsSource = releasesOnly;
            VersionsMenu.SelectedIndex = 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[Load Error]: {e.Message}");
        }
        finally
        {
            // ALWAYS release the lock
            _loadLock.Release();
        }
    }

    private async Task LaunchMinecraftAsync()
    {
        try 
        {
            string? selectedVersion = VersionsMenu.SelectedItem as string;
            string username = "Player";

            if (string.IsNullOrEmpty(selectedVersion))
            {
                Debug.WriteLine("Error: You must select a version first!");
                return;
            }
            
            var path = MinecraftPath.GetOSDefaultPath();
            var launcher = new MinecraftLauncher(path);

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                Session = MSession.CreateOfflineSession(username),
            };

            Debug.WriteLine($"[Astro] Launching {selectedVersion} for {username}...");

            var process = await launcher.CreateProcessAsync(selectedVersion, launchOption);
        
            process.Start();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[Launch Error]: {ex.Message}");
        }
    }

    private void SetupDrag(object? sender, PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }
}
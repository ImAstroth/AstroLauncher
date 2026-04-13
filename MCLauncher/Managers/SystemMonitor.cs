using System;
using System.Text.Json;
using System.Runtime.InteropServices;

using MCLauncher.JSON;
using MCLauncher.Launcher;

namespace MCLauncher.Managers;

public static class SystemMonitor
{
    public static void UpdateSystemLimits()
    {
        long ramBytes = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
        int totalRamMb = (int)(ramBytes / (1024 * 1024));

        var currentConfig = Json.LoadConfig();

        currentConfig.MaxPhysicalRamMb = totalRamMb; 
        
        if (currentConfig.SelectedRamMb > totalRamMb - 1024)
        {
            currentConfig.SelectedRamMb = totalRamMb - 1536;
        }

        Json.SaveConfig(currentConfig);
    }
}
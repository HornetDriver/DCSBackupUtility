using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DCSBackupUtility
{
    internal class AppConfig
    {
        public string BackupPath { get; set; } = @"D:\DCS_Backups";

        public string SecondaryBackupPath { get; set; } = @"E:\DCS_Backups";

        // Hourly, Daily, Weekly
        public string BackupFrequency { get; set; } = "Daily";

        // Number of ZIPs to keep
        public int PrimaryRetentionCount { get; set; } = 10;

        public int SecondaryRetentionCount { get; set; } = 5;

        // Last successful backup
        public DateTime LastBackup { get; set; } = DateTime.MinValue;

        public List<string> SelectedBackupItems { get; set; } = new()
        {
            @"Config\Input",
            @"Config\options.lua",
            @"MissionEditor\logbook.lua"
        };

        public static string ConfigPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "DCSBackupUtility",
            "config.json");

        public static AppConfig Load()
        {
            if (!File.Exists(ConfigPath))
            {
                AppConfig config = new AppConfig();
                config.Save();
                return config;
            }

            string json = File.ReadAllText(ConfigPath);

            return JsonSerializer.Deserialize<AppConfig>(json)!
                   ?? new AppConfig();
        }

        public void Save()
        {
            string? directory = Path.GetDirectoryName(ConfigPath);

            if (!string.IsNullOrWhiteSpace(directory))
                Directory.CreateDirectory(directory);

            string json = JsonSerializer.Serialize(
                this,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(ConfigPath, json);
        }
    }
}
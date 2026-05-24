using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace DCSBackupUtility
{
    internal static class BackupManager
    {
        public static void RunBackup(AppConfig config)
        {
            string userProfile =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.UserProfile);

            string[] dcsFolders =
            {
                Path.Combine(userProfile, "Saved Games", "DCS"),
                //Path.Combine(userProfile, "Saved Games", "DCS.openbeta")
            };

            List<string> itemsToBackup =
                config.SelectedBackupItems;

            Directory.CreateDirectory(config.BackupPath);

            string timestamp =
                DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            foreach (string dcsFolder in dcsFolders)
            {
                if (!Directory.Exists(dcsFolder))
                    continue;

                string dcsName =
                    Path.GetFileName(dcsFolder);

                string tempFolder =
                    Path.Combine(
                        config.BackupPath,
                        $"{dcsName}_{timestamp}");

                string zipFile =
                    tempFolder + ".zip";

                Directory.CreateDirectory(tempFolder);

                foreach (string item in itemsToBackup)
                {
                    string sourcePath =
                        Path.Combine(dcsFolder, item);

                    if (!File.Exists(sourcePath)
                        && !Directory.Exists(sourcePath))
                    {
                        continue;
                    }

                    string destinationPath =
                        Path.Combine(tempFolder, item);

                    string? destinationParent =
                        Path.GetDirectoryName(destinationPath);

                    if (!string.IsNullOrWhiteSpace(destinationParent))
                    {
                        Directory.CreateDirectory(destinationParent);
                    }
                    
                    if (Directory.Exists(sourcePath))
                    {
                        CopyDirectory(
                            sourcePath,
                            destinationPath);
                    }
                    else
                    {
                        File.Copy(
                            sourcePath,
                            destinationPath,
                            true);
                    }
                }

                if (File.Exists(zipFile))
                {
                    File.Delete(zipFile);
                }

                ZipFile.CreateFromDirectory(
                    tempFolder,
                    zipFile);
                ApplyRetentionPolicy(
                    config.BackupPath,
                    config.PrimaryRetentionCount);
                ApplyRetentionPolicy(
                    config.SecondaryBackupPath,
                    config.SecondaryRetentionCount);

                //
                // Secondary backup location
                //
                if (!string.IsNullOrWhiteSpace(
                    config.SecondaryBackupPath))
                {
                    Directory.CreateDirectory(
                        config.SecondaryBackupPath);

                    string secondaryZip =
                        Path.Combine(
                            config.SecondaryBackupPath,
                            Path.GetFileName(zipFile));

                    File.Copy(
                        zipFile,
                        secondaryZip,
                        true);
                }

                Directory.Delete(tempFolder, true);
            }
        }

        private static void CopyDirectory(
            string sourceDir,
            string destinationDir)
        {
            Directory.CreateDirectory(destinationDir);

            foreach (string file in Directory.GetFiles(
                sourceDir,
                "*",
                SearchOption.AllDirectories))
            {
                string relativePath =
                    Path.GetRelativePath(sourceDir, file);

                string destinationFile =
                    Path.Combine(destinationDir, relativePath);

                string? destinationFolder =
                    Path.GetDirectoryName(destinationFile);

                if (!string.IsNullOrWhiteSpace(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                File.Copy(file, destinationFile, true);
            }
        }

        private static void ApplyRetentionPolicy(
    string backupPath,
    int retentionCount)
        {
            if (retentionCount <= 0)
                return;

            DirectoryInfo directory =
                new DirectoryInfo(backupPath);

            FileInfo[] zipFiles =
                directory.GetFiles("*.zip")
                         .OrderByDescending(f => f.CreationTime)
                         .ToArray();

            if (zipFiles.Length <= retentionCount)
                return;

            foreach (FileInfo oldFile in zipFiles
                .Skip(retentionCount))
            {
                try
                {
                    oldFile.Delete();
                }
                catch
                {
                    // Optional:
                    // log deletion failure
                }
            }
        }
    }
}
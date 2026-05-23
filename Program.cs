using System;
using System.Linq;
using System.Windows.Forms;

namespace DCSBackupUtility
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            bool silentMode =
                args.Any(a =>
                    a.Equals("--silent",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    a.Equals("/silent",
                        StringComparison.OrdinalIgnoreCase));

            if (silentMode)
            {
                RunSilentBackup();
                return;
            }

            Application.Run(new MainForm());
        }

        private static void RunSilentBackup()
        {
            try
            {
                AppConfig config = AppConfig.Load();

                BackupManager.RunBackup(config);
            }
            catch
            {
                // Optional:
                // write log file here
            }
        }
    }
}
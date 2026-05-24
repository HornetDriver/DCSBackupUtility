using Microsoft.Win32.TaskScheduler;
using System.Diagnostics;

namespace DCSBackupUtility
{
    public static class BackupTaskScheduler
    {
        private const string TaskName = "DCS Backup Utility Scheduled Backup";

        public static void CreateOrUpdateTask(string frequency)
        {
            using TaskService ts = new TaskService();

            TaskDefinition td = ts.NewTask();

            td.RegistrationInfo.Description =
                "Runs DCS Backup Utility silently in the background.";

            td.Principal.LogonType = TaskLogonType.InteractiveToken;
            td.Principal.RunLevel = TaskRunLevel.LUA;

            td.Settings.Hidden = true;
            td.Settings.StartWhenAvailable = true;
            td.Settings.DisallowStartIfOnBatteries = false;
            td.Settings.StopIfGoingOnBatteries = false;

            Trigger trigger = frequency switch
            {
                "Weekly" => new WeeklyTrigger
                {
                    DaysOfWeek = DaysOfTheWeek.Sunday,
                    StartBoundary = DateTime.Today.AddHours(3)
                },

                "Monthly" => new MonthlyTrigger
                {
                    DaysOfMonth = new int[] { 1 },
                    StartBoundary = DateTime.Today.AddHours(3)
                },

                _ => new DailyTrigger
                {
                    DaysInterval = 1,
                    StartBoundary = DateTime.Today.AddHours(3)
                }
            };

            td.Triggers.Add(trigger);

            string exePath =
                Process.GetCurrentProcess().MainModule!.FileName!;

            td.Actions.Add(new ExecAction(
                exePath,
                "--backup --silent",
                Path.GetDirectoryName(exePath)
            ));

            ts.RootFolder.RegisterTaskDefinition(
                TaskName,
                td,
                TaskCreation.CreateOrUpdate,
                null,
                null,
                TaskLogonType.InteractiveToken
            );
        }

        public static void DeleteTask()
        {
            using TaskService ts = new TaskService();

            if (ts.GetTask(TaskName) != null)
            {
                ts.RootFolder.DeleteTask(TaskName, false);
            }
        }
    }
}
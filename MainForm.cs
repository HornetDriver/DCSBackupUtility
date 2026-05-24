using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DCSBackupUtility
{
    public partial class MainForm : Form
    {
        private readonly AppConfig _config;

        public MainForm()
        {
            InitializeComponent();

            _config = AppConfig.Load();

            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            txtPrimaryBackup.Text = _config.BackupPath;
            txtSecondaryBackup.Text = _config.SecondaryBackupPath;

            cmbScheduleFrequency.Items.Clear();
            cmbScheduleFrequency.Items.AddRange(new[]
            {
                "Daily",
                "Weekly",
                "Monthly"
            });

            cmbScheduleFrequency.SelectedItem = _config.BackupFrequency;

            numPrimaryRetention.Value = _config.PrimaryRetentionCount;
            numSecondaryRetention.Value = _config.SecondaryRetentionCount;

            checkedListPaths.Items.Clear();

            string[] items =
            {
                @"Config\Input",
                @"Config\options.lua",
                @"MissionEditor\logbook.lua",
                @"Kneeboard",
                @"Missions",
                @"Liveries",
                @"Scripts",
                @"Tracks",
                @"Screenshots"
            };

            foreach (string item in items)
            {
                bool isChecked = _config.SelectedBackupItems.Contains(item);
                checkedListPaths.Items.Add(item, isChecked);
            }

            numSecondaryRetention.Enabled =
                !string.IsNullOrWhiteSpace(txtSecondaryBackup.Text);
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            _config.BackupPath = txtPrimaryBackup.Text;
            _config.SecondaryBackupPath = txtSecondaryBackup.Text;

            _config.BackupFrequency =
                cmbScheduleFrequency.SelectedItem?.ToString() ?? "Daily";

            _config.PrimaryRetentionCount =
                (int)numPrimaryRetention.Value;

            _config.SecondaryRetentionCount =
                (int)numSecondaryRetention.Value;

            _config.SelectedBackupItems.Clear();

            foreach (object checkedItem in checkedListPaths.CheckedItems)
            {
                _config.SelectedBackupItems.Add(checkedItem.ToString()!);
            }

            _config.Save();
            if (chkScheduledBackup.Checked)
            {
                BackupTaskScheduler.CreateOrUpdateTask(
                    cmbScheduleFrequency.SelectedItem?.ToString() ?? "Daily"
                );

                MessageBox.Show("Scheduled task created or updated.");
            }
            else
            {
                BackupTaskScheduler.DeleteTask();
            }

            MessageBox.Show("Configuration saved.");
        }

        private async void btnRunBackup_Click(object? sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Running backup...";
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 30;
                btnRunBackup.Enabled = false;

                await Task.Run(() =>
                {
                    BackupManager.RunBackup(_config);
                });

                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Value = 100;
                lblStatus.Text = "Backup completed.";

                MessageBox.Show("Backup completed successfully.");
            }
            catch (Exception ex)
            {
                progressBar.Style = ProgressBarStyle.Blocks;
                lblStatus.Text = "Backup failed.";

                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnRunBackup.Enabled = true;
            }
        }

        private void btnBrowsePrimary_Click(object? sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPrimaryBackup.Text = dialog.SelectedPath;
            }
        }

        private void btnBrowseSecondary_Click(object? sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtSecondaryBackup.Text = dialog.SelectedPath;

                numSecondaryRetention.Enabled =
                    !string.IsNullOrWhiteSpace(txtSecondaryBackup.Text);
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbScheduleFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReadMe_Click(object sender, EventArgs e)
        {
            string readmePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "README.md");

            if (!File.Exists(readmePath))
            {
                MessageBox.Show("README.md was not found.");
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = readmePath,
                UseShellExecute = true
            });
        }
    }
}

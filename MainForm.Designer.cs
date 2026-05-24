namespace DCSBackupUtility
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnSave = new Button();
            btnRunBackup = new Button();
            btnBrowsePrimary = new Button();
            btnBrowseSecondary = new Button();
            txtPrimaryBackup = new TextBox();
            txtSecondaryBackup = new TextBox();
            cmbScheduleFrequency = new ComboBox();
            numPrimaryRetention = new NumericUpDown();
            numSecondaryRetention = new NumericUpDown();
            checkedListPaths = new CheckedListBox();
            lblStatus = new Label();
            progressBar = new ProgressBar();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            chkScheduledBackup = new CheckBox();
            btnReadMe = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numPrimaryRetention).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSecondaryRetention).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(45, 311);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Config";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRunBackup
            // 
            btnRunBackup.Location = new Point(147, 311);
            btnRunBackup.Name = "btnRunBackup";
            btnRunBackup.Size = new Size(162, 23);
            btnRunBackup.TabIndex = 1;
            btnRunBackup.Text = "Run on demand backup";
            btnRunBackup.UseVisualStyleBackColor = true;
            btnRunBackup.Click += btnRunBackup_Click;
            // 
            // btnBrowsePrimary
            // 
            btnBrowsePrimary.Location = new Point(45, 135);
            btnBrowsePrimary.Name = "btnBrowsePrimary";
            btnBrowsePrimary.Size = new Size(75, 23);
            btnBrowsePrimary.TabIndex = 2;
            btnBrowsePrimary.Text = "Primary";
            btnBrowsePrimary.UseVisualStyleBackColor = true;
            btnBrowsePrimary.Click += btnBrowsePrimary_Click;
            // 
            // btnBrowseSecondary
            // 
            btnBrowseSecondary.Location = new Point(45, 180);
            btnBrowseSecondary.Name = "btnBrowseSecondary";
            btnBrowseSecondary.Size = new Size(75, 23);
            btnBrowseSecondary.TabIndex = 3;
            btnBrowseSecondary.Text = "Secondary";
            btnBrowseSecondary.UseVisualStyleBackColor = true;
            btnBrowseSecondary.Click += btnBrowseSecondary_Click;
            // 
            // txtPrimaryBackup
            // 
            txtPrimaryBackup.Location = new Point(126, 136);
            txtPrimaryBackup.Name = "txtPrimaryBackup";
            txtPrimaryBackup.Size = new Size(225, 23);
            txtPrimaryBackup.TabIndex = 4;
            // 
            // txtSecondaryBackup
            // 
            txtSecondaryBackup.Location = new Point(126, 178);
            txtSecondaryBackup.Name = "txtSecondaryBackup";
            txtSecondaryBackup.Size = new Size(225, 23);
            txtSecondaryBackup.TabIndex = 5;
            // 
            // cmbScheduleFrequency
            // 
            cmbScheduleFrequency.FormattingEnabled = true;
            cmbScheduleFrequency.Location = new Point(379, 216);
            cmbScheduleFrequency.Name = "cmbScheduleFrequency";
            cmbScheduleFrequency.Size = new Size(121, 23);
            cmbScheduleFrequency.TabIndex = 6;
            cmbScheduleFrequency.SelectedIndexChanged += cmbScheduleFrequency_SelectedIndexChanged;
            // 
            // numPrimaryRetention
            // 
            numPrimaryRetention.Location = new Point(379, 135);
            numPrimaryRetention.Name = "numPrimaryRetention";
            numPrimaryRetention.Size = new Size(120, 23);
            numPrimaryRetention.TabIndex = 7;
            // 
            // numSecondaryRetention
            // 
            numSecondaryRetention.Location = new Point(379, 178);
            numSecondaryRetention.Name = "numSecondaryRetention";
            numSecondaryRetention.Size = new Size(120, 23);
            numSecondaryRetention.TabIndex = 8;
            // 
            // checkedListPaths
            // 
            checkedListPaths.FormattingEnabled = true;
            checkedListPaths.Location = new Point(505, 101);
            checkedListPaths.Name = "checkedListPaths";
            checkedListPaths.Size = new Size(174, 220);
            checkedListPaths.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(180, 247);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status";
            lblStatus.Click += lblStatus_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(45, 265);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(349, 23);
            progressBar.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.DCSBackupUtil;
            pictureBox1.Location = new Point(45, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(111, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(263, 27);
            label1.Name = "label1";
            label1.Size = new Size(207, 30);
            label1.TabIndex = 13;
            label1.Text = "DCS Backup Utility";
            label1.UseMnemonic = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(379, 101);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 14;
            label2.Text = "# Backups to keep";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(198, 101);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 15;
            label3.Text = "Location";
            // 
            // chkScheduledBackup
            // 
            chkScheduledBackup.AutoSize = true;
            chkScheduledBackup.Location = new Point(45, 220);
            chkScheduledBackup.Name = "chkScheduledBackup";
            chkScheduledBackup.Size = new Size(144, 19);
            chkScheduledBackup.TabIndex = 17;
            chkScheduledBackup.Text = "Create Scheduled Task";
            chkScheduledBackup.UseVisualStyleBackColor = true;
            // 
            // btnReadMe
            // 
            btnReadMe.Location = new Point(315, 311);
            btnReadMe.Name = "btnReadMe";
            btnReadMe.Size = new Size(75, 23);
            btnReadMe.TabIndex = 18;
            btnReadMe.Text = "README";
            btnReadMe.UseVisualStyleBackColor = true;
            btnReadMe.Click += btnReadMe_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(311, 219);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 19;
            label4.Text = "Frequency";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 356);
            Controls.Add(label4);
            Controls.Add(btnReadMe);
            Controls.Add(chkScheduledBackup);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(progressBar);
            Controls.Add(lblStatus);
            Controls.Add(checkedListPaths);
            Controls.Add(numSecondaryRetention);
            Controls.Add(numPrimaryRetention);
            Controls.Add(cmbScheduleFrequency);
            Controls.Add(txtSecondaryBackup);
            Controls.Add(txtPrimaryBackup);
            Controls.Add(btnBrowseSecondary);
            Controls.Add(btnBrowsePrimary);
            Controls.Add(btnRunBackup);
            Controls.Add(btnSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "DCS Backup Utility";
            ((System.ComponentModel.ISupportInitialize)numPrimaryRetention).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSecondaryRetention).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbScheduleFrequency;
        private NumericUpDown numPrimaryRetention;
        private NumericUpDown numSecondaryRetention;
        private CheckedListBox checkedListPaths;
        private Button btnSave;
        private Button btnRunBackup;
        private Button btnBrowsePrimary;
        private Button btnBrowseSecondary;
        private TextBox txtPrimaryBackup;
        private TextBox txtSecondaryBackup;
        private Label lblStatus;
        private ProgressBar progressBar;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox chkScheduledBackup;
        private Button btnReadMe;
        private Label label4;
    }
}
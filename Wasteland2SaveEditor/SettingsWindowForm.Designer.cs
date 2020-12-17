
namespace Wasteland2SaveEditor
{
    partial class SettingsWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindowForm));
            this.checkBox_enableBackups = new System.Windows.Forms.CheckBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_applyChanges = new System.Windows.Forms.Button();
            this.textBox_defaultSaveGames = new System.Windows.Forms.TextBox();
            this.label_appSettings = new System.Windows.Forms.Label();
            this.label_defaultSaveGames = new System.Windows.Forms.Label();
            this.button_defaultSaveGamesBrowse = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_cheatMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox_enableBackups
            // 
            this.checkBox_enableBackups.AutoSize = true;
            this.checkBox_enableBackups.Location = new System.Drawing.Point(12, 107);
            this.checkBox_enableBackups.Name = "checkBox_enableBackups";
            this.checkBox_enableBackups.Size = new System.Drawing.Size(167, 19);
            this.checkBox_enableBackups.TabIndex = 0;
            this.checkBox_enableBackups.Text = "Create .backup file on save";
            this.checkBox_enableBackups.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(235, 197);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_applyChanges
            // 
            this.button_applyChanges.Location = new System.Drawing.Point(397, 197);
            this.button_applyChanges.Name = "button_applyChanges";
            this.button_applyChanges.Size = new System.Drawing.Size(75, 23);
            this.button_applyChanges.TabIndex = 2;
            this.button_applyChanges.Text = "Apply";
            this.button_applyChanges.UseVisualStyleBackColor = true;
            this.button_applyChanges.Click += new System.EventHandler(this.button_applyChanges_Click);
            // 
            // textBox_defaultSaveGames
            // 
            this.textBox_defaultSaveGames.Location = new System.Drawing.Point(12, 59);
            this.textBox_defaultSaveGames.Name = "textBox_defaultSaveGames";
            this.textBox_defaultSaveGames.Size = new System.Drawing.Size(379, 23);
            this.textBox_defaultSaveGames.TabIndex = 3;
            // 
            // label_appSettings
            // 
            this.label_appSettings.AutoSize = true;
            this.label_appSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_appSettings.Location = new System.Drawing.Point(12, 9);
            this.label_appSettings.Name = "label_appSettings";
            this.label_appSettings.Size = new System.Drawing.Size(53, 15);
            this.label_appSettings.TabIndex = 4;
            this.label_appSettings.Text = "Settings";
            // 
            // label_defaultSaveGames
            // 
            this.label_defaultSaveGames.AutoSize = true;
            this.label_defaultSaveGames.Location = new System.Drawing.Point(12, 41);
            this.label_defaultSaveGames.Name = "label_defaultSaveGames";
            this.label_defaultSaveGames.Size = new System.Drawing.Size(154, 15);
            this.label_defaultSaveGames.TabIndex = 5;
            this.label_defaultSaveGames.Text = "Save Games folder directory";
            // 
            // button_defaultSaveGamesBrowse
            // 
            this.button_defaultSaveGamesBrowse.Location = new System.Drawing.Point(397, 59);
            this.button_defaultSaveGamesBrowse.Name = "button_defaultSaveGamesBrowse";
            this.button_defaultSaveGamesBrowse.Size = new System.Drawing.Size(75, 23);
            this.button_defaultSaveGamesBrowse.TabIndex = 6;
            this.button_defaultSaveGamesBrowse.Text = "Browse...";
            this.button_defaultSaveGamesBrowse.UseVisualStyleBackColor = true;
            this.button_defaultSaveGamesBrowse.Click += new System.EventHandler(this.button_defaultSaveGamesBrowse_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(316, 197);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_cheatMode
            // 
            this.checkBox_cheatMode.AutoSize = true;
            this.checkBox_cheatMode.Location = new System.Drawing.Point(12, 149);
            this.checkBox_cheatMode.Name = "checkBox_cheatMode";
            this.checkBox_cheatMode.Size = new System.Drawing.Size(127, 19);
            this.checkBox_cheatMode.TabIndex = 8;
            this.checkBox_cheatMode.Text = "Enable cheat mode";
            this.checkBox_cheatMode.UseVisualStyleBackColor = true;
            // 
            // SettingsWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 232);
            this.Controls.Add(this.checkBox_cheatMode);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_defaultSaveGamesBrowse);
            this.Controls.Add(this.label_defaultSaveGames);
            this.Controls.Add(this.label_appSettings);
            this.Controls.Add(this.textBox_defaultSaveGames);
            this.Controls.Add(this.button_applyChanges);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.checkBox_enableBackups);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wasteland 2 Save Editor - Application Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_enableBackups;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_applyChanges;
        private System.Windows.Forms.TextBox textBox_defaultSaveGames;
        private System.Windows.Forms.Label label_appSettings;
        private System.Windows.Forms.Label label_defaultSaveGames;
        private System.Windows.Forms.Button button_defaultSaveGamesBrowse;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkBox_cheatMode;
    }
}
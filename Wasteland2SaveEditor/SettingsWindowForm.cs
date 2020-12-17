using System;
using System.IO;
using System.Windows.Forms;
using Wasteland2SaveEditor.Editor;

namespace Wasteland2SaveEditor
{
    public partial class SettingsWindowForm : Form
    {
        private AppConfig config;

        public SettingsWindowForm(AppConfig config)
        {
            this.config = config;

            InitializeComponent();

            textBox_defaultSaveGames.Text = config.DefaultSavePath;
            checkBox_enableBackups.Checked = config.BackupEnabled;
            checkBox_cheatMode.Checked = config.CheatModeEnabled;
        }

        private void button_applyChanges_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            ApplySettings();
            Close();
        }

        private void button_defaultSaveGamesBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog openFolderBrowser = new FolderBrowserDialog())
            {
                if (Directory.Exists(config.DefaultSavePath))
                {
                    openFolderBrowser.SelectedPath = config.DefaultSavePath + "\\";
                }
                else
                {
                    openFolderBrowser.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }

                if (openFolderBrowser.ShowDialog() == DialogResult.OK)
                {
                    textBox_defaultSaveGames.Text = openFolderBrowser.SelectedPath + "\\";
                }
            }
        }

        private void ApplySettings()
        {
            config.DefaultSavePath = textBox_defaultSaveGames.Text;
            config.BackupEnabled = checkBox_enableBackups.Checked;
            config.CheatModeEnabled = checkBox_cheatMode.Checked;

            config.SaveSettings();
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Editor
{
    public class AppConfig
    {
        private const string settingsFileName = "settings.cfg";

        private string filePath;
        private string dataString;

        private bool cheatModeEnabled;

        public string DefaultSavePath { get; set; }
        public bool BackupEnabled { get; set; }
        public bool CheatModeEnabled 
        {
            get => cheatModeEnabled; 
            set 
            {
                cheatModeEnabled = value;
                onCheatModeChange?.Invoke(CheatModeEnabled); 
            } 
        }

        public Action<bool> onCheatModeChange;

        public AppConfig()
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory + settingsFileName;

            if (File.Exists(filePath))
            {
                dataString = File.ReadAllText(filePath);
            }
            else
            {
                WriteDefaultFile();
            }

            dataString = dataString.Trim(' ');

            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                DefaultSavePath = GetValue("saveDir");
                BackupEnabled = bool.Parse(GetValue("enableBackup"));
                CheatModeEnabled = bool.Parse(GetValue("cheatMode"));
            }
            catch
            {
                WriteDefaultFile();
                LoadSettings();
            }
        }

        public void SaveSettings()
        {
            dataString = string.Empty;

            SetValue("saveDir", DefaultSavePath);
            SetValue("enableBackup", BackupEnabled.ToString());
            SetValue("cheatMode", CheatModeEnabled.ToString());

            File.WriteAllText(filePath, dataString);
        }

        private void SetValue(string key, string value)
        {
            if (HasKey(key))
            {
                UpdateLine(key, value);
            }
            else
            {
                WriteLine(key, value);
            }

            File.WriteAllText(filePath, dataString);
        }

        private bool HasKey(string key)
        {
            return dataString.Contains(key);
        }

        private string GetValue(string key)
        {
            string line = ReadLine(key);

            line = line.TrimEnd("\n");
            line = line.TrimEnd("\r");
            line = line.TrimStart($"{key}=");

            return line;
        }

        private string ReadLine(string key)
        {
            return GetLine(GetAllLines(dataString), key);
        }

        private string GetLine(string[] allLines, string key)
        {
            for (int i = 0; i < allLines.Length; i++)
            {
                if (allLines[i].Contains($"{key}="))
                {
                    return allLines[i];
                }
            }

            return string.Empty;
        }

        private string[] GetAllLines(string data)
        {
            List<string> subStrings1 = data.Split("\r\n").ToList();
            List<string> subStrings2 = data.Split("\r").ToList();
            List<string> subStrings3 = data.Split("\n").ToList();

            subStrings1.RemoveAll(item => string.IsNullOrEmpty(item));
            subStrings2.RemoveAll(item => string.IsNullOrEmpty(item));
            subStrings3.RemoveAll(item => string.IsNullOrEmpty(item));

            List<List<string>> substrings = new List<List<string>>() { subStrings1, subStrings2, subStrings3 };

            int longestListIndex = 0;

            for (int i = 0; i < substrings.Count; i++)
            {
                if (substrings[i].Count > substrings[longestListIndex].Count)
                {
                    longestListIndex = i;
                }
            }

            return substrings[longestListIndex].ToArray();
        }

        private void WriteLine(string key, string value)
        {
            dataString += $"{key}={value}\n";
        }

        private void UpdateLine(string key, string newValue)
        {
            string line = ReadLine(key);
            string newLine = $"{key}={newValue}";
            dataString = dataString.Replace(line, newLine);
        }

        private void WriteDefaultFile()
        {
            dataString = string.Empty;
            WriteLine("saveDir", $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\My Games\\Wasteland2DC\\Save Games\\");
            WriteLine("enableBackup", $"{true}");
            WriteLine("cheatMode", $"{false}");

            File.WriteAllText(filePath, dataString);
        }
    }
}

using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Wasteland2SaveEditor.Character;
using Wasteland2SaveEditor.Collections;
using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Editor
{
    public class SaveEditor
    {
        private List<PlayerCharacter> characters = new List<PlayerCharacter>();

        private string saveFolder;
        private string savePath;

        private string dataString;

        private AppConfig config;

        public string LoadedSavePath { get => savePath; }
        public AppConfig Config { get => config; }

        public List<PlayerCharacter> Characters { get => characters; }
        public Flags Flags { get; private set; }
        public Perks Perks { get; private set; }
        public Quirks Quirks { get; private set; }

        public SaveEditor()
        {
            config = new AppConfig();
        }

        public bool LoadFile()
        {
            saveFolder = config.DefaultSavePath;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (Directory.Exists(saveFolder))
                {
                    openFileDialog.InitialDirectory = saveFolder;
                }
                else
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }

                openFileDialog.Filter = "XML save files (*.xml)|*.xml";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var stream = openFileDialog.OpenFile();

                    savePath = openFileDialog.FileName;

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataString = reader.ReadToEnd();
                    }
                }
                else
                {
                    return false;
                }
            }

            dataString = dataString.Replace("", "\n", "\r", "\t");

            Flags = new Flags();
            Perks = new Perks();
            Quirks = new Quirks();

            characters = CreatePCs(dataString, new Data(Flags, Perks, Quirks));

            return true;
        }

        public bool RestoreFile()
        {
            saveFolder = config.DefaultSavePath;
            string backupPath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (Directory.Exists(saveFolder))
                {
                    openFileDialog.InitialDirectory = saveFolder;
                }
                else
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }

                openFileDialog.Filter = "Save backup files (*.backup)|*.backup";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    backupPath = openFileDialog.FileName;
                }
                else
                {
                    return false;
                }
            }

            RestoreFromBackup(backupPath);

            return true;
        }

        public void SaveFile()
        {
            if (config.BackupEnabled)
            {
                CreateBackup();
            }

            string saveString = "";

            for (int i = 0; i < characters.Count; i++)
            {
                saveString += characters[i].Data;
            }

            dataString = dataString.InsertBetween(Flags.pcs.Start, Flags.pcs.End, saveString);

            File.WriteAllText(savePath, dataString);
        }

        private void CreateBackup()
        {
            DateTime now = DateTime.Now;

            string date = $"{now.Day.ToString().PadLeft(2,'0')}-{now.Month.ToString().PadLeft(2, '0')}-{now.Year}";

            string backupPath = savePath.Remove(savePath.LastIndexOf('.')) + $"_{now.Hour}.{now.Minute}.{now.Second}-{date}.backup";

            File.Copy(savePath, backupPath, false);
        }

        private void RestoreFromBackup(string backupPath)
        {
            int indexOfBackupSuffix = backupPath.LastIndexOf("_");

            string restoredSavePath = backupPath.Remove(indexOfBackupSuffix) + ".xml";

            File.Copy(backupPath, restoredSavePath, true);
        }

        private List<PlayerCharacter> CreatePCs(string saveDataString, Data data)
        {
            Flags flags = data.flags;

            List<PlayerCharacter> characters = new List<PlayerCharacter>();

            int startIndex = saveDataString.IndexOf(flags.pcs.Start) + flags.pcs.Start.Length;
            int endIndex = saveDataString.IndexOf(flags.pcs.End);

            string substring = saveDataString.Substring(startIndex, endIndex - startIndex);

            string[] characterDataStrings = substring.Split(flags.pc.End + flags.pc.Start);

            characterDataStrings[0] = characterDataStrings[0].TrimStart(flags.pc.Start);
            characterDataStrings[characterDataStrings.Length - 1] = characterDataStrings[characterDataStrings.Length - 1].TrimEnd(flags.pc.End);

            for (int i = 0; i < characterDataStrings.Length; i++)
            {
                characters.Add(new PlayerCharacter(characterDataStrings[i], i, data));
            }

            return characters;
        }
    }
}

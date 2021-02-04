using System;
using System.Collections.Generic;
using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Character
{
    public class CharacterSkills
    {
        private readonly Flag skillFlag = new Flag("skillXps");
        private readonly Flag pairFlag = new Flag("pair");
        private readonly Flag keyFlag = new Flag("key");
        private readonly Flag valueFlag = new Flag("value");

        // 31 is the number of skills in the game
        private readonly Skill[] all = new Skill[31];

        private readonly Dictionary<string, string> keyToDisplayName = new Dictionary<string, string>()
        {
            { "alarmDisarm",        "Alarm Disarming" },
            { "animalWhisperer",    "Animal Whisperer" },
            { "atWeapons",          "Heavy Weapons" },
            { "barter",             "Barter" },
            { "bladedWeapons",      "Bladed Weapons" },
            { "bluntWeapons",       "Blunt Weapons" },
            { "brawling",           "Brawling" },
            { "bruteForce",         "Brute Force" },
            { "calvinBackerSkill",  "Southwestern Folklore" },
            { "combatShooting",     "Combat Shooting" },
            { "computerTech",       "Computer Science" },
            { "demolitions",        "Demolitions" },
            { "doctor",             "Surgeon" },
            { "energyWeapons",      "Energy Weapons" },
            { "fieldMedic",         "Field Medic" },
            { "handgun",            "Handguns" },
            { "intimidate",         "Hard Ass" },
            { "leadership",         "Leadership" },
            { "manipulate",         "Smart Ass" },
            { "mechanicalRepair",   "Mechanical Repair" },
            { "outdoorsman",        "Outdoorsman" },
            { "perception",         "Perception" },
            { "pickLock",           "Lockpicking" },
            { "rifle",              "Assault Rifles" },
            { "safecrack",          "Safecracking" },
            { "shotgun",            "Shotguns" },
            { "smg",                "Submachine Guns" },
            { "sniperRifle",        "Sniper Rifles" },
            { "spotLie",            "Kiss Ass" },
            { "toasterRepair",      "Toaster Repair" },
            { "weaponSmith",        "Weaponsmithing" }
        };
        private readonly Dictionary<string, int> keyToIndex = new Dictionary<string, int>()
        {
            { "alarmDisarm",        0 },
            { "animalWhisperer",    1 },
            { "atWeapons",          2 },
            { "barter",             3 },
            { "bladedWeapons",      4 },
            { "bluntWeapons",       5 },
            { "brawling",           6 },
            { "bruteForce",         7 },
            { "calvinBackerSkill",  8 },
            { "combatShooting",     9 },
            { "computerTech",       10 },
            { "demolitions",        11 },
            { "doctor",             12 },
            { "energyWeapons",      13 },
            { "fieldMedic",         14 },
            { "handgun",            15 },
            { "intimidate",         16 },
            { "leadership",         17 },
            { "manipulate",         18 },
            { "mechanicalRepair",   19 },
            { "outdoorsman",        20 },
            { "perception",         21 },
            { "pickLock",           22 },
            { "rifle",              23 },
            { "safecrack",          24 },
            { "shotgun",            25 },
            { "smg",                26 },
            { "sniperRifle",        27 },
            { "spotLie",            28 },
            { "toasterRepair",      29 },
            { "weaponSmith",        30 }
        };

        #region Skills
        public Skill AlarmDisarming { get => all[0]; }
        public Skill AnimalWhisperer { get => all[1]; }
        public Skill HeavyWeapons { get => all[2]; }
        public Skill Barter { get => all[3]; }
        public Skill BladedWeapons { get => all[4]; }
        public Skill BluntWeapons { get => all[5]; }
        public Skill Brawling { get => all[6]; }
        public Skill BruteForce { get => all[7]; }
        public Skill SouthwesternFolklore { get => all[8]; }
        public Skill CombatShooting { get => all[9]; }
        public Skill ComputerScience { get => all[10]; }
        public Skill Demolitions { get => all[11]; }
        public Skill Surgeon { get => all[12]; }
        public Skill EnergyWeapons { get => all[13]; }
        public Skill FieldMedic { get => all[14]; }
        public Skill Handguns { get => all[15]; }
        public Skill HardAss { get => all[16]; }
        public Skill Leadership { get => all[17]; }
        public Skill SmartAss { get => all[18]; }
        public Skill MechanicalRepair { get => all[19]; }
        public Skill Outdoorsman { get => all[20]; }
        public Skill Perception { get => all[21]; }
        public Skill Lockpicking { get => all[22]; }
        public Skill AssaultRifles { get => all[23]; }
        public Skill Safecracking { get => all[24]; }
        public Skill Shotguns { get => all[25]; }
        public Skill SubmachineGuns { get => all[26]; }
        public Skill SniperRifles { get => all[27]; }
        public Skill KissAss { get => all[28]; }
        public Skill ToasterRepair { get => all[29]; }
        public Skill Weaponsmithing { get => all[30]; }
        #endregion

        public Skill[] All { get => all; }

        public string Data
        {
            get
            {
                string data = "";

                for (int i = 0; i < all.Length; i++)
                {
                    data += all[i].Data;
                }

                return data;
            }
        }

        public int MaximumSkillPointCount
        {
            get
            {
                int count = 0;

                foreach (Skill skill in all)
                {
                    count += skill.MaximumPoints;
                }

                return count;
            }
        }

        public CharacterSkills(string data)
        {
            // find the skills in the data string and split them up into seperate strings
            string allSkillsString = data.GetBetween(skillFlag.Start, skillFlag.End);
            string[] skillStrings = allSkillsString.Split(pairFlag.End + pairFlag.Start);

            // loop through all the created strings and set the value of the all array
            for (int i = 0; i < all.Length; i++)
            {
                string key = skillStrings[i].GetBetween(keyFlag.Start, keyFlag.End);
                int value = int.Parse(skillStrings[i].GetBetween(valueFlag.Start, valueFlag.End));

                all[keyToIndex[key]] = new Skill(key, value, keyToDisplayName[key], keyToIndex[key]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Character
{
    public class CharacterSkills
    {
        private Flag skillFlag = new Flag("skillXps");
        private Flag pairFlag = new Flag("pair");
        private Flag valueFlag = new Flag("value");

        private List<Skill> all = new List<Skill>();

        private List<Skill> generalSkills = new List<Skill>();
        private List<Skill> weaponSkills = new List<Skill>();
        private List<Skill> knowledgeSkills = new List<Skill>();

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

        public List<Skill> All { get => all; }
        public List<Skill> GeneralSkills { get => generalSkills; }
        public List<Skill> WeaponSkills { get => weaponSkills; }
        public List<Skill> KnowledgeSkills { get => knowledgeSkills; }

        public string Data
        {
            get
            {
                string data = "";

                for (int i = 0; i < all.Count; i++)
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

        public CharacterSkills(string rawCharacterData)
        {
            string skillsDataString = rawCharacterData.GetBetween(skillFlag.Start, skillFlag.End);

            string[] skillsData = skillsDataString.Split(pairFlag.End + pairFlag.Start);
            skillsData[0].TrimStart(pairFlag.Start);
            skillsData[skillsData.Length - 1].TrimEnd(pairFlag.End);

            #region Add skills to list of all skills
            all.Add(new Skill("alarmDisarm", int.Parse(skillsData[0].GetBetween(valueFlag.Start, valueFlag.End)), "Alarm Disarming", 0));
            all.Add(new Skill("animalWhisperer", int.Parse(skillsData[1].GetBetween(valueFlag.Start, valueFlag.End)), "Animal Whisperer", 1));
            all.Add(new Skill("atWeapons", int.Parse(skillsData[2].GetBetween(valueFlag.Start, valueFlag.End)), "Heavy Weapons", 2));
            all.Add(new Skill("barter", int.Parse(skillsData[3].GetBetween(valueFlag.Start, valueFlag.End)), "Barter", 3));
            all.Add(new Skill("bladedWeapons", int.Parse(skillsData[4].GetBetween(valueFlag.Start, valueFlag.End)), "Bladed Weapons", 4));
            all.Add(new Skill("bluntWeapons", int.Parse(skillsData[5].GetBetween(valueFlag.Start, valueFlag.End)), "Blunt Weapons", 5));
            all.Add(new Skill("brawling", int.Parse(skillsData[6].GetBetween(valueFlag.Start, valueFlag.End)), "Brawling", 6));
            all.Add(new Skill("bruteForce", int.Parse(skillsData[7].GetBetween(valueFlag.Start, valueFlag.End)), "Brute Force", 7));
            all.Add(new Skill("calvinBackerSkill", int.Parse(skillsData[8].GetBetween(valueFlag.Start, valueFlag.End)), "Southwestern Folklore", 8));
            all.Add(new Skill("combatShooting", int.Parse(skillsData[9].GetBetween(valueFlag.Start, valueFlag.End)), "Combat Shooting", 9));
            all.Add(new Skill("computerTech", int.Parse(skillsData[10].GetBetween(valueFlag.Start, valueFlag.End)), "Computer Science", 10));
            all.Add(new Skill("demolitions", int.Parse(skillsData[11].GetBetween(valueFlag.Start, valueFlag.End)), "Demolitions", 11));
            all.Add(new Skill("doctor", int.Parse(skillsData[12].GetBetween(valueFlag.Start, valueFlag.End)), "Surgeon", 12));
            all.Add(new Skill("energyWeapons", int.Parse(skillsData[13].GetBetween(valueFlag.Start, valueFlag.End)), "Energy Weapons", 13));
            all.Add(new Skill("fieldMedic", int.Parse(skillsData[14].GetBetween(valueFlag.Start, valueFlag.End)), "Field Medic", 14));
            all.Add(new Skill("handgun", int.Parse(skillsData[15].GetBetween(valueFlag.Start, valueFlag.End)), "Handguns", 15));
            all.Add(new Skill("intimidate", int.Parse(skillsData[16].GetBetween(valueFlag.Start, valueFlag.End)), "Hard Ass", 16));
            all.Add(new Skill("leadership", int.Parse(skillsData[17].GetBetween(valueFlag.Start, valueFlag.End)), "Leadership", 17));
            all.Add(new Skill("manipulate", int.Parse(skillsData[18].GetBetween(valueFlag.Start, valueFlag.End)), "Smart Ass", 18));
            all.Add(new Skill("mechanicalRepair", int.Parse(skillsData[19].GetBetween(valueFlag.Start, valueFlag.End)), "Mechanical Repair", 19));
            all.Add(new Skill("outdoorsman", int.Parse(skillsData[20].GetBetween(valueFlag.Start, valueFlag.End)), "Outdoorsman", 20));
            all.Add(new Skill("perception", int.Parse(skillsData[21].GetBetween(valueFlag.Start, valueFlag.End)), "Perception", 21));
            all.Add(new Skill("pickLock", int.Parse(skillsData[22].GetBetween(valueFlag.Start, valueFlag.End)), "Lockpicking", 22));
            all.Add(new Skill("rifle", int.Parse(skillsData[23].GetBetween(valueFlag.Start, valueFlag.End)), "Assault Rifles", 23));
            all.Add(new Skill("safecrack", int.Parse(skillsData[24].GetBetween(valueFlag.Start, valueFlag.End)), "Safecracking", 24));
            all.Add(new Skill("shotgun", int.Parse(skillsData[25].GetBetween(valueFlag.Start, valueFlag.End)), "Shotguns", 25));
            all.Add(new Skill("smg", int.Parse(skillsData[26].GetBetween(valueFlag.Start, valueFlag.End)), "Submachine Guns", 26));
            all.Add(new Skill("sniperRifle", int.Parse(skillsData[27].GetBetween(valueFlag.Start, valueFlag.End)), "Sniper Rifles", 27));
            all.Add(new Skill("spotLie", int.Parse(skillsData[28].GetBetween(valueFlag.Start, valueFlag.End)), "Kiss Ass", 28));
            all.Add(new Skill("toasterRepair", int.Parse(skillsData[29].GetBetween(valueFlag.Start, valueFlag.End)), "Toaster Repair", 29));
            all.Add(new Skill("weaponSmith", int.Parse(skillsData[30].GetBetween(valueFlag.Start, valueFlag.End)), "Weaponsmithing", 30));
            #endregion

            #region Add skills to list of general skills
            generalSkills.Add(AnimalWhisperer);
            generalSkills.Add(Barter);
            generalSkills.Add(BruteForce);
            generalSkills.Add(HardAss);
            generalSkills.Add(KissAss);
            generalSkills.Add(Leadership);
            generalSkills.Add(Outdoorsman);
            generalSkills.Add(Perception);
            generalSkills.Add(SmartAss);
            generalSkills.Add(Weaponsmithing);
            generalSkills.Add(SouthwesternFolklore);
            generalSkills.Add(CombatShooting);
            #endregion

            #region Add skill to list of weapon skills
            weaponSkills.Add(AssaultRifles);
            weaponSkills.Add(BladedWeapons);
            weaponSkills.Add(BluntWeapons);
            weaponSkills.Add(Brawling);
            weaponSkills.Add(EnergyWeapons);
            weaponSkills.Add(Handguns);
            weaponSkills.Add(HeavyWeapons);
            weaponSkills.Add(Shotguns);
            weaponSkills.Add(SniperRifles);
            weaponSkills.Add(SubmachineGuns);
            #endregion

            #region Add skills to list of knowledge skills
            knowledgeSkills.Add(AlarmDisarming);
            knowledgeSkills.Add(ComputerScience);
            knowledgeSkills.Add(Demolitions);
            knowledgeSkills.Add(FieldMedic);
            knowledgeSkills.Add(Lockpicking);
            knowledgeSkills.Add(MechanicalRepair);
            knowledgeSkills.Add(Safecracking);
            knowledgeSkills.Add(Surgeon);
            knowledgeSkills.Add(ToasterRepair);
            #endregion
        }
    }
}

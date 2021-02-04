using System;
using Wasteland2SaveEditor.Collections;
using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Character
{
    public class PlayerCharacter
    {
        private int index;
        private string rawData;

        private Flags flags;
        private Perks existingPerks;
        private Quirks existingQuirks;

        #region character values
        private string displayName;
        private string genderSuffix;
        private int gender;

        private CharacterAttributes attributes;
        private CharacterSkills skills;
        private CharacterTraits traits;

        private int attributePoints;
        private int skillPoints;
        private int perkPoints;
        #endregion

        public CharacterAttributes Attributes { get => attributes; }
        public CharacterSkills Skills { get => skills; }
        public CharacterTraits Traits { get => traits; }

        public int AttributePoints { get => attributePoints; set => attributePoints = value; }
        public int SkillPoints { get => skillPoints; set => skillPoints = value; }
        public int PerkPoints { get => perkPoints; set => perkPoints = value; }

        /// <summary>
        /// Save data string of the current player character.
        /// </summary>
        public string Data
        {
            get
            {
                string data = rawData;

                data = data.InsertBetween(flags.attributes.Start, flags.attributes.End, attributes.Data); // attributes data
                data = data.InsertBetween(flags.skills.Start, flags.skills.End, skills.Data); // skills data
                data = data.InsertBetween(flags.traits.Start, flags.traits.End, traits.Data); // traits data

                data = data.InsertBetween(flags.attributePoints.Start, flags.attributePoints.End, Math.Clamp(attributePoints, 0, attributes.All.Length * Attribute.maximumPoints - attributes.All.Length).ToString());
                data = data.InsertBetween(flags.skillPoints.Start, flags.skillPoints.End, Math.Clamp(skillPoints, 0, skills.All.Length * Skill.maximumPoints).ToString());
                data = data.InsertBetween(flags.traitPoints.Start, flags.traitPoints.End, Math.Clamp(perkPoints, 0, existingPerks.All.Count).ToString());

                return $"{flags.pc.Start}{data}{flags.pc.End}";
            }
        }

        public PlayerCharacter(string dataString, int index, Data data)
        {
            rawData = dataString;
            this.index = index;
            flags = data.flags;
            existingPerks = data.perks;
            existingQuirks = data.quirks;

            gender = GetDataAsInteger(dataString, flags.gender);
            genderSuffix = gender == 1 ? "{M}" : "{F}";

            attributes = new CharacterAttributes(rawData);
            skills = new CharacterSkills(rawData);
            traits = new CharacterTraits(rawData, data.perks, data.quirks);

            attributePoints = GetDataAsInteger(dataString, flags.attributePoints);
            skillPoints = GetDataAsInteger(dataString, flags.skillPoints);
            perkPoints = GetDataAsInteger(dataString, flags.traitPoints);
        }

        private int GetDataAsInteger(string dataString, Flag flag)
        {
            return int.Parse(dataString.GetBetween(flag.Start, flag.End));
        }

        /// <summary>
        /// Formatted name of the character.
        /// </summary>
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(displayName))
                {
                    displayName = rawData.GetBetween(flags.displayName.Start, flags.displayName.End);
                }

                return displayName.Replace("", "<@>", genderSuffix).InsertSpaces();
            }
        }

        /// <summary>
        /// Adds a trait to the player character. (Perks or Quirks)
        /// </summary>
        /// <param name="trait">The trait to add to the character.</param>
        public void AddTrait(Trait trait)
        {
            // if a trait was successfully added
            if (traits.Add(trait))
            {
                // if the added trait was a perk, reduce the unused perk points
                if (existingPerks.All.Contains(trait))
                {
                    perkPoints--;
                }
            }
        }

        /// <summary>
        /// Removes a trait from the player character. (Perks or Quirks)
        /// </summary>
        /// <param name="trait">The trait to remove from the character.</param>
        public void RemoveTrait(Trait trait)
        {
            // if a trait was successfully removed
            if (traits.Remove(trait))
            {
                // if the added trait was a perk, increase the unused perk points
                if (existingPerks.All.Contains(trait))
                {
                    perkPoints++;
                }
            }
        }

        /// <summary>
        /// Changes an attributes value and adjusts the amount of ability points accordingly.
        /// </summary>
        /// <param name="newLevel">The new level of the attribute.</param>
        /// <param name="attributeIndex">The index of the attribute we want to change.</param>
        public void ChangeAttributeValue(int newLevel, int attributeIndex, bool cheatMode)
        {
            int currentLevel = attributes.All[attributeIndex].Value;
            int cost = currentLevel - newLevel;

            if (currentLevel == newLevel)
                return;

            if (!cheatMode)
            {
                if (attributePoints + cost < 0)
                {
                    cost = -attributePoints;
                }

                newLevel = attributes.All[attributeIndex].Value - cost;
            }

            attributePoints += cost;

            attributes.All[attributeIndex].Value = newLevel;
        }

        /// <summary>
        /// Changes a skills level and adjusts the amount of skill points accordingly.
        /// </summary>
        /// <param name="newLevel">The new level of the skill.</param>
        /// <param name="skillIndex">The indexof the skill in the all skills list .</param>
        public void ChangeSkillLevel(int newLevel, int skillIndex, bool cheatMode = false)
        {
            int currentLevel = skills.All[skillIndex].Level;
            int cost = skills.All[skillIndex].pointsAtLevel[newLevel] - skills.All[skillIndex].pointsAtLevel[currentLevel];

            if (currentLevel == newLevel)
                return;

            if (!cheatMode)
            {
                if (skillPoints - cost < 0)
                {
                    int deltaLevel = newLevel - currentLevel;

                    cost = 0;
                    newLevel = currentLevel;

                    for (int i = 1; i <= deltaLevel; i++)
                    {
                        int newCost = skills.All[skillIndex].pointsAtLevel[currentLevel + i] - skills.All[skillIndex].pointsAtLevel[currentLevel];

                        if (skillPoints - newCost >= 0)
                        {
                            cost = newCost;
                            newLevel = currentLevel + i;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (currentLevel == newLevel)
                return;

            skills.All[skillIndex].ChangeLevel(newLevel);

            skillPoints -= cost;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

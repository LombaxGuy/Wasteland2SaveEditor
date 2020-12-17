using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Wasteland2SaveEditor.Character;
using Wasteland2SaveEditor.Editor;

namespace Wasteland2SaveEditor
{
    public partial class Wasteland2SaveEditor : Form
    {
        public static SaveEditor saveEditor;

        private const string applicationName = "Wasteland 2 Save Editor";

        private int currentCharacterIndex = 0;

        private int usedSkillPoints;
        private int maximumSkillPoints;

        private int usedAttributePoints;
        private int maximumAttributePoints;

        private int existingPerksCount;
        private int activePerksCount;

        public Wasteland2SaveEditor()
        {
            InitializeComponent();

            saveEditor = new SaveEditor();

            saveEditor.Config.onCheatModeChange += (cheatMode) => { num_attributePoints.Enabled = cheatMode; };
            saveEditor.Config.onCheatModeChange += (cheatMode) => { num_skillPoints.Enabled = cheatMode; };
            saveEditor.Config.onCheatModeChange += (cheatMode) => { num_perkPoints.Enabled = cheatMode; };
        }

        #region Attributes tab
        /// <summary>
        /// Initializes the attributes tab.
        /// </summary>
        private void InitializeAttributes()
        {
            maximumAttributePoints = 9 * 7;

            // initialize each of the 7 attributes
            num_coordination.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Coordination.Value;
            num_luck.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Luck.Value;
            num_awareness.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Awareness.Value;
            num_strength.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Strength.Value;
            num_speed.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Speed.Value;
            num_intelligence.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Intelligence.Value;
            num_charisma.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Charisma.Value;

            num_attributePoints.Enabled = saveEditor.Config.CheatModeEnabled;
        }

        /// <summary>
        /// Updates the displayed number of attributes points and sets minimum and maximum points.
        /// </summary>
        private void UpdateAttributePoints()
        {
            #region Update attribute points
            usedAttributePoints = 0;
            foreach (var attribute in saveEditor.Characters[currentCharacterIndex].Attributes.All)
            {
                usedAttributePoints += attribute.Value;
            }

            // set min and max number of perk points, adds 7 to the max as we start from 1
            num_attributePoints.Maximum = maximumAttributePoints - usedAttributePoints + 7;
            num_attributePoints.Minimum = ((maximumAttributePoints - usedAttributePoints) - maximumAttributePoints) + 7;

            num_attributePoints.Value = saveEditor.Characters[currentCharacterIndex].AttributePoints;
            #endregion
        }

        #region Click events
        private void num_attributePoints_ValueChanged(object sender, EventArgs e)
        {
            if (saveEditor.Config.CheatModeEnabled)
            {
                saveEditor.Characters[currentCharacterIndex].AttributePoints = (int)num_attributePoints.Value;
            }

            num_attributePoints.Value = saveEditor.Characters[currentCharacterIndex].AttributePoints;
        }

        private void num_coordination_ValueChanged(object sender, EventArgs e)
        {
            saveEditor.Characters[currentCharacterIndex].ChangeAttributeValue((int)num_coordination.Value, 0, saveEditor.Config.CheatModeEnabled);
            num_coordination.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Coordination.Value;

            UpdateAttributePoints();
        }

        private void num_luck_ValueChanged(object sender, EventArgs e)
        {
            saveEditor.Characters[currentCharacterIndex].ChangeAttributeValue((int)num_luck.Value, 1, saveEditor.Config.CheatModeEnabled);
            num_luck.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Luck.Value;

            UpdateAttributePoints();
        }

        private void num_awareness_ValueChanged(object sender, EventArgs e)
        {
            saveEditor.Characters[currentCharacterIndex].ChangeAttributeValue((int)num_awareness.Value, 2, saveEditor.Config.CheatModeEnabled);
            num_awareness.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Awareness.Value;

            UpdateAttributePoints();
        }

        private void num_strength_ValueChanged(object sender, EventArgs e)
        {
            saveEditor.Characters[currentCharacterIndex].ChangeAttributeValue((int)num_strength.Value, 3, saveEditor.Config.CheatModeEnabled);
            num_strength.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Strength.Value;

            UpdateAttributePoints();
        }

        private void num_speed_ValueChanged(object sender, EventArgs e)
        {
            saveEditor.Characters[currentCharacterIndex].ChangeAttributeValue((int)num_speed.Value, 4, saveEditor.Config.CheatModeEnabled);
            num_speed.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Speed.Value;

            UpdateAttributePoints();
        }

        private void num_intelligence_ValueChanged(object sender, EventArgs e)
        {
            saveEditor.Characters[currentCharacterIndex].ChangeAttributeValue((int)num_intelligence.Value, 5, saveEditor.Config.CheatModeEnabled);
            num_intelligence.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Intelligence.Value;

            UpdateAttributePoints();
        }

        private void num_charisma_ValueChanged(object sender, EventArgs e)
        {
            saveEditor.Characters[currentCharacterIndex].ChangeAttributeValue((int)num_charisma.Value, 6, saveEditor.Config.CheatModeEnabled);
            num_charisma.Value = saveEditor.Characters[currentCharacterIndex].Attributes.Charisma.Value;

            UpdateAttributePoints();
        }
        #endregion
        #endregion

        #region Skills tab
        /// <summary>
        /// Initializes the skills tab.
        /// </summary>
        private void InitializeSkills()
        {
            maximumSkillPoints = saveEditor.Characters[currentCharacterIndex].Skills.MaximumSkillPointCount;

            // initialize skill points
            num_animalWhisperer.Value = saveEditor.Characters[currentCharacterIndex].Skills.AnimalWhisperer.Level;
            num_barter.Value = saveEditor.Characters[currentCharacterIndex].Skills.Barter.Level;
            num_bruteForce.Value = saveEditor.Characters[currentCharacterIndex].Skills.BruteForce.Level;
            num_hardAss.Value = saveEditor.Characters[currentCharacterIndex].Skills.HardAss.Level;
            num_kissAss.Value = saveEditor.Characters[currentCharacterIndex].Skills.KissAss.Level;
            num_leadership.Value = saveEditor.Characters[currentCharacterIndex].Skills.Leadership.Level;
            num_outdoorsman.Value = saveEditor.Characters[currentCharacterIndex].Skills.Outdoorsman.Level;
            num_perception.Value = saveEditor.Characters[currentCharacterIndex].Skills.Perception.Level;
            num_smartAss.Value = saveEditor.Characters[currentCharacterIndex].Skills.SmartAss.Level;
            num_weaponsmithing.Value = saveEditor.Characters[currentCharacterIndex].Skills.Weaponsmithing.Level;
            num_swFolklore.Value = saveEditor.Characters[currentCharacterIndex].Skills.SouthwesternFolklore.Level;
            num_combatShooting.Value = saveEditor.Characters[currentCharacterIndex].Skills.CombatShooting.Level;

            num_assaultRifles.Value = saveEditor.Characters[currentCharacterIndex].Skills.AssaultRifles.Level;
            num_bladed.Value = saveEditor.Characters[currentCharacterIndex].Skills.BladedWeapons.Level;
            num_blunt.Value = saveEditor.Characters[currentCharacterIndex].Skills.BluntWeapons.Level;
            num_brawling.Value = saveEditor.Characters[currentCharacterIndex].Skills.Brawling.Level;
            num_energy.Value = saveEditor.Characters[currentCharacterIndex].Skills.EnergyWeapons.Level;
            num_handguns.Value = saveEditor.Characters[currentCharacterIndex].Skills.Handguns.Level;
            num_heavy.Value = saveEditor.Characters[currentCharacterIndex].Skills.HeavyWeapons.Level;
            num_shotguns.Value = saveEditor.Characters[currentCharacterIndex].Skills.Shotguns.Level;
            num_sniperRifles.Value = saveEditor.Characters[currentCharacterIndex].Skills.SniperRifles.Level;
            num_submachineGuns.Value = saveEditor.Characters[currentCharacterIndex].Skills.SubmachineGuns.Level;

            num_alarmDisarming.Value = saveEditor.Characters[currentCharacterIndex].Skills.AlarmDisarming.Level;
            num_computerScience.Value = saveEditor.Characters[currentCharacterIndex].Skills.ComputerScience.Level;
            num_demolitions.Value = saveEditor.Characters[currentCharacterIndex].Skills.Demolitions.Level;
            num_fieldMedic.Value = saveEditor.Characters[currentCharacterIndex].Skills.FieldMedic.Level;
            num_lockpicking.Value = saveEditor.Characters[currentCharacterIndex].Skills.Lockpicking.Level;
            num_mechRepair.Value = saveEditor.Characters[currentCharacterIndex].Skills.MechanicalRepair.Level;
            num_safecracking.Value = saveEditor.Characters[currentCharacterIndex].Skills.Safecracking.Level;
            num_surgeon.Value = saveEditor.Characters[currentCharacterIndex].Skills.Surgeon.Level;
            num_toasterRepair.Value = saveEditor.Characters[currentCharacterIndex].Skills.ToasterRepair.Level;

            num_skillPoints.Enabled = saveEditor.Config.CheatModeEnabled;
        }

        /// <summary>
        /// Updates the displayed skill points and updates the minimum and maximum values.
        /// </summary>
        private void UpdateSkillPoints()
        {
            usedSkillPoints = 0;
            foreach (var skill in saveEditor.Characters[currentCharacterIndex].Skills.All)
            {
                usedSkillPoints += skill.Value;
            }

            num_skillPoints.Maximum = maximumSkillPoints - usedSkillPoints;
            num_skillPoints.Minimum = -usedSkillPoints;

            num_skillPoints.Value = saveEditor.Characters[currentCharacterIndex].SkillPoints;
        }

        #region Click events
        private void num_skillPoints_ValueChanged(object sender, EventArgs e)
        {
            saveEditor.Characters[currentCharacterIndex].SkillPoints = (int)num_skillPoints.Value;
        }

        private void num_animalWhisperer_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.AnimalWhisperer.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_animalWhisperer.Value, index);
            num_animalWhisperer.Value = saveEditor.Characters[currentCharacterIndex].Skills.AnimalWhisperer.Level;

            UpdateSkillPoints();
        }

        private void num_barter_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Barter.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_barter.Value, index);
            num_barter.Value = saveEditor.Characters[currentCharacterIndex].Skills.Barter.Level;

            UpdateSkillPoints();
        }

        private void num_bruteForce_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.BruteForce.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_bruteForce.Value, index);
            num_bruteForce.Value = saveEditor.Characters[currentCharacterIndex].Skills.BruteForce.Level;

            UpdateSkillPoints();
        }

        private void num_hardAss_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.HardAss.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_hardAss.Value, index);
            num_hardAss.Value = saveEditor.Characters[currentCharacterIndex].Skills.HardAss.Level;

            UpdateSkillPoints();
        }

        private void num_kissAss_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.KissAss.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_kissAss.Value, index);
            num_kissAss.Value = saveEditor.Characters[currentCharacterIndex].Skills.KissAss.Level;

            UpdateSkillPoints();
        }

        private void num_leadership_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Leadership.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_leadership.Value, index);
            num_leadership.Value = saveEditor.Characters[currentCharacterIndex].Skills.Leadership.Level;

            UpdateSkillPoints();
        }

        private void num_outdoorsman_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Outdoorsman.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_outdoorsman.Value, index);
            num_outdoorsman.Value = saveEditor.Characters[currentCharacterIndex].Skills.Outdoorsman.Level;

            UpdateSkillPoints();
        }

        private void num_perception_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Perception.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_perception.Value, index);
            num_perception.Value = saveEditor.Characters[currentCharacterIndex].Skills.Perception.Level;

            UpdateSkillPoints();
        }

        private void num_smartAss_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.SmartAss.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_smartAss.Value, index);
            num_smartAss.Value = saveEditor.Characters[currentCharacterIndex].Skills.SmartAss.Level;

            UpdateSkillPoints();
        }

        private void num_weaponsmithing_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Weaponsmithing.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_weaponsmithing.Value, index);
            num_weaponsmithing.Value = saveEditor.Characters[currentCharacterIndex].Skills.Weaponsmithing.Level;

            UpdateSkillPoints();
        }

        private void num_swFolklore_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.SouthwesternFolklore.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_swFolklore.Value, index);
            num_swFolklore.Value = saveEditor.Characters[currentCharacterIndex].Skills.SouthwesternFolklore.Level;

            UpdateSkillPoints();
        }

        private void num_combatShooting_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.CombatShooting.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_combatShooting.Value, index);
            num_combatShooting.Value = saveEditor.Characters[currentCharacterIndex].Skills.CombatShooting.Level;

            UpdateSkillPoints();
        }

        private void num_assaultRifles_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.AssaultRifles.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_assaultRifles.Value, index);
            num_assaultRifles.Value = saveEditor.Characters[currentCharacterIndex].Skills.AssaultRifles.Level;

            UpdateSkillPoints();
        }

        private void num_bladed_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.BladedWeapons.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_bladed.Value, index);
            num_bladed.Value = saveEditor.Characters[currentCharacterIndex].Skills.BladedWeapons.Level;

            UpdateSkillPoints();
        }

        private void num_blunt_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.BluntWeapons.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_blunt.Value, index);
            num_blunt.Value = saveEditor.Characters[currentCharacterIndex].Skills.BluntWeapons.Level;

            UpdateSkillPoints();
        }

        private void num_brawling_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Brawling.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_brawling.Value, index);
            num_brawling.Value = saveEditor.Characters[currentCharacterIndex].Skills.Brawling.Level;

            UpdateSkillPoints();
        }

        private void num_energy_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.EnergyWeapons.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_energy.Value, index);
            num_energy.Value = saveEditor.Characters[currentCharacterIndex].Skills.EnergyWeapons.Level;

            UpdateSkillPoints();
        }

        private void num_handguns_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Handguns.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_handguns.Value, index);
            num_handguns.Value = saveEditor.Characters[currentCharacterIndex].Skills.Handguns.Level;

            UpdateSkillPoints();
        }

        private void num_heavy_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.HeavyWeapons.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_heavy.Value, index);
            num_heavy.Value = saveEditor.Characters[currentCharacterIndex].Skills.HeavyWeapons.Level;

            UpdateSkillPoints();
        }

        private void num_shotguns_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Shotguns.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_shotguns.Value, index);
            num_shotguns.Value = saveEditor.Characters[currentCharacterIndex].Skills.Shotguns.Level;

            UpdateSkillPoints();
        }

        private void num_sniperRifles_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.SniperRifles.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_sniperRifles.Value, index);
            num_sniperRifles.Value = saveEditor.Characters[currentCharacterIndex].Skills.SniperRifles.Level;

            UpdateSkillPoints();
        }

        private void num_submachineGuns_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.SubmachineGuns.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_submachineGuns.Value, index);
            num_submachineGuns.Value = saveEditor.Characters[currentCharacterIndex].Skills.SubmachineGuns.Level;

            UpdateSkillPoints();
        }

        private void num_alarmDisarming_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.AlarmDisarming.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_alarmDisarming.Value, index);
            num_alarmDisarming.Value = saveEditor.Characters[currentCharacterIndex].Skills.AlarmDisarming.Level;

            UpdateSkillPoints();
        }

        private void num_computerScience_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.ComputerScience.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_computerScience.Value, index);
            num_computerScience.Value = saveEditor.Characters[currentCharacterIndex].Skills.ComputerScience.Level;

            UpdateSkillPoints();
        }

        private void num_demolitions_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Demolitions.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_demolitions.Value, index);
            num_demolitions.Value = saveEditor.Characters[currentCharacterIndex].Skills.Demolitions.Level;

            UpdateSkillPoints();
        }

        private void num_fieldMedic_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.FieldMedic.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_fieldMedic.Value, index);
            num_fieldMedic.Value = saveEditor.Characters[currentCharacterIndex].Skills.FieldMedic.Level;

            UpdateSkillPoints();
        }

        private void num_lockpicking_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Lockpicking.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_lockpicking.Value, index);
            num_lockpicking.Value = saveEditor.Characters[currentCharacterIndex].Skills.Lockpicking.Level;

            UpdateSkillPoints();
        }

        private void num_mechRepair_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.MechanicalRepair.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_mechRepair.Value, index);
            num_mechRepair.Value = saveEditor.Characters[currentCharacterIndex].Skills.MechanicalRepair.Level;

            UpdateSkillPoints();
        }

        private void num_safecracking_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Safecracking.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_safecracking.Value, index);
            num_safecracking.Value = saveEditor.Characters[currentCharacterIndex].Skills.Safecracking.Level;

            UpdateSkillPoints();
        }

        private void num_surgeon_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.Surgeon.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_surgeon.Value, index);
            num_surgeon.Value = saveEditor.Characters[currentCharacterIndex].Skills.Surgeon.Level;

            UpdateSkillPoints();
        }

        private void num_toasterRepair_ValueChanged(object sender, EventArgs e)
        {
            int index = saveEditor.Characters[currentCharacterIndex].Skills.ToasterRepair.Index;
            saveEditor.Characters[currentCharacterIndex].ChangeSkillLevel((int)num_toasterRepair.Value, index);
            num_toasterRepair.Value = saveEditor.Characters[currentCharacterIndex].Skills.ToasterRepair.Level;

            UpdateSkillPoints();
        }
        #endregion
        #endregion

        #region Perks tab
        /// <summary>
        /// Initializes the perks tab.
        /// </summary>
        private void InitializePerks()
        {
            existingPerksCount = saveEditor.Perks.All.Count;

            UpdatePerksAndPoints();
            ClearSelectedPerkItems();

            num_perkPoints.Enabled = saveEditor.Config.CheatModeEnabled;
        }

        /// <summary>
        /// Clears the selection of perk items.
        /// </summary>
        private void ClearSelectedPerkItems()
        {
            list_activePerks.ClearSelected();
            list_allPerks.ClearSelected();
        }

        /// <summary>
        /// Moves a perk from one listbox to the other. Returns true if an item was moved and false if no items was moved.
        /// </summary>
        /// <param name="fromListBox">The listbox we want to move the item from.</param>
        /// <param name="toListBox">The listbox we want to move the item to.</param>
        /// <returns></returns>
        private bool MovePerkItems(ListBox fromListBox, ListBox toListBox)
        {
            var selectedTraits = fromListBox.SelectedItems;

            if (selectedTraits == null)
            {
                return false;
            }

            if (fromListBox == list_allPerks)
            {
                if (!saveEditor.Config.CheatModeEnabled)
                {
                    if (selectedTraits.Count > saveEditor.Characters[currentCharacterIndex].PerkPoints)
                    {
                        string message = $"You are trying to add {selectedTraits.Count} perk(s) to the character '{saveEditor.Characters[currentCharacterIndex].Name}' while this character only has {saveEditor.Characters[currentCharacterIndex].PerkPoints} perk point(s). \nPlease select only up to {saveEditor.Characters[currentCharacterIndex].PerkPoints} perk(s) or enable 'Cheat mode' in application settings.";
                        string caption = "To many perks selected!";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;

                        MessageBox.Show(message, caption, buttons);

                        return false;
                    }
                }

                foreach (Trait item in selectedTraits)
                {
                    saveEditor.Characters[currentCharacterIndex].AddTrait(item);
                }
            }
            else
            {
                foreach (Trait item in selectedTraits)
                {
                    saveEditor.Characters[currentCharacterIndex].RemoveTrait(item);
                }
            }

            UpdatePerksAndPoints();

            return true;
        }

        /// <summary>
        /// Updates the form to display the correct perks and perk point values.
        /// </summary>
        private void UpdatePerksAndPoints()
        {
            #region Rebinds datasources for listboxes
            // active perks are set to the characters active perks, set to null first to update contents of the list box
            list_activePerks.DataSource = null;
            list_activePerks.DataSource = saveEditor.Characters[currentCharacterIndex].Traits.Perks;

            // all perks are set to all the existing perks minus the ones the character already has, set to null to update contents
            list_allPerks.DataSource = null;

            List<Trait> allPerks = saveEditor.Perks.All.ToList();

            foreach (var perk in saveEditor.Characters[currentCharacterIndex].Traits.Perks)
            {
                allPerks.Remove(perk);
            }

            list_allPerks.DataSource = allPerks;
            #endregion

            #region Update perk points
            activePerksCount = saveEditor.Characters[currentCharacterIndex].Traits.Perks.Count;

            // set min and max number of perk points
            num_perkPoints.Maximum = existingPerksCount - activePerksCount;
            num_perkPoints.Minimum = (existingPerksCount - activePerksCount) - existingPerksCount;

            num_perkPoints.Value = saveEditor.Characters[currentCharacterIndex].PerkPoints;
            #endregion
        }

        #region Click events
        private void num_perkPoints_ValueChanged(object sender, EventArgs e)
        {
            saveEditor.Characters[currentCharacterIndex].PerkPoints = (int)num_perkPoints.Value;
        }

        private void button_addPerk_Click(object sender, EventArgs e)
        {
            MovePerkItems(list_allPerks, list_activePerks);

            ClearSelectedPerkItems();
        }

        private void button_removePerk_Click(object sender, EventArgs e)
        {
            MovePerkItems(list_activePerks, list_allPerks);

            ClearSelectedPerkItems();
        }
        #endregion
        #endregion

        #region Quirks tab
        /// <summary>
        /// Initializes the quirk check box list.
        /// </summary>
        private void InitializeQuirks()
        {
            // clear all existing items from the box
            checkBox_quirks.Items.Clear();

            // adds all quirks to the list of quirks
            checkBox_quirks.Items.AddRange(saveEditor.Quirks.All.ToArray());

            // defines what happens when a quirks checked state is changed
            checkBox_quirks.ItemCheck += (sender, args) =>
            {
                if (args.NewValue == CheckState.Checked)
                {
                    if (!saveEditor.Config.CheatModeEnabled)
                    {
                        UncheckAllQuirks();
                    }

                    saveEditor.Characters[currentCharacterIndex].AddTrait((Trait)checkBox_quirks.Items[args.Index]);
                }
                else if (args.NewValue == CheckState.Unchecked)
                {
                    saveEditor.Characters[currentCharacterIndex].RemoveTrait((Trait)checkBox_quirks.Items[args.Index]);
                }
            };

            UpdateQuriks();
        }

        private void UncheckAllQuirks()
        {
            for (int i = 0; i < checkBox_quirks.Items.Count; i++)
            {
                checkBox_quirks.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        /// <summary>
        /// Updates the form to display the correct quirks.
        /// </summary>
        private void UpdateQuriks()
        {
            // activats the quriks of the currently selected character
            if (saveEditor.Characters[currentCharacterIndex].Traits.Quirks.Count > 0)
            {
                foreach (var quirk in saveEditor.Characters[currentCharacterIndex].Traits.Quirks)
                {
                    int qurikIndex = checkBox_quirks.Items.IndexOf(quirk);
                    checkBox_quirks.SetItemChecked(qurikIndex, true);
                }
            }
        }

        #region Click events
        private void checkBox_quirks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // display description of selected quirk
            // does nothing at the current moment as traits currently have no description
        }
        #endregion

        #endregion

        #region PC selection drop down
        private void InitializePCSelection()
        {
            dropdown_pcSelect.Items.Clear();

            var pcs = saveEditor.Characters.ToArray();

            dropdown_pcSelect.Items.AddRange(pcs);
            dropdown_pcSelect.SelectedIndex = 0;
        }

        private void dropdown_pcSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCharacterIndex = dropdown_pcSelect.SelectedIndex;

            InitializeAttributes();
            InitializeSkills();
            InitializePerks();
            InitializeQuirks();
        }
        #endregion

        #region File menu item click events
        private void fileMenuItem_open_OnClick(object sender, EventArgs e)
        {
            // open save file using save editor class
            if (saveEditor.LoadFile())
            {
                fileMenuItem_save.Enabled = true;
                dropdown_pcSelect.Enabled = true;
                allTabsControl.Enabled = true;

                Text = $"{applicationName} - {saveEditor.LoadedSavePath}";

                InitializePCSelection();
            }
        }

        private void fileMenuItem_save_OnClick(object sender, EventArgs e)
        {
            // save file using save editor class
            saveEditor.SaveFile();
        }

        private void fileMenuItem_restore_OnClick(object sender, EventArgs e)
        {
            saveEditor.RestoreFile();
        }

        private void settingsMenuItem_settings_OnClick(object sender, EventArgs e)
        {
            var settingsWindow = new SettingsWindowForm(saveEditor.Config);
            settingsWindow.ShowDialog(this);
        }
        #endregion
    }
}

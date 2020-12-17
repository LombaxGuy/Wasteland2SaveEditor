using System.Collections.Generic;
using Wasteland2SaveEditor.Character;

namespace Wasteland2SaveEditor.Collections
{
    public class Perks
    {
        private List<Trait> all = new List<Trait>();

        public List<Trait> All { get => all; }

        public Perks()
        {
            InitializeTraits();
        }

        private void InitializeTraits()
        {
            all.Add(new Trait("Trait_AdrenalineRush", "Adrenaline Rush"));
            all.Add(new Trait("Trait_Affable", "Affable"));
            all.Add(new Trait("Trait_AppliedForce", "Applied Force"));
            all.Add(new Trait("Trait_ArmorMaintenance", "Armor Maintenance"));
            all.Add(new Trait("Trait_Atomize", "Atomize"));
            all.Add(new Trait("Trait_Bandit", "Bandit"));
            all.Add(new Trait("Trait_BatteringFire", "Battering Fire"));
            all.Add(new Trait("Trait_BigGameHunter", "Big Game Hunter"));
            all.Add(new Trait("Trait_Bloodthirsty", "Bloodthirsty"));
            all.Add(new Trait("Trait_Bomberman", "Bomberman"));
            all.Add(new Trait("Trait_BulletRidden", "Bullet-Ridden"));
            all.Add(new Trait("Trait_Camel", "Camel"));
            all.Add(new Trait("Trait_CarefulHunter", "Careful Hunter"));
            all.Add(new Trait("Trait_Charge", "Charge!"));
            all.Add(new Trait("Trait_ConfidentShooter", "Confident Shooter"));
            all.Add(new Trait("Trait_CyberScrounger", "Cyber Scrounger"));
            all.Add(new Trait("Trait_Deadeye", "Deadeye"));
            all.Add(new Trait("Trait_Deconstructor", "Deconstructor"));
            all.Add(new Trait("Trait_Desperado", "Desperado"));
            all.Add(new Trait("Trait_DevastatingFire", "Devastating Fire"));
            all.Add(new Trait("Trait_Dowsing", "Dowsing"));
            all.Add(new Trait("Trait_Enrage", "Enrage"));
            all.Add(new Trait("Trait_EntanglingStrike", "Strategic strike (Brawling)"));
            all.Add(new Trait("Trait_EntanglingStrike_Bladed", "Strategic strike (Bladed)"));
            all.Add(new Trait("Trait_EntanglingStrike_Blunt", "Strategic strike (Blunt)"));
            all.Add(new Trait("Trait_ExpertPhysician", "Expert Physician"));
            all.Add(new Trait("Trait_Explorer", "Explorer"));
            all.Add(new Trait("Trait_FastReload", "Fast Reload"));
            all.Add(new Trait("Trait_FocusedShooter", "Focused Shooter"));
            all.Add(new Trait("Trait_FreeForAll", "Free For All"));
            all.Add(new Trait("Trait_Ghost", "Ghost"));
            all.Add(new Trait("Trait_GlancingStrike", "Glancing Strike (Brawling)"));
            all.Add(new Trait("Trait_GlancingStrike_Bladed", "Glancing Strike (Bladed)"));
            all.Add(new Trait("Trait_GlancingStrike_Blunt", "Glancing Strike (Blunt)"));
            all.Add(new Trait("Trait_Gunner", "Gunner"));
            all.Add(new Trait("Trait_Gunslinger", "Gunslinger"));
            all.Add(new Trait("Trait_Handyman", "Handyman"));
            all.Add(new Trait("Trait_Healthy", "Healthy"));
            all.Add(new Trait("Trait_HitTheDeck", "Hit The Deck!"));
            all.Add(new Trait("Trait_Hoarder", "Hoarder"));
            all.Add(new Trait("Trait_Hoboism", "Junk Diver"));
            all.Add(new Trait("Trait_HollowPoint", "Full Metal Jacket"));
            all.Add(new Trait("Trait_ImprovisedExplosives", "Improvised Explosives"));
            all.Add(new Trait("Trait_Infuriate", "Infuriate"));
            all.Add(new Trait("Trait_Intimidating", "Intimidating"));
            all.Add(new Trait("Trait_KnowItAll", "Know-It-All"));
            all.Add(new Trait("Trait_Limber", "Limber"));
            all.Add(new Trait("Trait_LongArm", "Long Arm"));
            all.Add(new Trait("Trait_LooseChange", "Loose Change"));
            all.Add(new Trait("Trait_MasterHunter", "Master Hunter"));
            all.Add(new Trait("Trait_MasterThief", "Master Thief"));
            all.Add(new Trait("Trait_MeleeShooting", "Melee Shooting"));
            all.Add(new Trait("Trait_Nimble", "Tinkerer"));
            all.Add(new Trait("Trait_Obliterator", "Obliterator"));
            all.Add(new Trait("Trait_OnTheMend", "On The Mend"));
            all.Add(new Trait("Trait_OpportuneStrike", "Opportune Strike (Brawling)"));
            all.Add(new Trait("Trait_OpportuneStrike_Bladed", "Opportune Strike (Bladed)"));
            all.Add(new Trait("Trait_OpportuneStrike_Blunt", "Opportune Strike (Blunt)"));
            all.Add(new Trait("Trait_Overcharge", "Overcharge"));
            all.Add(new Trait("Trait_Overclocker", "Overclocker"));
            all.Add(new Trait("Trait_Overload", "Overload"));
            all.Add(new Trait("Trait_OverwhelmingFire", "Overwhelming Fire"));
            all.Add(new Trait("Trait_Pawner", "Pawner"));
            all.Add(new Trait("Trait_PowderPacker", "Powder Packer"));
            all.Add(new Trait("Trait_PreciseHunter", "Precise Hunter"));
            all.Add(new Trait("Trait_QuickReflexes", "Quick Reflexes"));
            all.Add(new Trait("Trait_RadiantPersonality", "Radiant Personality"));
            all.Add(new Trait("Trait_ReinforcedPlating", "Reinforced Plating"));
            all.Add(new Trait("Trait_Robophobic", "Robophobic"));
            all.Add(new Trait("Trait_RushNAttack", "Rush 'N Attack"));
            all.Add(new Trait("Trait_Samurai", "Samurai"));
            all.Add(new Trait("Trait_Scout", "Scout"));
            all.Add(new Trait("Trait_SelfDefense", "Self Defense"));
            all.Add(new Trait("Trait_ShoulderTheLoad", "Shoulder The Load"));
            all.Add(new Trait("Trait_SilverTongued", "Silver-Tongued"));
            all.Add(new Trait("Trait_Slayer", "Slayer"));
            all.Add(new Trait("Trait_SmoothOperator", "Smooth Operator"));
            all.Add(new Trait("Trait_SolarPowered", "Solar Powered"));
            all.Add(new Trait("Trait_StaggeringForce", "Staggering Force"));
            all.Add(new Trait("Trait_Stimpaks", "Stimpaks"));
            all.Add(new Trait("Trait_StunningForce", "Stunning Force"));
            all.Add(new Trait("Trait_TacticalPositioning", "Tactical Positioning"));
            all.Add(new Trait("Trait_Taunt", "Taunt"));
            all.Add(new Trait("Trait_ThickSkin", "Hardened"));
            all.Add(new Trait("Trait_ToasterExpert", "Toaster Expert"));
            all.Add(new Trait("Trait_Tormentor", "Tormentor"));
            all.Add(new Trait("Trait_TrainedPhysician", "Trained Physician"));
            all.Add(new Trait("Trait_Turtle", "Turtle"));
            all.Add(new Trait("Trait_Watchman", "Watchman"));
            all.Add(new Trait("Trait_Weathered", "Weathered"));
            all.Add(new Trait("Trait_WhackAMole", "Whack-a-Mole"));
            all.Add(new Trait("Trait_WorldTraveler", "World Traveler"));
            all.Add(new Trait("Trait_ZenShooter", "Zen Shooter"));
            all.Add(new Trait("Trait_Zeroed", "Zeroed"));
        }
    }
}

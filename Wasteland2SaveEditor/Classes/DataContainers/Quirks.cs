using System.Collections.Generic;
using Wasteland2SaveEditor.Character;

namespace Wasteland2SaveEditor.Collections
{
    public class Quirks
    {
        private List<Trait> all = new List<Trait>();

        public List<Trait> All { get => all; }

        public Quirks()
        {
            all.Add(new Trait("Trait_AnimalHusbandry", "Animal Husbandry"));
            all.Add(new Trait("Trait_Ascetic", "Ascetic"));
            all.Add(new Trait("Trait_Asshole", "Asshole")); // new, might not work
            all.Add(new Trait("Trait_BrittleBones", "Brittle Bones"));
            all.Add(new Trait("Trait_DelayedGratification", "Delayed Gratification"));
            all.Add(new Trait("Trait_Disparnumerophobia", "Disparnumerophobia"));
            all.Add(new Trait("Trait_FaintingGoat", "Fainting Goat")); // new, might not work
            all.Add(new Trait("Trait_HeavyHanded", "Heavy Handed"));
            all.Add(new Trait("Trait_ManicDepressive", "Manic Depressive"));
            all.Add(new Trait("Trait_Hypochondriac", "Mysophobic"));
            all.Add(new Trait("Trait_Opportunist", "Opportunist"));
            all.Add(new Trait("Trait_Psychopath", "Psychopath"));
            all.Add(new Trait("Trait_RaisedInTheCircus", "Raised In The Circus"));
            all.Add(new Trait("Trait_RepressedRage", "Repressed Rage"));
            all.Add(new Trait("Trait_ThickSkinned", "Thick Skinned"));
            all.Add(new Trait("Trait_Twitchy", "Twitchy"));
            all.Add(new Trait("Trait_TwoPumpChump", "Two Pump Chump"));
            all.Add(new Trait("Trait_Unlucky", "Unlucky"));
            all.Add(new Trait("Trait_WayOfTheSqueezins", "Way Of The Squeezins"));
        }
    }
}

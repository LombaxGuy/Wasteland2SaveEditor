using System;
using System.Collections.Generic;
using Wasteland2SaveEditor.Collections;
using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Character
{
    public class CharacterTraits
    {
        private Flag traitsFlag = new Flag("traits");
        private Flag pairFlag = new Flag("pair");
        private Flag keyFlag = new Flag("key");

        private List<Trait> allPerks = new List<Trait>();
        private List<Trait> allQuirks = new List<Trait>();

        private List<Trait> perks = new List<Trait>();
        private List<Trait> quirks = new List<Trait>();

        public List<Trait> All
        {
            get
            {
                List<Trait> all = new List<Trait>();
                all.AddRange(perks);
                all.AddRange(quirks);
                return all;
            }
        }
        public List<Trait> Perks { get => perks; }
        public List<Trait> Quirks { get => quirks; }

        public string Data
        {
            get
            {
                string data = "";

                for (int i = 0; i < All.Count; i++)
                {
                    data += All[i].Data;
                }

                return data;
            }
        }

        public CharacterTraits(string rawData, Perks allPerks, Quirks allQuirks)
        {
            this.allPerks = allPerks.All;
            this.allQuirks = allQuirks.All;

            string rawTraitsData = rawData.GetBetween(traitsFlag.Start, traitsFlag.End);

            if (string.IsNullOrEmpty(rawTraitsData))
                return;

            string[] traitsData = rawTraitsData.Split(pairFlag.End + pairFlag.Start);
            traitsData[0].TrimStart(pairFlag.Start);
            traitsData[traitsData.Length - 1].TrimEnd(pairFlag.End);

            foreach (var traitString in traitsData)
            {
                string traitKey = traitString.GetBetween(keyFlag.Start, keyFlag.End);

                Trait trait = allPerks.All.Find(trait => trait.Key == traitKey);

                if (trait != null)
                {
                    this.perks.Add(trait);
                }
                else
                {
                    trait = allQuirks.All.Find(trait => trait.Key == traitKey);
                    
                    if (trait != null)
                    {
                        this.quirks.Add(trait);
                    }
                }
            }
        }

        public bool Remove(Trait trait)
        {
            if (All.Contains(trait))
            {
                if (perks.Contains(trait))
                {
                    perks.Remove(trait);
                    return true;
                }
                else if (quirks.Contains(trait))
                {
                    quirks.Remove(trait);
                    return true;
                }
            }

            return false;
        }

        public bool Add(Trait trait)
        {
            if (allPerks.Contains(trait))
            {
                if (perks.Contains(trait))
                {
                    // perk already in perks
                    return false;
                }
                else
                {
                    perks.Add(trait);
                    return true;
                }
            }
            else if (allQuirks.Contains(trait))
            {
                if (quirks.Contains(trait))
                {
                    // quirk already in quirks
                    return false;
                }
                else
                {
                    quirks.Add(trait);
                    return true;
                }
            }
            else
            {
                // error trait does not exist
                return false;
            }
        }
    }
}

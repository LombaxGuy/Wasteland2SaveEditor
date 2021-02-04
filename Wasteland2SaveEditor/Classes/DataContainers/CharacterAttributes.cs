using System.Collections.Generic;
using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Character
{
    public class CharacterAttributes
    {
        // flags use for seperating the data string
        private readonly Flag attributesFlag = new Flag("attributes");
        private readonly Flag pairFlag = new Flag("pair");
        private readonly Flag keyFlag = new Flag("key");
        private readonly Flag valueFlag = new Flag("value");

        private readonly Attribute[] all = new Attribute[7];

        private readonly Dictionary<string, int> keyToIndex = new Dictionary<string, int>()
        {
            { "coordination",   0 },
            { "luck",           1 },
            { "awareness",      2 },
            { "strength",       3 },
            { "speed",          4 },
            { "intelligence",   5 },
            { "charisma",       6 }
        };

        public Attribute[] All { get => all; }
        public Attribute Coordination { get => all[keyToIndex["coordination"]]; }
        public Attribute Luck { get => all[keyToIndex["luck"]]; }
        public Attribute Awareness { get => all[keyToIndex["awareness"]]; }
        public Attribute Strength { get => all[keyToIndex["strength"]]; }
        public Attribute Speed { get => all[keyToIndex["speed"]]; }
        public Attribute Intelligence { get => all[keyToIndex["intelligence"]]; }
        public Attribute Charisma { get => all[keyToIndex["charisma"]]; }

        /// <summary>
        /// Returns a data string of the characters attributes.
        /// </summary>
        public string Data
        {
            get
            {
                string data = "";

                // add each attribute to the data string in order
                for (int i = 0; i < all.Length; i++)
                {
                    data += all[i].Data;
                }

                return data;
            }
        }

        public CharacterAttributes(string data)
        {
            // finds the attributes and splits them up into seperate strings
            string allAttributesString = data.GetBetween(attributesFlag.Start, attributesFlag.End);
            string[] attributeStrings = allAttributesString.Split(pairFlag.End + pairFlag.Start);

            // loop through the strings and set the values of the 'all' array
            for (int i = 0; i < attributeStrings.Length; i++)
            {
                string key = attributeStrings[i].GetBetween(keyFlag.Start, keyFlag.End);
                int value = int.Parse(attributeStrings[i].GetBetween(valueFlag.Start, valueFlag.End));

                all[keyToIndex[key]] = new Attribute(key, value);
            }
        }
    }
}

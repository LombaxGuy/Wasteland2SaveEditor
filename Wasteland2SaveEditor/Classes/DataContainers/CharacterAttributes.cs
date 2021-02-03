using System;
using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Character
{
    public class CharacterAttributes
    {
        private Flag attributesFlag = new Flag("attributes");
        private Flag pairFlag = new Flag("pair");
        private Flag keyFlag = new Flag("key");
        private Flag valueFlag = new Flag("value");

        private Attribute[] all = new Attribute[7];

        public Attribute Coordination { get => all[0]; }
        public Attribute Luck { get => all[1]; }
        public Attribute Awareness { get => all[2]; }
        public Attribute Strength { get => all[3]; }
        public Attribute Speed { get => all[4]; }
        public Attribute Intelligence { get => all[5]; }
        public Attribute Charisma { get => all[6]; }

        public Attribute[] All { get => all; }

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

        public CharacterAttributes(string rawCharacterData)
        {
            string rawAttributeData = rawCharacterData.GetBetween(attributesFlag.Start, attributesFlag.End);

            string[] attributeData = rawAttributeData.Split(pairFlag.End + pairFlag.Start);

            for (int i = 0; i < attributeData.Length; i++)
            {
                string key = attributeData[i].GetBetween(keyFlag.Start, keyFlag.End);
                int value = int.Parse(attributeData[i].GetBetween(valueFlag.Start, valueFlag.End));

                all[GetIndexFromKey(key)] = new Attribute(key, value);
            }
        }

        private int GetIndexFromKey(string key)
        {
            switch (key)
            {
                case "coordination":
                    return 0;

                case "luck":
                    return 1;

                case "awareness":
                    return 2;

                case "strength":
                    return 3;

                case "speed":
                    return 4;

                case "intelligence":
                    return 5;

                case "charisma":
                    return 6;

                default:
                    throw new Exception($"Attribute key '{key}' does not exist!");
            }
        }
    }
}

using System.Collections.Generic;
using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Character
{
    public class CharacterAttributes
    {
        private Flag attributesFlag = new Flag("attributes");
        private Flag pairFlag = new Flag("pair");
        private Flag valueFlag = new Flag("value");

        private List<Attribute> all = new List<Attribute>();

        public Attribute Coordination { get => all[0]; }
        public Attribute Luck { get => all[1]; }
        public Attribute Awareness { get => all[2]; }
        public Attribute Strength { get => all[3]; }
        public Attribute Speed { get => all[4]; }
        public Attribute Intelligence { get => all[5]; }
        public Attribute Charisma { get => all[6]; }

        public List<Attribute> All { get => all; }

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

        public CharacterAttributes(string rawCharacterData)
        {
            string rawAttributeData = rawCharacterData.GetBetween(attributesFlag.Start, attributesFlag.End);

            string[] attributeData = rawAttributeData.Split(pairFlag.End + pairFlag.Start);
            attributeData[0].TrimStart(pairFlag.Start);
            attributeData[attributeData.Length - 1].TrimEnd(pairFlag.End);

            all.Add(new Attribute("coordination", int.Parse(attributeData[0].GetBetween(valueFlag.Start, valueFlag.End))));
            all.Add(new Attribute("luck", int.Parse(attributeData[1].GetBetween(valueFlag.Start, valueFlag.End))));
            all.Add(new Attribute("awareness", int.Parse(attributeData[2].GetBetween(valueFlag.Start, valueFlag.End))));
            all.Add(new Attribute("strength", int.Parse(attributeData[3].GetBetween(valueFlag.Start, valueFlag.End))));
            all.Add(new Attribute("speed", int.Parse(attributeData[4].GetBetween(valueFlag.Start, valueFlag.End))));
            all.Add(new Attribute("intelligence", int.Parse(attributeData[5].GetBetween(valueFlag.Start, valueFlag.End))));
            all.Add(new Attribute("charisma", int.Parse(attributeData[6].GetBetween(valueFlag.Start, valueFlag.End))));
        }
    }
}

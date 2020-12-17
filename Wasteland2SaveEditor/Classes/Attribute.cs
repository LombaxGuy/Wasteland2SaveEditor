using Wasteland2SaveEditor.Extensions;

namespace Wasteland2SaveEditor.Character
{
    public class Attribute : KeyValuePair
    {
        public const int minimumPoints = 1;
        public const int maximumPoints = 10;

        public Attribute(string name, int points = 1) : base(name, points)
        {
            DisplayName = name.CapitalizeFirstLetter();
        }
    }
}

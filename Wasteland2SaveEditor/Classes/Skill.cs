namespace Wasteland2SaveEditor.Character
{
    public class Skill : KeyValuePair
    {
        public const int minimumPoints = 0;
        public const int maximumPoints = 44;

        public readonly int[] pointsAtLevel = new int[] { 0, 2, 4, 6, 10, 14, 18, 24, 30, 36, 44 };

        public override int Value { get => value; set => this.value = value; }

        public int Level
        {
            get
            {
                int level = -1;

                for (int i = 0; i < pointsAtLevel.Length; i++)
                {
                    if (pointsAtLevel[i] <= value)
                    {
                        level = i;
                    }
                }

                return level;
            }
        }

        public int MaximumPoints { get => maximumPoints; }

        public int Index { get; private set; }

        public Skill(string name, int points, string displayName, int index) : base(name, points)
        {
            if (points < minimumPoints)
            {
                value = minimumPoints;
            }

            if (points > maximumPoints)
            {
                value = maximumPoints;
            }

            DisplayName = displayName;
            Index = index;
        }

        public int ChangeLevel(int toLevel)
        {
            int pointCost = pointsAtLevel[toLevel] - pointsAtLevel[Level];

            value = pointsAtLevel[toLevel];

            return pointCost;
        }
    }
}

namespace Wasteland2SaveEditor.Character
{
    public class Trait : KeyValuePair
    {
        public Trait(string key, string displayName) : base(key, 1)
        {
            this.key = key;

            DisplayName = displayName;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}

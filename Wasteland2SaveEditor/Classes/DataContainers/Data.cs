namespace Wasteland2SaveEditor.Collections
{
    public struct Data
    {
        public Flags flags;
        public Perks perks;
        public Quirks quirks;

        public Data(Flags flags, Perks perks, Quirks quirks)
        {
            this.flags = flags;
            this.perks = perks;
            this.quirks = quirks;
        }
    }
}

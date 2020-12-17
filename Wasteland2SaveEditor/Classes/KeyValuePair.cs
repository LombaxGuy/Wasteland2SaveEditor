namespace Wasteland2SaveEditor.Character
{
    public abstract class KeyValuePair
    {
        protected string key;
        protected int value;

        private Flag pairFlag = new Flag("pair");
        private Flag keyFlag = new Flag("key");
        private Flag valueFlag = new Flag("value");

        public string Key { get => key; }
        public virtual int Value { get => value; set => this.value = value; }

        public string DisplayName { get; protected set; }

        public string Data
        {
            get
            {
                return $"{pairFlag.Start}{keyFlag.Start}{key}{keyFlag.End}{valueFlag.Start}{value}{valueFlag.End}{pairFlag.End}";
            }
        }

        public KeyValuePair(string key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }
}

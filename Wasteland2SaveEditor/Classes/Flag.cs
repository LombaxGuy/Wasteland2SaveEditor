namespace Wasteland2SaveEditor.Character
{
    public class Flag
    {
        private string start;
        private string end;
        private string tag;

        public string Start { get => start; }
        public string End { get => end; }
        public string Tag { get => tag; }

        public Flag(string tag)
        {
            this.tag = tag;
            start = $"<{tag}>";
            end = $"</{tag}>";
        }
    }
}

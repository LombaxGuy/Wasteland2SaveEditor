using Wasteland2SaveEditor.Character;

namespace Wasteland2SaveEditor.Collections
{
    public class Flags
    {
        public Flag pcs = new Flag("pcs");
        public Flag pc = new Flag("pc");
        public Flag displayName = new Flag("displayName");
        public Flag gender = new Flag("gender");

        public Flag attributes = new Flag("attributes");
        public Flag skills = new Flag("skillXps");
        public Flag traits = new Flag("traits");

        public Flag attributePoints = new Flag("availableAttributePoints");
        public Flag skillPoints = new Flag("availableSkillPoints");
        public Flag traitPoints = new Flag("availableTraitPoints");
    }
}

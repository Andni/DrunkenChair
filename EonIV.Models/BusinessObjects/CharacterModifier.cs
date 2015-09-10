namespace Niklasson.EonIV.Models.BusinessObjects
{
    public abstract class CharacterModifier : CharacterModifierNode
    {
        public virtual string Label { get; set; }

        public string Condition { get; set; }

        public string Description { get; set; }
    }
}
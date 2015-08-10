namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterData : ICharacterData
    {
        public CharacterBasics Basics { get; set; }
        public BaseAttributeDices ExtraAttributeDiceDistribution { get; set; }
        public RuleBookEventSet Events { get; set; }

        public CharacterData()
        {
            Basics = new CharacterBasics();
            ExtraAttributeDiceDistribution = new BaseAttributeDices();
            Events = new RuleBookEventSet();
        }

        public CharacterSheet ToCharacterSheet()
        {
            return new CharacterSheet(this);
        }
    }
}

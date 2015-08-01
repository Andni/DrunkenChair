namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface ICharacterData
    {
        CharacterBasics Basics { get; set; }
        BaseAttributeDices ExtraAttributeDiceDistribution { get; set; }
        RuleBookEventSet Events { get; set; }
    }
}

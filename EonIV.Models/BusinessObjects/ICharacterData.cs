namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface ICharacterData
    {
        Archetype Archetype { get; set; }
        Background Background { get; set; }
        Environment Environment { get; set; }
        Race Race { get; set; }
        
        BaseAttributeDices ExtraAttributeDiceDistribution { get; set; }
        RuleBookEventSet Events { get; set; }

        EventTableRolls GetEventRolls();
    }
}

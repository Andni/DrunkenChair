namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface ICharacterBasics
    {
        Archetype Archetype { get; set; }
        Background Background { get; set; }
        Environment Environment { get; set; }
        Race Race { get; set; }

        CharacterBasicChoices ToBasicChoices();
    }
}

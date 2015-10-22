using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface ICharacterAttributes : ICharacterBaseAttributes
    {
        CharacterBaseAttributeSet Base { get; set; }
        //CharacterAttributeSet Derived { get; }

        DiceRollCheck Movement { get;}
        DiceRollCheck Impression { get; }
        DiceRollCheck Build { get; }
        DiceRollCheck Lifeforce { get; }
        DiceRollCheck Reaction { get; }
        DiceRollCheck Selfcontrol { get; }
        DiceRollCheck Vigilance { get; }
    }
}

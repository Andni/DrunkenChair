using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.DrunkenChair.Models
{
    public interface ICharacterAttributes
    {
        CharacterBaseAttributeSet Base { get; set; }
        //CharacterAttributeSet Derived { get; }

        DiceRollCheck Strength { get; }
        DiceRollCheck Stamina { get; }
        DiceRollCheck Agility { get; }
        DiceRollCheck Perception { get; }
        DiceRollCheck Will { get; }
        DiceRollCheck Psyche { get; }
        DiceRollCheck Wisdom { get; }
        DiceRollCheck Charisma { get; }

        DiceRollCheck Movement { get;}
        DiceRollCheck Impression { get; }
        DiceRollCheck Build { get; }
        DiceRollCheck Lifeforce { get; }
        DiceRollCheck Reaction { get; }
        DiceRollCheck Selfcontrol { get; }
        DiceRollCheck Vigilance { get; }
    }
}

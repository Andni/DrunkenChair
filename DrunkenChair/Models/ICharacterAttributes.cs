using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Niklasson.DrunkenChair.Models;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Character
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

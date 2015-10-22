using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface ICharacterBaseAttributes
    {
        DiceRollCheck Strength { get; }
        DiceRollCheck Stamina { get; }
        DiceRollCheck Agility { get; }
        DiceRollCheck Perception { get; }
        DiceRollCheck Will { get; }
        DiceRollCheck Psyche { get; }
        DiceRollCheck Wisdom { get; }
        DiceRollCheck Charisma { get; }
    }
}

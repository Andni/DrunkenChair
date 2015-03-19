using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenChair.Models
{
    public interface ICharacterAttributes
    {
        CharacterBaseAttributes Base { get; set; }
        DerivedCharacterAttributes Derived { get; }

        Attribute Strength { get; }
        Attribute Stamina { get; }
        Attribute Agility { get; }
        Attribute Perception { get; }
        Attribute Will { get; }
        Attribute Psyche { get; }
        Attribute Wisdom { get; }
        Attribute Charisma { get; }

        Attribute Movement { get;}
        Attribute Impression { get; }
        Attribute Build { get; }
        Attribute Lifeforce { get; }
        Attribute Reaction { get; }
        Attribute Selfcontrol { get; }
        Attribute Vigilance { get; }
    }
}

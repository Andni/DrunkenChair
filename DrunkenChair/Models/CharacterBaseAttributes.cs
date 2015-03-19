using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DrunkenChair.Models
{
    [ComplexType]
    public class CharacterBaseAttributes
    {
        [Display(Name = "Styrka")]
        public Attribute Strength { get; set; }
        [Display(Name = "Tålighet")]
        public Attribute Stamina { get; set; }
        public Attribute Agility { get; set; }
        public Attribute Perception { get; set; }
        public Attribute Will { get; set; }
        public Attribute Psyche { get; set; }
        public Attribute Wisdom { get; set; }
        public Attribute Charisma { get; set; }

        public CharacterBaseAttributes()
            : this(
                new Attribute(0, 0),
                new Attribute(0, 0),
                new Attribute(0, 0),
                new Attribute(0, 0),
                new Attribute(0, 0),
                new Attribute(0, 0),
                new Attribute(0, 0),
                new Attribute(0, 0)
                ) { }

        public CharacterBaseAttributes(Attribute str, Attribute sta, Attribute agl, Attribute per, Attribute wil, Attribute psy, Attribute wis, Attribute cha)
        {
            Strength = str;
            Stamina = sta;
            Agility = agl;
            Perception = per;
            Will = wil;
            Psyche = psy;
            Wisdom = wis;
            Charisma = cha;
        }
    }
}
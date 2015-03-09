using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace DrunkenChair.Models
{
    [ComplexType]
    public class Attributes : IDerivedAttributes
    {
        public Attribute Strength { get; set; }
        public Attribute Stamina { get; set; }
        public Attribute Agility { get; set; }
        public Attribute Perception { get; set; }
        public Attribute Will { get; set; }
        public Attribute Psyche { get; set; }
        public Attribute Wisdom { get; set; }
        public Attribute Charisma { get; set; }
        
        public Attribute Movement
        {
            get
            {
                return (Agility + Stamina) / 2;
            }
        }

        public Attribute Impression
        {
            get
            {
                return (Wisdom + Charisma) / 2;
            }
        }

        public Attribute BodyBuild
        {
            get
            {
                return (Strength + Stamina) / 2;
            }
        }

        public Attribute Lifeforce
        {
            get
            {
                return (Will + Stamina) / 2;
            }
        }

        public Attribute Reaction
        {
            get
            {
                return (Agility + Perception) / 2;
            }
        }

        public Attribute Selfcontrol
        {
            get
            {
                return (Will + Psyche) / 2;
            }
        }

        public Attribute Viligance
        {
            get
            {
                return (Perception + Psyche) / 2;
            }
        }

        public Attributes(): this(
            new Attribute(0, 0), 
            new Attribute(0, 0), 
            new Attribute(0, 0), 
            new Attribute(0, 0), 
            new Attribute(0, 0), 
            new Attribute(0, 0), 
            new Attribute(0, 0), 
            new Attribute(0, 0)
            ){}

        public Attributes(Attribute str, Attribute sta, Attribute agl, Attribute per, Attribute wil, Attribute psy, Attribute wis, Attribute cha)
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
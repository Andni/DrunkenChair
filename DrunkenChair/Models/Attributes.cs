using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DrunkenChair.Models
{
    [ComplexType]
    public class Attributes : IDerivedAttributes, IEnumerable<Attribute>
    {
        [Display(Name="Styrka")]
        public Attribute Strength { get; set; }
        [Display(Name="Tålighet")]
        public Attribute Stamina { get; set; }
        public Attribute Agility { get; set; }
        public Attribute Perception { get; set; }
        public Attribute Will { get; set; }
        public Attribute Psyche { get; set; }
        public Attribute Wisdom { get; set; }
        public Attribute Charisma { get; set; }

        private List<Attribute> testList = new List<Attribute>();

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

        public Attributes()
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

            testList.Add(Strength);
            testList.Add(Stamina);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (System.Collections.Generic.IEnumerator<Attribute>)GetEnumerator();
        }

        public IEnumerator<Attribute> GetEnumerator()
        {
            return testList.GetEnumerator();
        }

        public IList <Attribute> GetBaseAttributes()
        {
            return new List<Attribute> {Strength, Stamina, Agility, Perception, Will, Psyche, Wisdom, Charisma};
        }

        public IList<Attribute> GetDerivedAttributes()
        {
            return new List<Attribute> { Movement, Impression, BodyBuild, Lifeforce, Reaction, Selfcontrol, Viligance};
        }
    }
}
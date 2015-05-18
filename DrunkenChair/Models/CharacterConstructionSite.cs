using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterConstructionSite
    {
        ////first step
        //public CharacterBasics BasicsDetails { get; set; }

        ////second step
        //public CharacterAttributeDetails AttributeDetails{ get; set; }
        
        ////third step
        //public EventDetails EventDetails{ get; set; }

        public EonIvCharacterSheet CharacterSheet
        {
            get
            {
                return Character.ToCharacterSheet();
            }
        }

        public CharacterData Character { get; set; }
        

        
        public CharacterMetaData Scaffolding { get; set; }

        public EventTableRolls GetEventRolls { get; set; }

        public EonIvCharacterSheet GetCharacterPreview()
        {
            return Character.ToCharacterSheet();

            //var c = new EonIvCharacter()
            //{
            //    Archetype = BasicsDetails.Archetype ?? new Archetype(),
            //    Background = BasicsDetails.Background ?? new Background(),
            //    Environment = BasicsDetails.Environment ?? new Environment(),
            //    Race = BasicsDetails.Race ?? new Race(),
            //    Skills = SkillSet
            //};

            //CharacterBaseAttributeSet attributes = AttributeDetails.GetBonusDiceDistribution() ?? new CharacterBaseAttributeSet();
            //if(BasicsDetails.Race != null)
            //{
            //    attributes += BasicsDetails.Race.StartingAttributes;
            //}
            //c.Attributes = new CharacterAttributeSet(attributes);

            //return c;
        }

        public CharacterConstructionSite()
        {
            Character = new CharacterData();
            Scaffolding = new CharacterMetaData();
        }
    }
}
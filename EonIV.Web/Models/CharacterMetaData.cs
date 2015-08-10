using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterMetaData
    {
        private CharacterData character;

        public CharacterMetaData(CharacterData character)
        {
            this.character = character;
            Skillpoints = new Skillpoints();
        }

        public EventTableRolls EventRolls {
            get
            { return character.Basics.GetEventRolls(); }    
        }
        public CharacterBaseAttributeSet BonusDiceDistribution { get; set; }
        public Skillpoints Skillpoints { get; set; }


        public int FreeEventRolls { get; set; }
    }
}
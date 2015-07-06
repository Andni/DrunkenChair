﻿using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class EonIVCharacterSheet
    {
        public int ID { get; set; }
     
        public string Archetype { get; set; }
        public string Background { get; set; }
        public string Environment { get; set; }
        public string Race { get; set; }

        public CharacterAttributeSet Attributes { get; set; }
        [Column("CharacterSkills")]
        public CharacterSkills Skills { get; set; }
        
        public EonIVCharacterSheet()
        {
            //Basics = new CharacterBasics();
            Attributes = new CharacterAttributeSet();
        }
    }
}
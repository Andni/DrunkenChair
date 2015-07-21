﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.BusinessObjects
{
    public class CharacterGenerationData
    {
        private CharacterData character;
        private Skillpoints skillpoints;

        public CharacterGenerationData(CharacterData character)
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

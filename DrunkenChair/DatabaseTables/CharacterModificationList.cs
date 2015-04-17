using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrunkenChair.Models;

namespace DrunkenChair.DatabaseTables
{
    public class CharacterModificationOpitons
    {
        public int ID { get; set; }
        public List<EonIVCharacterModifier> Alternatives { get; set; }

        public CharacterModificationOpitons()
        {
            Alternatives = new List<EonIVCharacterModifier>();
        }

        public static implicit operator CharacterModificationOpitons(EonIVCharacterModifier mod)
        {
            return new CharacterModificationOpitons() { Alternatives = new List<EonIVCharacterModifier> { mod } };
        }
    }
}   
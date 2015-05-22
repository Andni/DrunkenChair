using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public abstract class EonIVCharacterModifier// : CharacterModifierBase
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("CharacterModificationOptions")]
        public int? CharacterModificationOptions_ID { get; set; }
        public string Condition { get; set; }
        public virtual CharacterModificationOptions CharacterModificationOptions { get; set; }

        //[ForeignKey("Events")]
        //public int? EventsID { get; set; }
        //public virtual Event Events { get; set; }

        //[ForeignKey("EonIVCharacterModifierSelector")]
        //public int? EonIVCharacterModifierSelectorID { get; set; }
        //public virtual EonIVCharacterModifierSelector EonIVCharacterModifierSelector { get; set; }

    }
}
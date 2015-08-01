﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Shared.DatabaseTables
{
    public abstract class EonIVCharacterModifier// : CharacterModifierBase
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("CharacterModificationOptions")]
        public int? CharacterModificationOptions_ID { get; set; }
        public string Condition { get; set; }
        public virtual CharacterModificationOptions CharacterModificationOptions { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ConcreteModelType { get { return this.GetType().ToString(); } }

        //[ForeignKey("Events")]
        //public int? EventsID { get; set; }
        //public virtual Event Events { get; set; }

        //[ForeignKey("EonIVCharacterModifierSelector")]
        //public int? EonIVCharacterModifierSelectorID { get; set; }
        //public virtual EonIVCharacterModifierSelector EonIVCharacterModifierSelector { get; set; }

    }
}
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public abstract class CharacterModifier : CharacterModifierNode
    {
        //[ForeignKey("CharacterModificationOptions")]
        //public int? CharacterModificationOptions_ID { get; set; }
        
        public virtual CharacterModifierContainer ParentContainer { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ConcreteModelType { get { return this.GetType().ToString(); } }

        public string Condition { get; set; }
        //public virtual CharacterModificationOptions CharacterModificationOptions { get; set; }

    }
}
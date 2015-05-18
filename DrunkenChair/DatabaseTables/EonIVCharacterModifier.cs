using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public abstract class EonIVCharacterModifier : IEonIVCharacterModifier
    {
        public int ID { get; set; }
        public int CharacterModificationOptionsID { get; set; }
        public string Condition { get; set; }

        public virtual CharacterModificationOptions CharacterModoficationsOptions { get; set; }
    }
}
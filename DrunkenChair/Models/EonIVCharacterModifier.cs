using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrunkenChair.Models.Interfaces;

namespace DrunkenChair.Models
{
    public abstract class EonIVCharacterModifier : IEonIVCharacterModifier
    {
        public int ID { get; set; }
        public int CharacterModificationList_ID { get; set; }
    }
}
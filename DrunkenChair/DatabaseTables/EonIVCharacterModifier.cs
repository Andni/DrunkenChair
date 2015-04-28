using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Model.Interfaces;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public abstract class EonIVCharacterModifier : IEonIVCharacterModifier
    {
        public int ID { get; set; }
        public int CharacterModificationList_ID { get; set; }
        public string Condition { get; set; }
    }
}
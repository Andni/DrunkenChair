using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrunkenChair.Models;

namespace DrunkenChair.DatabaseTables
{
    public class AttributeModification : EonIVCharacterModifier
    {
        public int ID { get; set; }
        public DrunkenChair.Character.Attribute Attribute { get; set; }
        public int Value { get; set; }
        
        public void AddDie(int dies = 1)
        {
            Value += dies * EonIVValue.valuePerD6;
        }

        public void SubtractDie(int dies = 1)
        {
            Value -= dies * EonIVValue.valuePerD6;
        }
    }
}
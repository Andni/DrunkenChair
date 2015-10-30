using System;
using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Apprentice : CharacterModifier
    {
        string Background { get; set; }

        public override string ConcreteModelType
        {
            get
            {
                return typeof(Apprentice).ToString();
            }
        }
    }
}
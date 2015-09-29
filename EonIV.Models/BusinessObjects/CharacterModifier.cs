using System;
using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public abstract class CharacterModifier : CharacterModifierNode
    {
        public string Condition { get; set; }
        
        public override IList<CharacterModifier> Flatten()
        {
            var res = new List<CharacterModifier>();
            res.Add(this);
            return res;
        }
    }
}
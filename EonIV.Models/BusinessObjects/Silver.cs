using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Silver : CharacterModifier
    {
        public int Amount { get; set; }

        public override string ConcreteModelType
        {
            get
            {
                return typeof(Silver).ToString();
            }
        }
    }
}

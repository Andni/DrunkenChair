using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class JadednessCross : CharacterModifier
    {
        public int Crosses { get; set; }

        public JadednessType Type { get; set; }

        public override string ConcreteModelType
        {
            get
            {
                return typeof(JadednessCross).ToString();
            }
        }
    }

    public enum JadednessType
    {
        VULNRABILITY = 0,
        VIOLENCE = 1,
        SUPERNATURAL = 2
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class EventRoll : CharacterModifier
    {
        public EventCategory EventCategory { get; set;}
        public int Rolls { get; set; }

        public override string ConcreteModelType
        {
            get
            {
                return typeof(EventRoll).ToString();
            }
        }
    }
}

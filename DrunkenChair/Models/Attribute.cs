using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace DrunkenChair.Models
{
    [ComplexType]
    public class Attribute
    {

        private const int valuePerD6 = 4;

        public int UnlimitedDice6
        {
            get
            {
                return Value / valuePerD6;
            }
        }
        public int Bonus {
            get
            {
                return this.Value % valuePerD6;
            }
        }
        public int Value { get; set; }

        public Attribute() : this(0) {}

        public Attribute(int value)
        {
            this.Value = value;
        }

        public Attribute(int unlimitedDice6, int bonus)
        {
            this.Value = unlimitedDice6 * valuePerD6;
        }

        public Attribute(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(?<d6>\d+)([TDtd]6)?(\+(?<bonus>\d+))?");
            var res = regex.Match(str);
            if(res.Groups["d6"].Success && res.Groups["bonus"].Success)
            {
                this.Value = Convert.ToInt32(res.Groups["d6"].Value) * valuePerD6 + Convert.ToInt32(res.Groups["bonus"].Value);
            }
            else if(res.Groups["d6"].Success)
            {
                this.Value = Convert.ToInt32(res.Groups["d6"].Value);
            }
            else
            {
                this.Value = 0;
            }
        }

        public object Clone()
        {
            return new Attribute(this.Value);
        }

        public static Attribute operator+(Attribute lh, Attribute rh)
        {
            if (lh == null || rh == null)
            {
                return null;
            }
            var total = lh.Value + rh.Value;
            return new Attribute(total);
        }

        public static Attribute operator/(Attribute lh, double rh)
        {
            if (lh == null)
            {
                return null;
            }
            return new Attribute((int) Math.Floor( lh.Value/rh ));
        }
        
        public static implicit operator Attribute(int value)
        {
            return new Attribute(value);
        }

        public static implicit operator Attribute(string str)
        {
            return new Attribute(str);
        }

    }
}
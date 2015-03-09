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
        public int UnlimitedDice6 { get; set; }
        public int Bonus { get; set; }

        public Attribute() : this(0, 0) { }

        public Attribute(int value)
        {
            Bonus = value % 4;
            UnlimitedDice6 = value / 4;

        }

        public Attribute(int unlimitedDice6, int bonus)
        {
            UnlimitedDice6 = unlimitedDice6;
            Bonus = bonus;
        }

        public static Attribute operator+(Attribute lh, Attribute rh)
        {
            var total = lh.Value() + rh.Value();
            return new Attribute(total);
        }

        public static Attribute operator/(Attribute lh, double rh)
        {
            return new Attribute((int) Math.Floor( lh.Value()/rh ));
        }

        private int Value()
        {
            return UnlimitedDice6 * 4 + Bonus;
        }
    }
}
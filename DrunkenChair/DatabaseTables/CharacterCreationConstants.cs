using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Niklasson.DrunkenChair.Model
{
    public enum Constant
    {
        BonusAttributeDiceses,
        MaxBonusAttributeDicesSpentOnOneAttribute
    }

    public class CharacterCreationConstants
    {
        [Key]
        public Constant Constant { get; private set; }
        public int Value { get; private set; }

        public CharacterCreationConstants() : this(Constant.BonusAttributeDiceses, 10)
        { }

        public CharacterCreationConstants(Constant c, int value)
        {
            Constant = c;
            Value = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niklasson.DrunkenChair.Models
{
    public static class EonIVValue
    {
        public const int valuePerD6 = 4;

        public static int DiceToValue(int dices)
        {
            return dices * valuePerD6;
        }
    }
}

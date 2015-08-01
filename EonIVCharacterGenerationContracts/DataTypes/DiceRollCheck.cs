using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.DataTypes
{
    [ComplexType]
    public class DiceRollCheck
    {

        private int valuePerD6 = EonIVValue.valuePerD6;

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

        public DiceRollCheck() : this(0) {}

        public DiceRollCheck(int value)
        {
            this.Value = value;
        }

        public DiceRollCheck(int unlimitedDice6, int bonus)
        {
            this.Value = unlimitedDice6 * valuePerD6;
        }

        public DiceRollCheck(string str)
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

        public static DiceRollCheck CreateFromDice(int dice)
        {
            return new DiceRollCheck(EonIVValue.DiceToValue(dice));
        }

        public void AddDice(int dices = 1)
        {
            this.Value += EonIVValue.DiceToValue(dices);
        }

        public object Clone()
        {
            return new DiceRollCheck(this.Value);
        }

        public static DiceRollCheck operator+(DiceRollCheck lh, DiceRollCheck rh)
        {
            if (lh == null || rh == null)
            {
                return null;
            }
            var total = lh.Value + rh.Value;
            return new DiceRollCheck(total);
        }

        public static DiceRollCheck operator/(DiceRollCheck lh, double rh)
        {
            if (lh == null)
            {
                return null;
            }
            return new DiceRollCheck((int) Math.Floor( lh.Value/rh ));
        }
        
        public static implicit operator DiceRollCheck(int value)
        {
            return new DiceRollCheck(value);
        }

        public static implicit operator DiceRollCheck(string str)
        {
            return new DiceRollCheck(str);
        }

    }
}
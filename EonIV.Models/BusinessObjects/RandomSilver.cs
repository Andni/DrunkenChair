using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class RandomSilver : CharacterModifier
    {
        public DiceRollCheck Dices { get; set; }

        public override string Label
        {
            get
            {   
                if(string.IsNullOrEmpty(base.Label))
                {
                    return "Pengar";
                }
                return base.Label;
            }

            set
            {
                base.Label = value;
            }
        }

        public override string Description
        {
            get
            {
                if (string.IsNullOrEmpty(base.Description))
                {
                    return string.Format("{0}x{1} silver.", Dices, SilverMultiplier);
                }
                return base.Description;
            }

            set
            {
                base.Description = value;
            }
        }

        public int SilverMultiplier { get; set; }

        public int Resolve()
        {
            return Dices.Roll() * SilverMultiplier;
        }

        public override string ConcreteModelType
        {
            get
            {
                return typeof(RandomSilver).ToString();
            }
        }
    }
}

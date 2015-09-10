using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class RandomSilver : CharacterModifier
    {
        public DiceRollCheck Dices { get; set; }

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

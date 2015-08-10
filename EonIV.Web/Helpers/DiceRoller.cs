using Niklasson.Toolbox;

namespace Niklasson.DrunkenChair.Helpers
{
    public class DiceRoller : IDiceRoller
    {
        public int RollD100()
        {
            return RandomNumberGenerator.Next(1, 100);
        }

        public int RollD6(int dices = 1)
        {
            return UnlimitedD6(dices);
        }

        private int UnlimitedD6(int dices)
        {
            int value = 0;
            var dicesToRoll = dices;
            while(dicesToRoll > 0)
            {
                var tmp = RandomNumberGenerator.Next(1, 6);
                if (tmp == 6)
                {
                    dicesToRoll++;
                }
                else
                {
                    dicesToRoll--;
                    value += tmp;
                }
            }
            return value;
        }
    }
}
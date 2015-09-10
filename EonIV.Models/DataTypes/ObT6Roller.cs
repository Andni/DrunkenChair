using Niklasson.EonIV.Models.BusinessObjects;
namespace Niklasson.EonIV.Models.DataTypes
{
    public sealed class ObT6Roller : IObT6Roller
    {
        private static readonly ObT6Roller instance = new ObT6Roller();

        public static ObT6Roller Instance
        {
            get
            {
                return instance;
            }
        }

        private ObT6Roller() { }
        static ObT6Roller() { }



        public int Roll(int dices)
        {
            System.Random rand = new System.Random();

            int dicesToRoll = dices;
            int result = 0;

            while (dicesToRoll > 0)
            {
                var roll = rand.Next(1, 6);

                if (roll == 6)
                {
                    dicesToRoll++;
                }
                else
                {
                    result += roll;
                    dicesToRoll--;
                }
            }
            return result;
        }
    }
}

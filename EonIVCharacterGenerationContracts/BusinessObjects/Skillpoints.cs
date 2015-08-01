using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    [ComplexType]
    public class Skillpoints
    {
        public int Battle { get; set; }
        public int Social { get; set; }
        public int Knowledge { get; set; }
        public int Mystic { get; set; }
        public int Movement { get; set; }
        public int Wilderness { get; set; }
        public int FreeChoise { get; set; }

        public int Count()
        {
            return Battle + Social + Knowledge + Mystic +
                Movement + Wilderness + FreeChoise;
        }

        public static Skillpoints operator+(Skillpoints lh, Skillpoints rh)
        {
            return new Skillpoints()
            {
                Battle = lh.Battle + rh.Battle,
                Social = lh.Social + rh.Social,
                Knowledge = lh.Knowledge + rh.Knowledge,
                Mystic = lh.Mystic + rh.Mystic,
                Movement = lh.Movement + rh.Movement,
                Wilderness = lh.Wilderness + rh.Wilderness,
                FreeChoise = lh.FreeChoise + rh.FreeChoise
            };
        }
    }
}

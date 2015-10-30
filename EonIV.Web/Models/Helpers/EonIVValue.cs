namespace Niklasson.EonIV.Web.Models.Helpers
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

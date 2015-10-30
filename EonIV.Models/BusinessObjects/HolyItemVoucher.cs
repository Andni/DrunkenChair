namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class HolyItemVoucher : CharacterModifier
    {
        public int NumberOfHolyItems { get; set; } = 1;

        public override string ConcreteModelType
        {
            get
            {
                return typeof(HolyItemVoucher).ToString();
            }
        }
    }
}
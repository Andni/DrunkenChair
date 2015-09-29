using System;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class MysteryVoucher : CharacterModifier
    {
        public int NumberOfMysteries { get; set; } = 1;

        public override string ConcreteModelType
        {
            get
            {
                return typeof(MysteryVoucher).ToString();
            }
        }
    }
}
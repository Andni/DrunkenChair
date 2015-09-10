using System;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class WeaponVoucher : CharacterModifier
    {
        public WeaponRarity Rarity { get; set; }
            
        public virtual ItemProperties AddedProperties { get; set; }

        public override string ConcreteModelType
        {
            get
            {
                return typeof(WeaponVoucher).ToString();
            }
        }
    }

    public enum WeaponRarity
    {
        COMMON = 0,
        UNCOMMON = 1,
        RARE = 2,
    }

}
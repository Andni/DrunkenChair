using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Gear : CharacterModifier
    {
        public int BaseItemId { get; set; }

        [ForeignKey("BaseItemId")]
        public virtual BaseItem Item { get; set; }

        public WeaponVoucher WeaponVoucher { get; set; } 

        public override string ConcreteModelType
        {
            get
            {
                return typeof(Gear).ToString();
            }
        }

    }
}

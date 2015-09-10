using System.ComponentModel.DataAnnotations.Schema; 

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Item : BaseItem
    {
        public int PropertiesContainerId { get; set; }

        [ForeignKey("PropertiesContainerId")]
        public virtual ItemProperties Properties { get; set; }
    }
}

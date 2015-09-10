using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class BaseItem
    {
        [Key]
        public int BaseItemId { get; set; }

        public string ItemName { get; set; }
        
        public string Description { get; set; }

        public int Value { get; set; }
    }
}

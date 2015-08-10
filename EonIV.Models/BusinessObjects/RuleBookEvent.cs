using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public enum EventCategory
    {
        TRAVELS_AND_ADVENTURES = 1,
        INTRIGUE_AND_MISDEADS = 2,
        KNOWLEDGE_AND_MYSTERIES = 3,
        BATTLES_AND_SKIRMISHES = 4,
        UNCATEGORIZED = 0
    }

    public class RuleBookEvent : IRuleBookEvent
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public EventCategory Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        //[Required]
        //public virtual List<CharacterModificationOptions> ModificationOptions { get; set; }
        
        public virtual CharacterModifierContainerSingleChoice CharacterModifiers { get; set; }

        public CharacterEvent ToCharacterEvent()
        {
            return new CharacterEvent()
            {
                Category = this.Category,
                Description = this.Description,
                Name = this.Name,
                Number = this.Number
            };
        }
    }

}
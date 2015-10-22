using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public enum EventCategory
    {
        TravelsAndAdventures = 1,
        IntrigueAndMisdeads = 2,
        KnowledgeAndMysteries = 3,
        BattlesAndSkirmishes = 4,
        Uncategorized = 0
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
        
        public virtual CharacterModifierContainer CharacterModifiers { get; set; }

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
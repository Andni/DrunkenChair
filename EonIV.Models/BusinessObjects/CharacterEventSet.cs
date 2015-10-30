using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterEventSet : BaseEventSet<ICharacterEvent>
    {

        public CharacterEventSet() : base() {}

        public CharacterEventSet(IEnumerable<ICharacterEvent> events) : this()
        {
            foreach(ICharacterEvent e in events)
            {
                Add(e);
            }
        }

        public static implicit operator CharacterEventSet(List<ICharacterEvent> events)
        {
            return new CharacterEventSet
            {
                TravelsAndAdventures = new List<ICharacterEvent>(events.FilterByCategory(EventCategory.TravelsAndAdventures)),
                BattlesAndSkirmishes = new List<ICharacterEvent>(events.FilterByCategory(EventCategory.BattlesAndSkirmishes)),
                KnowledgeAndMysteries = new List<ICharacterEvent>(events.FilterByCategory(EventCategory.KnowledgeAndMysteries)),
                IntrigueAndMisdeads = new List<ICharacterEvent>(events.FilterByCategory(EventCategory.IntrigueAndMisdeads))
            };
        }
    }
}

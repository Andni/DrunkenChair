using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class BaseEventSet<T> where T : IBaseEvent
    {
        public List<T> TravelsAndAdventures { get; set; }
        public List<T> BattlesAndSkirmishes { get; set; }
        public List<T> IntrigueAndMisdeads { get; set; }
        public List<T> KnowledgeAndMysteries { get; set; }

        public BaseEventSet()
        {
            TravelsAndAdventures = new List<T>();
            BattlesAndSkirmishes = new List<T>();
            IntrigueAndMisdeads = new List<T>();
            KnowledgeAndMysteries = new List<T>();
        }

        public BaseEventSet(IEnumerable<T> eventList) : this()
        {
            foreach(T e in eventList)
            {
                this.Add(e);
            }
        }

        public List<T> this[EventCategory cat]
        {
            get
            {
                switch (cat)
                {
                    case EventCategory.TRAVELS_AND_ADVENTURES:
                        return TravelsAndAdventures;
                    case EventCategory.BATTLES_AND_SKIRMISHES:
                        return BattlesAndSkirmishes;
                    case EventCategory.INTRIGUE_AND_MISDEADS:
                        return IntrigueAndMisdeads;
                    case EventCategory.KNOWLEDGE_AND_MYSTERIES:
                        return KnowledgeAndMysteries;
                    default:
                        return new List<T>();
                }
            }
        }

        public bool Add(T evnt)
        {
            if (evnt.Category != EventCategory.UNCATEGORIZED)
            {
                this[evnt.Category].Add(evnt);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.DrunkenChair.Repository;
using Niklasson.DrunkenChair.Models;
using Niklasson.DrunkenChair.Character;


namespace Niklasson.DrunkenChair.ServiceLayer
{
    public class EonIVCharacterGenerationService : IEonIVCharacterGenerationService
    {

        private IEonIVCharacterGenerationTables generationTables;

        public EonIVCharacterGenerationService(IEonIVCharacterGenerationTables tables)
        {
            generationTables = tables;
        }

        public Event GetRandomEvent(EventCategory cat)
        {
            return generationTables.GetRandomEvent(cat);
        }

        public IEnumerable<Archetype> Archetypes
        {
            get
            {
                return generationTables.Archetypes.OrderBy(t => t.Name);
            }
        }

        public IEnumerable<Background> Backgrounds
        {
            get
	        {
		        return generationTables.Backgrounds.OrderBy(t => t.Name);
            }
        }
        
        public IEnumerable<Environment> Environments
        {
            get
	        {
		        return generationTables.Environments.OrderBy(t => t.Name);
            }
        }
        public IEnumerable<Race> Races
        {
            get 
            {
                return generationTables.Races.OrderBy(t => t.Name);
            }
        }

        public RolledEvents RollEvents(EventTableRolls eventRolls)
        {
            RolledEvents events = new RolledEvents();

            events.Travels = GetRandomEvents(EventCategory.TRAVELS_AND_ADVENTURES, eventRolls.TravlesAndAdventures);
            events.Intrigue = GetRandomEvents(EventCategory.INTRIGUE_AND_MISDEADS, eventRolls.IntrigueAndIlldeads);
            events.Knowledge = GetRandomEvents(EventCategory.KNOWLEDGE_AND_MYSTERIES, eventRolls.KnowledgeAndMysteries);
            events.Battles = GetRandomEvents(EventCategory.BATTLES_AND_SKIRMISHES, eventRolls.BattlesAndSkirmishes);

            return events;
        }

        public CharacterBasics ResolveBasicDetails(CharacterBasicDetails details)
        {
            CharacterBasics res = new CharacterBasics();

            res.Archetype = Archetypes.SingleOrDefault(a => a.Name == details.SelectedArchetype) ?? new Archetype();
            res.Background = Backgrounds.SingleOrDefault(a => a.Name == details.SelectedBackground) ?? new Background();
            res.Environment = Environments.SingleOrDefault(a => a.Name == details.SelectedEnvironment) ?? new Environment();
            res.Race = Races.SingleOrDefault(a => a.Name == details.SelectedRace) ?? new Race();

            return res;
        }

        private List<Event> GetRandomEvents(EventCategory cat, int number)
        {
            return generationTables.GetRandomEvents(cat, number).ToList();
        }
    }
}
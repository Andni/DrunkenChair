using System.Collections.Generic;
using System.Linq;
using Niklasson.EonIV.DataAccess.Repositories;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Services
{
    public class EonIVCharacterGenerationService : IEonIVCharacterGenerationService
    {

        private IEonIVCharacterGenerationTables generationTables;

        public EonIVCharacterGenerationService(IEonIVCharacterGenerationTables tables)
        {
            generationTables = tables;
        }

        public ICollection<Background> GetRandomBackgrounds(int count)
        {
            return generationTables.GetRandomBackgrounds(count);
        }

        public IRuleBookEvent GetRandomEvent(EventCategory cat)
        {
            return generationTables.GetRandomEvent(cat);
        }

        public Background GetBackground(string backgroundName)
        {
            return generationTables.Backgrounds.Where(b => b.Name == backgroundName).SingleOrDefault();
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

        public Archetype GetArchetype(string archetypeName)
        {
            return generationTables.Archetypes.Where(r => r.Name == archetypeName).SingleOrDefault();
        }

        public Race GetRace(string raceName)
        {
            return generationTables.Races.Where(r => r.Name == raceName).SingleOrDefault();
        }

        public Environment GetEnvironment(string environmentName)
        {
            return generationTables.Environments.Where(r => r.Name == environmentName).SingleOrDefault();
        }


        public IEnumerable<IRuleBookEvent> RollEvents(EventTableRolls eventRolls)
        { 
            var events = new List<IRuleBookEvent>();

            var v = GetRandomEvents(EventCategory.TRAVELS_AND_ADVENTURES, eventRolls.TravlesAndAdventures);
            events.AddRange( v); 
            events.AddRange(GetRandomEvents(EventCategory.INTRIGUE_AND_MISDEADS, eventRolls.IntrigueAndIlldeads));
            events.AddRange(GetRandomEvents(EventCategory.KNOWLEDGE_AND_MYSTERIES, eventRolls.KnowledgeAndMysteries));
            events.AddRange(GetRandomEvents(EventCategory.BATTLES_AND_SKIRMISHES, eventRolls.BattlesAndSkirmishes));

            return events;
        }

        public CharacterBasics ResolveBasicChoices(ICharacterBasicChoices details)
        {
            CharacterBasics res = new CharacterBasics();

            res.Archetype = Archetypes.SingleOrDefault(a => a.Name == details.SelectedArchetype) ?? new Archetype();
            res.Background = Backgrounds.SingleOrDefault(a => a.Name == details.SelectedBackground) ?? new Background();
            res.Environment = Environments.SingleOrDefault(a => a.Name == details.SelectedEnvironment) ?? new Environment();
            res.Race = Races.SingleOrDefault(a => a.Name == details.SelectedRace) ?? new Race();

            return res;
        }

        public void SetBasicDetails(ICharacterBasicChoices basics)
        {

        }

        private List<IRuleBookEvent> GetRandomEvents(EventCategory cat, int number)
        {
            return generationTables.GetRandomEvents(cat, number).ToList();
        }
    }
}
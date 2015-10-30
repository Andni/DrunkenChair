using System.Linq;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Services
{

    public class CharacterConstructionSite
    {
        private CharacterData characterData = new CharacterData();
        
        public CharacterConstructionSite()
        {
        }

        public EventTableRolls GetCharacterEventRolls(){
            return characterData.GetEventRolls();
        }

        public void SetBackground(Background background)
        {
            characterData.Background = background;
        }

        public void SetArchetype(Archetype archetype)
        {
            characterData.Archetype = archetype;
        }

        public void SetRace(Race race)
        {
            characterData.Race = race;
        }

        public void SetEnvironment(Environment environment)
        {
            characterData.Environment = environment;
        }

        public void SetBackground(string backgroundName, IEonIVCharacterGenerationService service)
        {
            var background = service.GetBackground(backgroundName);
            if(background != null)
            {
                characterData.Background = background;
            }
        }

        public IBaseAttributeDices GetCharacterAttributeExtraDiceDistribution()
        {
            return characterData.ExtraAttributeDiceDistribution;
        }
        
        public void SetCharacterAttributeExtraDiceDistribution(IBaseAttributeDices extraDices)
        {
            characterData.ExtraAttributeDiceDistribution = new BaseAttributeDices(extraDices);
        }

        public RuleBookEventSet GetCharacterEvents() {
            return characterData.Events;
        }

        public CharacterSheet ToCharacterSheet()
        {
            return new CharacterSheet(characterData);
        }

        public CharacterGenerationData GetGenerationData()
        {
            return new CharacterGenerationData(characterData);
        }

        public bool RerollEvent(EventCategory cat, int index, IEonIVCharacterGenerationService characterGenerationService)
        {
            if (index + 1 > characterData.Events[cat].Count())
            {
                return false;
            }
            else
            {
                var e = characterGenerationService.GetRandomEvent(cat);
                characterData.Events[cat][index] = e;
                return true;
            }
        }

        public IRuleBookEvent AddRandomEvent(EventCategory eventCategory, IEonIVCharacterGenerationService service)
        {
            var ev = service.GetRandomEvent(eventCategory);
            characterData.Events.Add(ev);
            return ev;
        }

        public void RollEvents(IEonIVCharacterGenerationService service)
        {
            characterData.Events = new RuleBookEventSet(service.RollEvents(characterData.GetEventRolls()));
        }

        public void SetCharacterEventDetails(RuleBookEventSet events)
        {                                                                
            characterData.Events = events;
        }

        public string GetArchetypeName()
        {
            return characterData.Archetype.Name;
        }

        public string GetBackgroundName()
        {
            return characterData.Background.Name;
        }

        public string GetEnvironmentName()
        {
            return characterData.Environment.Name;
        }

        public string GetRaceName()
        {
            return characterData.Race.Name;
        }

        public Archetype Archetype
        {
            get { return characterData.Archetype; }
            set { characterData.Archetype = value; }
        }

        public Background Background
        {
            get { return characterData.Background; }
            set { characterData.Background= value; }
        }

        public Environment Environment
        {
            get { return characterData.Environment; }
            set { characterData.Environment = value; }
        }

        public Race Race
        {
            get { return characterData.Race; }
            set { characterData.Race = value; }
        }



        public void SetRace(string raceName, IEonIVCharacterGenerationService characterGenerationService)
        {
            characterData.Race = characterGenerationService.GetRace(raceName);
        }

        public void SetArchetype(string archetypeName, IEonIVCharacterGenerationService characterGenerationService)
        {
            characterData.Archetype = characterGenerationService.GetArchetype(archetypeName);
        }

        public void SetEnvironment(string environmentName, IEonIVCharacterGenerationService characterGenerationService)
        {
            characterData.Environment = characterGenerationService.GetEnvironment(environmentName);
        }
    }
}                  

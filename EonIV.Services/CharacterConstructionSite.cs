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
            return characterData.Basics.GetEventRolls();
        }

        public void SetCharacterBasicDetails(ICharacterBasicChoices basicChoices, IEonIVCharacterGenerationService service)
        {
            characterData.Basics = service.ResolveBasicChoices(basicChoices);
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
            return characterData.ToCharacterSheet();
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
            characterData.Events = new RuleBookEventSet(service.RollEvents(characterData.Basics.GetEventRolls()));
        }

        public void SetCharacterEventDetails(RuleBookEventSet events)
        {                                                                
            characterData.Events = events;
        }

        public string GetArchetype()
        {
            return characterData.Basics.Archetype;
        }

        public string GetBackground()
        {
            return characterData.Basics.Background;
        }

        public string GetEnvironment()
        {
            return characterData.Basics.Environment;
        }

        public string GetRace()
        {
            return characterData.Basics.Race;
        }
    }
}                  

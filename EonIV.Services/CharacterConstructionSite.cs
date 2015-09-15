using System;
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
            characterData.Events = new RuleBookEventSet(service.RollEvents(characterData.GetEventRolls()));
        }

        public void SetCharacterEventDetails(RuleBookEventSet events)
        {                                                                
            characterData.Events = events;
        }

        public string GetArchetype()
        {
            return characterData.Archetype;
        }

        public string GetBackground()
        {
            return characterData.Background;
        }

        public string GetEnvironment()
        {
            return characterData.Environment;
        }

        public string GetRace()
        {
            return characterData.Race;
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

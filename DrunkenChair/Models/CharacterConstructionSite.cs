using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Character;
using Niklasson.EonIV.CharacterGeneration.Contracts;

using System.Web.Mvc;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterConstructionSite : ICharacterConstructionSite
    {
        private CharacterData character = new CharacterData();

        public CharacterMetaData GetScaffolding()
        {
            return Character.Scaffolding;
        }

        public CharacterData Character {
            get
            {
                return character;
            }
        }
        
        public CharacterBasicDetails CharacterBasicDetails{
            get
            {
                var basics = Character.GetBasicDetails();
                basics.CharacterConstructionSite = this;
                return basics;
            }
        }

        public void SetCharacterBasicDetails(CharacterBasics details)
        {
            Character.Basics = details;
        }

        public CharacterAttributeDetails CharacterAttributeDetails
        {
            get
            {
                var res = new CharacterAttributeDetails()
                {
                    CharacterBaseAttributeSet = Character.AttributeBonusDices,
                    CharacterConstructionSite = this
                };
                return res;
            }
            set
            {
                Character.AttributeBonusDices = value.GetCharacterBaseAttributeSet();
            }
        }

        public CharacterEventDetails CharacterEventDetails {
            get
            {
                CharacterEventDetails res = new Models.CharacterEventDetails();
                res.RolledEvents = Character.Events;
                res.FreeEventRolls = GetScaffolding().FreeEventRolls;
                res.CharacterConstructionSite = this;
                return res;
            }
            set
            {
                Character.Events = value.RolledEvents;
            }
        }

        public CharacterSheet CharacterSheet
        {   
            get
            {
                return Character.ToCharacterSheet();
            }
        }

        public CharacterSheet GetCharacterPreview()
        {
            return Character.ToCharacterSheet();
        }

        //public bool RerollEvent(EventCategory cat, int index, IEonIVCharacterGenerationService characterGenerationService)
        //{
        //    if(index + 1 > character.RolledEvents[cat].Count() )
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        var e = characterGenerationService.GetRandomEvent(cat);
        //        var updatedList = character.RolledEvents[cat].ToList();
        //        updatedList[index] = e;
        //        character.RolledEvents[cat] = (IEnumerable<Event>)updatedList;
        //        return true;
        //    }
        //}

        //private CharacterBasics ResolveCharacterBasics(CharacterBasicDetails details, IEonIVCharacterGenerationService characterGenerationService)
        //{
        //    CharacterBasics res = new CharacterBasics();

        //    res.Archetype = characterGenerationService.Archetypes.SingleOrDefault(a => a.Name == details.SelectedArchetype) ?? new Archetype();
        //    res.Background = characterGenerationService.Backgrounds.SingleOrDefault(a => a.Name == details.SelectedBackground) ?? new Background();
        //    res.Environment = characterGenerationService.Environments.SingleOrDefault(a => a.Name == details.SelectedEnvironment) ?? new Environment();
        //    res.Race = characterGenerationService.Races.SingleOrDefault(a => a.Name == details.SelectedRace) ?? new Race();
            
        //    return res;
        //}

        //public void RollEvents(IEonIVCharacterGenerationService service)
        //{
        //    character.RolledEvents = service.RollEvents(character.Scaffolding.EventRolls);
        //}

        //public Event AddRandomEvent(EventCategory eventCategory, IEonIVCharacterGenerationService service)
        //{
        //    var ev = service.GetRandomEvent(eventCategory);
        //    character.RolledEvents.Add(ev);
        //    return ev;
        //}
    }
}
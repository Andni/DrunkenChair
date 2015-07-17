using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.Composition;

using Niklasson.DrunkenChair.Models;
using Niklasson.DrunkenChair.Character;
using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.DrunkenChair.Extensions;

namespace Niklasson.DrunkenChair.Controllers
{
    public class EonIVCharacterCreatorController : Controller
    {
        private IEonIVCharacterGenerationService characterGenerationService;
        
        public EonIVCharacterCreatorController(IEonIVCharacterGenerationService service)
        {
            characterGenerationService = service;
        }

        private string sessionStringCharacter = "character";

        // GET: EonIvCharacters/Create
        public ActionResult Create()
        {   
            return View(GetBlankCharacterBasicDetails());
        }

        private CharacterBasicDetails GetBlankCharacterBasicDetails()
        {
            return new CharacterBasicDetails()
            {
                Archetypes = new SelectList(characterGenerationService.Archetypes),
                Environments = new SelectList(characterGenerationService.Environments),
                Races = new SelectList(characterGenerationService.Races),
                CharacterConstructionSite = new CharacterConstructionSite()
            };
        }

        // POST: EonIvCharacters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterBasicDetails basicDetails, string previousButton, string nextButton)
        {
            var ccs = GetCharacterConstructionSite();
            if(nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    ccs.SetCharacterBasicDetails(characterGenerationService.ResolveBasicChoices(basicDetails));
                    return View("CharacterAttributeDetails", ccs.CharacterAttributeDetails);
                }
            }
            return View(ccs.CharacterBasicDetails);
        }

        // GET: EonIvCharacters/CharacterAttributeDetails
        public ActionResult CharacterAttributeDetails()
        {
            int DicesToDistribute = 10;
            int MaxDicesPerAttribute = 5;
            
            ViewBag.DicesToDistribute = DicesToDistribute;
            ViewBag.MaxDiceesPerAttribute = MaxDicesPerAttribute;

            return View(new CharacterAttributeDetails() { CharacterConstructionSite = GetCharacterConstructionSite()});
        }

        [HttpPost]
        public ActionResult CharacterAttributeDetails(CharacterAttributeDetails attributeDetails, string previousButton, string nextButton)
        {
            var ccs = GetCharacterConstructionSite();
            if(nextButton != null)
            {
                if(ModelState.IsValid)
                {
                    ccs.CharacterAttributeDetails = attributeDetails;
                    var rolledEvents = RollEvents(ccs.GetScaffolding().EventRolls);
                    ccs.Character.Events = new EventViewModelSet(rolledEvents);
                    return View("CharacterEventDetails", ccs.CharacterEventDetails);
                }
            }
            
            if(previousButton != null)
            {
                return View("Create", ccs.CharacterBasicDetails);
            }
            
            return View(ccs.CharacterAttributeDetails);
        }

        [HttpPost]
        public ActionResult RerollEvent(RerollEventRequest request)
        {
            var ccs = GetCharacterConstructionSite();
            var newEvent = new EventViewModel(characterGenerationService.GetRandomEvent(request.Category));
            ccs.Character.Events[request.Category][request.Index] = newEvent;
            return PartialView("RolledEvents", ccs.Character.Events);
        }

        [HttpPost]
        public ActionResult CharacterEventDetails(CharacterEventDetails eventDetails, string previousButton, string nextButton)
        {
            if(nextButton != null)
            {
                if(ModelState.IsValid)
                {
                    GetCharacterConstructionSite().CharacterEventDetails = eventDetails;
                    return View("CharacterResourceDetials"); //placeholder, should return next view
                }
                else
                {   
                    return View(eventDetails);
                }
            }
            
            if (previousButton != null)
            {
                return View("CharacterAttributeDetails", GetCharacterConstructionSite().CharacterAttributeDetails);
            }
            
            return View("CharacterEventDetails", GetCharacterConstructionSite().CharacterEventDetails);
        }

        [HttpGet]
        public JsonResult GetDerivedAttributes(string str, string sta, string agl, string per, string wil, string psy, string wis, string cha)
        {
            var res = new JsonResult();
            var atr = new CharacterAttributeSet()
            {
                Strength = str,
                Stamina = sta,
                Agility = agl,
                Perception = per,
                Will = wil,
                Psyche = psy,
                Wisdom = wis,
                Charisma = cha
            };
            res.Data = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(atr);
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }

        [HttpPost]
        public JsonResult AddRandomEventToCategory(RandomEventRequest request)
        {
            var result = new JsonResult();
            var ev = new EventViewModel(characterGenerationService.GetRandomEvent(request.EventCategory));
            GetCharacterConstructionSite().Character.Events.Add(ev);
            result.Data = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ev);
            return result;
        }

        private CharacterConstructionSite GetCharacterConstructionSite()
        {
            if (Session[sessionStringCharacter] == null)
            {
                Session[sessionStringCharacter] = new CharacterConstructionSite();
            }
            return (CharacterConstructionSite)Session[sessionStringCharacter];
        }

        private void RemoveCharacter()
        {
            Session.Remove(sessionStringCharacter);
        }

        public bool RerollEvent(EventCategory cat, int index)
        {
            var character = GetCharacterConstructionSite().Character;
            if (index + 1 > character.Events[cat].Count())
            {
                return false;
            }
            else
            {
                var newEvent = new EventViewModel(characterGenerationService.GetRandomEvent(cat));
                character.Events[cat][index] = newEvent;
                return true;
            }
        }

        private CharacterBasics ResolveCharacterBasics(CharacterBasicDetails details)
        {
            CharacterBasics res = new CharacterBasics();

            res.Archetype = characterGenerationService.Archetypes.SingleOrDefault(a => a.Name == details.SelectedArchetype) ?? new Archetype();
            res.Background = characterGenerationService.Backgrounds.SingleOrDefault(a => a.Name == details.SelectedBackground) ?? new Background();
            res.Environment = characterGenerationService.Environments.SingleOrDefault(a => a.Name == details.SelectedEnvironment) ?? new Environment();
            res.Race = characterGenerationService.Races.SingleOrDefault(a => a.Name == details.SelectedRace) ?? new Race();

            return res;
        }

        public IEnumerable<IRuleBookEvent> RollEvents(EventTableRolls rolls)
        {
            var character = GetCharacterConstructionSite().Character;
            var events = characterGenerationService.RollEvents(rolls);
            return events;
        }

        public EventViewModel AddRandomEvent(EventCategory eventCategory, IEonIVCharacterGenerationService service)
        {
            var ev = new EventViewModel(service.GetRandomEvent(eventCategory));
            GetCharacterConstructionSite().Character.Events.Add(ev);
            return ev;
        }
    }
}

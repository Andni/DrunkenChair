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
using Niklasson.EonIV.CharacterGeneration.BusinessObjects;

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

        private CharacterBasicStepViewModel GetBlankCharacterBasicDetails()
        {
            return new CharacterBasicStepViewModel()
            {
                Archetypes = new SelectList(characterGenerationService.Archetypes),
                Environments = new SelectList(characterGenerationService.Environments),
                Races = new SelectList(characterGenerationService.Races),
                CharacterPreview = new CharacterPreview(GetCharacterConstructionSite()),

                SelectedArchetype = characterGenerationService.Archetypes.FirstOrDefault(),
                SelectedEnvironment = characterGenerationService.Environments.FirstOrDefault(),
                SelectedRace = characterGenerationService.Races.FirstOrDefault()
            };
        }

        // POST: EonIvCharacters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterBasicStepViewModel basicDetails, string previousButton, string nextButton)
        {
            var ccs = GetCharacterConstructionSite();
            if(nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    ccs.SetCharacterBasicDetails(basicDetails, characterGenerationService);
                    return View("CharacterAttributeDetails", new CharacterAttributeStepViewModel() { Preview = new CharacterPreview(ccs) });
                }
            }
            return View(new CharacterBasicStepViewModel() { CharacterPreview = new CharacterPreview(ccs) });
        }

        // GET: EonIvCharacters/CharacterAttributeDetails
        public ActionResult CharacterAttributeDetails()
        {
            int DicesToDistribute = 10;
            int MaxDicesPerAttribute = 5;

            ViewBag.DicesToDistribute = DicesToDistribute;
            ViewBag.MaxDiceesPerAttribute = MaxDicesPerAttribute;

            return View(
                new CharacterAttributeStepViewModel()
                {
                    Preview = new CharacterPreview(GetCharacterConstructionSite())
                }    
            );
        }
        
        [HttpPost]
        public ActionResult CharacterAttributeDetails(CharacterAttributeStepViewModel attributeDetails, string previousButton, string nextButton)
        {
            var ccs = GetCharacterConstructionSite();
            if(nextButton != null)
            {
                if(ModelState.IsValid)
                {
                    ccs.SetCharacterAttributeExtraDiceDistribution(attributeDetails);
                    ccs.RollEvents(characterGenerationService);
                    return View("CharacterEventDetails", new CharacterEventStepViewModel(ccs));
                }
            }
            
            if(previousButton != null)
            {
                return View("Create", new CharacterBasicStepViewModel() { CharacterPreview = new CharacterPreview(ccs) });
            }

            return View(new CharacterAttributeStepViewModel() { Preview = new CharacterPreview(ccs) });
        }

        [HttpPost]
        public ActionResult RerollEvent(RerollEventRequest request)
        {
            var ccs = GetCharacterConstructionSite();

            ccs.RerollEvent(request.Category, request.Index, characterGenerationService);

            return PartialView("RuleBookEventSet", ccs.GetCharacterEvents());
        }

        [HttpPost]
        public ActionResult CharacterEventDetails(CharacterEventDetails eventDetails, string previousButton, string nextButton)
        {
            if(nextButton != null)
            {
                if(ModelState.IsValid)
                {
                    GetCharacterConstructionSite().SetCharacterEventDetails(eventDetails.Events);
                    return View("CharacterResourceDetials"); //placeholder, should return next view
                }
                else
                {   
                    return View(eventDetails);
                }
            }
            
            if (previousButton != null)
            {
                return View("CharacterAttributeDetails",
                    new CharacterAttributeStepViewModel()
                    {
                        Preview = new CharacterPreview(GetCharacterConstructionSite())
                    });
            }
            
            return View("CharacterEventDetails", GetCharacterConstructionSite().GetCharacterEvents());
        }

        [HttpGet]
        public ActionResult GetCharacterPreview(string selectedArchetype, string selectedRace, string selectedEnvironment)
        {
            var choices = new CharacterBasicChoices()
            {
                SelectedArchetype = selectedArchetype,
                SelectedEnvironment = selectedEnvironment,
                SelectedRace = selectedEnvironment
            };
            var ccs = GetCharacterConstructionSite();
            ccs.SetCharacterBasicDetails(choices, characterGenerationService);
            return PartialView("CharacterPreview", new CharacterPreview(ccs));
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
            var ev = GetCharacterConstructionSite().AddRandomEvent(request.EventCategory, characterGenerationService);
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

        //public bool RerollEvent(EventCategory cat, int index)
        //{
        //    var character = GetCharacterConstructionSite().Character;
        //    if (index + 1 > character.Events[cat].Count())
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        var newEvent = new EventViewModel(characterGenerationService.GetRandomEvent(cat));
        //        character.Events[cat][index] = newEvent;
        //        return true;
        //    }
        //}

        private CharacterBasics ResolveCharacterBasics(CharacterBasicStepViewModel details)
        {
            CharacterBasics res = new CharacterBasics();

            res.Archetype = characterGenerationService.Archetypes.SingleOrDefault(a => a.Name == details.SelectedArchetype) ?? new Archetype();
            res.Background = characterGenerationService.Backgrounds.SingleOrDefault(a => a.Name == details.SelectedBackground) ?? new Background();
            res.Environment = characterGenerationService.Environments.SingleOrDefault(a => a.Name == details.SelectedEnvironment) ?? new Environment();
            res.Race = characterGenerationService.Races.SingleOrDefault(a => a.Name == details.SelectedRace) ?? new Race();

            return res;
        }

        //public IEnumerable<IRuleBookEvent> RollEvents(EventTableRolls rolls)
        //{
        //    var character = GetCharacterConstructionSite().Character;
        //    var events = characterGenerationService.RollEvents(rolls);
        //    return events;
        //}

        //public EventViewModel AddRandomEvent(EventCategory eventCategory, IEonIVCharacterGenerationService service)
        //{
        //    var ev = new EventViewModel(service.GetRandomEvent(eventCategory));
        //    GetCharacterConstructionSite().Character.Events.Add(ev);
        //    return ev;
        //}
    }
}

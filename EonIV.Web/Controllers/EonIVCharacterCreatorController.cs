using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Niklasson.DrunkenChair.Models;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Services;

namespace Niklasson.DrunkenChair.Controllers
{
    public class EonIVCharacterCreatorController : Controller
    {
        private readonly IEonIVCharacterGenerationService characterGenerationService;
        
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
            var ccs = GetCharacterConstructionSite();
            
            var selectedArchetype = characterGenerationService.Archetypes.FirstOrDefault();
            var selectedEnvironment = characterGenerationService.Environments.FirstOrDefault();
            var selectedRace = characterGenerationService.Races.FirstOrDefault();
            ccs.SetCharacterBasicDetails(new CharacterBasicChoices
                {
                    SelectedArchetype = selectedArchetype,
                    SelectedEnvironment = selectedEnvironment,
                    SelectedRace = selectedRace
                },
                characterGenerationService);

            return new CharacterBasicStepViewModel(ccs)
            {
                Archetypes = new SelectList(characterGenerationService.Archetypes),
                Environments = new SelectList(characterGenerationService.Environments),
                Races = new SelectList(characterGenerationService.Races),
                Backgrounds = new List<Background>(characterGenerationService.GetRandomBackgrounds(2)),

                CharacterPreview = new CharacterPreview(GetCharacterConstructionSite()),
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
                    return View("UnderConstruction"); //placeholder, should return next view
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
        public ActionResult GetCharacterPreview(string archetype, string race, string environment)
        {
            var choices = new CharacterBasicChoices()
            {
                SelectedArchetype = archetype,
                SelectedEnvironment = environment,
                SelectedRace = race
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
            res.Data = new JavaScriptSerializer().Serialize(atr);
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }

        [HttpPost]
        public JsonResult AddRandomEventToCategory(RandomEventRequest request)
        {
            var result = new JsonResult();
            var ev = GetCharacterConstructionSite().AddRandomEvent(request.EventCategory, characterGenerationService);
            result.Data = new JavaScriptSerializer().Serialize(ev);
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
        
        private CharacterBasics ResolveCharacterBasics(CharacterBasicStepViewModel details)
        {
            CharacterBasics res = new CharacterBasics();

            res.Archetype = characterGenerationService.Archetypes.SingleOrDefault(a => a.Name == details.SelectedArchetype) ?? new Archetype();
            res.Background = characterGenerationService.Backgrounds.SingleOrDefault(a => a.Name == details.SelectedBackground) ?? new Background();
            res.Environment = characterGenerationService.Environments.SingleOrDefault(a => a.Name == details.SelectedEnvironment) ?? new Environment();
            res.Race = characterGenerationService.Races.SingleOrDefault(a => a.Name == details.SelectedRace) ?? new Race();

            return res;
        }

    }
}

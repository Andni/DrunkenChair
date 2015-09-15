using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Niklasson.EonIV.Web.Models;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Services;

using Environment = Niklasson.EonIV.Models.BusinessObjects.Environment;

namespace Niklasson.EonIV.Web.Controllers
{
    public class EonIVCharacterCreatorController : Controller
    {
        private readonly IEonIVCharacterGenerationService characterGenerationService;
        
        public EonIVCharacterCreatorController(IEonIVCharacterGenerationService service)
        {
            characterGenerationService = service;
        }

        private string sessionStringCharacter = "character";


        [HttpGet]
        public ActionResult BackgroundStep()
        {
            return View(GetCharacterBackgroundStepWithBackgrounds());
        }

        [HttpPost]
        public ActionResult BackgroundStep(CharacterBackgroundStepViewModel backgroundDetails, string nextButton, string previousButton)
        {
            var ccs = GetCharacterConstructionSite();
            if (nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    var races = new SelectList(characterGenerationService.Races);
                    return View("RaceStep", new CharacterRaceStepViewModel(ccs)
                    {
                        Races = races,
                        SelectedRace = string.IsNullOrEmpty(ccs.GetRace()) ? characterGenerationService.Races.FirstOrDefault() : ccs.GetRace(),
                    });
                }
            }

            if (previousButton != null)
            {
                return View("BackgroundStep", new CharacterBackgroundStepViewModel(ccs));
            }

            return View(backgroundDetails);
        }
        
        [HttpPost]
        public ActionResult RaceStep(CharacterRaceStepViewModel raceStep, string nextButton, string previousButton)
        {
            var ccs = GetCharacterConstructionSite();
            if (nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    var archetypes = new SelectList(characterGenerationService.Archetypes);
                    var selectedArchetype = string.IsNullOrEmpty(ccs.GetArchetype()) ? characterGenerationService.Archetypes.FirstOrDefault() : ccs.GetArchetype();

                    return View("ArchetypeStep",
                        new CharacterArchetypeStepViewModel(ccs)
                        {
                            Archetypes = archetypes,
                            SelectedArchetype = selectedArchetype
                        }
                    );
                }
            }

            if (previousButton != null)
            {
                return View("BackgroundStep", new CharacterBackgroundStepViewModel(ccs));
            }

            return View(raceStep);
        }

        [HttpPost]
        public ActionResult ArchetypeStep(CharacterRaceStepViewModel archetypeStep, string nextButton, string previousButton)
        {
            var ccs = GetCharacterConstructionSite();
            if (nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    var environments = new SelectList(characterGenerationService.Environments);
                    var selectedEnvironment = string.IsNullOrEmpty(ccs.GetEnvironment()) ? characterGenerationService.Environments.FirstOrDefault() : ccs.GetEnvironment();
                    return View("EnvironmentStep", new CharacterEnvironmentStepViewModel(ccs)
                    {
                        Environments = environments,
                        SelectedEnvironment = selectedEnvironment
                    });
                }
            }

            if (previousButton != null)
            {
                return View("RaceStep", new CharacterRaceStepViewModel(ccs));
            }

            return View(archetypeStep);
        }

        [HttpPost]
        public ActionResult EnvironmentStep(CharacterRaceStepViewModel environmentStep, string nextButton, string previousButton)
        {
            var ccs = GetCharacterConstructionSite();
            if (nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    var environments = new SelectList(characterGenerationService.Environments);
                    var selectedEnvironment = string.IsNullOrEmpty(ccs.GetEnvironment()) ? environments.FirstOrDefault().ToString() : ccs.GetEnvironment();
                    return View("CharacterAttributeDetails", new CharacterEnvironmentStepViewModel(ccs)
                        {
                            Environments = environments,
                            SelectedEnvironment = selectedEnvironment,
                        }
                    );
                }
            }

            if (previousButton != null)
            {
                return View("ArchetypeStep", new CharacterArchetypeStepViewModel(ccs));
            }

            return View(environmentStep);
        }
        
        private CharacterBackgroundStepViewModel GetCharacterBackgroundStepWithBackgrounds()
        {
            var ccs = GetCharacterConstructionSite();
            var backgrounds = characterGenerationService.GetRandomBackgrounds(2);
            var backgroundStep = new CharacterBackgroundStepViewModel(ccs)
            {
                Backgrounds = backgrounds.ToList(),
                SelectedBackground = backgrounds.FirstOrDefault(),
                BackgroundInfo = backgrounds.FirstOrDefault(),
            };
            return backgroundStep;
        }

        //private CharacterBasicStepViewModel GetBlankCharacterBasicDetails()
        //{
        //    var ccs = GetCharacterConstructionSite();
            
        //    var selectedArchetype = characterGenerationService.Archetypes.FirstOrDefault();
        //    var selectedEnvironment = characterGenerationService.Environments.FirstOrDefault();
        //    var selectedRace = characterGenerationService.Races.FirstOrDefault();
        //    ccs.SetCharacterBasicDetails(new CharacterBasicChoices
        //        {
        //            SelectedArchetype = selectedArchetype,
        //            SelectedEnvironment = selectedEnvironment,
        //            SelectedRace = selectedRace
        //        },
        //        characterGenerationService);

        //    return new CharacterBasicStepViewModel(ccs)
        //    {
        //        Archetypes = new SelectList(characterGenerationService.Archetypes),
        //        Environments = new SelectList(characterGenerationService.Environments),
        //        Races = new SelectList(characterGenerationService.Races),
        //        Backgrounds = new List<Background>(characterGenerationService.GetRandomBackgrounds(2)),

        //        CharacterPreview = new CharacterPreview(GetCharacterConstructionSite()),
        //    };
        //}

        // POST: EonIvCharacters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(CharacterBasicStepViewModel basicDetails, string previousButton, string nextButton)
        //{
        //    var ccs = GetCharacterConstructionSite();
        //    if(nextButton != null)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            ccs.SetCharacterBasicDetails(basicDetails, characterGenerationService);
        //            return View("CharacterAttributeDetails", new CharacterBonusAttributeStepViewModel() { Preview = new CharacterPreview(ccs) });
        //        }
        //    }
        //    return View(new CharacterBasicStepViewModel() { CharacterPreview = new CharacterPreview(ccs) });
        //}

        // GET: EonIvCharacters/CharacterAttributeDetails
        public ActionResult CharacterAttributeDetails()
        {
            int DicesToDistribute = 10;
            int MaxDicesPerAttribute = 5;

            ViewBag.DicesToDistribute = DicesToDistribute;
            ViewBag.MaxDiceesPerAttribute = MaxDicesPerAttribute;

            return View(
                new CharacterBonusAttributeStepViewModel()
                {
                    Preview = new CharacterPreview(GetCharacterConstructionSite())
                }    
            );
        }
        
        [HttpPost]
        public ActionResult CharacterAttributeDetails(CharacterBonusAttributeStepViewModel attributeDetails, string previousButton, string nextButton)
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

            return View(new CharacterBonusAttributeStepViewModel() { Preview = new CharacterPreview(ccs) });
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
                    new CharacterBonusAttributeStepViewModel()
                    {
                        Preview = new CharacterPreview(GetCharacterConstructionSite())
                    });
            }
            
            return View("CharacterEventDetails", GetCharacterConstructionSite().GetCharacterEvents());
        }

        [HttpGet]
        public ActionResult UpdateBackground(string background)
        {
            var ccs = GetCharacterConstructionSite();
            ccs.SetBackground(background, characterGenerationService);
            return PartialView("CharacterPreview", new CharacterPreview(ccs));
        }

        [HttpGet]
        public ActionResult UpdateRace(string race)
        {
            var ccs = GetCharacterConstructionSite();
            ccs.SetRace(race, characterGenerationService);
            return PartialView("CharacterPreview", new CharacterPreview(ccs));
        }
        
        [HttpGet]
        public ActionResult UpdateArchetype(string archetype)
        {
            var ccs = GetCharacterConstructionSite();
            ccs.SetArchetype(archetype, characterGenerationService);
            return PartialView("CharacterPreview", new CharacterPreview(ccs));
        }
        
        [HttpGet]
        public ActionResult UpdateEnvironment(string environment)
        {
            var ccs = GetCharacterConstructionSite();
            ccs.SetEnvironment(environment, characterGenerationService);
            return PartialView("CharacterPreview", new CharacterPreview(ccs));
        }

        [HttpGet]
        public ActionResult GetCharacterPreview()
        {
            return PartialView("CharacterPreview", new CharacterPreview(GetCharacterConstructionSite()));
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

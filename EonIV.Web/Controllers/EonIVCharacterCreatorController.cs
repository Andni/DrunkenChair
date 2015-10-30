using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Niklasson.EonIV.Web.Models;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Services;

using Environment = Niklasson.EonIV.Models.BusinessObjects.Environment;
using System.Diagnostics;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Web.Controllers
{
    public partial class EonIVCharacterCreatorController : Controller
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
        public ActionResult BackgroundStep(string SelectedBackground, string nextButton, string previousButton)
        {
            var ccs = GetCharacterConstructionSite();
            if (nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    return View("RaceStep", GetCharacterRaceStepViewModel());
                }
            }
            
            return View(GetCharacterBackgroundStepViewModel());
        }
        
        [HttpPost]
        public ActionResult RaceStep(string SelectedRace, string nextButton, string previousButton)
        {
            var ccs = GetCharacterConstructionSite();
            if (nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    ccs.Race = characterGenerationService.GetRace(SelectedRace);       
                    return View("ArchetypeStep", GetCharacterArchetypeStepViewModel());
                }
            }

            if (previousButton != null)
            {
                return View("BackgroundStep", GetCharacterBackgroundStepViewModel());
            }

            return View(GetCharacterRaceStepViewModel());
        }

        [HttpPost]
        public ActionResult ArchetypeStep(CharacterArchetypeStepViewModel CharacterArchetypeStepViewModel, string nextButton, string previousButton)
        {
            var ccs = GetCharacterConstructionSite();
            if (nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    //TODO: validate archetype resource selection

                    return View("EnvironmentStep", GetCharacterEnvironmentStepViewModel());
                }
            }

            if (previousButton != null)
            {
                return View("RaceStep", GetCharacterRaceStepViewModel());
            }

            return View(GetCharacterArchetypeStepViewModel());
        }

        [HttpPost]
        public ActionResult EnvironmentStep(Environment CurrentSelectedEnvironment, string nextButton, string previousButton)
        {
            var ccs = GetCharacterConstructionSite();
            if (nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    var environments = new SelectList(characterGenerationService.Environments);
                    var selectedEnvironment = string.IsNullOrEmpty(ccs.GetEnvironmentName()) ? environments.FirstOrDefault().ToString() : ccs.GetEnvironmentName();
                    return View("CharacterAttributeDetails", GetCharacterBonusAttributeStepViewModel());
                }
            }

            if (previousButton != null)
            {
                return View("ArchetypeStep", new CharacterArchetypeStepViewModel(ccs));
            }

            return View(new CharacterEnvironmentStepViewModel(ccs));
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
                return View("EnvironmentStep", GetCharacterEnvironmentStepViewModel());
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

        [HttpPost]
        public ActionResult SetArchetype(Archetype archetype)
        {
            var ccs = GetCharacterConstructionSite();
            ccs.SetArchetype(archetype);
            return PartialView("CharacterPreview", new CharacterPreview(ccs));
        }

        [HttpPost]
        public ActionResult SetBackground(Background background)
        {
            var ccs = GetCharacterConstructionSite();
            ccs.SetBackground(background);
            return PartialView("CharacterPreview", new CharacterPreview(ccs));
        }

        [HttpGet]
        public ActionResult GetCharacterPreview()
        {
            return PartialView("CharacterPreview", new CharacterPreview(GetCharacterConstructionSite()));
        }

        [HttpGet]
        public ActionResult GetArchetype(string archetype)
        {
            return PartialView("Archetype", characterGenerationService.GetArchetype(archetype));
        }

        [HttpGet]
        public ActionResult GetBackground(string background)
        {
            return PartialView("Background", characterGenerationService.GetBackground(background));
        }

        [HttpGet]
        public ActionResult GetEnvironment(string environment)
        {
            return PartialView("Environment", characterGenerationService.GetEnvironment(environment));
        }

        [HttpGet]
        public ActionResult GetRace(string race)
        {
            return PartialView("Race", characterGenerationService.GetRace(race));
        }
        
        [HttpGet]
        public JsonResult GetDerivedAttributes(string str, string sta, string agl, string per, string wil, string psy, string wis, string cha)
        {
            var res = new JsonResult();
            var atr = new CharacterAttributeSet()
            {
                Strength = new DiceRollCheck(str),
                Stamina = new DiceRollCheck(sta),
                Agility = new DiceRollCheck(agl),
                Perception = new DiceRollCheck(per),
                Will = new DiceRollCheck(wil),
                Psyche = new DiceRollCheck(psy),
                Wisdom = new DiceRollCheck(wis),
                Charisma = new DiceRollCheck(cha),
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


        #region helpers methods

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
        
        private CharacterBackgroundStepViewModel GetCharacterBackgroundStepWithBackgrounds()
        {
            var ccs = GetCharacterConstructionSite();
            var backgrounds = characterGenerationService.GetRandomBackgrounds(2);

            if(ccs.Background == null)
            {
                ccs.Background = backgrounds.First();
            }

            var backgroundStep = new CharacterBackgroundStepViewModel(ccs)
            {
                Backgrounds = backgrounds.ToList(),
                SelectedBackground = backgrounds.FirstOrDefault(),
                BackgroundInfo = backgrounds.FirstOrDefault(),
            };
            return backgroundStep;
        }

        private CharacterRaceStepViewModel GetCharacterRaceStepViewModel()
        {
            var ccs = GetCharacterConstructionSite();
            var races = characterGenerationService.Races;
            if (ccs.Race == null)
            {
                ccs.Race = races.First();
            }
            
            return new CharacterRaceStepViewModel(ccs)
            {
                Races = new SelectList(races),
                DefaultRace = ccs.Race,
                SelectedRace = ccs.Race.Name
            };
        }

        private CharacterArchetypeStepViewModel GetCharacterArchetypeStepViewModel()
        {
            var ccs = GetCharacterConstructionSite();
            var archetypes = characterGenerationService.Archetypes;
            if (ccs.Archetype == null)
            {
                ccs.Archetype = archetypes.First();
            }
            
            return new CharacterArchetypeStepViewModel(ccs)
            {
                Archetypes = new SelectList(archetypes),
                DefaultArchetype  = ccs.Archetype,
                SelectedArchetype = ccs.Archetype.Name
            };
        }


        private CharacterBackgroundStepViewModel GetCharacterBackgroundStepViewModel()
        {
            var ccs = GetCharacterConstructionSite();
            var backgrounds = characterGenerationService.GetRandomBackgrounds(2);
            var background = ccs.Background ?? backgrounds.FirstOrDefault();

            return new CharacterBackgroundStepViewModel(ccs)
            {
                Backgrounds = backgrounds.ToList(),
                SelectedBackground = background.Name,
            };
        }
        
        private CharacterEnvironmentStepViewModel GetCharacterEnvironmentStepViewModel()
        {
            var ccs = GetCharacterConstructionSite();
            var environments = characterGenerationService.Environments;
            if (ccs.Environment == null)
            {
                ccs.Environment = environments.First();
            }
            
            return new CharacterEnvironmentStepViewModel(ccs)
            {
                Environments = new SelectList(environments),
                DefaultEnvironment = ccs.Environment,
                SelectedEnvironment = ccs.Environment.Name
            };
        }

        private CharacterBonusAttributeStepViewModel GetCharacterBonusAttributeStepViewModel()
        {
            var ccs = GetCharacterConstructionSite();
            var b = ccs.GetCharacterAttributeExtraDiceDistribution();

            int dicesLeft = 10 - b.AgilityBonusDices - b.CharismaBonusDices - b.PerceptionBonusDices - b.PsycheBonusDices
                - b.StaminaBonusDices - b.StrengthBonusDices - b.WillBonusDices - b.WisdomBonusDices;

            var res = new CharacterBonusAttributeStepViewModel()
            {
                DicesLeftToDistribute = dicesLeft,
                Preview = new CharacterPreview(ccs),
            };

            return res;
        }
        #endregion
    }
}

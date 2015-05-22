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
using Niklasson.DrunkenChair.DatabaseTables;

using Niklasson.DrunkenChair.ServiceLayer;
using Niklasson.DrunkenChair.Parts;

namespace Niklasson.DrunkenChair.Controllers
{
    public class EonIVCharacterCreatorController : Controller
    {

        private IEonIVCharacterGenerationService characterGenerationService;
        
        public EonIVCharacterCreatorController(IEonIVCharacterGenerationService service)
        {
            characterGenerationService = service;
        }

        //private EonIvCharacterDbContext db = new EonIvCharacterDbContext();
        private string sessionStringCharacter = "character";
        private const string wizardStepsSessionString = "wizardsteps";

        // GET: EonIvCharacters
        public ActionResult Index()
        {
            return View();
        }

        // GET: EonIvCharacters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EonIvCharacterSheet eonIvCharacter = new EonIvCharacterSheet();
            if (eonIvCharacter == null)
            {
                return HttpNotFound();
            }
            return View(eonIvCharacter);
        }

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
            if(nextButton != null)
            {
                if (ModelState.IsValid)
                {
                    HandleBasicDetailsPost(basicDetails);
                    return View("CharacterAttributeDetails", WizardSteps.AttributeDetails);
                }
            }

            return View(WizardSteps.BasicDetails);
        }

        private void HandleBasicDetailsPost(CharacterBasicDetails basicDetails)
        {
            var ccs = GetCharacterConstructionSite();
            ccs.Character.Basics = ResolveCharacterBasics(basicDetails);

            WizardSteps.BasicDetails = basicDetails;
            WizardSteps.AttributeDetails = new CharacterAttributeDetails()
            {
                CharacterConstructionSite = ccs
            };

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
            if(nextButton != null)
            {
                if(ModelState.IsValid)
                {
                    HandleAttributeDetailsPost(attributeDetails);
                    return View("CharacterEventDetails", WizardSteps.EventDetails);
                }
            }
            
            if(previousButton != null)
            {
                return View("Create", WizardSteps.BasicDetails);
            }
            
            return View();
        }

        private void HandleAttributeDetailsPost(Models.CharacterAttributeDetails attributeDetails)
        {

            var ccs = GetCharacterConstructionSite();
            ccs.Scaffolding.BonusDiceDistribution = attributeDetails.GetBonusDiceDistribution();
            
            var wizardSteps = WizardSteps;
            wizardSteps.AttributeDetails = attributeDetails;
            wizardSteps.EventDetails = new CharacterEventDetails()
            {
                CharacterConstructionSite = ccs,
                RolledEvents = GetTestRolledEvents(),
                FreeEventRolls = 2
            };
        }

        // GET: EonIvCharacters/CharacterEventDetails
        public ActionResult CharacterEventDetails()
        {
            var eventDetails = GetCharacterEventDetails();
            eventDetails.RolledEvents = GetTestRolledEvents();
            WizardSteps.EventDetails = eventDetails;
            var ccs = GetCharacterConstructionSite();
            ccs.Scaffolding.EventDetails = eventDetails;

            eventDetails.CharacterConstructionSite = ccs;
            return View("CharacterEventDetails", eventDetails);
        }

        private static RolledEvents GetTestRolledEvents()
        {
            var rolledEvents = new RolledEvents()
            {
                Intrigue = new List<Event>()
                {
                    new Event()
                    {
                        Id = 3,
                        Name = "testEvent",
                        Number = 123,
                        Category = EventCategory.INTRIGUE_AND_MISDEADS,
                        Description = "test event description that is very silly and slightly longish to test how linebreaks are displayed.",
                        Modifications = new List<CharacterModificationOptions> {
                            new CharacterModificationOptions()
                            {
                                Alternatives = {

                                    new AttributeModification()
                                    {
                                        Attribute = Attribute.AGILITY,
                                        Value = 3
                                    },
                                    new AttributeModification()
                                    {
                                        Attribute = Attribute.PERCEPTION,
                                        Value = 3
                                    }
                                }
                            },

                            new CharacterModificationOptions()
                            {
                                Alternatives = new List<EonIVCharacterModifier>()
                                {
                                    new SkillModification()
                                    {
                                        Name = "Ljuga",
                                        Value = 5,
                                        LearningModifier = LearningModifier.FAST_LEARNER
                                    }
                                }
                            }
                        }
                    },

                    new Event()
                    {

                        Id = 3,
                        Name = "testEvent",
                        Category = EventCategory.INTRIGUE_AND_MISDEADS,
                        Number = 123,
                        Description = "test event 2 description that is very silly and slightly longish to test how linebreaks are displayed.",
                        Modifications = new List<CharacterModificationOptions> {
                            new CharacterModificationOptions()
                            {
                                Alternatives = {
                                    new AttributeModification()
                                    {
                                        Attribute = Attribute.AGILITY,
                                        Value = 3
                                    },
                                    new AttributeModification()
                                    {
                                        Attribute = Attribute.PERCEPTION,
                                        Value = 3
                                    }
                                }
                            },

                            new CharacterModificationOptions()
                            {
                                Alternatives = new List<EonIVCharacterModifier>()
                                {
                                    new SkillModification()
                                    {
                                        Name = "Ljuga",
                                        Value = 5,
                                        LearningModifier = LearningModifier.FAST_LEARNER
                                    }
                                }
                            }
                        }
                    }
                }
            };
            return rolledEvents;
        }

        private CharacterEventDetails GetCharacterEventDetails()
        {
            var ccs = GetCharacterConstructionSite();

            var eventRolls = ccs.Scaffolding.EventRolls;
            var rolledEvents = characterGenerationService.RollEvents(eventRolls);
            return new CharacterEventDetails()
            {
                RolledEvents = rolledEvents,
                FreeEventRolls = eventRolls.FreeChoise,
                CharacterConstructionSite = ccs
            };
        }

        [HttpPost]
        public ActionResult RerollEvent(RerollEventRequest request)
        {
            //TODO: get events, reroll the one selected, and post the updated set back
            var list = WizardSteps.EventDetails.RolledEvents[request.Category].ToList();

            //var ccs = GetCharacterConstructionSite();
            //var list = ccs.Scaffolding.EventDetails.RolledEvents[request.Category].ToList();
            if(request.Index + 1 > list.Count() )
            {
                return null;
            }
            else
            {
                list[request.Index] = characterGenerationService.GetRandomEvent(request.Category);
                WizardSteps.EventDetails.RolledEvents[request.Category] = list;
            }

            return PartialView("RolledEvents", WizardSteps.EventDetails.RolledEvents);
        }

        [HttpPost]
        public ActionResult CharacterEventDetails(CharacterEventDetails eventDetails, string previousButton, string nextButton)
        {
            if(nextButton != null)
            {
                if(ModelState.IsValid)
                {
                    HandleEventDetailsPost(eventDetails);
                    return View(); //placeholder, should return next view
                }
            }
            
            if (previousButton != null)
            {
                return View("CharacterAttributeDetails", WizardSteps.AttributeDetails);
            }
            
            return View("CharacterEventDetails", WizardSteps.EventDetails);
        }

        private void HandleEventDetailsPost(Models.CharacterEventDetails eventDetails)
        {
            var ccs = GetCharacterConstructionSite();
            //resolve events
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
                Will = per,
                Psyche = psy,
                Wisdom = wis,
                Charisma = cha
            };
            res.Data = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(atr);
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }

        [HttpPost]
        public JsonResult GetRandomEvent(RandomEventRequest request)
        {
            var result = new JsonResult();

            var ev = characterGenerationService.GetRandomEvent(request.EventCategory);
            result.Data = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ev);
            return result;
        }

        private CharacterBasics ResolveCharacterBasics(CharacterBasicDetails details)
        {
            CharacterBasics res = new CharacterBasics();

            res.Archetype = characterGenerationService.Archetypes.SingleOrDefault(a => a.Name == details.SelectedArchetype);
            res.Background = characterGenerationService.Backgrounds.SingleOrDefault(a => a.Name == details.SelectedBackground);
            res.Environment = characterGenerationService.Environments.SingleOrDefault(a => a.Name == details.SelectedEnvironment);
            res.Race = characterGenerationService.Races.SingleOrDefault(a => a.Name == details.SelectedRace);

            return res;
        }

        private CharacterConstructionSite GetCharacterConstructionSite()
        {
            if (Session[sessionStringCharacter] == null)
            {
                Session[sessionStringCharacter] = new CharacterConstructionSite();
            }
            return (CharacterConstructionSite)Session[sessionStringCharacter];
        }

        private WizardSteps WizardSteps
        {
            get{
                if (Session[wizardStepsSessionString] == null)
                {
                    Session[wizardStepsSessionString] = new WizardSteps();
                }
                return (WizardSteps)Session[wizardStepsSessionString];
            }
        }

        private void RemoveCharacter()
        {
            Session.Remove(sessionStringCharacter);
        }

    }
}

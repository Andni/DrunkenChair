using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.Composition;


using Niklasson.DrunkenChair.Model;
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
            EonIvCharacter eonIvCharacter = new EonIvCharacter();
            if (eonIvCharacter == null)
            {
                return HttpNotFound();
            }
            return View(eonIvCharacter);
        }

        // GET: EonIvCharacters/Create
        public ActionResult Create()
        {
            var ccs = GetCharacterConstructionSite();
            ccs.Character.Attributes = new CharacterAttributeSet();
            ccs.Scaffolding.EventRolls = new EventTableRolls();
            ccs.Scaffolding.Skillpoints = new Skillpoints();

            return View(new CharacterBasicDetails(
                new SelectList(characterGenerationService.Archetypes),
                new SelectList(characterGenerationService.Environments),
                new SelectList(characterGenerationService.Races))
                {
                    CharacterConstructionSite = ccs
                });
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

                    var cs = GetCharacterConstructionSite();
                    cs.BasicsDetails = ResolveCharacterBasics(basicDetails);
                
                    return View("CharacterAttributeDetails",
                        new CharacterAttributeDetails(cs));
                }
            }

            return View();
        }

        // GET: EonIvCharacters/CharacterAttributeDetails
        public ActionResult CharacterAttributeDetails()
        {
            int DicesToDistribute = 10;
            int MaxDicesPerAttribute = 5;
            
            ViewBag.DicesToDistribute = DicesToDistribute;
            ViewBag.MaxDiceesPerAttribute = MaxDicesPerAttribute;

            return View(new CharacterAttributeDetails(GetCharacterConstructionSite() ));
        }

        // GET: EonIvCharacters/CharacterAttributeDetails
        [HttpPost]
        public ActionResult CharacterAttributeDetails(CharacterAttributeDetails attributeDetails, string previousButton, string nextButton)
        {
            if(nextButton != null)
            {
                if(ModelState.IsValid)
                {
                    var cs = GetCharacterConstructionSite();
                    cs.BonusDiceDistribution = attributeDetails.GetBonusDiceDistribution();

                    return View("CharacterEventDetails", new CharacterEventDetails());
                }
            }
            
            if(previousButton != null)
            {
                return View("Create");
            }
            
            return View();
        }

        // GET: EonIvCharacters/CharacterEventDetails
        public ActionResult CharacterEventDetails()
        {
            var eventDetails = CreateCharacterEventDetails();
            
            return View(eventDetails);
        }

        private CharacterEventDetails CreateCharacterEventDetails()
        {
            var ccs = GetCharacterConstructionSite();

            var eventRolls = ccs.GetEventRolls();
            var rolledEvents = characterGenerationService.RollEvents(eventRolls);
            return new CharacterEventDetails()
            {
                RolledEvents = rolledEvents,
                FreeEventRolls = eventRolls.FreeChoise,
                CharacterConstructionSite = ccs
            };
        }

        [HttpPost]
        public ActionResult CharacterEventDetails(CharacterEventDetails eventDetails, string previousButton, string nextButton)
        {
            if(nextButton != null)
            {
                if(ModelState.IsValid)
                {
                    return View(); //placeholder, should return next view
                }
            }
            
            if (previousButton != null)
            {
                return View("CharacterAttributeDetails", new CharacterAttributeDetails(GetCharacterConstructionSite()));
            }
            
            return View("CharacterEventDetails", eventDetails);
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

        private void RemoveCharacter()
        {
            Session.Remove(sessionStringCharacter);
        }

    }
}

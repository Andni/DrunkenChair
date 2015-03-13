using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DrunkenChair.Models;

namespace DrunkenChair.Controllers
{
    public class EonIvCharactersController : Controller
    {
        private EonIvCharacterDbContext db = new EonIvCharacterDbContext();
        private string sessionStringCharacter = "character";

        // GET: EonIvCharacters
        public ActionResult Index()
        {
            return View(db.EonIvCharacters.ToList());
        }

        // GET: EonIvCharacters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EonIvCharacter eonIvCharacter = db.EonIvCharacters.Find(id);
            if (eonIvCharacter == null)
            {
                return HttpNotFound();
            }
            return View(eonIvCharacter);
        }

        // GET: EonIvCharacters/Create
        public ActionResult Create()
        {
            var ArchetypeList = new List<string>();
            var RaceList = new List<Race>();
            var EnvironmentList = new List<string>();

            var ArchetypeQuerry = from d in db.Archetypes
                                  orderby d.Name
                                  select d.Name;
            ArchetypeList.AddRange(ArchetypeQuerry);

            var RaceQuerry = from d in db.Races
                             orderby d.Name
                             select d;
            RaceList.AddRange(RaceQuerry);

            var EnvironmentQuerry = from d in db.Environments
                             orderby d.Name
                             select d.Name;
            EnvironmentList.AddRange(EnvironmentQuerry);

            var ccs = GetCharacterConstructionSite();
            ccs.Character.Attributes = new Attributes();
            ccs.Scaffolding.EventRolls = new EventTableRolls();
            ccs.Scaffolding.Skillpoints = new Skillpoints();

            return View(new BasicCharacterDetails(
                new SelectList(ArchetypeList),
                new SelectList(EnvironmentList),
                RaceList)
                {
                    CharacterConstructionSite = ccs
                });
        }

        // POST: EonIvCharacters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BasicCharacterDetails basicDetails)
        {
            if (ModelState.IsValid)
            {
                var cs = GetCharacterConstructionSite();
                cs.Character.Basics.Archetype = basicDetails.Archetype;
                cs.Character.Basics.Background = basicDetails.Background;
                cs.Character.Basics.Environment = basicDetails.Environment;
                cs.Character.Basics.Race = basicDetails.Race;

                return View("CharacterAttributeDetails",
                    new CharacterAttributeDetails(
                        db.CreationConstants.Single( c => c.Constant == Constant.BonusAttributeDiceses).Value,
                        db.CreationConstants.Single( c => c.Constant == Constant.MaxBonusAttributeDicesSpentOnOneAttribute).Value,
                        db.Races.SingleOrDefault( r => r.Name == basicDetails.Race).StartingAttributes
                    ));
            }

            return View();
        }

        // GET: EonIvCharacters/CharacterAttributeDetails
        public ActionResult CharacterAttributeDetails()
        {
            int DicesToDistribute = db.CreationConstants.Single(c => c.Constant == Constant.BonusAttributeDiceses).Value;
            int MaxDicesPerAttribute = db.CreationConstants.Single(c => c.Constant == Constant.MaxBonusAttributeDicesSpentOnOneAttribute).Value;
            
            ViewBag.DicesToDistribute = DicesToDistribute;
            ViewBag.MaxDiceesPerAttribute = MaxDicesPerAttribute;

            return View(new CharacterAttributeDetails(DicesToDistribute, MaxDicesPerAttribute, new Attributes())
            {CharacterConstructionSite = (EonIVCharacterConstructionSite)(Session[sessionStringCharacter]) });
        }


        // GET: EonIvCharacters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EonIvCharacter eonIvCharacter = db.EonIvCharacters.Find(id);
            if (eonIvCharacter == null)
            {
                return HttpNotFound();
            }
            return View(eonIvCharacter);
        }

        // POST: EonIvCharacters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Basics")] EonIvCharacter eonIvCharacter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eonIvCharacter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eonIvCharacter);
        }

        // GET: EonIvCharacters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EonIvCharacter eonIvCharacter = db.EonIvCharacters.Find(id);
            if (eonIvCharacter == null)
            {
                return HttpNotFound();
            }
            return View(eonIvCharacter);
        }

        // POST: EonIvCharacters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EonIvCharacter eonIvCharacter = db.EonIvCharacters.Find(id);
            db.EonIvCharacters.Remove(eonIvCharacter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            
        [HttpGet]
        public ActionResult GetCharacterPreview(string archetype, string race, string environment)
        {
            //CharacterBasics model = new CharacterBasics();

            EonIVCharacterConstructionSite ccs = GetCharacterConstructionSite();

            var theArchetype = db.Archetypes.Single(a => a.Name == archetype);
            var theRace = db.Races.Single(r => r.Name == race);
            var theEnvironment = db.Environments.Single(r => r.Name == environment);

            //model.Attributes = theRace.StartingAttributes;
            //model.EventRolls = theArchetype.LifeEventRolls + theEnvironment.Events;
            //model.Skillpoints = theEnvironment.Skills;

            ccs.Character.Attributes = theRace.StartingAttributes;
            ccs.Scaffolding.EventRolls = theArchetype.LifeEventRolls + theEnvironment.Events;
            ccs.Scaffolding.Skillpoints = theEnvironment.Skills;

            return PartialView("CharacterPreview",  ccs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private EonIVCharacterConstructionSite GetCharacterConstructionSite()
        {
            if (Session[sessionStringCharacter] == null)
            {
                Session[sessionStringCharacter] = new EonIVCharacterConstructionSite();
            }
            return (EonIVCharacterConstructionSite)Session[sessionStringCharacter];
        }

        private void RemoveCharacter()
        {
            Session.Remove(sessionStringCharacter);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Niklasson.DrunkenChair.Model;

namespace Niklasson.DrunkenChair.Controllers
{
    public class EonIvCharactersController : Controller
    {
        private EonIvCharacterDbContext db = new EonIvCharacterDbContext();

        // GET: EonIvCharacters
        public async Task<ActionResult> Index()
        {
            return View(await db.EonIvCharacters.ToListAsync());
        }

        // GET: EonIvCharacters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EonIvCharacter eonIvCharacter = await db.EonIvCharacters.FindAsync(id);
            if (eonIvCharacter == null)
            {
                return HttpNotFound();
            }
            return View(eonIvCharacter);
        }

        // GET: EonIvCharacters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EonIvCharacters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Archetype,Background,Environment,Race,Attributes")] EonIvCharacter eonIvCharacter)
        {
            if (ModelState.IsValid)
            {
                db.EonIvCharacters.Add(eonIvCharacter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eonIvCharacter);
        }

        // GET: EonIvCharacters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EonIvCharacter eonIvCharacter = await db.EonIvCharacters.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "ID,Archetype,Background,Environment,Race,Attributes")] EonIvCharacter eonIvCharacter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eonIvCharacter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eonIvCharacter);
        }

        // GET: EonIvCharacters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EonIvCharacter eonIvCharacter = await db.EonIvCharacters.FindAsync(id);
            if (eonIvCharacter == null)
            {
                return HttpNotFound();
            }
            return View(eonIvCharacter);
        }

        // POST: EonIvCharacters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EonIvCharacter eonIvCharacter = await db.EonIvCharacters.FindAsync(id);
            db.EonIvCharacters.Remove(eonIvCharacter);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

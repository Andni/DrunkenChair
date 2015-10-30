using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Services;

namespace Niklasson.EonIV.Web.Controllers
{
    public class EonIvCharactersController : Controller
    {
        private IEonIVCharacterRepository characterRepository;

        // GET: EonIvCharacters
        public async Task<ActionResult> Index()
        {
            return View(await characterRepository.GetLatestCharacters(12));
        }

        // GET: EonIvCharacters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterSheet eonIvCharacter = await characterRepository.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "ID,Archetype,Background,Environment,Race,Attributes")] CharacterSheet eonIvCharacter)
        {
            if (ModelState.IsValid)
            {
                characterRepository.Add(eonIvCharacter);
                await characterRepository.SaveChangesAsync();
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
            CharacterSheet eonIvCharacter = await characterRepository.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "ID,Archetype,Background,Environment,Race,Attributes")] CharacterSheet eonIvCharacter)
        {
            if (ModelState.IsValid)
            {
                characterRepository.SetModified(eonIvCharacter);
                await characterRepository.SaveChangesAsync();
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
            CharacterSheet eonIvCharacter = await characterRepository.FindAsync(id);
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
            CharacterSheet eonIvCharacter = await characterRepository.FindAsync(id);
            characterRepository.Remove(eonIvCharacter);
            await characterRepository.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && characterRepository != null)
            {
                characterRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

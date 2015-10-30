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

namespace Niklasson.EonIV.Web.Controllers
{
    public partial class EonIVCharacterCreatorController : Controller
    {

#if DEBUG
        [HttpGet]
        public ActionResult ArchetypeStep()
        {
            var ccs = GetCharacterConstructionSite();

            var archetypes = new SelectList(characterGenerationService.Archetypes);
            var selectedArchetype =
                string.IsNullOrEmpty(ccs.GetArchetypeName()) ?
                characterGenerationService.Archetypes.FirstOrDefault().ToString() :
                ccs.GetArchetypeName();
            var archetype = characterGenerationService.Archetypes.FirstOrDefault();

            return View("ArchetypeStep",
                new CharacterArchetypeStepViewModel(ccs)
                {
                    Archetypes = archetypes,
                    DefaultArchetype = archetype,
                    SelectedArchetype = selectedArchetype
                }
            );
        }
        
        // GET: EonIvCharacters/CharacterAttributeDetails
        public ActionResult CharacterAttributeDetails()
        {
            return View(
                new CharacterBonusAttributeStepViewModel()
                {
                    Preview = new CharacterPreview(GetCharacterConstructionSite())
                }
            );
        }

#endif
    }
}

using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.DrunkenChair.Models
{
    public interface ICharacterPreview
    {
        CharacterSheet CharacterSheet { get; }
        CharacterGenerationData Scaffolding { get; }        
    }
}

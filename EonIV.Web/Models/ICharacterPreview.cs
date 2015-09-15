using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Web
{
    public interface ICharacterPreview
    {
        CharacterSheet CharacterSheet { get; }
        CharacterGenerationData Scaffolding { get; }        
    }
}

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterBasicChoices : ICharacterBasicChoices
    {
        public string SelectedArchetype { get; set; }
        public string SelectedBackground { get; set; }
        public string SelectedEnvironment { get; set; }
        public string SelectedRace { get; set; }
    }
}

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface ICharacterBasicChoices
    {
        string SelectedArchetype { get; set; }
        string SelectedBackground { get; set; }
        string SelectedEnvironment { get; set; }
        string SelectedRace { get; set; }
    }
}

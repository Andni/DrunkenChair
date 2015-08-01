namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface IBaseAttributeDices
    {
        int StrengthBonusDices { get; set; }
        int StaminaBonusDices { get; set; }
        int AgilityBonusDices { get; set; }
        int PerceptionBonusDices { get; set; }
        int WillBonusDices { get; set; }
        int PsycheBonusDices { get; set; }
        int WisdomBonusDices { get; set; }
        int CharismaBonusDices { get; set; }
    }
}

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class BaseAttributeDices : IBaseAttributeDices
    {

        public BaseAttributeDices() { }
        
        public BaseAttributeDices(IBaseAttributeDices extraDices)
        {
            StrengthBonusDices = extraDices.StrengthBonusDices;
            StaminaBonusDices = extraDices.StaminaBonusDices;
            AgilityBonusDices = extraDices.AgilityBonusDices;
            PerceptionBonusDices = extraDices.PerceptionBonusDices;
            WillBonusDices = extraDices.WillBonusDices;
            PsycheBonusDices = extraDices.PsycheBonusDices;
            WisdomBonusDices = extraDices.WillBonusDices;
            CharismaBonusDices = extraDices.CharismaBonusDices;
        }
        public int StrengthBonusDices { get; set; }
        public int StaminaBonusDices { get; set; }
        public int AgilityBonusDices { get; set; }
        public int PerceptionBonusDices { get; set; }
        public int WillBonusDices { get; set; }
        public int PsycheBonusDices { get; set; }
        public int WisdomBonusDices { get; set; }
        public int CharismaBonusDices { get; set; }
    }
}

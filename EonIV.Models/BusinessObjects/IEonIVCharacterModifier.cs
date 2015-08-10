namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface IEonIVCharacterModifier
    {
        int ID { get; set; }
        int EventID { get; set; }
        string Condition { get; set; }
        RuleBookEvent Event { get; set; }
    }
}

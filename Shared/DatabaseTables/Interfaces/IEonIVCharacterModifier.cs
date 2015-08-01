namespace Shared.DatabaseTables.Interfaces
{
    public interface IEonIVCharacterModifier
    {
        int ID { get; set; }
        int EventID { get; set; }
        string Condition { get; set; }
        Event Event { get; set; }
    }
}

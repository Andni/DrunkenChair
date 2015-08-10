namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface IBaseEvent
    {
        int Number { get; set; }
        string Name { get; set; }
        EventCategory Category { get; set; }
        string Description { get; set; }
    }
}

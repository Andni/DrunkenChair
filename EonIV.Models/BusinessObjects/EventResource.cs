namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class EventResource : CharacterModifier
    {
        public override string ConcreteModelType
        {
            get { return typeof (EventResource).ToString(); }
        }
    }
}
namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterEventDetails
    {
        protected RuleBookEventSet events = new RuleBookEventSet();

        public RuleBookEventSet Events
        {
            get
            {
                return events;
            }
        }
    }
}

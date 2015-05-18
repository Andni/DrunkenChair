
using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Controllers
{
    public class RerollEventRequest
    {
        public EventCategory Category { get; set; }
        public int Index { get; set; }
    }
}

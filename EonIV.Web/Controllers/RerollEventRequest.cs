
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Web.Controllers
{
    public class RerollEventRequest
    {
        public EventCategory Category { get; set; }
        public int Index { get; set; }
    }
}

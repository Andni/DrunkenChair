using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Niklasson.DrunkenChair.Models;
//using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Models.Interfaces
{
    public interface IEonIVCharacterModifier
    {
        int ID { get; set; }
        int EventID { get; set; }
        string Condition { get; set; }
        EventViewModel Event { get; set; }
    }
}

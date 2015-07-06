using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.DrunkenChair.Shared.DatabaseTables
{
    public interface IEonIVCharacterModifier
    {
        int ID { get; set; }
        int EventID { get; set; }
        string Condition { get; set; }
        Event Event { get; set; }
    }
}

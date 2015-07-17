using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public interface IBaseEvent
    {
        int Number { get; set; }
        string Name { get; set; }
        EventCategory Category { get; set; }
        string Description { get; set; }
    }
}

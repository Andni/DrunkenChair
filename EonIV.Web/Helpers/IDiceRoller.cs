using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.DrunkenChair.Helpers
{
    interface IDiceRoller
    {
        int RollD100();
        int RollD6(int dices);
    }
}

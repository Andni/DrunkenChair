using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrunkenChair.Models.DatabaseTables.Helpers
{
    interface IAttributeModificationParser
    {
        AttributeModification TryParse(string text);
    }
}
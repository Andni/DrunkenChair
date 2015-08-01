using System.Collections.Generic;
using System.Linq;
using Shared.DataTypes;

namespace Shared.DatabaseTables.Helpers
{
    public static class AttributeHelper
    {
        private static Dictionary<Attribute, string> dic = new Dictionary<Attribute, string>()
        {
            { Attribute.AGILITY, "rörlighet" },
            { Attribute.BASEARMOR, "grundrustning" },
            { Attribute.BASEDAMAGE, "grundskada" },
            { Attribute.BUILD, "kroppsbyggnad" },
            { Attribute.CHARISMA, "utstrålning" },
            { Attribute.IMPRESSION, "intryck" },
            { Attribute.LIFEFORCE, "livskraft" },
            { Attribute.MOVEMENT, "förflyttning" },
            { Attribute.PERCEPTION, "uppfattning" },
            { Attribute.PSYCHE, "psyke" },
            { Attribute.REACTION, "reaktion" },
            { Attribute.SELFCONTROL, "självkontroll" },
            { Attribute.STAMINA, "tålighet" },
            { Attribute.STRENGTH, "styrka" },
            { Attribute.UNDEFINED, "odefinierad" },
            { Attribute.VIGILANCE, "vaksamhet" },
            { Attribute.WILL, "vilja" },
            { Attribute.WISDOM, "visdom" },
        };

        public static Attribute ParseAttribute(string attribute)
        {
            return dic.SingleOrDefault(a => a.Value.Equals(attribute.ToLower())).Key;
        }

        public static string GetAttributeTranslation(Attribute attribute)
        {
            return dic.SingleOrDefault(a => a.Key.Equals(attribute)).Value;

        }
    }
}
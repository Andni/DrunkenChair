using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrunkenChair.Character
{
    public enum BaseAttribute
    {
        UNDEFINED = 0,

        STRENGTH = 1,
        STAMINA = 2,
        AGILITY = 3,
        PERCEPTION = 4,
        WILL = 5,
        PSYCHE = 6,
        WISDOM = 7,
        CHARISMA = 8
    }


    public enum Attribute
    {
        UNDEFINED = 0,

        STRENGTH = 1,
        STAMINA = 2,
        AGILITY = 3,
        PERCEPTION = 4,
        WILL = 5,
        PSYCHE = 6,
        WISDOM = 7,
        CHARISMA = 8,
        
        MOVEMENT = 9,
        REACTION = 10,
        SELFCONTROL = 11,
        BUILD = 12,
        VIGILANCE = 13,
        LIFEFORCE = 14,
        IMPRESSION = 15,
        
        BASEARMOR = 16,
        BASEDAMAGE = 17
    }

}
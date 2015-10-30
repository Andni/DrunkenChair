using System;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class JadednessCross : CharacterModifier
    {
        public int Crosses { get; set; }

        public override string Label
        {
            get
            {
                if(string.IsNullOrEmpty(label))
                {
                    return "Avtrubbning";
                }
                return label;
            }

            set
            {
                label = value;
            }
        }

        public override string Description
        {
            get
            {
                string t = "";
                switch (Type)
                {
                    case JadednessType.Supernatural:
                        t = "övernaturligt";
                        break;
                    case JadednessType.Violence:
                        t = "våld";
                        break;
                    case JadednessType.Vulnrability:
                        t = "utsatthet";
                        break;
                    default:
                        t = "";
                        break;
                }

                if (string.IsNullOrEmpty(description))
                {
                    return String.Format("{0} Avtrubbningskryss ({1})", Crosses, t);
                }
                return description;
            }

            set
            {
                description = value;
            }
        }

        public JadednessType Type { get; set; }

        public override string ConcreteModelType
        {
            get
            {
                return typeof(JadednessCross).ToString();
            }
        }
    }

    public enum JadednessType
    {
        Vulnrability = 0,
        Violence = 1,
        Supernatural = 2
    }
}

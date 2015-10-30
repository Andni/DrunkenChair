using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class ArmourSet : CharacterModifier
    {
        public ArmourCoverage Coverage { get; set; }
        
        public override string Label
        {
            get
            {
                if(string.IsNullOrEmpty(label))
                {
                    return "Rustning";
                }
                return label;
            }

            set
            {
                label = value;
            }
        }
        
        [NotMapped]
        public string SelectedMaterial { get; set; }

        public List<string> ValidMaterials { get; set; } = new List<string>();

        public override string ConcreteModelType
        {
            get
            {
                return typeof(ArmourSet).ToString();
            }
        }
    }

    [Flags]
    public enum ArmourCoverage
    {
        Head = 1,
        Torso = 2,
        RightArm = 4,
        LeftArm = 8,
        RightLeg = 16,
        LeftLeg = 32,
        All = 126,
    }

    public class ArmourMaterial
    {
        public string Name { get; set; }
        public int Chrush { get; set; }
        public int Slash { get; set; }
        public int Thrust { get; set; }
        public int Weight { get; set; }
    }
}
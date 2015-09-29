using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterModifierContainerMultiChoice : CharacterModifierContainer
    {
        public int NumberOfChoices { get; set; }

        [NotMapped]
        public List<bool> SelectedIndices { get; set; } = new List<bool>();
        
        public override string Description
        {
            get
            {
                if(string.IsNullOrEmpty(description))
                {
                    return string.Format("Välj {0} av nedanstående alternativ.", NumberOfChoices);
                }
                else
                {
                    return description;
                }
            }

            set
            {
                description = value;
            }
        }

        public CharacterModifierContainerMultiChoice() { }

        public CharacterModifierContainerMultiChoice(int numberOfChoices, string label, string description)
        {
            this.label = label;
            this.description = description;
            NumberOfChoices = numberOfChoices;
        }

        public CharacterModifierContainerMultiChoice(int numberOfChoices)
        {
            NumberOfChoices = numberOfChoices;
        }

        public override void Add(CharacterModifierNode node)
        {
            SelectedIndices.Add(new bool());
            base.Add(node);
        }

        public override string ConcreteModelType
        {
            get
            {
                return typeof(CharacterModifierContainerMultiChoice).ToString();
            }
        }
    }
}

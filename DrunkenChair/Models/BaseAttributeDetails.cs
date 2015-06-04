using System;
using System.ComponentModel.DataAnnotations;
using Niklasson.DrunkenChair.ServiceLayer;

namespace Niklasson.DrunkenChair.Character
{
    public class BaseAttributeDetails
    {
        [Range(0, 0, ErrorMessage = "Alla bonustärningar måste spenderas.")]
        public int DicesLeftToDistribute { get; set; }
        public int MaxDicesPerAttribute = 5;

        private const string rangeErrorMessage = " max 5";

        [Required]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int StrenghtBonusDices { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int StaminaBonusDices { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int AgilityBonusDices { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int PerceptionBonusDices { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int WillBonusDices { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int PsycheBonusDices { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int WisdomBonusDices { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int CharismaBonusDices { get; set; }

        public BaseAttributeDetails()
        {
            DicesLeftToDistribute = 10;
        }

        public CharacterBaseAttributeSet CharacterBaseAttributeSet
        {
            get
            {
                return GetCharacterBaseAttributeSet();
            }
            set
            {
                var MaxBonusDices = CharacterCreationConstants.MaxBonusDicesToSpend;
                var currentBonus = value.GetTotalAttributeDices();
                if( currentBonus> MaxBonusDices)
                {
                    throw new ArgumentOutOfRangeException("Bonus attribute dices exceed allowed limit");
                }
                else
                {
                    this.AgilityBonusDices = value.Agility.UnlimitedDice6;
                    this.CharismaBonusDices = value.Charisma.UnlimitedDice6;
                    this.PerceptionBonusDices = value.Perception.UnlimitedDice6;
                    this.PsycheBonusDices = value.Psyche.UnlimitedDice6;
                    this.StaminaBonusDices= value.Stamina.UnlimitedDice6;
                    this.StrenghtBonusDices = value.Strength.UnlimitedDice6;
                    this.WillBonusDices = value.Will.UnlimitedDice6;
                    this.WisdomBonusDices = value.Wisdom.UnlimitedDice6;
                    DicesLeftToDistribute = MaxBonusDices - currentBonus;
                }
            }
        }

        public CharacterBaseAttributeSet GetCharacterBaseAttributeSet()
        {
            return CharacterBaseAttributeSet.CreateFromDiceSet(
                StrenghtBonusDices,
                StaminaBonusDices,
                AgilityBonusDices,
                PerceptionBonusDices,
                WillBonusDices,
                PsycheBonusDices,
                WisdomBonusDices,
                CharismaBonusDices
            );
        }

    }
}
﻿using System;
using System.ComponentModel.DataAnnotations;
using Niklasson.EonIV.Models;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Web.Models
{
    public class CharacterBonusAttributeStepViewModel : IBaseAttributeDices
    {
        [Range(0, 0, ErrorMessage = "Alla bonustärningar måste spenderas.")]
        public int DicesLeftToDistribute { get; set; } = 10;
        public int MaxDicesPerAttribute = 5;

        private const string rangeErrorMessage = " max 5";

        [Required]
        [Display(Name="Styrka")]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int StrengthBonusDices { get; set; }
        [Required]
        [Display(Name = "Tålighet")]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int StaminaBonusDices { get; set; }
        [Required]
        [Display(Name = "Rörlighet")]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int AgilityBonusDices { get; set; }
        [Required]
        [Display(Name = "Uppfattning")]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int PerceptionBonusDices { get; set; }
        [Required]
        [Display(Name = "Vilja")]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int WillBonusDices { get; set; }
        [Required]
        [Display(Name = "Psyke")]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int PsycheBonusDices { get; set; }
        [Required]
        [Display(Name = "Visdom")]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int WisdomBonusDices { get; set; }
        [Required]
        [Display(Name = "Utstrålning")]
        [Range(0, 5, ErrorMessage = rangeErrorMessage)]
        public int CharismaBonusDices { get; set; }

        public CharacterBonusAttributeStepViewModel() { }

        public CharacterBaseAttributeSet CharacterBaseAttributeSet
        {
            get
            {
                return GetCharacterBaseAttributeSet();
            }
            set
            {
                var MaxBonusDices = CharacterGenerationsConstants.MaxBonusDicesToSpend;
                var currentBonus = value.GetTotalAttributeDices();
                if( currentBonus> MaxBonusDices)
                {
                    throw new ArgumentOutOfRangeException("Bonus attribute dices exceed allowed limit");
                }
                else
                {
                    AgilityBonusDices = value.Agility.UnlimitedDice6;
                    CharismaBonusDices = value.Charisma.UnlimitedDice6;
                    PerceptionBonusDices = value.Perception.UnlimitedDice6;
                    PsycheBonusDices = value.Psyche.UnlimitedDice6;
                    StaminaBonusDices = value.Stamina.UnlimitedDice6;
                    StrengthBonusDices = value.Strength.UnlimitedDice6;
                    WillBonusDices = value.Will.UnlimitedDice6;
                    WisdomBonusDices = value.Wisdom.UnlimitedDice6;
                    DicesLeftToDistribute = MaxBonusDices - currentBonus;
                }
            }
        }

        public CharacterBaseAttributeSet GetCharacterBaseAttributeSet()
        {
            return CharacterBaseAttributeSet.CreateFromDiceSet(
                StrengthBonusDices,
                StaminaBonusDices,
                AgilityBonusDices,
                PerceptionBonusDices,
                WillBonusDices,
                PsycheBonusDices,
                WisdomBonusDices,
                CharismaBonusDices
            );
        }

        public CharacterPreview Preview { get; set; }
    }
}
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    [ComplexType]
    public class CharacterBaseAttributeSet : ICharacterBaseAttributes
    {
        [Display(Name = "Styrka")]
        public DiceRollCheck Strength { get; set; }
        [Display(Name = "Tålighet")]
        public DiceRollCheck Stamina { get; set; }
        public DiceRollCheck Agility { get; set; }
        public DiceRollCheck Perception { get; set; }
        public DiceRollCheck Will { get; set; }
        public DiceRollCheck Psyche { get; set; }
        public DiceRollCheck Wisdom { get; set; }
        public DiceRollCheck Charisma { get; set; }

        public CharacterBaseAttributeSet()
            : this(
                new DiceRollCheck(0, 0),
                new DiceRollCheck(0, 0),
                new DiceRollCheck(0, 0),
                new DiceRollCheck(0, 0),
                new DiceRollCheck(0, 0),
                new DiceRollCheck(0, 0),
                new DiceRollCheck(0, 0),
                new DiceRollCheck(0, 0)
                ) { }

        public CharacterBaseAttributeSet(DiceRollCheck str, DiceRollCheck sta, DiceRollCheck agl, DiceRollCheck per, DiceRollCheck wil, DiceRollCheck psy, DiceRollCheck wis, DiceRollCheck cha)
        {
            Strength = str;
            Stamina = sta;
            Agility = agl;
            Perception = per;
            Will = wil;
            Psyche = psy;
            Wisdom = wis;
            Charisma = cha;
        }

        public static CharacterBaseAttributeSet CreateFromDiceSet(int str, int sta, int agl, int per, int wil, int psy, int wis, int cha)
        {
            return new CharacterBaseAttributeSet()
            {
                Agility = DiceRollCheck.CreateFromDice(agl),
                Charisma = DiceRollCheck.CreateFromDice(cha),
                Perception = DiceRollCheck.CreateFromDice(per),
                Psyche = DiceRollCheck.CreateFromDice(psy),
                Stamina = DiceRollCheck.CreateFromDice(sta),
                Strength = DiceRollCheck.CreateFromDice(str),
                Will = DiceRollCheck.CreateFromDice(wil),
                Wisdom = DiceRollCheck.CreateFromDice(wis)
            };
        }

        public int GetTotalAttributeDices()
        {
            int res = Strength.UnlimitedDice6 +
                Stamina.UnlimitedDice6 +
                Agility.UnlimitedDice6 +
                Perception.UnlimitedDice6 +
                Psyche.UnlimitedDice6 +
                Will.UnlimitedDice6 +
                Wisdom.UnlimitedDice6 +
                Charisma.UnlimitedDice6;
            return res;
        }

        public static CharacterBaseAttributeSet operator +(CharacterBaseAttributeSet lh, CharacterBaseAttributeSet rh)
        {
            lh.Agility += rh.Agility;
            lh.Charisma += rh.Charisma;
            lh.Perception += rh.Perception;
            lh.Psyche += rh.Psyche;
            lh.Stamina += rh.Stamina;
            lh.Strength += rh.Strength;
            lh.Will += rh.Will;
            lh.Wisdom += rh.Wisdom;
            
            return lh;
        }

        public static CharacterBaseAttributeSet operator +(CharacterBaseAttributeSet lh, BaseAttributeDices rh)
        {
            lh.Agility.AddDice(rh.AgilityBonusDices);
            lh.Charisma.AddDice(rh.CharismaBonusDices);
            lh.Perception.AddDice(rh.PerceptionBonusDices);
            lh.Psyche.AddDice(rh.PsycheBonusDices);
            lh.Stamina.AddDice(rh.StaminaBonusDices);
            lh.Strength.AddDice(rh.StrengthBonusDices);
            lh.Will.AddDice(rh.WillBonusDices);
            lh.Wisdom.AddDice(rh.WisdomBonusDices);

            return lh;
        }
    }
}
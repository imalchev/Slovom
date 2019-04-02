using System;

namespace Slovom.Internal
{
    /// <summary>
    /// Speller for numbers up to 999. If number is less than 100 _tensSpeller is used to spell the number.
    /// </summary>
    internal class HundredsSpeller : ChainedSpeller
    {
        public HundredsSpeller(Speller tensSpeller)
            : base(tensSpeller)
        {
        }

        public override SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral)
        {
            if (number < 100)
            {
                return InnerSpeller.Spell(number, gender);
            }

            ulong hundreds = (number / 100) * 100;

            SpelledNumber hundredsInWords = new SpelledNumber(GetHundreds(hundreds), false);

            ulong reminder = number % 100;
            if (reminder == 0)
            {
                return hundredsInWords;
            }

            return hundredsInWords.Concat(InnerSpeller.Spell(reminder, gender));
        }

        public override SpelledNumber SpellOrdinal(ulong number, Gender gender = Gender.Neutral)
        {
            if (number < 100)
            {
                return InnerSpeller.SpellOrdinal(number, gender);
            }

            ulong hundreds = (number / 100) * 100;
            ulong reminder = number % 100;
            if (reminder == 0)
            {
                string ordinalHundredsInWords = GetHundredsOrdinal(hundreds, gender);
                return new SpelledNumber(ordinalHundredsInWords, false);
            }

            SpelledNumber hundredsInWords = new SpelledNumber(GetHundreds(hundreds), false);

            return hundredsInWords.Concat(InnerSpeller.SpellOrdinal(reminder, gender));
        }

        private string GetHundreds(ulong number)
        {
            switch (number)
            {
                case 100: return "сто";
                case 200: return "двеста";
                case 300: return "триста";
                case 400: return "четиристотин";
                case 500: return "петстотин";
                case 600: return "шестстотин";
                case 700: return "седемстотин";
                case 800: return "осемстотин";
                case 900: return "деветстотин";
                default:
                    throw new ArgumentOutOfRangeException(nameof(number), $"'{nameof(HundredsSpeller)}' can't spell number {number}!");
            }
        }

        private string GetHundredsOrdinal(ulong number, Gender gender)
        {
            switch (number)
            {
                case 100: return (gender == Gender.Male ? "стотен" : gender == Gender.Female ? "стотна" : "стотно");
                case 200: return (gender == Gender.Male ? "двестен" : gender == Gender.Female ? "двестна" : "двстно");
                case 300: return (gender == Gender.Male ? "тристотен" : gender == Gender.Female ? "тристотна" : "тристотно");
                case 400: return (gender == Gender.Male ? "четистотен" : gender == Gender.Female ? "четиристотна" : "четиристотно");
                case 500: return (gender == Gender.Male ? "петстотен" : gender == Gender.Female ? "петстотна" : "петстотно");
                case 600: return (gender == Gender.Male ? "шестстотен" : gender == Gender.Female ? "шестстотна" : "шестстотно");
                case 700: return (gender == Gender.Male ? "седемстотен" : gender == Gender.Female ? "седемстотна" : "седемстотно");
                case 800: return (gender == Gender.Male ? "осемстотен" : gender == Gender.Female ? "осемстотна" : "осемстотно");
                case 900: return (gender == Gender.Male ? "деветстотен" : gender == Gender.Female ? "деветстотна" : "деветстотно");
                default:
                    throw new ArgumentOutOfRangeException(nameof(number), $"'{nameof(TensSpeller)}' is can't spell number {number}!");
            }
        }
    }
}

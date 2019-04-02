using System;

namespace Slovom.Internal
{
    /// <summary>
    /// Speller for numbers up to 99. If number is less than 20 - inner speller is used.
    /// </summary>
    internal class TensSpeller : ChainedSpeller
    {
        public TensSpeller(Speller speller19)
            : base(speller19)
        {
        }

        public override SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral)
        {
            if (number < 20)
            {
                return InnerSpeller.Spell(number, gender);
            }

            ulong tens = (number / 10) * 10;

            string tensInWords = GetTens(tens);
            var tensSpelled = new SpelledNumber(tensInWords, false);

            ulong reminder = number % 10;
            if (reminder == 0)
            {
                return tensSpelled;
            }

            return tensSpelled.Concat(InnerSpeller.Spell(reminder, gender));
        }

        public override SpelledNumber SpellOrdinal(ulong number, Gender gender = Gender.Neutral)
        {
            if (number < 20)
            {
                return InnerSpeller.SpellOrdinal(number, gender);
            }

            ulong tens = (number / 10) * 10;
            ulong reminder = number % 10;
            if (reminder == 0)
            {
                string tensOrdinal = GetTensOrdinal(number, gender);
                return new SpelledNumber(tensOrdinal, false);
            }

            string tensInWords = GetTens(tens);
            var tensSpelled = new SpelledNumber(tensInWords, false);

            return tensSpelled.Concat(InnerSpeller.SpellOrdinal(reminder, gender));
        }

        private string GetTens(ulong number)
        {
            switch (number)
            {
                case 20: return "двадесет";
                case 30: return "тридесет";
                case 40: return "четиридесет";
                case 50: return "петдесет";
                case 60: return "шестдесет";
                case 70: return "седемдесет";
                case 80: return "осемдесет";
                case 90: return "деветдесет";
                default: throw new ArgumentOutOfRangeException(nameof(number), $"'{nameof(TensSpeller)}' is can't spell number {number}!");
            }
        }

        private string GetTensOrdinal(ulong number, Gender gender)
        {
            switch (number)
            {
                case 20: return (gender == Gender.Male ? "двадесети" : gender == Gender.Female ? "двадесета" : "двадесето");
                case 30: return (gender == Gender.Male ? "тридесети" : gender == Gender.Female ? "тридесета" : "тридесето");
                case 40: return (gender == Gender.Male ? "четиридесети" : gender == Gender.Female ? "четиридесета" : "четиридесето");
                case 50: return (gender == Gender.Male ? "петдесети" : gender == Gender.Female ? "петдесета" : "петдесето");
                case 60: return (gender == Gender.Male ? "шестдесети" : gender == Gender.Female ? "шестдесета" : "шестдесето");
                case 70: return (gender == Gender.Male ? "седемдесети" : gender == Gender.Female ? "седемдесета" : "седемдесето");
                case 80: return (gender == Gender.Male ? "осемдесети" : gender == Gender.Female ? "осемдесета" : "осемдесето");
                case 90: return (gender == Gender.Male ? "деветдесети" : gender == Gender.Female ? "деветдесета" : "деветдесето");
                default: throw new ArgumentOutOfRangeException(nameof(number), $"'{nameof(TensSpeller)}' is can't spell number {number}!");
            }
        }
    }
}

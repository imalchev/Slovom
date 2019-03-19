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
    }
}

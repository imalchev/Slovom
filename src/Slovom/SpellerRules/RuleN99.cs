using System;

namespace Slovom.SpellerRules
{
    /// <summary>
    /// Speller for numbers up to 99
    /// </summary>
    internal class RuleN99 : INumberSpeller
    {
        private readonly INumberSpeller _rule19 = new RuleN19();

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number < 20)
            {
                return _rule19.Spell(number, gender);
            }

            uint tens = (number / 10) * 10;

            string head = GetTens(tens);

            uint reminder = number % 10;
            if (reminder == 0)
            {
                return new SpelledNumber(tens, head, false);
            }

            string result = head + " и " + _rule19.Spell(reminder, gender);

            return new SpelledNumber(number, result, true);
        }

        private string GetTens(uint number)
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
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}

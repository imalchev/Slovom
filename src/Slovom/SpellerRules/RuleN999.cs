using System;

namespace Slovom.SpellerRules
{
    /// <summary>
    /// Speller for numbers up to 999
    /// </summary>
    internal class RuleN999 : INumberSpeller
    {
        private readonly INumberSpeller _rule99 = new RuleN99();

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number < 100)
            {
                return _rule99.Spell(number, gender);
            }

            uint hundreds = (number / 100) * 100;
            string hundredsInWords = GetHundreds(hundreds);

            SpelledNumber left = new SpelledNumber(hundreds, hundredsInWords, false);

            uint reminder = number % 100;
            if (reminder == 0)
            {
                return left;
            }

            return left.Concat(_rule99.Spell(reminder, gender));

            // if (reminder < 20 || reminder % 10 == 0)
            // {
            //     return hundredsInWords + " и " + _rule99.Spell(reminder, gender);
            // }
            // 
            // return hundredsInWords + " " + _rule99.Spell(reminder);
        }

        private string GetHundreds(uint number)
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
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

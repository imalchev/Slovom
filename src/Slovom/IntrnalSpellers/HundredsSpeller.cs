using System;

namespace Slovom.InternalSpellers
{
    /// <summary>
    /// Speller for numbers up to 999
    /// </summary>
    internal class HundredsSpeller : INumberSpeller
    {
        private readonly INumberSpeller _tensSpeller;

        public HundredsSpeller(INumberSpeller tensSpeller)
        {
            _tensSpeller = tensSpeller;
        }

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number < 100)
            {
                return _tensSpeller.Spell(number, gender);
            }

            uint hundreds = (number / 100) * 100;
            string hundredsInWords = GetHundreds(hundreds);

            SpelledNumber left = new SpelledNumber(hundreds, hundredsInWords, false);

            uint reminder = number % 100;
            if (reminder == 0)
            {
                return left;
            }

            return left.Concat(_tensSpeller.Spell(reminder, gender));
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

using System;

namespace Slovom.Internal
{
    /// <summary>
    /// Speller for numbers up to 999. If number is less than 100 _tensSpeller is used to spell the number.
    /// </summary>
    internal class HundredsSpeller : ChainedSpeller
    {
        // private readonly Speller _tensSpeller;

        public HundredsSpeller(Speller tensSpeller)
            : base(tensSpeller)
        {
            // _tensSpeller = tensSpeller;
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
    }
}

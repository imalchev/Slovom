using System;

namespace Slovom.InternalSpellers
{
    /// <summary>
    /// Speller for numbers up to 19
    /// </summary>
    internal class NumbersTo19Speller : INumberSpeller
    {
        private INumberSpeller _digitsSpeller;

        public NumbersTo19Speller(INumberSpeller digitsSpeller)
        {
            _digitsSpeller = digitsSpeller;
        }

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number < 10)
            {
                return _digitsSpeller.Spell(number, gender);
            }

            string result;
            switch (number)
            {
                case 10: result = "десет"; break;
                case 11: result = "единадесет"; break;
                case 12: result = "дванадесет"; break;
                case 13: result = "тринадесет"; break;
                case 14: result = "четиринадесет"; break;
                case 15: result = "петнадесет"; break;
                case 16: result = "шестнадесет"; break;
                case 17: result = "седемнадесет"; break;
                case 18: result = "осемнадесет"; break;
                case 19: result = "деветнадесет"; break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new SpelledNumber(number, result, false);
        }
    }
}

using System;

namespace Slovom.Internal
{
    /// <summary>
    /// Speller for numbers up to 19. If number is less than 10 spelling is provided to its child elements.
    /// </summary>
    internal class NumbersTo19Speller : ChainedSpeller
    {
        public NumbersTo19Speller(Speller digitsSpeller)
            : base(digitsSpeller)
        {
        }

        public override SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral)
        {
            if (number < 10)
            {
                return InnerSpeller.Spell(number, gender);
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
                    throw new ArgumentOutOfRangeException(nameof(number), $"'{nameof(NumbersTo19Speller)}' is can't spell number {number}!");
            }

            return new SpelledNumber(result, false);
        }

        public override SpelledNumber SpellOrdinal(ulong number, Gender gender = Gender.Neutral)
        {
            if (number < 10)
            {
                return InnerSpeller.SpellOrdinal(number, gender);
            }

            string result;
            switch (number)
            {
                case 10: result = (gender == Gender.Male ? "десети" : gender == Gender.Female ? "десета" : "десето"); break;
                case 11: result = (gender == Gender.Male ? "единадесети" : gender == Gender.Female ? "единадесета" : "единадесето"); break;
                case 12: result = (gender == Gender.Male ? "дванадесети" : gender == Gender.Female ? "дванадесета" : "дванадесето"); break;
                case 13: result = (gender == Gender.Male ? "тринадесети" : gender == Gender.Female ? "тринадесета" : "тринадесето"); break;
                case 14: result = (gender == Gender.Male ? "четиринадесети" : gender == Gender.Female ? "четиринадесета" : "четиринадесето"); break;
                case 15: result = (gender == Gender.Male ? "петнадесети" : gender == Gender.Female ? "петнадесета" : "петнадесето"); break;
                case 16: result = (gender == Gender.Male ? "шестнадесети" : gender == Gender.Female ? "шестнадесета" : "шестнадесето"); break;
                case 17: result = (gender == Gender.Male ? "седемнадесети" : gender == Gender.Female ? "седемнадесета" : "седемнадесето"); break;
                case 18: result = (gender == Gender.Male ? "осемнадесети" : gender == Gender.Female ? "осемнадесета" : "осемнадесето"); break;
                case 19: result = (gender == Gender.Male ? "деветнадесети" : gender == Gender.Female ? "деветнадесета" : "деветнадесето"); break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(number), $"'{nameof(NumbersTo19Speller)}' is can't spell number {number}!");
            }

            return new SpelledNumber(result, false);
        }
    }
}

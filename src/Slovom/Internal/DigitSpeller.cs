using System;

namespace Slovom.Internal.OrdinalSpellers
{
    /// <summary>
    /// Speller for numbers up to 9
    /// </summary>
    internal class DigitSpeller : Speller
    {
        public override SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral)
        {
            string result;
            switch (number)
            {
                case 1: result = (gender == Gender.Male ? "един": gender == Gender.Female ? "една" : "едно"); break;
                case 2: result = (gender == Gender.Male ? "два" : "две"); break;
                case 3: result = "три"; break;
                case 4: result = "четири"; break;
                case 5: result = "пет"; break;
                case 6: result = "шест"; break;
                case 7: result = "седем"; break;
                case 8: result = "осем"; break;
                case 9: result = "девет"; break;
                default: throw new ArgumentOutOfRangeException(nameof(number), $"'{nameof(DigitSpeller)}' is can't spell number {number}!");
            }

            return new SpelledNumber(result, false);
        }

        public override SpelledNumber SpellOrdinal(ulong number, Gender gender = Gender.Neutral)
        {
            string result;
            switch (number)
            {
                case 1: result = (gender == Gender.Male ? "първи" : gender == Gender.Female ? "първа" : "първо"); break;
                case 2: result = (gender == Gender.Male ? "втори" : gender == Gender.Female ? "втора" : "второ"); break;
                case 3: result = (gender == Gender.Male ? "трети" : gender == Gender.Female ? "трета" : "трето"); break;
                case 4: result = (gender == Gender.Male ? "четвърти" : gender == Gender.Female ? "четвърта" : "четвърто"); break;
                case 5: result = (gender == Gender.Male ? "пети" : gender == Gender.Female ? "пета" : "пето"); break;
                case 6: result = (gender == Gender.Male ? "шести" : gender == Gender.Female ? "шеста" : "шесто"); break;
                case 7: result = (gender == Gender.Male ? "седми" : gender == Gender.Female ? "седма" : "седмо"); break;
                case 8: result = (gender == Gender.Male ? "осми" : gender == Gender.Female ? "осма" : "осмо"); break;
                case 9: result = (gender == Gender.Male ? "девети" : gender == Gender.Female ? "девета" : "девето"); break;
                default: throw new ArgumentOutOfRangeException(nameof(number), $"'{nameof(DigitSpeller)}' is can't spell number {number}!");
            }

            return new SpelledNumber(result, false);
        }
    }
}

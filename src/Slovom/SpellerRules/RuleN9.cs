using System;
using System.Collections.Generic;
using System.Text;

namespace Slovom.SpellerRules
{
    /// <summary>
    /// Speller for numbers up to 9
    /// </summary>
    internal class RuleN9 : INumberSpeller
    {
        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
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
                default: throw new ArgumentOutOfRangeException();
            }

            return new SpelledNumber(number, result, false);
        }
    }
}

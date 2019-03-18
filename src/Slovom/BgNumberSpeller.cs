using Slovom.SpellerRules;

namespace Slovom
{
    public class BgNumberSpeller
    {
        private static readonly INumberSpeller s_spellingRules;

        static BgNumberSpeller()
        {
            s_spellingRules = new HeadSpeller(new RuleN999999999());
        }

        public string Spell(int number)
        {
            bool isNegative = false;
            if (number < 0)
            {
                isNegative = true;
                number = number * (-1);
            }

            SpelledNumber result = s_spellingRules.Spell((uint)number);
            
            return (isNegative ? "минус " : "") + result;
        }
    }
}

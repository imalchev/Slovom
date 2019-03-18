namespace Slovom.SpellerRules
{
    internal class HeadSpeller : INumberSpeller
    {
        private readonly INumberSpeller _maxNumberSpeller;

        public HeadSpeller(INumberSpeller maxNumberSpeller)
        {
            _maxNumberSpeller = maxNumberSpeller;
        }

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number > 0)
            {
                return _maxNumberSpeller.Spell(number);
            }

            return new SpelledNumber(0, "нула", false);
        }
    }
}

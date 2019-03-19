namespace Slovom.Internal
{
    internal class ZeroSpeller : INumberSpeller
    {
        private readonly INumberSpeller _maxNumberSpeller;

        public ZeroSpeller(INumberSpeller maxNumberSpeller)
        {
            _maxNumberSpeller = maxNumberSpeller;
        }

        public SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral)
        {
            if (number > 0)
            {
                return _maxNumberSpeller.Spell(number);
            }

            return new SpelledNumber("нула", false);
        }
    }
}

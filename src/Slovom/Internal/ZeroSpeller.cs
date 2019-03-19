namespace Slovom.Internal
{
    internal class ZeroSpeller : ChainedSpeller
    {
        public ZeroSpeller(Speller maxNumberSpeller)
            : base(maxNumberSpeller)
        {
        }

        public override SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral)
        {
            if (number > 0)
            {
                return InnerSpeller.Spell(number, gender);
            }

            return new SpelledNumber("нула", false);
        }
    }
}

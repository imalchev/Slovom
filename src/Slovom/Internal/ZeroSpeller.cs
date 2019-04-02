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

        public override SpelledNumber SpellOrdinal(ulong number, Gender gender = Gender.Neutral)
        {
            if (number > 0)
            {
                return InnerSpeller.SpellOrdinal(number, gender);
            }

            if (gender == Gender.Male)
            {
                return new SpelledNumber("нулев", false);
            }
            else if (gender == Gender.Female)
            {
                return new SpelledNumber("нулева", false);
            }

            return new SpelledNumber("нулево", false);
        }
    }
}

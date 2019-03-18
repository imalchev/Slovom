namespace Slovom.InternalSpellers
{
    /// <summary>
    /// Represents algorithm capable to spell numbers up to 999 milions
    /// </summary>
    internal class MillionsSpeller : INumberSpeller
    {
        private readonly INumberSpeller _thousandsSpeller;

        public MillionsSpeller(INumberSpeller thousandsSpeller)
        {
            _thousandsSpeller = thousandsSpeller;
        }

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number < 1_000_000)
            {
                return _thousandsSpeller.Spell(number, gender);
            }

            uint milions = number / 1_000_000;

            SpelledNumber milionsSpelled;
            if (milions == 1)
            {
                milionsSpelled = new SpelledNumber(1_000_000, "един милион", false);
            }
            else
            {
                SpelledNumber spelled = _thousandsSpeller.Spell(milions, Gender.Male);

                milionsSpelled = new SpelledNumber(spelled.Number * 1_000_000, spelled.Spelled + " милиона", spelled.ContainsAnd);
            }

            uint reminder = number % 1_000_000;

            if (reminder == 0)
            {
                return milionsSpelled;
            }

            return milionsSpelled.Concat(_thousandsSpeller.Spell(reminder));
        }
    }
}

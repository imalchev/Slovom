namespace Slovom.InternalSpellers
{
    internal class BillionsSpeller : INumberSpeller
    {
        private readonly INumberSpeller _millionsSpeller;

        public BillionsSpeller(INumberSpeller millionsSpeller)
        {
            _millionsSpeller = millionsSpeller;
        }

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number < 1_000_000_000)
            {
                return _millionsSpeller.Spell(number, gender);
            }

            uint milions = number / 1_000_000_000;

            SpelledNumber milionsSpelled;
            if (milions == 1)
            {
                milionsSpelled = new SpelledNumber(1_000_000_000, "един милиард", false);
            }
            else
            {
                SpelledNumber spelled = _millionsSpeller.Spell(milions, Gender.Male);

                milionsSpelled = new SpelledNumber(spelled.Number * 1_000_000, spelled.Spelled + " милиардa", spelled.ContainsAnd);
            }

            uint reminder = number % 1_000_000_000;

            if (reminder == 0)
            {
                return milionsSpelled;
            }

            return milionsSpelled.Concat(_millionsSpeller.Spell(reminder));
        }
    }
}

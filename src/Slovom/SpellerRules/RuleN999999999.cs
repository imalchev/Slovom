namespace Slovom.SpellerRules
{
    internal class RuleN999999999 : INumberSpeller
    {
        private readonly INumberSpeller _speller999999 = new RuleN999999();

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number < 1_000_000)
            {
                return _speller999999.Spell(number, gender);
            }

            uint milions = number / 1_000_000;

            SpelledNumber milionsSpelled;
            if (milions == 1)
            {
                milionsSpelled = new SpelledNumber(1_000_000, "един милион", false);
            }
            else
            {
                SpelledNumber spelled = _speller999999.Spell(milions, Gender.Male);

                milionsSpelled = new SpelledNumber(spelled.Number * 1_000_000, spelled.Spelled + " милиона", spelled.ContainsAnd);
            }

            uint reminder = number % 1_000_000;

            if (reminder == 0)
            {
                return milionsSpelled;
            }

            return milionsSpelled.Concat(_speller999999.Spell(reminder));
        }
    }
}

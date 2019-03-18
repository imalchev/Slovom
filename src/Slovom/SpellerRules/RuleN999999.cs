namespace Slovom.SpellerRules
{
    internal class RuleN999999 : INumberSpeller
    {
        private readonly INumberSpeller _speller999 = new RuleN999();

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number < 1000)
            {
                return _speller999.Spell(number, gender);
            }

            uint thousands = number / 1_000;

            SpelledNumber thousandsSpelled;
            if (thousands == 1)
            {
                thousandsSpelled = new SpelledNumber(1_000, "хиляда", false);
            }
            else
            {
                SpelledNumber spelled = _speller999.Spell(thousands, Gender.Female);

                thousandsSpelled = new SpelledNumber(spelled.Number * 1_000, spelled.Spelled + " хиляди", spelled.ContainsAnd);
            }

            uint reminder = number % 1_000;

            if (reminder == 0)
            {
                return thousandsSpelled;
            }

            return thousandsSpelled.Concat(_speller999.Spell(reminder));
        }
    }
}

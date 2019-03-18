namespace Slovom.InternalSpellers
{
    /// <summary>
    /// Represents algorithm for spelling numbers up to 999 999
    /// </summary>
    internal class ThousandsSpeller : INumberSpeller
    {
        private readonly INumberSpeller _hundredsSpeller;

        public ThousandsSpeller(INumberSpeller hundredsSpeller)
        {
            _hundredsSpeller = hundredsSpeller;
        }

        public SpelledNumber Spell(uint number, Gender gender = Gender.Neutral)
        {
            if (number < 1_000)
            {
                return _hundredsSpeller.Spell(number, gender);
            }

            uint thousands = number / 1_000;

            SpelledNumber thousandsSpelled;
            if (thousands == 1)
            {
                thousandsSpelled = new SpelledNumber(1_000, "хиляда", false);
            }
            else
            {
                SpelledNumber spelled = _hundredsSpeller.Spell(thousands, Gender.Female);

                thousandsSpelled = new SpelledNumber(spelled.Number * 1_000, spelled.Spelled + " хиляди", spelled.ContainsAnd);
            }

            uint reminder = number % 1_000;

            if (reminder == 0)
            {
                return thousandsSpelled;
            }

            return thousandsSpelled.Concat(_hundredsSpeller.Spell(reminder));
        }
    }
}

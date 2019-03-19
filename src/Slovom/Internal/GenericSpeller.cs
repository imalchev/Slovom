namespace Slovom.Internal
{
    internal class GenericSpeller : INumberSpeller
    {
        private readonly INumberSpeller _childSpeller;
        private readonly GenericSpellerSettings _settings;

        public GenericSpeller(INumberSpeller childSpeller, GenericSpellerSettings settings)
        {
            _childSpeller = childSpeller;
            _settings = settings;
        }

        public SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral)
        {
            if (number < _settings.Magnitude)
            {
                return _childSpeller.Spell(number, gender);
            }

            ulong numberOfUnits = number / _settings.Magnitude;

            SpelledNumber thousandsSpelled;
            if (numberOfUnits == 1)
            {
                thousandsSpelled = new SpelledNumber(_settings.Singular, false);
            }
            else
            {
                SpelledNumber spelled = _childSpeller.Spell(numberOfUnits, _settings.SpellingGender);

                thousandsSpelled = new SpelledNumber(spelled.Spelled + _settings.PluralSuffix, spelled.ContainsAnd);
            }

            ulong reminder = number % _settings.Magnitude;

            if (reminder == 0)
            {
                return thousandsSpelled;
            }

            return thousandsSpelled.Concat(_childSpeller.Spell(reminder));
        }
    }
}

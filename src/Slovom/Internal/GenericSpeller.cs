namespace Slovom.Internal
{
    /// <summary>
    /// Spells numbers using generic algorithm. Spells the upper part over <see cref="GenericSpellerSettings.Magnitude"/>
    /// </summary>
    internal class GenericSpeller : ChainedSpeller
    {
        private readonly GenericSpellerSettings _settings;

        public GenericSpeller(Speller childSpeller, GenericSpellerSettings settings)
            : base(childSpeller)
        {
            _settings = settings;
        }

        public override SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral)
        {
            if (number < _settings.Magnitude)
            {
                return InnerSpeller.Spell(number, gender);
            }

            ulong numberOfUnits = number / _settings.Magnitude;

            SpelledNumber unitsSpelled;
            if (numberOfUnits == 1)
            {
                unitsSpelled = new SpelledNumber(_settings.Singular, false);
            }
            else
            {
                SpelledNumber spelled = InnerSpeller.Spell(numberOfUnits, _settings.SpellingGender);

                unitsSpelled = new SpelledNumber(spelled.Spelled + _settings.PluralSuffix, spelled.ContainsAnd);
            }

            ulong reminder = number % _settings.Magnitude;

            if (reminder == 0)
            {
                return unitsSpelled;
            }

            return unitsSpelled.Concat(InnerSpeller.Spell(reminder, gender));
        }

        public override SpelledNumber SpellOrdinal(ulong number, Gender gender = Gender.Neutral)
        {
            if (number < _settings.Magnitude)
            {
                return InnerSpeller.SpellOrdinal(number, gender);
            }

            ulong numberOfUnits = number / _settings.Magnitude;
            ulong reminder = number % _settings.Magnitude;

            if (reminder == 0)
            {
                string result = GetOrdinal(numberOfUnits, gender);

                SpelledNumber unitsOrdinalSpelled = new SpelledNumber(result, false);
                return unitsOrdinalSpelled;
            }

            SpelledNumber unitsSpelled;
            if (numberOfUnits == 1)
            {
                unitsSpelled = new SpelledNumber(_settings.Singular, false);
            }
            else
            {
                SpelledNumber spelled = InnerSpeller.Spell(numberOfUnits, _settings.SpellingGender);

                unitsSpelled = new SpelledNumber(spelled.Spelled + _settings.PluralSuffix, spelled.ContainsAnd);
            }

            return unitsSpelled.Concat(InnerSpeller.SpellOrdinal(reminder, gender));
        }

        private string GetOrdinal(ulong numberOfUnits, Gender gender)
        {
            if (numberOfUnits == 1)
            {
                return _settings.GetOrdinalSuffix(gender);
            }

            return InnerSpeller.Spell(numberOfUnits, _settings.SpellingGender) + " " + _settings.GetOrdinalSuffix(gender);
        }        
    }
}

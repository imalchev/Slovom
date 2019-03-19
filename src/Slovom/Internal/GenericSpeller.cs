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
    }
}

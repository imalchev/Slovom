using System;

namespace Slovom.Internal
{
    internal class GenericSpellerSettings
    {
        public ulong Magnitude { get; }
        public string Singular { get; }
        public string PluralSuffix { get; }
        public Gender SpellingGender { get; }
        public string OrdinalMaleSuffix { get; }
        public string OrdinalFemaleSuffix { get; }
        public string OrdinalNeutralSuffix { get; }

        public GenericSpellerSettings(ulong magnitude, string singular, string pluralSuffix, Gender spellingGender, string ordinalMaleSuffix, string ordinalFemaleSuffix, string ordinalNeutralSuffix)
        {
            Magnitude = magnitude;
            Singular = singular;
            PluralSuffix = pluralSuffix;
            SpellingGender = spellingGender;
            OrdinalMaleSuffix = ordinalMaleSuffix;
            OrdinalFemaleSuffix = ordinalFemaleSuffix;
            OrdinalNeutralSuffix = ordinalNeutralSuffix;
        }

        public string GetOrdinalSuffix(Gender ordinalGender)
        {
            return ordinalGender == Gender.Male ? OrdinalMaleSuffix : ordinalGender == Gender.Female ? OrdinalFemaleSuffix : OrdinalNeutralSuffix;
        }
    }
}

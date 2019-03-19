namespace Slovom.Internal
{
    internal class GenericSpellerSettings
    {
        public ulong Magnitude { get; }
        public string Singular { get; }
        public string PluralSuffix { get; }
        public Gender SpellingGender { get; }

        public GenericSpellerSettings(ulong magnitude, string singular, string pluralSuffix, Gender spellingGender)
        {
            Magnitude = magnitude;
            Singular = singular;
            PluralSuffix = pluralSuffix;
            SpellingGender = spellingGender;
        }
    }
}

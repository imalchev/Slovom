namespace Slovom.Internal
{
    internal abstract class Speller
    {
        public abstract SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral);

        public abstract SpelledNumber SpellOrdinal(ulong number, Gender gender = Gender.Neutral);
    }
}

namespace Slovom.Internal
{
    internal abstract class Speller
    {
        public abstract SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral);
    }
}

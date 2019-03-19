namespace Slovom.Internal
{
    internal interface INumberSpeller
    {
        SpelledNumber Spell(ulong number, Gender gender = Gender.Neutral);
    }
}

namespace Slovom.InternalSpellers
{
    internal interface INumberSpeller
    {
        SpelledNumber Spell(uint number, Gender gender = Gender.Neutral);
    }
}

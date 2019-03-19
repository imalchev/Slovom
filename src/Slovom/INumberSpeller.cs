namespace Slovom
{
    public interface INumberSpeller
    {
        bool CanSpell(long number);

        string Spell(long number, Gender gender = Gender.Neutral);
    }
}

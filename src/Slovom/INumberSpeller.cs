namespace Slovom
{
    /// <summary>
    /// Provides abstraction to the core functionality of the library
    /// </summary>
    public interface INumberSpeller
    {
        /// <summary>
        /// Checks if number can be spelled. If it can't <see cref="Spell(long, Gender)"/> will throw an exception.
        /// </summary>
        bool CanSpell(long number);

        /// <summary>
        /// Spells number <paramref name="number"/> into written language words.
        /// </summary>
        /// <param name="number">The number to be spelled</param>
        /// <param name="gender">Grammatical gender to spell in. If it does matter.</param>
        /// <returns></returns>
        string Spell(long number, Gender gender = Gender.Neutral);
    }
}

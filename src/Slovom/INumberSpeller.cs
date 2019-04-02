namespace Slovom
{
    /// <summary>
    /// Provides abstraction to the core functionality of the library
    /// </summary>
    public interface INumberSpeller
    {
        /// <summary>
        /// Spells <paramref name="number"/> into written language words.
        /// </summary>
        /// <param name="number">The number to be spelled</param>
        /// <param name="gender">Grammatical gender to spell in. If it does matter.</param>
        string Spell(long number, Gender gender = Gender.Neutral);

        /// <summary>
        /// Spell <paramref name="number"/> as it is an order
        /// </summary>
        /// <param name="number">The number to be spelled</param>
        /// <param name="gender"></param>
        string SpellOrdinal(long number, Gender gender = Gender.Neutral);
    }
}

using Slovom.Internal;
using System;

namespace Slovom
{
    /// <summary>
    /// Implementation of INumberSpeller interface for Bulgarian language.
    /// </summary>
    /// <threadsafety static="true" instance="true">
    /// Each instance method of this class is thread safe.
    /// </threadsafety>
    public class BgNumberSpeller : INumberSpeller
    {
        private static readonly Speller s_speller;

        public const long MaxSpellableNumber = 999_999_999_999_999;
        public const long MinSpellableNumber = -999_999_999_999_999;

        static BgNumberSpeller()
        {
            var digitsSpeller = new DigitSpeller();
            var numTo19Speller = new NumbersTo19Speller(digitsSpeller);
            var tensSpeller = new TensSpeller(numTo19Speller);
            var hundredsSpeller = new HundredsSpeller(tensSpeller);
            var thousandsSpeller = new GenericSpeller(
                childSpeller: hundredsSpeller,
                settings: new GenericSpellerSettings(1_000, "хиляда", " хиляди", Gender.Female));
            var millionsSpeller = new GenericSpeller(
                childSpeller: thousandsSpeller, 
                settings: new GenericSpellerSettings(1_000_000, "един милион", " милиона", Gender.Male));
            var billionsSpeller = new GenericSpeller(
                childSpeller: millionsSpeller,
                settings: new GenericSpellerSettings(1_000_000_000, "един милиард", " милиарда", Gender.Male));
            var trillionsSpeller = new GenericSpeller(
                childSpeller: billionsSpeller,
                settings: new GenericSpellerSettings(1_000_000_000_000, "един трилион", " трилиона", Gender.Male));

            s_speller = new ZeroSpeller(trillionsSpeller);
        }

        /// <summary>
        /// Checks if <paramref name="number"/> can be spelled. False if <paramref name="number"/> is out of range of the spellable numbers by the library.
        /// </summary>
        public bool CanSpell(long number) => number >= MinSpellableNumber && number <= MaxSpellableNumber;

        /// <summary>
        /// Spells number up bigger than <see cref="MinSpellableNumber"/> and less than <see cref="MaxSpellableNumber"/>
        /// </summary>
        /// <param name="number">The integer number to spell</param>
        /// <param name="gender">The gender to spell. This matters only for the singular part of the number: "един", "една", "едно".</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="number"/> is beyond supported range of numbers.</exception>
        public string Spell(long number, Gender gender = Gender.Neutral)
        {
            if (number > MaxSpellableNumber)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"The library supports max number of {MaxSpellableNumber}");
            }

            if (number < MinSpellableNumber)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"The library supports max number of {MaxSpellableNumber}");
            }

            bool isNegative = false;
            if (number < 0)
            {
                isNegative = true;
                number = number * (-1);
            }

            SpelledNumber result = s_speller.Spell((ulong)number, gender);

            return (isNegative ? "минус " : "") + result;
        }
    }
}

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
            var kvadrilionsSpeller = new GenericSpeller(
                    childSpeller: trillionsSpeller,
                    settings: new GenericSpellerSettings(1_000_000_000_000_000, "един квадрилион", " квадрилиона", Gender.Male));
            var kvintalionsSpeller = new GenericSpeller(
                    childSpeller: kvadrilionsSpeller,
                    settings: new GenericSpellerSettings(1_000_000_000_000_000_000, "един квинталион", " квинталиона", Gender.Male));

            s_speller = new ZeroSpeller(kvintalionsSpeller);
        }

        /// <summary>
        /// Spells number 
        /// </summary>
        /// <param name="number">The integer number to spell</param>
        /// <param name="gender">The gender to spell. This matters only for the singular part of the number: "един", "една", "едно".</param>
        public string Spell(long number, Gender gender = Gender.Neutral)
        {
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

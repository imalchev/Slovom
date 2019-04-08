using Slovom.Internal;
using Slovom.Internal.OrdinalSpellers;

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
                    settings: new GenericSpellerSettings(1_000, "хиляда", " хиляди", Gender.Female, "хиляден", "хилядна", "хилядно"));
            var millionsSpeller = new GenericSpeller(
                    childSpeller: thousandsSpeller, 
                    settings: new GenericSpellerSettings(1_000_000, "един милион", " милиона", Gender.Male, "милионен", "милионна", "милионно"));
            var billionsSpeller = new GenericSpeller(
                    childSpeller: millionsSpeller,
                    settings: new GenericSpellerSettings(1_000_000_000, "един милиард", " милиарда", Gender.Male, "милиарден", "милиардна", "милиардно"));
            var trillionsSpeller = new GenericSpeller(
                    childSpeller: billionsSpeller,
                    settings: new GenericSpellerSettings(1_000_000_000_000, "един трилион", " трилиона", Gender.Male, "трилионен", "трилионна", "трилионно"));
            var kvadrilionsSpeller = new GenericSpeller(
                    childSpeller: trillionsSpeller,
                    settings: new GenericSpellerSettings(1_000_000_000_000_000, "един квадрилион", " квадрилиона", Gender.Male, "квадрилионен", "квадрилионна", "квадрилионно"));
            var kvintalionsSpeller = new GenericSpeller(
                    childSpeller: kvadrilionsSpeller,
                    settings: new GenericSpellerSettings(1_000_000_000_000_000_000, "един квинталион", " квинталиона", Gender.Male, "квинталионен", "квинталионна", "квинталионно"));

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public string SpellOrdinal(long number, Gender gender = Gender.Neutral)
        {
            bool isNegative = false;
            if (number < 0)
            {
                isNegative = true;
                number = number * (-1);
            }

            SpelledNumber result = s_speller.SpellOrdinal((ulong)number, gender);

            return (isNegative ? "минус " : "") + result;
        }
    }
}

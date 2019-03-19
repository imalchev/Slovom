using Slovom.Internal;

namespace Slovom
{
    public class BgNumberSpeller
    {
        private static readonly INumberSpeller s_speller;

        static BgNumberSpeller()
        {
            var digitsSpeller = new DigitSpeller();
            var numTo19Speller = new NumbersTo19Speller(digitsSpeller);
            var tensSpeller = new TensSpeller(numTo19Speller);
            var hundredsSpeller = new HundredsSpeller(tensSpeller);

            var thousandsSpeller = new GenericSpeller(hundredsSpeller, new GenericSpellerSettings(1_000, "хиляда", " хиляди", Gender.Female));
            var millionsSpeller = new GenericSpeller(thousandsSpeller, new GenericSpellerSettings(1_000_000, "един милион", " милиона", Gender.Male));
            var billionsSpeller = new GenericSpeller(millionsSpeller, new GenericSpellerSettings(1_000_000_000, "един милиард", " милиарда", Gender.Male));

            s_speller = new ZeroSpeller(billionsSpeller);
        }

        public string Spell(int number)
        {
            bool isNegative = false;
            if (number < 0)
            {
                isNegative = true;
                number = number * (-1);
            }

            SpelledNumber result = s_speller.Spell((uint)number);
            
            return (isNegative ? "минус " : "") + result;
        }
    }
}

using Slovom.InternalSpellers;

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
            var thousandsSpeller = new ThousandsSpeller(hundredsSpeller);
            var millionsSpeller = new MillionsSpeller(thousandsSpeller);
            var billionsSpeller = new BillionsSpeller(millionsSpeller);

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

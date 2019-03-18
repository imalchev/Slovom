using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slovom
{
    public class BgSpeller
    {
        public string Spell(int number)
        {
            if (number == 0)
            {
                return "нула";
            }

            bool isNegative = false;
            if (number < 0)
            {
                isNegative = true;
                number = number * (-1);
            }

            IReadOnlyList<ushort> digits = Parse(number).Reverse().ToList();

            string result;
            if (digits.Count == 1)
            {
                result = SpellDigit(digits[0]);
            }
            else if (digits.Count == 2)
            {
                result = SpellNumberFrom10To99(digits);
            }
            else if (digits.Count == 3)
            {
                result = SpellNumberFrom100To999(digits);
            }
            else
            {
                throw new NotImplementedException();
            }

            return (isNegative ? "минус " : "") + result;
        }

        private string SpellDigit(ushort digit)
        {
            switch (digit)
            {
                case 1: return "едно";
                case 2: return "две";
                case 3: return "три";
                case 4: return "четири";
                case 5: return "пет";
                case 6: return "шест";
                case 7: return "седем";
                case 8: return "осем";
                case 9: return "девет";
                    
                default:
                    throw new InvalidOperationException();
            }
        }

        private string SpellTens(ushort number)
        {
            if (number == 2)
            {
                return "двадесет";
            }

            return SpellDigit(number) + "десет";
        }

        private string SpellHundreds(ushort number)
        {
            if (number == 1)
            {
                return "сто";
            }

            if (number <= 3)
            {
                return SpellDigit(number) + "ста";
            }

            return SpellDigit(number) + "стотин";
        }

        private string SpellNumberFrom10To99(IReadOnlyList<ushort> digits)
        {
            if (digits[0] == 1)
            {
                if (digits[1] == 0)
                {
                    return "десет";
                }
                else if (digits[1] == 1)
                {
                    return "единадесет";
                }
                else if (digits[1] == 2)
                {
                    return "дванадесет";
                }

                return SpellDigit(digits[1]) + "надесет"; 
            }

            if (digits[1] == 0)
            {
                return SpellTens(digits[0]);
            }

            return SpellTens(digits[0]) + " и " + SpellDigit(digits[1]);
        }

        private string SpellNumberFrom100To999(IReadOnlyList<ushort> digits)
        {
            string number = SpellHundreds(digits[0]);

            if (digits[1] == 0)
            {
                if (digits[2] == 0)
                {
                    return number;
                }

                return number + " и " + SpellDigit(digits[2]);
            }
            else if (digits[1] == 1 || digits[2] == 0)
            {
                return number + " и " + SpellNumberFrom10To99(digits.Skip(1).ToList());
            }

            return number + " " + SpellNumberFrom10To99(digits.Skip(1).ToList());
        }

        private IEnumerable<ushort> Parse(int number)
        {
            int remainder = number;
            do
            {
                yield return (ushort)(remainder % 10);
                remainder = remainder / 10;
            }
            while (remainder != 0);
        }
    }
}

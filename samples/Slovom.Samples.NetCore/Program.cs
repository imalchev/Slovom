using System;

namespace Slovom.Samples.NetCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number to spell!");
            Console.Write("> ");

            string input = Console.ReadLine();

            long number;
            while (!long.TryParse(input, out number))
            {
                Console.WriteLine("Invalid number! Try again!");
                Console.Write("> ");
            }

            INumberSpeller speller = new BgNumberSpeller();

            string numberInWords = speller.Spell(number);

            Console.WriteLine(numberInWords);
            Console.ReadLine();
        }
    }
}

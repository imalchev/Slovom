using System;

namespace Slovom.Samples.Full
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number to spell!");
            Console.Write("> ");

            string input;
            do
            {
                input = Console.ReadLine();

                long number;
                while (!long.TryParse(input, out number))
                {
                    Console.WriteLine("Invalid number! Try again!");
                    Console.Write("> ");
                    input = Console.ReadLine();
                }

                INumberSpeller speller = new BgNumberSpeller();

                string numberInWords = speller.Spell(number, Gender.Female);

                Console.WriteLine(numberInWords);
                Console.Write("> ");
            }
            while (input.ToUpper() != "EXIT");

            Console.ReadLine();
        }
    }
}

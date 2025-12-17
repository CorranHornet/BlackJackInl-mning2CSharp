using System;
using BlackJackInlämning2CSharp.Models;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static void Main()
        {
            bool runAgain = true;

            while (runAgain)
            {
                Deck deck = new Deck();
                Dealer dealer = new Dealer();

                Console.WriteLine("\nDealer draws cards until reaching 17 or more.\n");

                dealer.PlayTurn(deck);

                Console.WriteLine($"Dealer final total: {dealer.Total}");

                Console.WriteLine("\nRun the dealer draw test again? (y/n)");
                string input = Console.ReadLine()?.ToLower();
                runAgain = input == "y";
                Console.WriteLine();
            }
        }
    }
}

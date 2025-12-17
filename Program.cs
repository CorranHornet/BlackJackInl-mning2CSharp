using System;
using BlackJackInlämning2CSharp.Models;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static void Main()
        {
            Deck deck = new Deck();
            Player player = new Player();

            Console.WriteLine("Player class refactor test\n");

            bool runAgain = true;
            while (runAgain)
            {
                player.ResetHand();
                for (int i = 0; i < 2; i++) // initial 2 cards
                {
                    player.DrawCard(deck);
                }

                Console.WriteLine($"Player total: {player.Total}\n");

                Console.WriteLine("Run player draw again? (y/n)");
                string input = Console.ReadLine()?.ToLower();
                runAgain = input == "y";
            }
        }
    }
}

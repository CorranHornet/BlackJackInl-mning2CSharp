using System;
using BlackJackInlämning2CSharp.Models;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static void Main()
        {
            Game game = new Game();

            bool playAgain = true;
            while (playAgain)
            {
                game.PlayRound();

                Console.WriteLine("\nPlay again? (y/n)");
                string input = Console.ReadLine()?.ToLower();
                playAgain = input == "y";
                Console.WriteLine();
            }
        }
    }
}

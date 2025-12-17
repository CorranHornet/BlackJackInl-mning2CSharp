using BlackJackInlämning2CSharp.Services;
using System;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static void Main()
        {
            bool runAgain = true;

            while (runAgain)
            {
                Game game = new Game();
                game.Start(); // Single-player vs dealer round

                Console.WriteLine("\nPlay another round? (y/n)");
                string input = Console.ReadLine()?.ToLower();
                runAgain = input == "y";
                Console.WriteLine();
            }
        }
    }
}

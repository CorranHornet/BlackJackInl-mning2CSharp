namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static void Main()
        {
            bool playAgain = true;

            while (playAgain)
            {
                Game game = new Game();
                game.Start();

                Console.WriteLine("\nPlay again? (y/n)");
                playAgain = Console.ReadLine()?.ToLower() == "y";
            }
        }
    }
}

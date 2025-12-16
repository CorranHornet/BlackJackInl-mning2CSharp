using System;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static string[] deck = new string[52];
        static Random random = new Random();

        static int playerTotal;
        static int playerAces;

        static void Main()
        {
            SetupDeck();

            Console.WriteLine("Player turn with Ace handling\n");

            bool runAgain = true;

            while (runAgain)
            {
                RunPlayerTurn();

                Console.WriteLine("\nPlay again? (y/n)");
                string input = Console.ReadLine()?.ToLower();
                runAgain = input == "y";

                Console.WriteLine();
            }
        }

        static void SetupDeck()
        {
            string[] suits = { "hearts", "diamonds", "clubs", "spades" };
            string[] ranks =
            {
                "ace","2","3","4","5","6","7","8","9","10","jack","queen","king"
            };

            int index = 0;
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck[index++] = $"{rank} of {suit}";
                }
            }
        }

        static void RunPlayerTurn()
        {
            ResetPlayer();

            Console.WriteLine("Player starts drawing...\n");

            bool playerTurn = true;

            while (playerTurn)
            {
                DrawCardPlayer();
                AdjustForAces();

                Console.WriteLine($"Player total: {playerTotal}");

                if (playerTotal > 21)
                {
                    Console.WriteLine("Player busts!");
                    break;
                }

                Console.WriteLine("\nHit or Stand? (h/s): ");
                string choice = Console.ReadLine()?.ToLower();

                if (choice == "s")
                    playerTurn = false;

                Console.WriteLine();
            }

            Console.WriteLine($"Player ends with total: {playerTotal}");
        }

        static void ResetPlayer()
        {
            playerTotal = 0;
            playerAces = 0;
        }

        static void DrawCardPlayer()
        {
            string card = deck[random.Next(deck.Length)];
            int value = ConvertCard(card);

            playerTotal += value;

            Console.WriteLine($"Player draws: {card}");

            if (card.StartsWith("ace"))
            {
                playerAces++;
                Console.WriteLine("Ace counted as 11 (may be adjusted later if total exceeds 21)");
            }
        }

        static int ConvertCard(string card)
        {
            string rank = card.Split(' ')[0];

            switch (rank)
            {
                case "ace": return 11;
                case "king":
                case "queen":
                case "jack": return 10;
                default: return int.Parse(rank);
            }
        }

        static void AdjustForAces()
        {
            while (playerTotal > 21 && playerAces > 0)
            {
                playerTotal -= 10;
                playerAces--;
                Console.WriteLine("Ace adjusted from 11 to 1 to avoid bust");
            }
        }
    }
}

using System;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static string[] deck = new string[52];
        static Random random = new Random();

        static int dealerTotal;
        static int dealerAces;

        static void Main()
        {
            SetupDeck();

            Console.WriteLine("Dealer logic test (Blackjack rules)\n");

            bool runAgain = true;

            while (runAgain)
            {
                RunDealerTurn();

                Console.WriteLine("\nRun dealer again? (y/n)");
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

        static void RunDealerTurn()
        {
            ResetDealer();

            Console.WriteLine("Dealer starts drawing...\n");

            // Dealer draws until rules are met
            while (dealerTotal < 17)
            {
                DrawCardDealer();
                AdjustForAces(); // removed ref, works directly on static fields
                Console.WriteLine($"Dealer total: {dealerTotal}\n");
            }

            Console.WriteLine($"Dealer stands with total: {dealerTotal}");
        }

        static void ResetDealer()
        {
            dealerTotal = 0;
            dealerAces = 0;
        }

        static void DrawCardDealer()
        {
            string card = deck[random.Next(deck.Length)];
            int value = ConvertCard(card);

            dealerTotal += value;

            if (card.StartsWith("ace"))
                dealerAces++;

            Console.WriteLine($"Dealer draws: {card}");
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

        // Refactored to remove ref — works on static fields directly
        static void AdjustForAces()
        {
            while (dealerTotal > 21 && dealerAces > 0)
            {
                dealerTotal -= 10;
                dealerAces--;
            }
        }
    }
}

using System;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static string[] deck = new string[52];
        static Random random = new Random();

        static int dealerTotal;
        static int dealerAces;

        static int playerTotal;
        static int playerAcesChosenAs11;

        static void Main()
        {
            SetupDeck();

            Console.WriteLine("Blackjack player turn with Ace choice\n");

            bool playAgain = true;
            while (playAgain)
            {
                RunPlayerTurn();

                Console.WriteLine("\nDo you want to play again? (y/n)");
                string input = Console.ReadLine()?.ToLower();
                playAgain = input == "y";
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

        // ---------------- PLAYER TURN ----------------
        static void RunPlayerTurn()
        {
            ResetPlayer();
            Console.WriteLine("Player starts drawing...\n");

            bool turn = true;
            while (turn && playerTotal <= 21)
            {
                Console.WriteLine($"Player total: {playerTotal}");
                Console.Write("Hit or Stand? (h/s): ");
                string input = Console.ReadLine()?.ToLower();

                if (input == "h")
                {
                    DrawCardPlayer();
                    AdjustPlayerAces();
                }
                else if (input == "s")
                {
                    turn = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Type 'h' to hit or 's' to stand.");
                }
            }

            Console.WriteLine($"\nPlayer ends with total: {playerTotal}");
        }

        static void ResetPlayer()
        {
            playerTotal = 0;
            playerAcesChosenAs11 = 0;
        }

        static void DrawCardPlayer()
        {
            string card = deck[random.Next(deck.Length)];
            int value;

            if (card.StartsWith("ace"))
            {
                Console.WriteLine("Ace drawn! Do you want it to count as 1 or 11? (1/11)");
                string choice = Console.ReadLine();

                if (choice == "1")
                    value = 1;
                else
                {
                    value = 11;
                    playerAcesChosenAs11++;
                }
            }
            else
            {
                value = ConvertCard(card);
            }

            playerTotal += value;
            Console.WriteLine($"Player draws: {card}");
            Console.WriteLine($"Player total now: {playerTotal}\n");
        }

        static int ConvertCard(string card)
        {
            string rank = card.Split(' ')[0];

            switch (rank)
            {
                case "king":
                case "queen":
                case "jack": return 10;
                default: return int.Parse(rank);
            }
        }

        static void AdjustPlayerAces()
        {
            // Only reduce 11-valued Aces to 1 if total exceeds 21
            while (playerTotal > 21 && playerAcesChosenAs11 > 0)
            {
                playerTotal -= 10;
                playerAcesChosenAs11--;
                Console.WriteLine("Ace adjusted from 11 to 1 to avoid bust");
            }
        }

        // ---------------- DEALER TURN ----------------
        static void RunDealerTurn()
        {
            ResetDealer();

            Console.WriteLine("Dealer starts drawing...\n");

            while (dealerTotal < 17)
            {
                DrawCardDealer();
                AdjustForAces();
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

        static void AdjustForAces()
        {
            while (dealerTotal > 21 && dealerAces > 0)
            {
                dealerTotal -= 10;
                dealerAces--;
                Console.WriteLine("Ace adjusted from 11 to 1 to avoid bust");
            }
        }
    }
}

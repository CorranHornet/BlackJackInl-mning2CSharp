using System;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static string[] deck = new string[52];
        static Random random = new Random();

        // Dealer variables
        static int dealerTotal;
        static int dealerAces;
        static string dealerFirstCard;
        static string dealerSecondCard;

        // Player variables
        static int playerTotal;
        static int playerAcesChosenAs11;
        static string playerFirstCard;
        static string playerSecondCard;

        static void Main()
        {
            SetupDeck();

            Console.WriteLine("Blackjack game: Full round play\n");

            bool playAgain = true;
            while (playAgain)
            {
                PlayRound();

                Console.WriteLine("\nPlay another round? (y/n)");
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

        // ---------------- FULL ROUND ----------------
        static void PlayRound()
        {
            ResetPlayer();
            ResetDealer();

            // Initial dealing: 2 cards each
            playerFirstCard = DrawCardPlayer(initial: true);
            playerSecondCard = DrawCardPlayer(initial: true);

            dealerFirstCard = DrawCardDealer();
            dealerSecondCard = DrawCardDealer(hidden: true);

            Console.WriteLine($"Dealer shows: {dealerFirstCard}");
            Console.WriteLine($"Player cards: {playerFirstCard}, {playerSecondCard}");
            Console.WriteLine($"Player total: {playerTotal}\n");

            // Player turn
            RunPlayerTurn();

            // If player busts, dealer wins automatically
            if (playerTotal > 21)
            {
                Console.WriteLine("Player busts! Dealer wins.");
                RevealDealerHand();
                return;
            }

            // Dealer turn
            Console.WriteLine("\nDealer reveals hidden card...");
            Console.WriteLine($"Dealer hand: {dealerFirstCard}, {dealerSecondCard}");
            RunDealerTurn();

            // Determine winner
            DetermineWinner();
        }

        // ---------------- PLAYER METHODS ----------------
        static void ResetPlayer()
        {
            playerTotal = 0;
            playerAcesChosenAs11 = 0;
        }

        static string DrawCardPlayer(bool initial = false)
        {
            string card = deck[random.Next(deck.Length)];
            int value;

            if (card.StartsWith("ace"))
            {
                if (initial) // auto assign 11 for initial cards
                {
                    value = 11;
                    playerAcesChosenAs11++;
                }
                else
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
            }
            else
            {
                value = ConvertCard(card);
            }

            playerTotal += value;
            if (!initial)
                Console.WriteLine($"Player draws: {card}");
            return card;
        }

        static void RunPlayerTurn()
        {
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

        static void AdjustPlayerAces()
        {
            while (playerTotal > 21 && playerAcesChosenAs11 > 0)
            {
                playerTotal -= 10;
                playerAcesChosenAs11--;
                Console.WriteLine("Ace adjusted from 11 to 1 to avoid bust");
            }
        }

        // ---------------- DEALER METHODS ----------------
        static void ResetDealer()
        {
            dealerTotal = 0;
            dealerAces = 0;
        }

        static string DrawCardDealer(bool hidden = false)
        {
            string card = deck[random.Next(deck.Length)];
            int value = ConvertCard(card);

            dealerTotal += value;

            if (card.StartsWith("ace"))
                dealerAces++;

            if (!hidden)
                Console.WriteLine($"Dealer draws: {card}");
            return card;
        }

        static void RunDealerTurn()
        {
            while (dealerTotal < 17)
            {
                DrawCardDealer();
                AdjustForAces();
                Console.WriteLine($"Dealer total: {dealerTotal}\n");
            }

            Console.WriteLine($"Dealer stands with total: {dealerTotal}");
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

        static void RevealDealerHand()
        {
            Console.WriteLine($"Dealer hand: {dealerFirstCard}, {dealerSecondCard}");
            Console.WriteLine($"Dealer total: {dealerTotal}");
        }

        // ---------------- ROUND OUTCOME ----------------
        static void DetermineWinner()
        {
            if (dealerTotal > 21)
            {
                Console.WriteLine("Dealer busts! Player wins!");
                return;
            }

            if (playerTotal > dealerTotal)
                Console.WriteLine("Player wins!");
            else if (dealerTotal > playerTotal)
                Console.WriteLine("Dealer wins!");
            else
                Console.WriteLine("Tie!");
        }

        static int ConvertCard(string card)
        {
            string rank = card.Split(' ')[0];

            switch (rank)
            {
                case "ace": return 11; // player choice handled separately
                case "king":
                case "queen":
                case "jack": return 10;
                default: return int.Parse(rank);
            }
        }
    }
}

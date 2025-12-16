using System;
using System.Collections.Generic;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static List<string> deck;
        static Random random = new Random();

        static int playerTotal;
        static int dealerTotal;

        static int playerAces;
        static int dealerAces;

        static void Main()
        {
            bool playAgain = true;

            while (playAgain)
            {
                StartNewRound();
                PlayPlayerTurn();
                PlayDealerTurn();
                DetermineWinner();

                Console.WriteLine("\nPlay again? (y/n)");
                playAgain = Console.ReadLine()?.ToLower() == "y";
                Console.WriteLine();
            }
        }

        static void StartNewRound()
        {
            SetupDeck();

            playerTotal = 0;
            dealerTotal = 0;
            playerAces = 0;
            dealerAces = 0;

            Console.WriteLine("New Blackjack round\n");

            DrawCardPlayer();
            DrawCardPlayer();

            DrawCardDealer();
            DrawCardDealer();

            ShowTotals(false);
        }

        static void SetupDeck()
        {
            deck = new List<string>();

            string[] suits = { "hearts", "diamonds", "clubs", "spades" };
            string[] ranks =
            {
                "ace","2","3","4","5","6","7","8","9","10","jack","queen","king"
            };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add($"{rank} of {suit}");
                }
            }
        }

        static void PlayPlayerTurn()
        {
            while (true)
            {
                Console.WriteLine($"\nPlayer total: {playerTotal}");
                Console.Write("Hit or Stand? (h/s): ");
                string choice = Console.ReadLine()?.ToLower();

                if (choice == "s")
                    break;

                if (choice == "h")
                {
                    DrawCardPlayer();
                    AdjustPlayerAces();

                    if (playerTotal > 21)
                    {
                        Console.WriteLine($"Player busts with {playerTotal}");
                        return;
                    }
                }
            }

            Console.WriteLine($"Player stands with {playerTotal}");
        }

        static void PlayDealerTurn()
        {
            if (playerTotal > 21)
                return;

            Console.WriteLine("\nDealer turn:");

            while (dealerTotal < 17)
            {
                DrawCardDealer();
                AdjustDealerAces();
            }

            Console.WriteLine($"Dealer stands with {dealerTotal}");
        }

        static void DrawCardPlayer()
        {
            string card = DrawRandomCard();
            int value = ConvertCard(card);

            playerTotal += value;

            if (card.StartsWith("ace"))
                playerAces++;

            Console.WriteLine($"Player draws: {card}");
        }

        static void DrawCardDealer()
        {
            string card = DrawRandomCard();
            int value = ConvertCard(card);

            dealerTotal += value;

            if (card.StartsWith("ace"))
                dealerAces++;

            Console.WriteLine($"Dealer draws: {card}");
        }

        static string DrawRandomCard()
        {
            int index = random.Next(deck.Count);
            string card = deck[index];
            deck.RemoveAt(index);
            return card;
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

        static void AdjustPlayerAces()
        {
            while (playerTotal > 21 && playerAces > 0)
            {
                playerTotal -= 10;
                playerAces--;
            }
        }

        static void AdjustDealerAces()
        {
            while (dealerTotal > 21 && dealerAces > 0)
            {
                dealerTotal -= 10;
                dealerAces--;
            }
        }

        static void DetermineWinner()
        {
            Console.WriteLine("\nFinal result:");
            ShowTotals(true);

            if (playerTotal > 21)
                Console.WriteLine("Dealer wins!");
            else if (dealerTotal > 21)
                Console.WriteLine("Player wins!");
            else if (playerTotal > dealerTotal)
                Console.WriteLine("Player wins!");
            else if (dealerTotal > playerTotal)
                Console.WriteLine("Dealer wins!");
            else
                Console.WriteLine("Push (tie).");
        }

        static void ShowTotals(bool showDealer)
        {
            Console.WriteLine($"Player total: {playerTotal}");
            if (showDealer)
                Console.WriteLine($"Dealer total: {dealerTotal}");
        }
    }
}

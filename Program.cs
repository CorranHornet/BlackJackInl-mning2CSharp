using System;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        // Arrays and variables
        static string[] card = new string[53]; // card deck (1–52)
        static string dealerHand;
        static string playerHand;
        static int playerTotal;
        static int dealerTotal;
        static int playerAces; // Tracks number of Aces for player
        static int dealerAces; // Tracks number of Aces for dealer

        static void Main()
        {
            Console.WriteLine("Blackjack game - Commit 4: Ace handling and correct scoring");
            blackJack();
        }

        static void blackJack()
        {
            InitializeDeck();

            dealerHand = "";
            playerHand = "";
            dealerTotal = 0;
            playerTotal = 0;
            dealerAces = 0;
            playerAces = 0;

            // Deal four cards each for testing and demonstration
            GetCardDealer();
            GetCardPlayer();
            GetCardDealer();
            GetCardPlayer();
            GetCardDealer();
            GetCardPlayer();
            GetCardDealer();
            GetCardPlayer();

            // Display hands and totals
            Console.WriteLine("Dealer's hand: " + dealerHand + " (" + dealerTotal + ")");
            Console.WriteLine("Player's hand: " + playerHand + " (" + playerTotal + ")");
        }

        static void GetCardDealer()
        {
            int cardValue = 0;
            string cardDrawn = "";
            GetCard(ref cardValue, ref cardDrawn);

            dealerTotal += cardValue;
            dealerHand += (dealerHand == "" ? "" : ", ") + cardDrawn;

            if (cardValue == 11) dealerAces++;

            // Adjust for Aces if total > 21
            while (dealerTotal > 21 && dealerAces > 0)
            {
                dealerTotal -= 10;
                dealerAces--;
            }
        }

        static void GetCardPlayer()
        {
            int cardValue = 0;
            string cardDrawn = "";
            GetCard(ref cardValue, ref cardDrawn);

            playerTotal += cardValue;
            playerHand += (playerHand == "" ? "" : ", ") + cardDrawn;

            if (cardValue == 11) playerAces++;

            // Adjust for Aces if total > 21
            while (playerTotal > 21 && playerAces > 0)
            {
                playerTotal -= 10;
                playerAces--;
            }
        }

        static void GetCard(ref int cardValue, ref string cardDrawn)
        {
            Random rnd = new Random();
            int index = 0;

            while (index == 0 || string.IsNullOrEmpty(card[index]))
            {
                index = rnd.Next(1, 53);
            }

            cardDrawn = card[index];
            card[index] = null; // remove from deck

            ConvertCard(ref cardValue, cardDrawn);
        }

        // Convert card to numeric value (Ace = 11 for now)
        static void ConvertCard(ref int cardValue, string cardDrawn)
        {
            string lower = cardDrawn.ToLower();
            string rank = lower.Split(' ')[0]; // e.g., "ace" from "ace of spades"

            switch (rank)
            {
                case "ace":
                    cardValue = 11;
                    break;
                case "king":
                case "queen":
                case "jack":
                case "10":
                    cardValue = 10;
                    break;
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    cardValue = int.Parse(rank);
                    break;
                default:
                    cardValue = 0; // fallback
                    break;
            }
        }

        static void InitializeDeck()
        {
            string[] suits = { "spades", "clubs", "hearts", "diamonds" };
            string[] ranks = { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };

            int index = 1;
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    card[index] = $"{rank} of {suit}";
                    index++;
                }
            }
        }
    }
}

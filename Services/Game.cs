using System;
using BlackJackInlämning2CSharp.Models;

namespace BlackJackInlämning2CSharp
{
    class Game
    {
        private Deck deck;
        private Player player;
        private Dealer dealer;

        public Game()
        {
            deck = new Deck();
            player = new Player();
            dealer = new Dealer();
        }

        public void Start()
        {
            player.ResetHand();
            dealer.ResetHand();

            //Player initial deal: exactly 2 cards
            player.DrawCard(deck);
            player.DrawCard(deck);

            // Dealer draws initial cards
            dealer.DrawInitialCards(deck);

            // Player turn
            PlayerTurn();

            // Reveal dealer hidden card
            dealer.RevealHiddenCard();

            // Dealer plays if player not busted
            if (player.Total <= 21)
                dealer.PlayTurn(deck);

            ShowFinalResult();
        }

        private void PlayerTurn()
        {
            while (true)
            {
                Console.WriteLine($"\nPlayer total: {player.Total}");
                Console.Write("Hit or Stand? (h/s): ");
                string input = Console.ReadLine()?.ToLower();

                if (input == "s") break;

                if (input == "h")
                {
                    player.DrawCard(deck);
                    if (player.Total > 21)
                    {
                        Console.WriteLine($"Player busts with {player.Total}");
                        break;
                    }
                }
            }
        }

        private void ShowFinalResult()
        {
            Console.WriteLine($"\nPlayer total: {player.Total}");
            Console.WriteLine($"Dealer total: {dealer.Total}");

            if (player.Total > 21) Console.WriteLine("Dealer wins!");
            else if (dealer.Total > 21 || player.Total > dealer.Total) Console.WriteLine("Player wins!");
            else if (dealer.Total > player.Total) Console.WriteLine("Dealer wins!");
            else Console.WriteLine("Push (tie).");
        }
    }
}

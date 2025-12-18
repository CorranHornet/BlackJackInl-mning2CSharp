using System;

namespace BlackJackInlämning2CSharp.Models
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

        public void PlayRound()
        {
            player.ResetHand();
            dealer.ResetHand();

            Console.WriteLine("\nNew Blackjack round\n");

            // Initial draw
            player.DrawCard(deck);
            player.DrawCard(deck);

            dealer.DrawInitialCards(deck);

            Console.WriteLine($"\nPlayer total: {player.Total}");

            PlayerTurn();

            // Reveal hidden card regardless of player bust
            dealer.RevealHiddenCard();

            if (player.Total <= 21)
                dealer.PlayTurn(deck);

            DetermineWinner();
        }

        private void PlayerTurn()
        {
            while (true)
            {
                Console.Write("\nHit or Stand? (h/s): ");
                string choice = Console.ReadLine()?.ToLower();

                if (choice == "s")
                    break;

                if (choice == "h")
                {
                    player.DrawCard(deck);
                    Console.WriteLine($"Player total: {player.Total}");

                    // Show dealer total after each player action
                    Console.WriteLine($"Dealer total: {dealer.Total}");

                    if (player.Total > 21)
                    {
                        Console.WriteLine("Player busts!");
                        break;
                    }
                }
            }
        }

        private void DetermineWinner()
        {
            Console.WriteLine("\nFinal result:");
            Console.WriteLine($"Player total: {player.Total}");
            Console.WriteLine($"Dealer total: {dealer.Total}");

            if (player.Total > 21)
                Console.WriteLine("Dealer wins!");
            else if (dealer.Total > 21)
                Console.WriteLine("Player wins!");
            else if (player.Total > dealer.Total)
                Console.WriteLine("Player wins!");
            else if (dealer.Total > player.Total)
                Console.WriteLine("Dealer wins!");
            else
                Console.WriteLine("Push (tie).");
        }
    }
}

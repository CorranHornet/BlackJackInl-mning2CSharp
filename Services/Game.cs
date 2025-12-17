using System;
using BlackJackInlämning2CSharp.Models;

namespace BlackJackInlämning2CSharp.Services
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
            StartNewRound();
            PlayerTurn();
            DealerTurn(); // dealer draws according to rules
            DetermineWinner();
        }

        private void StartNewRound()
        {
            deck = new Deck(); // reshuffle
            player.ResetHand();
            dealer.ResetHand();

            Console.WriteLine("=== New Blackjack Round ===\n");

            // Player draws 2 cards
            player.DrawCard(deck);
            player.DrawCard(deck);
            Console.WriteLine($"\nPlayer total: {player.Total}\n");

            // Dealer draws 2 cards
            dealer.DrawCard(deck);
            dealer.DrawCard(deck);
        }

        private void PlayerTurn()
        {
            while (true)
            {
                Console.Write("Hit or Stand? (h/s): ");
                string choice = Console.ReadLine()?.ToLower();

                if (choice == "s")
                    break;

                if (choice == "h")
                {
                    player.DrawCard(deck);

                    if (player.Total > 21)
                    {
                        Console.WriteLine($"Player busts with {player.Total}");
                        break;
                    }

                    Console.WriteLine($"Player total: {player.Total}");
                }
            }

            Console.WriteLine($"Player stands with {player.Total}");
        }

        private void DealerTurn()
        {
            Console.WriteLine("\nDealer's turn:");

            while (dealer.Total < 17)
            {
                dealer.DrawCard(deck); // logs "Dealer draws"
            }

            Console.WriteLine($"Dealer stands with {dealer.Total}");
        }

        private void DetermineWinner()
        {
            Console.WriteLine($"\nFinal totals - Player: {player.Total}, Dealer: {dealer.Total}");

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

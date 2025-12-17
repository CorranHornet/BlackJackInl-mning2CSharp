using System;
using BlackJackInlämning2CSharp.Models;

namespace BlackJackInlämning2CSharp.Services
{
    class Game
    {
        private Deck deck;
        private Player player;

        public Game()
        {
            deck = new Deck();
            player = new Player();
        }

        public void Start()
        {
            StartNewRound();
            PlayerTurn();
            Console.WriteLine($"Player stands with total: {player.Total}");
        }

        private void StartNewRound()
        {
            deck = new Deck(); // reshuffle each round
            player.ResetHand();

            Console.WriteLine("=== New Blackjack Round ===\n");

            // Player draws 2 initial cards
            player.DrawCard(deck);
            player.DrawCard(deck);

            Console.WriteLine($"\nPlayer total: {player.Total}\n");
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
        }
    }
}

using System;

namespace BlackJackInlämning2CSharp.Models
{
    class Dealer : Player
    {
        public void PlayTurn(Deck deck)
        {
            Console.WriteLine("Dealer's turn:");

            while (Total < 17)
            {
                DrawCard(deck);
            }

            Console.WriteLine($"Dealer stands with {Total}");
        }
    }
}

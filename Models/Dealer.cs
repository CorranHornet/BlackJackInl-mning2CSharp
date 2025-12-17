using System;

namespace BlackJackInlämning2CSharp.Models
{
    class Dealer : Player
    {
        public override void DrawCard(Deck deck)
        {
            Card card = deck.DrawCard();
            Hand.Add(card);
            Total += card.GetValue();

            if (card.Rank == "ace")
                AceCount++;

            AdjustForAces();
            Console.WriteLine($"Dealer draws: {card}");
        }

        public void PlayTurn(Deck deck)
        {
            while (Total < 17)
            {
                DrawCard(deck); // logs "Dealer draws"
            }

            Console.WriteLine($"Dealer stands with {Total}");
        }
    }
}

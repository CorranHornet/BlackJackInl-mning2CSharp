using System;
using BlackJackInlämning2CSharp.Models;

namespace BlackJackInlämning2CSharp.Models
{
    class Dealer : Player
    {
        private Card hiddenCard;

        // Dealer override allows changing text output
        public virtual void DrawCard(Deck deck, bool showOutput = true)
        {
            Card card = deck.DrawCard();
            Hand.Add(card);
            Total += card.GetValue();
            if (card.Rank == "ace") AceCount++;

            AdjustForAces();
            if (showOutput)
                Console.WriteLine($"Dealer draws: {card}");
        }

        // Initial dealer draw: first visible, second hidden
        public void DrawInitialCards(Deck deck)
        {
            DrawCard(deck); // First card visible

            hiddenCard = deck.DrawCard(); // Second card hidden
            Hand.Add(hiddenCard);
            Total += hiddenCard.GetValue();
            if (hiddenCard.Rank == "ace") AceCount++;
            AdjustForAces();
            Console.WriteLine("Dealer draws a hidden card");
        }

        public void RevealHiddenCard()
        {
            if (hiddenCard != null)
            {
                Console.WriteLine($"Dealer reveals hidden card: {hiddenCard}");
                hiddenCard = null;
            }
        }

        public void PlayTurn(Deck deck)
        {
            while (Total < 17)
            {
                DrawCard(deck);
            }
            Console.WriteLine($"Dealer stands with {Total}");
        }
    }
}

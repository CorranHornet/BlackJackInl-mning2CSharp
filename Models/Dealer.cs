using System;
using System.Collections.Generic;

namespace BlackJackInlämning2CSharp.Models
{
    class Dealer : Player
    {
        private Card hiddenCard;

        // Dealer draws 2 cards initially
        public void DrawInitialCards(Deck deck)
        {
            // First card is visible, suppress base PrintDraw
            Card firstCard = deck.DrawCard();
            Hand.Add(firstCard);
            Total += firstCard.GetValue();
            if (firstCard.Rank == "ace") AceCount++;
            AdjustForAces();

            Console.WriteLine($"Dealer shows: {firstCard}");
            Console.WriteLine($"Dealer total (visible card): {firstCard.GetValue()}");

            // Second card is hidden
            hiddenCard = deck.DrawCard();
            Hand.Add(hiddenCard);
            Total += hiddenCard.GetValue();
            if (hiddenCard.Rank == "ace") AceCount++;
            AdjustForAces();

            Console.WriteLine("Dealer draws a hidden card");
        }

        // Reveal the hidden card and show full hand
        public void RevealHiddenCard()
        {
            Console.WriteLine($"\nDealer reveals hidden card: {hiddenCard}");
            Console.Write("Dealer hand: ");
            for (int i = 0; i < Hand.Count; i++)
            {
                Console.Write($"{Hand[i]}");
                if (i < Hand.Count - 1) Console.Write(", ");
            }
            Console.WriteLine($"\nDealer total: {Total}");
        }

        public void PlayTurn(Deck deck)
        {
            Console.WriteLine("\nDealer turn:");

            while (Total < 17)
            {
                DrawCard(deck);
                Console.WriteLine($"Dealer total: {Total}");
            }

            Console.WriteLine($"Dealer stands with {Total}");
        }

        protected override void PrintDraw(Card card)
        {
            // Only print draws after initial cards
            if (!Hand.Contains(card) || card != Hand[0])
                Console.WriteLine($"Dealer draws: {card}");
        }
    }
}

using System;
using System.Collections.Generic;

namespace BlackJackInlämning2CSharp.Models
{
    class Player
    {
        public List<Card> Hand { get; private set; }
        public int Total { get; private set; }
        public int AceCount { get; private set; }

        public Player()
        {
            Hand = new List<Card>();
            Total = 0;
            AceCount = 0;
        }

        public void DrawCard(Deck deck)
        {
            Card card = deck.DrawCard();
            Hand.Add(card);
            int value = card.GetValue();
            Total += value;

            if (card.Rank == "ace")
            {
                AceCount++;
                Console.WriteLine($"Ace drawn! Current total: {Total} (Ace counted as 11, may adjust later)");
            }
            else
            {
                Console.WriteLine($"Player draws: {card} - total now: {Total}");
            }

            AdjustForAces();
        }

        private void AdjustForAces()
        {
            while (Total > 21 && AceCount > 0)
            {
                Total -= 10;
                AceCount--;
                Console.WriteLine("Ace adjusted from 11 to 1 to avoid bust");
            }
        }

        public void ResetHand()
        {
            Hand.Clear();
            Total = 0;
            AceCount = 0;
        }
    }
}

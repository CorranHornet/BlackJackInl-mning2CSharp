using System;
using System.Collections.Generic;

namespace BlackJackInlämning2CSharp.Models
{
    class Player
    {
        public List<Card> Hand { get; private set; }
        public int Total { get; protected set; }  // Protected so subclasses can access
        public int AceCount { get; protected set; }

        public Player()
        {
            Hand = new List<Card>();
            Total = 0;
            AceCount = 0;
        }

        public virtual void DrawCard(Deck deck)
        {
            Card card = deck.DrawCard();
            Hand.Add(card);
            Total += card.GetValue();

            if (card.Rank == "ace")
                AceCount++;

            AdjustForAces();
            PrintDraw(card);
        }

        protected virtual void PrintDraw(Card card)
        {
            Console.WriteLine($"Player draws: {card} - total now: {Total}");
        }

        protected void AdjustForAces()
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

using System;
using System.Collections.Generic;

namespace BlackJackInlämning2CSharp.Models
{
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            string[] suits = { "hearts", "diamonds", "clubs", "spades" };
            string[] ranks = { "ace","2","3","4","5","6","7","8","9","10","jack","queen","king" };

            cards = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        public Card DrawCard()
        {
            if (cards.Count == 0) throw new InvalidOperationException("Deck is empty");

            int index = random.Next(cards.Count);
            Card card = cards[index];
            cards.RemoveAt(index);
            return card;
        }
    }
}

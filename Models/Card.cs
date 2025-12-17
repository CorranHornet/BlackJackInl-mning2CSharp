using System;

namespace BlackJackInlämning2CSharp.Models
{
    class Card
    {
        public string Rank { get; }
        public string Suit { get; }

        public Card(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int GetValue()
        {
            switch (Rank)
            {
                case "ace": return 11;
                case "king":
                case "queen":
                case "jack": return 10;
                default: return int.Parse(Rank);
            }
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}

using System;
using BlackJackInlämning2CSharp.Models;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        static void Main()
        {
            Deck deck = new Deck();

            Console.WriteLine("Card and Deck refactor test\n");

            for (int i = 0; i < 5; i++)
            {
                Card card = deck.DrawCard();
                Console.WriteLine($"Drawn card: {card} - value: {card.GetValue()}");
            }
        }
    }
}

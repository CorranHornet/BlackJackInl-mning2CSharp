using System;
namespace BlackJackInlämning2CSharp;


class Program
{
    // Arrays and variables
    static string[] card = new string[53]; // an array that is the full deck, initially empty 
    static string samladeKortDealer;
    static string samladeKortSpelare;
    static int samladeIntSpelare;
    static int samladeIntDealer;
    static int allAcesDealer;
    static int allAcesSpelare;

    static void Main()
    {
        Console.WriteLine("Blackjack game project setup - first commit!");
        //Testing so ruleSet works for GH
        blackJack();
    }

    static void blackJack()
    {
        // TODO: implement game logic
    }

    static void hamtaKortDealer()
    {
        // TODO: implement dealer card draw
    }

    static void hamtaKortSpelare()
    {
        // TODO: implement player card draw
    }

    static void game()
    {
        // TODO: implement game loop
    }

    static void endgame()
    {
        // TODO: implement win/loss logic
    }

    static void visaKort()
    {
        // TODO: implement display of cards
    }
}

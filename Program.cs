using System;

namespace BlackJackInlämning2CSharp
{
    class Program
    {
        // Arrays and variables
        static string[] card = new string[53]; // Full deck array (1-52 used)
        static string samladeKortDealer;
        static string samladeKortSpelare;
        static int samladeIntSpelare;
        static int samladeIntDealer;
        static int allAcesDealer;
        static int allAcesSpelare;

        static void Main()
        {
            Console.WriteLine("Blackjack game project - second commit setup!");
            blackJack();
        }

        static void blackJack()
        {
            // Initialize variables
            samladeKortDealer = "";
            samladeKortSpelare = "";
            samladeIntDealer = 0;
            samladeIntSpelare = 0;
            allAcesDealer = 0;
            allAcesSpelare = 0;

            // Populate the card array
            cardArray();

            // TODO: call methods to start game
            // hamtaKortDealer();
            // hamtaKortSpelare();
            // game();
            // endgame();
        }

        static void cardArray()
        {
            // Spades
            card[1] = "ace of spades";
            card[2] = "2 of spades";
            card[3] = "3 of spades";
            card[4] = "4 of spades";
            card[5] = "5 of spades";
            card[6] = "6 of spades";
            card[7] = "7 of spades";
            card[8] = "8 of spades";
            card[9] = "9 of spades";
            card[10] = "10 of spades";
            card[11] = "jack of spades";
            card[12] = "queen of spades";
            card[13] = "king of spades";

            // Clubs
            card[14] = "ace of clubs";
            card[15] = "2 of clubs";
            card[16] = "3 of clubs";
            card[17] = "4 of clubs";
            card[18] = "5 of clubs";
            card[19] = "6 of clubs";
            card[20] = "7 of clubs";
            card[21] = "8 of clubs";
            card[22] = "9 of clubs";
            card[23] = "10 of clubs";
            card[24] = "jack of clubs";
            card[25] = "queen of clubs";
            card[26] = "king of clubs";

            // Hearts
            card[27] = "ace of hearts";
            card[28] = "2 of hearts";
            card[29] = "3 of hearts";
            card[30] = "4 of hearts";
            card[31] = "5 of hearts";
            card[32] = "6 of hearts";
            card[33] = "7 of hearts";
            card[34] = "8 of hearts";
            card[35] = "9 of hearts";
            card[36] = "10 of hearts";
            card[37] = "jack of hearts";
            card[38] = "queen of hearts";
            card[39] = "king of hearts";

            // Diamonds
            card[40] = "ace of diamonds";
            card[41] = "2 of diamonds";
            card[42] = "3 of diamonds";
            card[43] = "4 of diamonds";
            card[44] = "5 of diamonds";
            card[45] = "6 of diamonds";
            card[46] = "7 of diamonds";
            card[47] = "8 of diamonds";
            card[48] = "9 of diamonds";
            card[49] = "10 of diamonds";
            card[50] = "jack of diamonds";
            card[51] = "queen of diamonds";
            card[52] = "king of diamonds";
        }

        // TODO: implement dealer card draw
        static void hamtaKortDealer()
        {
        }

        // TODO: implement player card draw
        static void hamtaKortSpelare()
        {
        }

        // TODO: implement game loop
        static void game()
        {
        }

        // TODO: implement win/loss logic
        static void endgame()
        {
        }

        // TODO: implement display of cards
        static void visaKort()
        {
        }
    }
}

using System;
using System.Threading;

namespace Blackjack.Classes
{
    //class exists to handle all writing to and reading from the console
    public class ConsoleIO
    {
        public static void TellPlayerHand(Player player)
        {
            Console.WriteLine($"{player.Name}'s hand:");

            foreach (Card card in player.Hand)
            {
                Console.WriteLine($"The {card.Rank} of {card.Suit}");
            }

            Console.WriteLine();
            Console.WriteLine($"{player.Name}'s hand total is: {player.HandTotal}");
            Console.WriteLine();
        }

        public static void TellDealerShowing(Dealer dealer)
        {
            Console.WriteLine($"{dealer.Name} is showing:");

            for (int i = 1; i < dealer.Hand.Count; i++)
            {
                Console.WriteLine($"The {dealer.Hand[i].Rank} of {dealer.Hand[i].Suit}");
            }

            Console.WriteLine();
            Console.WriteLine($"{dealer.Name} is showing a total of: {dealer.ShowingTotal}");
            Console.WriteLine();
        }

        public static void TellPlayerShowDealer(Player player, Dealer dealer)
        {
            TellPlayerHand(player);
            TellDealerShowing(dealer);
        }

        public static void Busted(Player player)
        {
            Console.WriteLine($"{player.Name} went bust!");
        }

        public static bool AskToHit()
        {
            bool hit = false;
            bool inputIsCorrect = false;

            Console.WriteLine("Hit or Stay? Enter H to Hit or S to Stay: ");
            string userInput = Console.ReadLine().ToUpper();

            while (!inputIsCorrect)
            {
                if (userInput == "H" || userInput == "S")
                {
                    inputIsCorrect = true;

                    if (userInput == "H")
                    {
                        hit = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid entry, please enter H to Hit or S to Stay: ");
                    userInput = Console.ReadLine().ToUpper();
                }
            }

            return hit;
        }

        public static void TellWinner(Player player, Dealer dealer)
        {
            Console.WriteLine(Game.DetermineWinner(player, dealer));
        }

        public static bool AskToPlayAgain()
        {
            bool keepPlaying = false;
            bool inputIsCorrect = false;

            Console.WriteLine("Play again? Y/N: ");
            string userInput = Console.ReadLine().ToUpper();

            while (!inputIsCorrect)
            {
                if (userInput == "Y" || userInput == "N")
                {
                    inputIsCorrect = true;

                    if (userInput == "Y")
                    {
                        keepPlaying = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid entry, please enter Y or N: ");
                    userInput = Console.ReadLine().ToUpper();
                }
            }

            return keepPlaying;
        }

        public static void Pause(int additionalTime = 0)
        {
            Thread.Sleep(3000 + additionalTime);
        }

        public static void DealerThinking()
        {
            Console.WriteLine("Dealer is thinking...");
        }

        public static void DealerFlipsFaceDownCard()
        {
            Console.WriteLine("Dealer flips their face down card");
            Pause();
        }

        public static void DealerHits()
        {
            Console.WriteLine("Dealer Hits");
            Pause();
        }

        public static void DealerStays()
        {
            Console.WriteLine("Dealer Stays");
            Pause(500);
        }

        public static void ConsoleCleanup()
        {
            Console.Clear();
        }

        public static void NewDeck()
        {
            Console.Clear();
            Console.WriteLine("Deck is almost out of cards. Getting a new deck and shuffling...");
            Pause(500);
            Pause(500);
        }

        public static void RanOutOfCards()
        {
            Console.Clear();
            Console.WriteLine("Oops. The deck ran out of cards. That wasn't supposed to happen.");
            Pause();
        }
    }
}

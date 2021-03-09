using System.Collections.Generic;


namespace Blackjack.Classes
{
    public class Card
    {
        //fields exist so standard 52 card deck can be automatically created in the Deck class - see InitializeDeck method
        public static string[] possibleSuits = { "Clubs", "Diamonds", "Hearts", "Spades" };

        public static string[] possibleRanks = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};

        public static Dictionary<string, int> possibleValuesByRank = new Dictionary<string, int>()
        {
            {"Two", 2 },
            {"Three", 3 },
            {"Four", 4},
            {"Five", 5 },
            {"Six", 6 },
            {"Seven", 7 },
            {"Eight", 8 },
            {"Nine", 9 },
            {"Ten", 10 },
            {"Jack", 10 },
            {"Queen", 10 },
            {"King", 10 },
            {"Ace", 11 }
        };

        public string Suit { get; set; }

        public string Rank { get; set; }

        public int Value { get; set; }

        public Card() { }

        //below constructor used for unit tests only
        public Card(string suit, string rank, int value)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.Value = value;
        }
    }
}

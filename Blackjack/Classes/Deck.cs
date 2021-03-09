using System;
using System.Collections.Generic;

namespace Blackjack.Classes
{
    public class Deck
    {
        //properties
        public List<Card> Cards { get; set; }

        //constructor - requires a list of cards as a parameter
        public Deck(List<Card> cards)
        {
            this.Cards = cards;
        }

        //methods
        //initialize deck creates standard 52 card deck with suits, ranks, values
        public static List<Card> InitializeDeck()
        {
            List<Card> cards = Initialize52Cards();
            InitializeSuits(cards);
            InitializeRanks(cards);
            InitializeValues(cards);

            return cards;
        }

        //create 52 cards, add to a list
        private static List<Card> Initialize52Cards()
        {
            List<Card> cards = new List<Card>();

            for (int i = 1; i <= 52; i++)
            {
                Card c = new Card();
                cards.Add(c);
            }

            return cards;
        }

        //take list of (52) cards, assign each suit
        private static List<Card> InitializeSuits(List<Card> cards)
        {
            int suitIndex = 0;
            
            foreach (Card card in cards)
            {
                card.Suit = Card.possibleSuits[suitIndex];

                if (suitIndex == Card.possibleSuits.Length - 1)
                {
                    suitIndex = 0;
                }
                else
                {
                    suitIndex++;
                }
            }

            return cards;
        }

        //take list of (52) cards, assign each rank
        private static List<Card> InitializeRanks(List<Card> cards)
        {
            int rankIndex = 0;

            foreach (Card card in cards)
            {
                card.Rank = Card.possibleRanks[rankIndex];

                if (rankIndex == Card.possibleRanks.Length - 1)
                {
                    rankIndex = 0;
                }
                else
                {
                    rankIndex++;
                }
            }

            return cards;
        }

        //take list of (52) cards, assign each card's blackjack value based on its rank
        private static List<Card> InitializeValues(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                card.Value = Card.possibleValuesByRank[card.Rank];
            }

            return cards;
        }

        //shuffle deck by getting a random index number 
        public List<Card> Shuffle()
        {
            List<Card> cardsToReturn = new List<Card>();
            Random rnd = new Random();
            int cardIndex;

            while (Cards.Count > 0)
            {
                cardIndex = rnd.Next(Cards.Count);
                cardsToReturn.Add(Cards[cardIndex]);
                Cards.RemoveAt(cardIndex);
            }

            return cardsToReturn;
        }

        //remove and return the top(i.e. last) card in the deck
        public Card DealCard()
        {
            Card cardToDeal = Cards[Cards.Count - 1];
            Cards.RemoveAt(Cards.Count - 1);

            return cardToDeal;
        }
    }
}

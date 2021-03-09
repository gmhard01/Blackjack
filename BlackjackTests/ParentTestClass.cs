using Blackjack.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackTests
{
    [TestClass]
    public abstract class ParentTestClass
    {
        protected readonly Deck deck = new Deck(Deck.InitializeDeck());
        protected readonly Player player = new Player("testPlayer");
        protected readonly Dealer dealer = new Dealer("testDealer");
        protected readonly Card two = new Card("Spades", "Two", Card.possibleValuesByRank["Two"]);
        protected readonly Card three = new Card("Spades", "Three", Card.possibleValuesByRank["Three"]);
        protected readonly Card four = new Card("Spades", "Four", Card.possibleValuesByRank["Four"]);
        protected readonly Card five = new Card("Spades", "Five", Card.possibleValuesByRank["Five"]);
        protected readonly Card six = new Card("Spades", "Six", Card.possibleValuesByRank["Six"]);
        protected readonly Card seven = new Card("Spades", "Seven", Card.possibleValuesByRank["Seven"]);
        protected readonly Card eight = new Card("Spades", "Eight", Card.possibleValuesByRank["Eight"]);
        protected readonly Card nine = new Card("Spades", "Nine", Card.possibleValuesByRank["Nine"]);
        protected readonly Card ten = new Card("Spades", "Ten", Card.possibleValuesByRank["Ten"]);
        protected readonly Card jack = new Card("Spades", "Jack", Card.possibleValuesByRank["Jack"]);
        protected readonly Card queen = new Card("Spades", "Queen", Card.possibleValuesByRank["Queen"]);
        protected readonly Card king = new Card("Spades", "King", Card.possibleValuesByRank["King"]);
        protected readonly Card ace = new Card("Spades", "Ace", Card.possibleValuesByRank["Ace"]);
    }
}

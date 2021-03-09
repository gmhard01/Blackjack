using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Classes;

namespace BlackjackTests
{
    [TestClass]
    public class DeckTests : ParentTestClass
    {
        [TestMethod]
        public void InitializeDeckReturnsListCount52()
        {
            int expectedCardCount = 52;
            int actualCardCount = deck.Cards.Count;

            Assert.AreEqual(expectedCardCount, actualCardCount);
        }

        [TestMethod]
        public void InitializeDeckCreates13Clubs()
        {
            int actualClubCount = 0;

            foreach (Card card in deck.Cards)
            {
                if (card.Suit == "Clubs")
                {
                    actualClubCount++;
                }
            }

            int expectedClubCount = 13;

            Assert.AreEqual(expectedClubCount, actualClubCount);
        }

        [TestMethod]
        public void InitializeDeckCreates13Diamonds()
        {
            int actualDiamondCount = 0;

            foreach (Card card in deck.Cards)
            {
                if (card.Suit == "Diamonds")
                {
                    actualDiamondCount++;
                }
            }

            int expectedDiamondCount = 13;

            Assert.AreEqual(expectedDiamondCount, actualDiamondCount);
        }

        [TestMethod]
        public void InitializeDeckCreates13Hearts()
        {
            int actualHeartCount = 0;

            foreach (Card card in deck.Cards)
            {
                if (card.Suit == "Hearts")
                {
                    actualHeartCount++;
                }
            }

            int expectedHeartCount = 13;

            Assert.AreEqual(expectedHeartCount, actualHeartCount);
        }

        [TestMethod]
        public void InitializeDeckCreates13Spades()
        {
            int actualSpadeCount = 0;

            foreach (Card card in deck.Cards)
            {
                if (card.Suit == "Spades")
                {
                    actualSpadeCount++;
                }
            }

            int expectedSpadeCount = 13;

            Assert.AreEqual(expectedSpadeCount, actualSpadeCount);
        }

        [DataTestMethod]
        [DataRow("Two", 4)]
        [DataRow("Three", 4)]
        [DataRow("Four", 4)]
        [DataRow("Five", 4)]
        [DataRow("Six", 4)]
        [DataRow("Seven", 4)]
        [DataRow("Eight", 4)]
        [DataRow("Nine", 4)]
        [DataRow("Ten", 4)]
        [DataRow("Jack", 4)]
        [DataRow("Queen", 4)]
        [DataRow("King", 4)]
        [DataRow("Ace", 4)]
        public void InitializeDeckCreates4OfEachRank(string rank, int expectedRankCount)
        {
            int actualRankCount = 0;

            foreach (Card card in deck.Cards)
            {
                if (card.Rank == rank)
                {
                    actualRankCount++;
                }
            }

            Assert.AreEqual(expectedRankCount, actualRankCount);
        }

        [TestMethod]
        public void DealCardReducesCardCountByOne()
        {
            int countBefore = deck.Cards.Count;
            deck.DealCard();
            int countAfter = deck.Cards.Count;
            int actualDifference = countBefore - countAfter;
            int expectedDifference = 1;

            Assert.AreEqual(actualDifference, expectedDifference);
        }
    }
}

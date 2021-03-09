using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Classes;

namespace BlackjackTests
{
    [TestClass]
    public class GameTests : ParentTestClass
    {
        [TestMethod]
        public void TestStartingHandsContain2Cards()
        {
            Game.DealStartingHands(deck, dealer, player);

            int expectedHandCount = 2;
            int actualDealerHandCount = dealer.Hand.Count;
            int actualPlayerHandCount = player.Hand.Count;

            Assert.AreEqual(expectedHandCount, actualDealerHandCount);
            Assert.AreEqual(expectedHandCount, actualPlayerHandCount);
        }

        [TestMethod]
        public void PlayerBustTestOver21()
        {
            player.Hand.Add(ten);
            player.Hand.Add(jack);
            player.Hand.Add(two);

            bool actualPlayerBust = Game.PlayerBust(player);

            Assert.IsTrue(actualPlayerBust);
        }

        [TestMethod]
        public void PlayerBustTestAt21()
        {
            player.Hand.Add(ten);
            player.Hand.Add(ace);

            bool actualPlayerBust = Game.PlayerBust(player);

            Assert.IsFalse(actualPlayerBust);
        }

        [TestMethod]
        public void DetermineWinerTestDraw()
        {
            player.Hand.Add(three);
            player.Hand.Add(seven);
            dealer.Hand.Add(queen);

            string expectedReturnString = "The game ends in a draw!";
            string actualReturnString = Game.DetermineWinner(player, dealer);

            Assert.AreEqual(expectedReturnString, actualReturnString);
        }

        [TestMethod]
        public void DetermineWinerTestPlayerBust()
        {
            player.Hand.Add(king);
            player.Hand.Add(seven);
            player.Hand.Add(five);
            dealer.Hand.Add(queen);

            string expectedReturnString = "testDealer wins!";
            string actualReturnString = Game.DetermineWinner(player, dealer);

            Assert.AreEqual(expectedReturnString, actualReturnString);
        }

        [TestMethod]
        public void DetermineWinerTestDealerBust()
        {
            dealer.Hand.Add(king);
            dealer.Hand.Add(seven);
            dealer.Hand.Add(five);
            player.Hand.Add(queen);

            string expectedReturnString = "testPlayer wins!";
            string actualReturnString = Game.DetermineWinner(player, dealer);

            Assert.AreEqual(expectedReturnString, actualReturnString);
        }

        [TestMethod]
        public void DetermineWinerTestNoBust()
        {
            player.Hand.Add(king);
            player.Hand.Add(seven);
            dealer.Hand.Add(five);
            dealer.Hand.Add(queen);

            string expectedReturnString = "testPlayer wins!";
            string actualReturnString = Game.DetermineWinner(player, dealer);

            Assert.AreEqual(expectedReturnString, actualReturnString);
        }
    }
}

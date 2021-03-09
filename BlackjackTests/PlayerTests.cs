using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackTests
{
    [TestClass]
    public class PlayerTests : ParentTestClass
    {
        [TestMethod]
        public void HandTotalTest21()
        {
            player.Hand.Add(ace);
            player.Hand.Add(king);

            int expectedHandTotal = 21;
            int actualHandTotal = player.HandTotal;

            Assert.AreEqual(expectedHandTotal, actualHandTotal);
        }

        [TestMethod]
        public void HandTotalTestAceUsesValue1()
        {
            player.Hand.Add(ace);
            player.Hand.Add(king);
            player.Hand.Add(five);

            int expectedHandTotal = 16;
            int actualHandTotal = player.HandTotal;

            Assert.AreEqual(expectedHandTotal, actualHandTotal);
        }

        [TestMethod]
        public void HitIncreasesHandByOne()
        {
            int beforeHandCount = player.Hand.Count;
            player.Hit(deck);
            int afterHandCount = player.Hand.Count;

            int expectedDifference = 1;
            int actualDifference = afterHandCount - beforeHandCount;

            Assert.AreEqual(expectedDifference, actualDifference);
        }
    }
}

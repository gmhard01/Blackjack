using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackTests
{
    [TestClass]
    public class DealerTests : ParentTestClass
    {
        [TestMethod]
        public void GetShowingTotalTest()
        {
            dealer.Hand.Add(ace);
            dealer.Hand.Add(six);

            int expectedShowingTotal = 6;
            int actualShowingTotal = dealer.ShowingTotal;

            Assert.AreEqual(expectedShowingTotal, actualShowingTotal);
        }

        [TestMethod]
        public void HandIsSoftTestWithAce()
        {
            dealer.Hand.Add(ace);

            bool actualSoft = dealer.HandIsSoft();

            Assert.IsTrue(actualSoft);
        }

        [TestMethod]
        public void HandIsSoftTestNoAce()
        {
            dealer.Hand.Add(two);

            bool actualSoft = dealer.HandIsSoft();

            Assert.IsFalse(actualSoft);
        }

        [TestMethod]
        public void HandIs11OrLessTestTrue()
        {
            dealer.Hand.Add(five);
            dealer.Hand.Add(six);

            bool actual11OrLess = dealer.HandIs11OrLess();

            Assert.IsTrue(actual11OrLess);
        }

        [TestMethod]
        public void HandIs11OrLessTestFalse()
        {
            dealer.Hand.Add(six);
            dealer.Hand.Add(seven);

            bool actual11OrLess = dealer.HandIs11OrLess();

            Assert.IsFalse(actual11OrLess);
        }
        
        [TestMethod]
        public void HandIsSoft15OrLessTestTrue()
        {
            dealer.Hand.Add(ace);
            dealer.Hand.Add(four);

            bool actualSoft15OrLess = dealer.HandIsSoft15OrLess();

            Assert.IsTrue(actualSoft15OrLess);
        }

        [TestMethod]
        public void HandIsSoft15OrLessTestFalse()
        {
            dealer.Hand.Add(ace);
            dealer.Hand.Add(five);

            bool actualSoft15OrLess = dealer.HandIsSoft15OrLess();

            Assert.IsFalse(actualSoft15OrLess);
        }

        [TestMethod]
        public void HandIsSoft16OrMoreTestTrue()
        {
            dealer.Hand.Add(ace);
            dealer.Hand.Add(five);

            bool actualSoft16OrMore = dealer.HandIsSoft16OrMore();

            Assert.IsTrue(actualSoft16OrMore);
        }

        [TestMethod]
        public void HandIsSoft16OrMoreTestFalse()
        {
            dealer.Hand.Add(ace);
            dealer.Hand.Add(three);

            bool actualSoft16OrMore = dealer.HandIsSoft16OrMore();

            Assert.IsFalse(actualSoft16OrMore);
        }

        [TestMethod]
        public void HandIsHard12OrMoreTestTrue()
        {
            dealer.Hand.Add(six);
            dealer.Hand.Add(eight);

            bool actualHard12OrMore = dealer.HandIsHard12OrMore();

            Assert.IsTrue(actualHard12OrMore);
        }

        [TestMethod]
        public void HandIsHard17OrMoreTestTrue()
        {
            dealer.Hand.Add(ten);
            dealer.Hand.Add(seven);

            bool actual17OrMore = dealer.HandIsHard17OrMore();

            Assert.IsTrue(actual17OrMore);
        }

        [TestMethod]
        public void HandIs17OrMoreTestFalse()
        {
            dealer.Hand.Add(jack);
            dealer.Hand.Add(six);

            bool actual17OrMore = dealer.HandIsHard17OrMore();

            Assert.IsFalse(actual17OrMore);
        }

        [TestMethod]
        public void HandIs17OrMoreTestSoft17False()
        {
            dealer.Hand.Add(ace);
            dealer.Hand.Add(six);

            bool actual17OrMore = dealer.HandIsHard17OrMore();

            Assert.IsFalse(actual17OrMore);
        }
    }
}

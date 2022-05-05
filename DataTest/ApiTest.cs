using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {
        DataApi testBall;
        [TestMethod]
        public void BallTest()
        {
            testBall = DataApi.CreateBall(6, 9);
            Assert.AreEqual(testBall.getXPosition(), 6);
            Assert.AreEqual(testBall.getYPosition(), 9);
        }

        [TestMethod]
        public void TestBallSetValues()
        {
            testBall = DataApi.CreateBall(6, 9);
            Assert.AreEqual(testBall.getXPosition(), 6);
            Assert.AreEqual(testBall.getYPosition(), 9);
            testBall.setXPosition(10);
            testBall.setYPosition(1);
            Assert.AreEqual(testBall.getXPosition(), 10);
            Assert.AreEqual(testBall.getYPosition(), 1);
        }
    }
}
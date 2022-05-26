using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestData
{


    [TestClass]
    public class BallTest
    {
        private DataAbstractApi Api;

        [TestMethod]
        public void createIBallTest()
        {
            Api = DataAbstractApi.createApi(800, 600);
            Api.createBallsList(1);
            Assert.AreEqual(1, Api.getBall(0).ballId);

            Assert.IsTrue(Api.getBall(0).ballX >= Api.getBall(0).ballSize);
            Assert.IsTrue(Api.getBall(0).ballX <= (Api.width - Api.getBall(0).ballSize));
            Assert.IsTrue(Api.getBall(0).ballY >= Api.getBall(0).ballSize);
            Assert.IsTrue(Api.getBall(0).ballY <= (Api.height - Api.getBall(0).ballSize));

            Assert.IsTrue(Api.getBall(0).ballSize >= 20 && Api.getBall(0).ballSize <= 40);
            Assert.IsTrue(Api.getBall(0).ballWeight == Api.getBall(0).ballSize);
            Assert.IsTrue(Api.getBall(0).ballNewX >= -10 && Api.getBall(0).ballNewX <= 11);
            Assert.IsTrue(Api.getBall(0).ballNewY >= -10 && Api.getBall(0).ballNewY <= 11);
        }

        [TestMethod]
        public void moveTest()
        {
            Api = DataAbstractApi.createApi(800, 600);
            Api.createBallsList(1);
            double x = Api.getBall(0).ballX;
            double y = Api.getBall(0).ballY;
            Api.getBall(0).ballNewX = 5;
            Api.getBall(0).ballNewY = 5;
            Api.getBall(0).ballMove();
            Assert.AreNotEqual(x, Api.getBall(0).ballX);
            Assert.AreNotEqual(y, Api.getBall(0).ballY);
        }

        [TestMethod]
        public void setTests()
        {
            Api = DataAbstractApi.createApi(800, 600);
            Api.createBallsList(1);
            Api.getBall(0).ballX = 10;
            Api.getBall(0).ballY = 17;
            Api.getBall(0).ballNewX = 4;
            Api.getBall(0).ballNewY = -3;
            Assert.AreEqual(10, Api.getBall(0).ballX);
            Assert.AreEqual(17, Api.getBall(0).ballY);
            Assert.AreEqual(4, Api.getBall(0).ballNewX);
            Assert.AreEqual(-3, Api.getBall(0).ballNewY);
        }
    }
}
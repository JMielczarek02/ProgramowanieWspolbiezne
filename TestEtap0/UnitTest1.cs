using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEtap0
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddMethod()
        {
            Etap0.Class1 c1 = new Etap0.Class1();
            int value = 5;
            int value2 = 7;
            int result = c1.add(value, value2);
            Assert.AreEqual(value + value2, result);
        }
    }
}
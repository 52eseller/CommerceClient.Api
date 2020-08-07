using Moq;
using NUnit.Framework;

namespace UnitTest
{
    public class BasketUnitTest : BaseUnitTest
    {
        Mock ClientState;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
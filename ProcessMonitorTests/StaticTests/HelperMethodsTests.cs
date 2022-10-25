using ProcessMonitor.Static;

namespace ProcessMonitorTests.StaticTests
{
    public class HelperMethodsTests
    {
        [Test]
        public void TryParse()
        {
            Assert.IsFalse(HelperMethods.TryToParse("kk", out _));
            Assert.IsTrue(HelperMethods.TryToParse("5", out int result));
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void MultipleSameParams()
        {
            Assert.IsFalse(HelperMethods.MultipleSameParams("name kkkk name", "name"));
            Assert.IsTrue(HelperMethods.MultipleSameParams("name kkkk name", "kkkk"));
            Assert.IsFalse(HelperMethods.MultipleSameParams("name kkkk name", "llll"));
        }
    }
}

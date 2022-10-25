using ProcessMonitor.StaticClasses;

namespace ProcessMonitorTests.SingletonsTests
{
    public class LoggerTests
    {
        [Test]
        public void GetInstance_Test()
        {
            Assert.IsNotNull(Logger.GetInstance());
        }

        [Test]
        public void ConsoleLog_Test()
        {
            Logger.GetInstance().AddToQueue("Test");
            Assert.IsTrue(Logger.GetInstance().CountConsoleQueue() == 1);
        }

        [Test]
        public void FileLog_Test()
        {
            Logger.GetInstance().AddToFileQueue("Test");
            Assert.IsTrue(Logger.GetInstance().CountFileQueue() == 1);
        }

        [Test]
        public void GetValueFromConsoleQueue_Test()
        {
            Logger.GetInstance().AddToQueue("Test");
            Assert.That(Logger.GetInstance().GetValueFromQueue(), Is.EqualTo("Test"));
        }

        [Test]
        public void GetValueFromFileQueue_Test()
        {
            Logger.GetInstance().AddToFileQueue("Test");
            Assert.That(Logger.GetInstance().GetValueFromFileQueue(), Is.EqualTo("Test"));
        }
    }
}

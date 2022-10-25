using ProcessMonitor.Classes;
using ProcessMonitor.Singletons;

namespace ProcessMonitorTests.ThreadsTests
{
    public class LoggerThreadTests
    {
        [Test]
        public void Start_NotStarted_Test()
        {
            Assert.That(LoggerThread.IsStopped(), Is.EqualTo(true));
        }

        [Test]
        public void Start_OtherThreadsNotStarted_Test()
        {
            LoggerThread.Start();

            CommonUnitTests();
        }

        [Test]
        public void Start_ProcessStoreStarted_Test()
        {
            LoggerThread.Start();
            ProcessStore.GetInstance().Add("Test", 1, 1);

            CommonUnitTests();
        }

        [Test]
        public void Start_AllStarted_Test()
        {
            LoggerThread.Start();
            MonitorThread.Start();
            ProcessStore.GetInstance().Add("Test", 1, 1);

            CommonUnitTests();
        }

        private static void CommonUnitTests()
        {
            Assert.That(LoggerThread.IsStopped(), Is.EqualTo(false));

            LoggerThread.Stop();
            Assert.That(LoggerThread.IsStopped(), Is.EqualTo(true));
        }
    }
}
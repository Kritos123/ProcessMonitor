using ProcessMonitor.Classes;
using ProcessMonitor.Singletons;

namespace ProcessMonitorTests.ThreadsTests
{
    public class MonitorThreadTests
    {
        [Test]
        public void Start_NotStarted_Test()
        {
            Assert.That(MonitorThread.IsStopped(), Is.EqualTo(true));
        }

        [Test]
        public void Start_OtherThreadsNotStarted_Test()
        {
            MonitorThread.Start();

            CommonUnitTests();
        }

        [Test]
        public void Start_ProcessStoreStarted_Test()
        {
            MonitorThread.Start();
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
            Assert.That(MonitorThread.IsStopped(), Is.EqualTo(false));

            MonitorThread.Stop();
            Assert.That(MonitorThread.IsStopped(), Is.EqualTo(true));
        }
    }
}
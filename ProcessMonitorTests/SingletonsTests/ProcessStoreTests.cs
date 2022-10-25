using ProcessMonitor.Singletons;

namespace ProcessMonitorTests.SingletonsTests
{
    public class ProcessStoreTests
    {
        [Test]
        public void GetInstance_Test()
        {
            Assert.IsNotNull(ProcessStore.GetInstance());
        }

        [Test]
        public void GetAddProcesses_Test()
        {
            ProcessStore.GetInstance().Add("Test", 1, 1);
            Assert.IsTrue(ProcessStore.GetInstance().GetProcesses().Count() == 1);
        }
    }
}

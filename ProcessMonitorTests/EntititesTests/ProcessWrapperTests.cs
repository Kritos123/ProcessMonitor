using ProcessMonitor.Entities;

namespace ProcessMonitorTests.EntititesTests
{
    public class ProcessWrapperTests
    {
        [Test]
        public void GetProcessInfo_Test()
        {
            ProcessWrapper instance = new ProcessWrapper("Test", 1, 2);
            var results = instance.GetProcessInfo();

            Assert.That(results.Name, Is.EqualTo("Test"));
            Assert.That(results.MaxLifetime, Is.EqualTo(1));
            Assert.That(results.Frequency, Is.EqualTo(2));
        }

        [Test]
        public void Task_NotExists_Test()
        {
            ProcessWrapper instance = new ProcessWrapper("Test", 1, 2);
            Assert.IsFalse(instance.GetExistsTask());
        }

        [Test]
        public void Task_Exists_Test()
        {
            ProcessWrapper instance = new ProcessWrapper("Test", 1, 2);
            instance.SetExistsTask(true);
            Assert.IsTrue(instance.GetExistsTask());
        }
    }
}

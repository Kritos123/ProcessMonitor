namespace ProcessMonitor.Entities
{
    public class ProcessWrapper
    {
        private readonly string Name;
        private readonly int MaxLifetime;
        private readonly int Frequency;
        private bool ExistsTask;

        public ProcessWrapper(string name, int maxLifetime, int frequency)
        {
            Name = name;
            MaxLifetime = maxLifetime;
            Frequency = frequency;
            ExistsTask = false;
        }

        public void SetExistsTask(bool existsTask)
        {
            ExistsTask = existsTask;
        }

        public bool GetExistsTask()
        {
            return ExistsTask;
        }

        public (string Name, int MaxLifetime, int Frequency) GetProcessInfo()
        {
            return (Name, MaxLifetime, Frequency);
        }
    }
}

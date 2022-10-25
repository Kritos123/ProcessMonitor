using ProcessMonitor.Entities;
using ProcessMonitor.Static;
using ProcessMonitor.StaticClasses;

namespace ProcessMonitor.Singletons
{
    public sealed class ProcessStore
    {
        private static readonly ProcessStore _instance = new();

        private readonly Dictionary<string, ProcessWrapper> _monitoredProceses;

        private ProcessStore()
        {
            _monitoredProceses = new();
        }

        public static ProcessStore GetInstance()
        {
            return _instance;
        }

        public void Add(string process, int maxLifeTime, int frequency)
        {
            if (_monitoredProceses.ContainsKey(process))
            {
                Logger.GetInstance().AddToQueue(string.Format(GlobalVariables.EXISTS_PROCESS, process));
            }
            else
            {
                _monitoredProceses.Add(process, new ProcessWrapper(process, maxLifeTime, frequency));
                Logger.GetInstance().AddToQueue(string.Format(GlobalVariables.ADD_PROCESS, process));
            }
        }

        public ProcessWrapper[] GetProcesses()
        {
            return _monitoredProceses.Values.ToArray();
        }
    }
}

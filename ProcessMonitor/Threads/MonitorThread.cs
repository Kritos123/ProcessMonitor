using ProcessMonitor.Entities;
using ProcessMonitor.Singletons;
using ProcessMonitor.Static;
using ProcessMonitor.StaticClasses;
using System.Diagnostics;

namespace ProcessMonitor.Classes
{
    public static class MonitorThread
    {
        private static bool _stop;
        public static void Start()
        {
            _stop = false;
            new Thread(RunThread).Start();
        }

        internal static void RunThread()
        {
            while (true)
            {
                if (_stop)
                {
                    break;
                }

                foreach (var processEntry in ProcessStore.GetInstance().GetProcesses())
                {
                    if (!processEntry.GetExistsTask())
                    {
                        Task.Factory.StartNew(() => Run(processEntry));
                        processEntry.SetExistsTask(true);
                    }
                }
                Thread.Sleep(GlobalVariables.MAIN_MONITOR_THREAD_WAIT);
            }
        }

        internal static void Run(ProcessWrapper processWrapper)
        {
            while (true)
            {
                if (_stop)
                {
                    break;
                }

                var (Name, MaxLifetime, Frequency) = processWrapper.GetProcessInfo();

                foreach (var process in Process.GetProcessesByName(Name))
                {
                    if ((process.StartTime + TimeSpan.FromMinutes(MaxLifetime)) < DateTime.Now)
                    {
                        process.Kill();
                        Logger.GetInstance().AddToFileQueue(string.Format(GlobalVariables.KILLING_PROCESS, DateTime.Now, Name));
                    }
                }

                Logger.GetInstance().AddToFileQueue(string.Format(GlobalVariables.LAST_CHECKING, DateTime.Now, Name));
                Thread.Sleep(Frequency * GlobalVariables.MS_MULTIPLIED_BY);
            }
        }

        public static bool IsStopped()
        {
            return _stop;
        }

        public static void Stop()
        {
            _stop = true;
        }
    }
}

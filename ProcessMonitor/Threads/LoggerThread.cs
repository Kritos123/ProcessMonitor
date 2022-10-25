using ProcessMonitor.Static;
using ProcessMonitor.StaticClasses;

namespace ProcessMonitor.Classes
{
    public static class LoggerThread
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
                    if (Logger.GetInstance().CountConsoleQueue() == 0 && Logger.GetInstance().CountFileQueue() == 0)
                    {                       
                        break;
                    }
                }

                for (int i = 0; i < Logger.GetInstance().CountConsoleQueue(); i++)
                {
                    Console.Write(Logger.GetInstance().GetValueFromQueue());
                }

                for (int i = 0; i < Logger.GetInstance().CountFileQueue(); i++)
                {
                    _ = WriteToFielAsync(Logger.GetInstance().GetValueFromFileQueue());
                }

                Thread.Sleep(GlobalVariables.LOGGER_THREAD_SLEEP);
            }
        }

        internal static async Task WriteToFielAsync(string value)
        {
            using StreamWriter file = new(GlobalVariables.LOG_PATH, append: true);
            await file.WriteLineAsync(value);
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

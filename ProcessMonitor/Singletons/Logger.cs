namespace ProcessMonitor.StaticClasses
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new();

        private readonly Queue<string> _consoleOutput;
        private readonly Queue<string> _logs;

        private Logger()
        {
            _consoleOutput = new Queue<string>();
            _logs = new Queue<string>();
        }

        public static Logger GetInstance()
        {
            return _instance;
        }

        public void AddToQueue(string value)
        {
            _consoleOutput.Enqueue(value);
        }

        public void AddToFileQueue(string value)
        {
            _logs.Enqueue(value);
        }

        public string GetValueFromQueue()
        {
            if (_consoleOutput.Count > 0)
            {
                return _consoleOutput.Dequeue();
            }

            return "";
        }
        public string GetValueFromFileQueue()
        {
            if (_logs.Count > 0)
            {
                return _logs.Dequeue();
            }

            return "";
        }

        public int CountConsoleQueue()
        {
            return _consoleOutput.Count;
        }

        public int CountFileQueue()
        {
            return _logs.Count;
        }
    }
}

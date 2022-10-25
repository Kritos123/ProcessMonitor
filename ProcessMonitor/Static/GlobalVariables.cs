namespace ProcessMonitor.Static
{
    public static class GlobalVariables
    {
        public const string MAIN_LINE = "ProcessMonitor>";
        public const string HELP_LINE = "To add process for monitoring write -add Name=string MaxLifespan=int Frequency=int\n";
        public const string COVERSION_SUCESSFULL = "Converted '{0}' to {1}\n";
        public const string COVERSION_NOT_SUCESSFULL = "Attempted conversion of '{0}' failed\n";
        public const string HELP_CMD = "-help";
        public const string ADD_CMD = "-add";
        public const string QUIT_CMD = "-q";
        public const string NAME_PRM = "name";
        public const string MAX_LIFE_PRM = "maxlifespan";
        public const string FREQUENCY_PRM = "frequency";
        public const string MULTIPLE_PARAMS = "Multiple {0} params\n";
        public const string WRONG_MAX_LIFE_PARAMS = "Parametr maxlifespan have wrong value\n";
        public const string WRONG_FREQUENCY_PARAMS = "Parametr frequency have wrong value\n";
        public const string UNEXPECTED_PARAM = "Unexpected parametr\n";
        public const string PROCESS_ADDED = "Process added\n";
        public const string SHUTTING_DOWN = "Shutting down\n";
        public const string WRONG_SWICH = "Wrong switch\n";
        public const string PARAMETER_VALUES_NOT_ALLOWED = "Wrong params probably proces name not set or int values 0\n";
        public const string MISSING_PARM = "Missing Param\n";
        public const string KILLING_PROCESS = "[{0}]:Killing proces with name {1}";
        public const string LAST_CHECKING = "[{0}]:Last check {1}";
        public const string ADD_PROCESS = "Process with  name {0} added\n";
        public const string EXISTS_PROCESS = "Process with  name {0} already exists for monitoring";
        public const string LOG_PATH = "../Log.txt";

        public const char PARAM_VALUE_SPLITER = '=';
        public const char SWICH_OR_PARAMS_SPLITTER = ' ';

        public const int MAIN_MONITOR_THREAD_WAIT = 100;
        public const int MS_MULTIPLIED_BY = 60000;
        public const int LOGGER_THREAD_SLEEP = 0;
    }
}

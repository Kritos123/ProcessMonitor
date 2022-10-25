using ProcessMonitor.Classes;
using ProcessMonitor.Singletons;
using ProcessMonitor.StaticClasses;

namespace ProcessMonitor.Static
{
    public static class MainMethods
    {
        public static void Initialize()
        {
            LoggerThread.Start();
            MonitorThread.Start();
        }

        public static void Menu()
        {
            while (true)
            {
                Logger.GetInstance().AddToQueue(GlobalVariables.MAIN_LINE);
                string? cmd = Console.ReadLine()?.ToLower();
                if (cmd == null)
                {
                    continue;
                }
                var genericArguments = cmd.Split(GlobalVariables.SWICH_OR_PARAMS_SPLITTER, 2);
                if (genericArguments == null)
                {
                    continue;
                }

                if (genericArguments[0].Equals(GlobalVariables.HELP_CMD))
                {
                    Logger.GetInstance().AddToQueue(GlobalVariables.HELP_LINE);
                    continue;
                }
                else if (genericArguments[0].Equals(GlobalVariables.ADD_CMD))
                {
                    if (!HelperMethods.MultipleSameParams(cmd, GlobalVariables.NAME_PRM))
                    {
                        continue;
                    }
                    if (!HelperMethods.MultipleSameParams(cmd, GlobalVariables.MAX_LIFE_PRM))
                    {
                        continue;
                    }
                    if (!HelperMethods.MultipleSameParams(cmd, GlobalVariables.FREQUENCY_PRM))
                    {
                        continue;
                    }

                    var arguments = genericArguments.ToArray()[1].Split(GlobalVariables.SWICH_OR_PARAMS_SPLITTER);
                    string name = "";
                    int maxLifeSpan = 0;
                    int maxFrequency = 0;

                    foreach (var arg in arguments)
                    {
                        if (arg.Contains(GlobalVariables.NAME_PRM))
                        {
                            name = arg[(arg.IndexOf(GlobalVariables.PARAM_VALUE_SPLITER) + 1)..];
                        }
                        else if (arg.Contains(GlobalVariables.MAX_LIFE_PRM))
                        {
                            if (HelperMethods.TryToParse(arg[(arg.IndexOf(GlobalVariables.PARAM_VALUE_SPLITER) + 1)..], out maxLifeSpan)) { }
                            else
                            {
                                Logger.GetInstance().AddToQueue(GlobalVariables.WRONG_MAX_LIFE_PARAMS);
                                break;
                            }
                        }
                        else if (arg.Contains(GlobalVariables.FREQUENCY_PRM))
                        {
                            if (HelperMethods.TryToParse(arg[(arg.IndexOf(GlobalVariables.PARAM_VALUE_SPLITER) + 1)..], out maxFrequency)) { }
                            else
                            {
                                Logger.GetInstance().AddToQueue(GlobalVariables.WRONG_FREQUENCY_PARAMS);
                                break;
                            }
                        }
                        else
                        {
                            Logger.GetInstance().AddToQueue(GlobalVariables.UNEXPECTED_PARAM);
                            break;
                        }
                    }

                    if (name != null && maxLifeSpan != 0 && maxFrequency != 0)
                    {
                        ProcessStore.GetInstance().Add(name, maxLifeSpan, maxFrequency);
                        Logger.GetInstance().AddToQueue(GlobalVariables.PROCESS_ADDED);
                    }
                    else
                    {
                        Logger.GetInstance().AddToQueue(GlobalVariables.PARAMETER_VALUES_NOT_ALLOWED);
                    }

                }
                else if (genericArguments[0].Equals(GlobalVariables.QUIT_CMD))
                {
                    Logger.GetInstance().AddToQueue(GlobalVariables.SHUTTING_DOWN);
                    break;
                }
                else
                {
                    Logger.GetInstance().AddToQueue(GlobalVariables.WRONG_SWICH);
                    continue;
                }
            }
        }

        public static void Stop()
        {
            LoggerThread.Stop();
            MonitorThread.Stop();
        }
    }
}

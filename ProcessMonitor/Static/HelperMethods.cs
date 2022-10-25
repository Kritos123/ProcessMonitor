using ProcessMonitor.StaticClasses;

namespace ProcessMonitor.Static
{
    public static class HelperMethods
    {
        public static bool TryToParse(string value, out int number)
        {
            bool result = Int32.TryParse(value, out number);
            if (result)
            {
                Logger.GetInstance().AddToQueue(String.Format(GlobalVariables.COVERSION_SUCESSFULL, value, number));
            }
            else
            {
                value ??= "";
                Logger.GetInstance().AddToQueue(String.Format(GlobalVariables.COVERSION_NOT_SUCESSFULL, value));
            }

            return result;
        }

        public static bool MultipleSameParams(string fullString, string param)
        {
            if (fullString.Contains(param))
            {
                if (fullString.LastIndexOf(param) == fullString.IndexOf(param))
                {
                    return true;
                }
                else
                {
                    Logger.GetInstance().AddToQueue(string.Format(GlobalVariables.MULTIPLE_PARAMS, param));
                    return false;
                }
            }
            else
            {
                Logger.GetInstance().AddToQueue(GlobalVariables.MISSING_PARM);
                return false;
            }
        }
    }
}

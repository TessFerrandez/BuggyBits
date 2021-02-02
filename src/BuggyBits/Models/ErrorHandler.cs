using System;

namespace BuggyBits.Models
{
    public class ErrorHandler
    {
        public static void LogException(Exception ex)
        {
            Utility.WriteToLog(ex.Message, "c:\\log.txt");
        }
    }
}

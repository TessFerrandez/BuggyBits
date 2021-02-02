using System;
using System.IO;

namespace BuggyBits.Models
{
    public static class Utility
    {
        public static void WriteToLog(string message, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    //Log the event with date and time.
                    sw.WriteLine("--------------------------");
                    sw.WriteLine(DateTime.Now.ToLongTimeString());
                    sw.WriteLine("-------------------");
                    sw.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
            }
        }
    }
}

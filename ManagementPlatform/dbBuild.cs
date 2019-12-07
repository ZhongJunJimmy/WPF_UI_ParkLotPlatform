using System;
using System.IO;

namespace ManagementPlatform
{
    class dbBuild
    {
        public static bool createDatabase()
        {
            try
            {
                int intResult = 0;
                using (StreamReader sr = new StreamReader("./sqlCommand/dbCreate.sql"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    intResult = dbProcess.ExecuteSQL(line);
                }
                if (intResult == 0) return false;
                else return true;
            }
            catch
            {
                return false;
            }
        }


    }
}

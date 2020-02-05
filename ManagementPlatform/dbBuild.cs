using System;
using System.Data;
using System.IO;

namespace ManagementPlatform
{
    class dbBuild
    {
        public static bool createDatabase()
        {
            try
            {
                DataTable Result; ;
                using (StreamReader sr = new StreamReader("./sqlCommand/dbCreate.sql"))
                {
                    String line = sr.ReadToEnd();
                    Result = dbProcess.GetDataTable(line);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
 
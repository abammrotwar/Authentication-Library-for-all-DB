using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authentication_Library_for_all_DB
{
    public class DatabaseCredentials
    {
        /// <summary>
        /// This function is used to connect with the Database
        /// </summary>
        /// <param name="DBName">Name of the database like MySQL, SQL Server, Oracle and any other</param>
        /// <param name="ConnectionString">Connection String for connecting database</param>
        /// <param name="ReturnValue">1 for the entire row, 2 for only id. By default it will pass 2</param>
        /// <param name="DBValue">For SQL Server pass 1, For MySQL pass 2, For Oracle Pass 3, By default we assume that you are using SQL Server </param>
        public static Object DatabaseCredentials(string DBName, string ConnectionString,int ReturnValue = 2, int DBValue = 1)
        {
            object retunobject ="Dummy value";
            DBName = DBName.ToLower();
            switch (DBValue)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            return retunobject;
        }

        private object _MSSQLServerConnection()
        {
            return true;
        }
    }
}

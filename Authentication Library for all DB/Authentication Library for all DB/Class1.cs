﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;


namespace Authentication_Library_for_all_DB
{
    public class DatabaseCredentials
    {
        /// <summary>
        /// This function is used to connect with the Database
        /// </summary>
        /// <param name="DBName">Name of the database like MySQL, SQL Server, Oracle and any other</param>
        /// <param name="ConnectionString">Connection String for connecting database</param>
        /// <param name="query">query</param>
        /// <param name="ReturnValue">1 for the entire row, 2 for only id. By default it will pass 2</param>
        /// <param name="DBValue">For SQL Server pass 1, For MySQL pass 2, For Oracle Pass 3, By default we assume that you are using SQL Server </param>
        public static Object DatabaseCredentials(string DBName, string ConnectionString,string query, int ReturnValue = 2, int DBValue = 1)
        {
            Authentication_Library_for_all_DB.DatabaseCredentials ds = new Authentication_Library_for_all_DB.DatabaseCredentials();
            object retunobject = "Dummy value";
            DBName = DBName.ToLower();
            try
            {
                switch (DBValue)
                {
                    case 1:
                        retunobject = ds._MSSQLServerConnection(ConnectionString, ReturnValue, query);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
            
            return retunobject;
        }

        /// <summary>
        /// Get data from MS SQL Server
        /// </summary>
        /// <param name="ConnectionString">Connection String</param>
        /// <param name="ReturnValue">1 for the entire row, 2 for only id. By default it will pass 2</param>
        /// <param name="query">Query to run</param>
        /// <returns>Return type object according to ReturnValue</returns>
        private object _MSSQLServerConnection(string ConnectionString, int ReturnValue, string query)
        { 
            Object data = new object();
            if (ReturnValue == 1)
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(query,con);
               
                data = cmd.ExecuteScalar();
                return data;
            }
            else if (ReturnValue == 2)
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(query, con);

                return data;
            }
            return false;
        }
    }
}

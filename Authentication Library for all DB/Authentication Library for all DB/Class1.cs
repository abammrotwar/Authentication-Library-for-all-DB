using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using MySql.Data.MySqlClient;


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
        public static Object DatabaseCredentials(string DBName, string ConnectionString, string query, int ReturnValue = 2, int DBValue = 1)
        {
            Authentication_Library_for_all_DB.DatabaseCredentials ds = new Authentication_Library_for_all_DB.DatabaseCredentials();
            object retunobject = "Dummy value";
            DBName = DBName.ToLower();
            try
            {
                switch (DBValue)
                {
                    case 1:
                        retunobject = ds._MSSQLServerConnection(ConnectionString, query);
                        break;
                    case 2:
                        retunobject = ds._MySQLConnection(ConnectionString, query);
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
        /// <param name="query">Query to run</param>
        /// <returns>Return type object according to ReturnValue</returns>
        private object _MSSQLServerConnection(string ConnectionString, string query)
        {
            Object data = new object();

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                data = cmd.ExecuteScalar();
                con.Close();
                return data;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }


        }

        /// <summary>
        /// Get data from MySQL
        /// </summary>
        /// <param name="ConnectionString">Connection String</param>
        /// <param name="query">Query to run</param>
        /// <returns>Return type object according to ReturnValue</returns>
        private object _MySQLConnection(string ConnectionString, string query)
        {
            Object data = new object();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, con);
            try
            {
                con.Open();
                data = cmd.ExecuteScalar();
                con.Close();
                return data;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }
    }
}

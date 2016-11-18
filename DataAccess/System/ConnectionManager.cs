using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
//using System.Data.OracleClient;

namespace  DataAcess
{
   internal class ConnectionManager
    {
       const string DEFAULT_CONNECTION_KEY = "defaultConnection";
        /// <summary>
        /// Establish Connection to the database and Return an open connection.
        /// </summary>
        /// <returns>Open connection to the database</returns>
        internal IDbConnection GetConnection()
        {
            IDbConnection connection = null;
            string connectionString = Configuration.ConnectionString;
            switch (Configuration.DBProvider.Trim().ToUpper())
            {
                case Comon.SQL_SERVER_DB_PROVIDER:
                    connection = new SqlConnection(connectionString);
                    break;
                case Comon.MY_SQL_DB_PROVIDER:
                  //  connection = new MySqlConnection(connectionString);
                    break;
                case Comon.ORACLE_DB_PROVIDER:
                    //connection = new OracleConnection(connectionString);
                    break;
                case Comon.EXCESS_DB_PROVIDER:
                    connection = new OleDbConnection(connectionString);
                    break;
                case Comon.ODBC_DB_PROVIDER:
                    connection = new OdbcConnection(connectionString);
                    break;
                case Comon.OLE_DB_PROVIDER:
                    connection = new OleDbConnection(connectionString);
                    break;
            }

            try
            {
                connection.Open();
            }
            catch (Exception err)
            {
                throw err;
            }

            return connection;
        }

    }
}

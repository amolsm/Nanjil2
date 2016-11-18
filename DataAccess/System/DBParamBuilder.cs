using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;

namespace DataAcess
{
    internal class DBParamBuilder
    {
        internal IDataParameter GetParameter(DBParameter parameter)
        {
            IDbDataParameter dbParam = GetParameter();
            dbParam.ParameterName = parameter.Name;
            dbParam.Value = parameter.Value;
            dbParam.Direction = parameter.ParamDirection;
            dbParam.DbType = parameter.Type;

            return dbParam;
        }

        internal List<IDataParameter> GetParameterCollection(DBParameterCollection parameterCollection)
        {
            List<IDataParameter> dbParamCollection = new List<IDataParameter>();
            IDataParameter dbParam = null;
            foreach (DBParameter param in parameterCollection.Parameters)
            {
                dbParam = GetParameter(param);
                dbParamCollection.Add(dbParam);
            }

            return dbParamCollection;
        }

        #region Private Methods
        private IDbDataParameter GetParameter()
        {
            IDbDataParameter dbParam = null;
            switch (Configuration.DBProvider.Trim().ToUpper())
            {
                case Comon.SQL_SERVER_DB_PROVIDER:
                    dbParam = new SqlParameter();
                    break;
                case Comon.MY_SQL_DB_PROVIDER:
                  //  dbParam = new MySqlParameter();
                    break;
                case Comon.ORACLE_DB_PROVIDER:
                   // dbParam = new OracleParameter();
                    break;
                case Comon.EXCESS_DB_PROVIDER:
                    dbParam = new OleDbParameter();
                    break;
                case Comon.OLE_DB_PROVIDER:
                    dbParam = new OleDbParameter();
                    break;
                case Comon.ODBC_DB_PROVIDER:
                    dbParam = new OdbcParameter();
                    break;
            }
            return dbParam;
        }



        #endregion
    }
}

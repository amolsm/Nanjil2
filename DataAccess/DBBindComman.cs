﻿using DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBBindComman
    {
        DBHelper _DBHelper = new DBHelper();
        public DataSet BindCommanDropDwon(string ValueID, string TextFiled, string TableName, string status)
        {
            DataSet DS=new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ValueID", ValueID));
            paramCollection.Add(new DBParameter("@TextFiled",TextFiled ));
            paramCollection.Add(new DBParameter("@TableName",TableName ));
            paramCollection.Add(new DBParameter("@status", status));
            return _DBHelper.ExecuteDataSet("GetDropDownValues", paramCollection, CommandType.StoredProcedure);
            
        }
        public DataSet BindBoothUserDropDwon(string ShiftDate, int boothid)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ShiftDate", ShiftDate));
            paramCollection.Add(new DBParameter("@boothid", boothid));

            return _DBHelper.ExecuteDataSet("GetBoothUserDropDwon", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet BindDispatchUserDropDwon(string ShiftDate, int brandid)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ShiftDate", ShiftDate));
            paramCollection.Add(new DBParameter("@Brandid", brandid));

            return _DBHelper.ExecuteDataSet("GetDispatchUserDropDwon", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet BindTypeDropDwon(string ValueID, string TextFiled, string TableName, string Table2, string Status1, string status)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ValueID", ValueID));
            paramCollection.Add(new DBParameter("@TextFiled", TextFiled));
            paramCollection.Add(new DBParameter("@TableName", TableName));
            paramCollection.Add(new DBParameter("@Table2", Table2));
            paramCollection.Add(new DBParameter("@Status1", Status1));
            paramCollection.Add(new DBParameter("@status", status));
            return _DBHelper.ExecuteDataSet("sp_TypeDropDwon ", paramCollection, CommandType.StoredProcedure);

        }
        

        public DataSet BindCommanDropDwonDistinct(string ValueID, string TextFiled, string TableName, string status)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection();
            //paramCollection.Add(new DBParameter("@ValueID", ValueID));
            paramCollection.Add(new DBParameter("@TextFiled", TextFiled));
            paramCollection.Add(new DBParameter("@TableName", TableName));
            paramCollection.Add(new DBParameter("@status", status));
            return _DBHelper.ExecuteDataSet("GetDropDownValuesDist", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet GetAllActiveAndDeactiveCount(string TableName, string status)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection(); 
            paramCollection.Add(new DBParameter("@TableName", TableName));
            paramCollection.Add(new DBParameter("@status", status));
            return _DBHelper.ExecuteDataSet("Sp_GetActiveAndDeactiveCount", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet GetAllActiveAndDeactiveCountForRoute(string TableName, string status)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TableName", TableName));
            paramCollection.Add(new DBParameter("@status", status));
            return _DBHelper.ExecuteDataSet("Sp_GetActiveAndDeactiveCountForRoute", paramCollection, CommandType.StoredProcedure);

        }

        public DataSet GetDispSalesman(string Dates, int routeid, int BrandId)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Dates", Dates));
            paramCollection.Add(new DBParameter("@routeid", routeid));
            paramCollection.Add(new DBParameter("@BrandId", BrandId));
            return _DBHelper.ExecuteDataSet("csh_getSalesmanbyroute", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet GetCategory(string Category, string TableName)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramcollection = new DataAcess.DBParameterCollection();
            paramcollection.Add(new DBParameter("@Category", Category));
            paramcollection.Add(new DBParameter("@TableName", TableName));
            return _DBHelper.ExecuteDataSet("GetCategory", paramcollection, CommandType.StoredProcedure);
        }
        public DataSet GetIncentiveTariff(string QCat, string TableName)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramcollection = new DataAcess.DBParameterCollection();
            paramcollection.Add(new DBParameter("@Category", QCat));
            //paramcollection.Add(new DBParameter("@ID", ID));
            paramcollection.Add(new DBParameter("@TableName", TableName));
            return _DBHelper.ExecuteDataSet("GetIncentiveTariff", paramcollection, CommandType.StoredProcedure);
        }

    }
}
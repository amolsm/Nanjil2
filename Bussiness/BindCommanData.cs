using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess;
namespace Bussiness
{
    public class BindCommanData
    {
        public static DataSet BindCommanDropDwon(string ValueID, string TextFiled, string TableName, string States)
        {
            DBBindComman dbbindComman = new DBBindComman();
            return dbbindComman.BindCommanDropDwon(  ValueID,   TextFiled,   TableName,   States);
        }
        public static DataSet BindTypeDropDwon(string ValueID, string TextFiled, string TableName, string Table2, string Status1, string States)
        {
            DBBindComman dbbindComman = new DBBindComman();
            return dbbindComman.BindTypeDropDwon(ValueID, TextFiled, TableName, Table2,  Status1, States);
        }
        public static DataSet BindBoothUserDropDwon(string ShiftDate, int boothid)
        {
            DBBindComman dbbindComman = new DBBindComman();
            return dbbindComman.BindBoothUserDropDwon(ShiftDate, boothid);
        }
        public static DataSet BindDispatchUserDropDwon(string ShiftDate, int brandid)
        {
            DBBindComman dbbindComman = new DBBindComman();
            return dbbindComman.BindDispatchUserDropDwon(ShiftDate, brandid);
        }
        public static DataSet BindCommanDropDwonDistinct(string ValueID, string TextFiled, string TableName, string States)
        {
            DBBindComman dbbindComman = new DBBindComman();
            return dbbindComman.BindCommanDropDwonDistinct(ValueID, TextFiled, TableName, States);
        }
        public static DataSet GetAllActiveAndDeactiveCount( string TableName, string States)
        {
            DBBindComman dbbindComman = new DBBindComman();
            return dbbindComman.GetAllActiveAndDeactiveCount(TableName, States);
        }
        

    }
}
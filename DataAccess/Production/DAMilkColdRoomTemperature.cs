using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAMilkColdRoomTemperature
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int colddata(MMilkColdRoomTemperature receive)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@MilkColdRoomTemperaturId", receive.MilkColdRoomTemperaturId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@MilkColdRoomTemperaturShiftId", receive.MilkColdRoomTemperaturShiftId));
                paramcollection.Add(new DBParameter("@MilkColdRoomTemperaturDate", receive.MilkColdRoomTemperaturDate));
                //paramcollection.Add(new DBParameter("@ColdRoomsForMilk", receive.ColdRoomsForMilk));
                paramcollection.Add(new DBParameter("@ColdRoom1", receive.ColdRoom1));
                paramcollection.Add(new DBParameter("@ColdRoom2", receive.ColdRoom2));
                paramcollection.Add(new DBParameter("@ColdRoom3", receive.ColdRoom3));
                paramcollection.Add(new DBParameter("@CheckedBy", receive.CheckedBy));
                paramcollection.Add(new DBParameter("@verifierBy", receive.verifierBy));
                paramcollection.Add(new DBParameter("@BreakAndDownServices", receive.BreakAndDownServices));
                paramcollection.Add(new DBParameter("@MilkColdRoomStatusId", receive.MilkColdRoomStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_MilkColdRoomTemperaturDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetMilkColdRoomTemperatureDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetMilkColdRoomTemperaturDetailsById", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetMilkColdRoomTemperatureDetails(RMRecieve R)
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            paramcollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetMilkColdRoomTemperaturDetails", paramcollection, CommandType.StoredProcedure);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;
namespace DataAccess.Production
{
    public class DACurdProcessing
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int CurdProcessData(MCurdProcessing recieve)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", recieve.RMRId));
                paramCollection.Add(new DBParameter("@CurdProcessDate", recieve.CurdProcessDate));
                paramCollection.Add(new DBParameter("@CurdProcessShiftId", recieve.CurdProcessShiftId));
                paramCollection.Add(new DBParameter("@HeatTemp", recieve.HeatingTemp));
                paramCollection.Add(new DBParameter("@HoldTime", recieve.HoldingTime));
                paramCollection.Add(new DBParameter("@Inoculation", recieve.InoculationMilkTemp));
                paramCollection.Add(new DBParameter("@CultureAdd", recieve.CultureAdd));
                paramCollection.Add(new DBParameter("@CultureLotNo", recieve.CultureLotNo));
                paramCollection.Add(new DBParameter("@CultureExpDate", recieve.CultureExpDate));
                paramCollection.Add(new DBParameter("@IncubationStart", recieve.IncubationStartTime));
                paramCollection.Add(new DBParameter("@IncubationEnd", recieve.IncubationEndTime));
                paramCollection.Add(new DBParameter("@CanCurd", recieve.MilkQtyforCanCurd));
                paramCollection.Add(new DBParameter("@CupPauchCurd", recieve.MilkQtyforCupPouchCurd));
                paramCollection.Add(new DBParameter("@PackingStartTime", recieve.PackingStartTime));
                paramCollection.Add(new DBParameter("@PackingEndTime", recieve.PackingEndTime));
                paramCollection.Add(new DBParameter("@BatchCode", recieve.BatchCode));
                paramCollection.Add(new DBParameter("@ColdRoomTemp", recieve.ColdRoomTemp));
                paramCollection.Add(new DBParameter("@ProcessBy", recieve.ProcessedBy));
                paramCollection.Add(new DBParameter("@LabTech", recieve.LabTechnician));
                paramCollection.Add(new DBParameter("@VerifiedBy", recieve.VerifiedBy));
                paramCollection.Add(new DBParameter("@ApprovedBy", recieve.ApprovedBy));
                paramCollection.Add(new DBParameter("@CurdProcessingStatusId", recieve.CurdProcessingStatusId));
                paramCollection.Add(new DBParameter("@flag", recieve.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_CurdProcessing", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {

                string MSG = EX.ToString();


            }
            return result;

        }

        public DataSet GetCurdProcessDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetCurdInformation", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetCurdProcessDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("[sp_Prod_GetCurdProcessDetailsbyID]", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }
    }

   
}
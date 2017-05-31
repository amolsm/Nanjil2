using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DATraceabilityMilkQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int tracqcdata(MTraceabilityMilkQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                //paramcollection.Add(new DBParameter("@TraceabilityMilkQCId", receive.TraceabilityMilkQCId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@CreamAndSkimDate", receive.CreamAndSkimDate));
                paramcollection.Add(new DBParameter("@PackingDate", receive.PackingDate));
                paramcollection.Add(new DBParameter("@TraceabilitMilkQCShiftId", receive.TraceabilitMilkQCShiftId));
                paramcollection.Add(new DBParameter("@TankerCode", receive.TankerCode));
                paramcollection.Add(new DBParameter("@SMPBatchCode", receive.SMPBatchCode));
                paramcollection.Add(new DBParameter("@TankerPampingTime", receive.TankerPampingTime));
                paramcollection.Add(new DBParameter("@ChilledMilkSiloNo", receive.ChilledMilkSiloNo));
                paramcollection.Add(new DBParameter("@ProcessSiloNo", receive.ProcessSiloNo));
                paramcollection.Add(new DBParameter("@CreamTemperature", receive.CreamTemperature));
                paramcollection.Add(new DBParameter("@SkimTemperature", receive.SkimTemperature));
                paramcollection.Add(new DBParameter("@FAT", receive.FAT));
                paramcollection.Add(new DBParameter("@Taste", receive.Taste));
                paramcollection.Add(new DBParameter("@Smell", receive.Smell));
                paramcollection.Add(new DBParameter("@Color", receive.Color));
                paramcollection.Add(new DBParameter("@PhosphatasTest", receive.PhosphatasTest));
                paramcollection.Add(new DBParameter("@Acidity", receive.Acidity));
                paramcollection.Add(new DBParameter("@CLR", receive.CLR));
                paramcollection.Add(new DBParameter("@PackedCode", receive.PackedCode));
                paramcollection.Add(new DBParameter("@SNF", receive.SNF));
                paramcollection.Add(new DBParameter("@Technician", receive.Technician));
                paramcollection.Add(new DBParameter("@TraceabilityStatusId", receive.TraceabilityStatusId));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_TraceabilityMilkQCDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetTraceabilityQCDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetTraceabilityMilkQCDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetTraceabilityDetails(RMRecieve R)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", R.RMRDate));
            return _DBHelper.ExecuteDataSet("sp_Prod_GetTraceabilityMilkQCDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}
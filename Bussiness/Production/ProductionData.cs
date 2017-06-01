using DataAccess;
using DataAccess.Production;
using Model.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness.Production
{
   
        public class ProductionData
        {
            DBProduction dbproduction;
            DataSet DS;
            public int RMRData(RMRecieve recieve)
            {

                dbproduction = new DBProduction();
                int Result = 0;
                try
                {
                    Result = dbproduction.RMRData(recieve);

                }
                catch (Exception)
                {

                    throw;
                }
                return Result;
            }
        
        //RMR On Item click
        public DataSet GetRMRDatabyId(int RMRId)
        {
            dbproduction = new DBProduction();
            return dbproduction.GetRMRDetailsbyID(RMRId);
        }

        //RMR Rp bind
        public DataSet GetRMRDetails(RMRecieve R)
            {
                dbproduction = new DBProduction();

                return dbproduction.GetRMRDetails(R);
            }

        public DataSet GetExistingBatchNo(string batchno)
        {
            dbproduction = new DBProduction();
            return dbproduction.GetExistingBatchNo(batchno);
        }
    }
    }

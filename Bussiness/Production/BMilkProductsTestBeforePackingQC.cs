using System;
using Model.Production;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess.Production;
using DataAccess;
using Bussiness;
using Model;

namespace Bussiness.Production
{
    public class BMilkProductsTestBeforePackingQC
    {
        DAMilkProductsTestBeforePackingQC damptbpqc;
        DataSet DS;

        public int milkproductdata(MMilkProductsTestBeforePackingQC receive)
        { 
            damptbpqc=new DAMilkProductsTestBeforePackingQC();
            int Result = 0;
            try
            {

                Result = damptbpqc.milkproductdata(receive);
            }

            catch (Exception)
            {
                throw;
            }
                return Result;
        }

        public DataSet GetMilkProductsTestBeforePackingQCDetailsById(int Id)
        {
            damptbpqc = new DAMilkProductsTestBeforePackingQC();
            return damptbpqc.GetMilkProductsTestBeforePackingQCDetailsById(Id);
        }

        public DataSet GetMilkProductsTestBeforePackingQCDetails(RMRecieve R)
        {
            damptbpqc = new DAMilkProductsTestBeforePackingQC();
            return damptbpqc.GetMilkProductsTestBeforePackingQCDetails(R);
        }
    }
}
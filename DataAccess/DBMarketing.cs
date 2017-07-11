using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAcess;
using Model;

namespace DataAccess
{
    public class DBMarketing
    {
        DataSet DS = new DataSet();
        DBHelper _DBHelper = new DBHelper();
        public DataSet GetAgentInfoForSchemeRefund(int AgentID)
        {
           
          
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID ", AgentID));
                DS = _DBHelper.ExecuteDataSet("mk_getagenttotalscheme", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public DataSet GetSchemeRefundInfo(Marketings marketing)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID", marketing.AgentID));
                paramCollection.Add(new DBParameter("@CreatedBy", marketing.CreatedBy));
                paramCollection.Add(new DBParameter("@TokanId", marketing.TokanNo));
                DS = _DBHelper.ExecuteDataSet("mk_GetAgentSchemeRefund", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet SalesAnalysisitemwiseByDateForPlantandBooth(string startDate, string endDate, int brandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", startDate));
            paramCollection.Add(new DBParameter("@EndDate", endDate));
            paramCollection.Add(new DBParameter("@BrandID", brandID));
            return _DBHelper.ExecuteDataSet("sp_SalesComparisonReportItemwise", paramCollection, CommandType.StoredProcedure);

        }

        public int AddSchemeRefund(Marketings marketing)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID", marketing.RouteID));
                paramCollection.Add(new DBParameter("@AgentID", marketing.AgentID));
                paramCollection.Add(new DBParameter("@TotalSchemeAmt", marketing.TotalSchemeAmt));
                paramCollection.Add(new DBParameter("@SchemerefundAmt", marketing.SchemerefundAmt));
                paramCollection.Add(new DBParameter("@balanceAmt", marketing.balanceAmt));
                paramCollection.Add(new DBParameter("@requestdate", marketing.requestdate));
                paramCollection.Add(new DBParameter("@refunddate", marketing.refunddate));
                paramCollection.Add(new DBParameter("@CreatedBy", marketing.CreatedBy));
                paramCollection.Add(new DBParameter("@TokanId", marketing.TokanNo));
                result = _DBHelper.ExecuteNonQuery("mk_AddSchemeRefund", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }

        public DataSet SalesComparisionreportItemwisebyDate(string start1Date, string end1Date, string start2Date, string end2Date, int routeID, int brandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Dispatch1BeginDate", start1Date));
            paramCollection.Add(new DBParameter("@Dispatch1EndDate", end1Date));
            paramCollection.Add(new DBParameter("@Dispatch2BeginDate", start2Date));
            paramCollection.Add(new DBParameter("@Dispatch2EndDate", end2Date));
            paramCollection.Add(new DBParameter("@RouteID", routeID));

            paramCollection.Add(new DBParameter("@BrandID", brandID));
            return _DBHelper.ExecuteDataSet("sp_SalesComparisonReportItemwise", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet NewAgentListDetails(string startdate, string enddate, int routeid,int asoempid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", startdate));
            paramCollection.Add(new DBParameter("@EndDate", enddate));
            paramCollection.Add(new DBParameter("@RouteID", routeid));
            paramCollection.Add(new DBParameter("@AsoEmpId", asoempid));
            return _DBHelper.ExecuteDataSet("mk_ViewNewAgentList", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet AgentRefundSchemeSummary(string StartDate, string EndDate, int RouteID, int AgentID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@RefundBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@RefundEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            paramCollection.Add(new DBParameter("@AgentID", AgentID));
            return _DBHelper.ExecuteDataSet("mk_AgentRefundSchemeSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet ItemWiseStaffSalesSummarybyDate(string StartDate, string EndDate, int EmployeID, string flag)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@EmployeeID", EmployeID));
            paramCollection.Add(new DBParameter("@Flag", flag));
            return _DBHelper.ExecuteDataSet("mk_GetMarketingReportStaffItemwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet BillWiseStaffSalesSummarybyDate(string StartDate, string EndDate, int EmployeID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@EmployeeID", EmployeID));

            return _DBHelper.ExecuteDataSet("mk_StaffBillwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }

        public int AddAgentDamageReplacementRateSetup(string agentId, int routeid, int categoryid, int typeid, int commodityid, string damagereplacementrate, bool isActive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@agentId ", agentId));
                paramCollection.Add(new DBParameter("@routeid ", routeid));
                paramCollection.Add(new DBParameter("@categoryid", categoryid));
                paramCollection.Add(new DBParameter("@typeid", typeid));
                paramCollection.Add(new DBParameter("@commodityid", commodityid));
                paramCollection.Add(new DBParameter("@damagereplacementrate", damagereplacementrate));
                paramCollection.Add(new DBParameter("@isActive ", isActive));

                result = _DBHelper.ExecuteNonQuery("mk_AddAgentDamageReplacementRateSetup", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return result;

        }

        public DataSet ReturnComparisionreportbyDate(string Start1Date, string End1Date, string Start2Date, string End2Date, int AgentID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Dispatch1BeginDate", Start1Date));
            paramCollection.Add(new DBParameter("@Dispatch1EndDate", End1Date));
            paramCollection.Add(new DBParameter("@Dispatch2BeginDate", Start2Date));
            paramCollection.Add(new DBParameter("@Dispatch2EndDate", End2Date));
          
            paramCollection.Add(new DBParameter("@AgentID", AgentID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("mk_DispatchReturnAgencywiseComparisonReport", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet ViewNewAgentList(string StartDate, string EndDate, int RouteID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            return _DBHelper.ExecuteDataSet("mk_ViewNewAgentList", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet ViewAgentListNotPlacedOrder(string StartDate, string EndDate, int RouteID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            return _DBHelper.ExecuteDataSet("mk_ViewAgentNotPlacedOrderbetweenTwoDates", paramCollection, CommandType.StoredProcedure);
        }


        public DataSet ViewDeactiveAgentList(string StartDate, string EndDate, int RouteID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            return _DBHelper.ExecuteDataSet("mk_ViewDeactiveAgentList", paramCollection, CommandType.StoredProcedure);

        }

        public DataSet ViewAgentSlabReportList(string StartDate, string EndDate, int RouteID, int SlabId, int TypeId)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            paramCollection.Add(new DBParameter("@SlabId", SlabId));
            paramCollection.Add(new DBParameter("@TypeId", TypeId));
            return _DBHelper.ExecuteDataSet("mk_ViewAgentListBasisOfSlab", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet ViewItemwisePurchaseAgentList(string StartDate, string EndDate, int RouteID, int TypeID, int CommodityID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            paramCollection.Add(new DBParameter("@TypeID", TypeID));
            paramCollection.Add(new DBParameter("@CommodityID", CommodityID));
            return _DBHelper.ExecuteDataSet("mk_ViewItemwisePurchaseAgentList", paramCollection, CommandType.StoredProcedure);
        }


        public DataSet AmountwiseIceCreamReport(string StartDate, string EndDate, int RouteID, int typeid,int commodityid,double startamt, double endamt,int flag)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            paramCollection.Add(new DBParameter("@TypeId", typeid));
            paramCollection.Add(new DBParameter("@CommodityId", commodityid));
            paramCollection.Add(new DBParameter("@startamt", startamt));
            paramCollection.Add(new DBParameter("@endamt", endamt));
            paramCollection.Add(new DBParameter("@flag", flag));
            return _DBHelper.ExecuteDataSet("mk_AmountwiseIceCreamReport", paramCollection, CommandType.StoredProcedure);
        }
       

    }
}
  

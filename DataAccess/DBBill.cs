using DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBBill
    {
        DBHelper _DBHelper = new DBHelper();
        public DataSet GenrateBillByDate(string Date, int routeID, int salesEmpID)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", Date));
            paramCollection.Add(new DBParameter("@routeID", routeID));
            paramCollection.Add(new DBParameter("@salesEmpID", salesEmpID));
           
            return _DBHelper.ExecuteDataSet("sp_GenrateBIll", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet BoothSalesAnalysis(string Date, int boothid, int brandid)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", Date));
            paramCollection.Add(new DBParameter("@boothid", boothid));
            paramCollection.Add(new DBParameter("@brandid", brandid));

            return _DBHelper.ExecuteDataSet("sp_BoothReportSalesAnalysis", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet BoothSalesAnalysisUser(string Date, int boothid, int userid, int brandid)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", Date));
            paramCollection.Add(new DBParameter("@boothid", boothid));
            paramCollection.Add(new DBParameter("@userid", userid));
            paramCollection.Add(new DBParameter("@brandid", brandid));
            return _DBHelper.ExecuteDataSet("sp_BoothReportSalesAnalysisUser", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetEditReturnSchemeDetails(string date, int routeId, int flag)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", date));
            paramCollection.Add(new DBParameter("@RouteID", routeId));
            paramCollection.Add(new DBParameter("@flag", flag));
            return _DBHelper.ExecuteDataSet("sp_EditReturnSchemeRoleback", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet AgentSchemeSummaryOpeningClosing(string startDate, string endDate, int routeId, int agentId)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@startDate", startDate));
            paramCollection.Add(new DBParameter("@endDate", endDate));
            paramCollection.Add(new DBParameter("@routeId", routeId));
            paramCollection.Add(new DBParameter("@agentId", agentId));
            return _DBHelper.ExecuteDataSet("mk_AgentSchemeSummaryOpeningClosing", paramCollection, CommandType.StoredProcedure);

        }

        public DataSet GenrateBIllDetailsID(int orderid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@orderID", orderid));
            return _DBHelper.ExecuteDataSet("sp_GenrateBIllDetailsID", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet SalesAnalysisitemwiseByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_GetReportSalesAnalysisitemwise", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet BillwiseSalesSummaryByDate(string StartDate, string EndDate, int routeID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            return _DBHelper.ExecuteDataSet("sp_GetReportBillwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet AgentSchemeDetails(string StartDate, string EndDate, int routeID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));

            return _DBHelper.ExecuteDataSet("Proc_AgentScheme", paramCollection, CommandType.StoredProcedure);


        }
        public DataSet GenrateItemwiseSalesSummaryByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_GetReportGenrateItemwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GenrateReportByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@OrderEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_GetReportGenrateReportByDate", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet getStockforbooth(int boothid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@boothid", boothid));

            return _DBHelper.ExecuteDataSet("getStockforbooth", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet getStockforboothViewStock(int boothid, int brandid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@boothid", boothid));
            paramCollection.Add(new DBParameter("@brandid", brandid));
            return _DBHelper.ExecuteDataSet("Sp_getStockforboothViewStock", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet getStockforboothLanding(int boothid, int userid, string ShiftDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@boothid", boothid));
            paramCollection.Add(new DBParameter("@userid", userid));
            paramCollection.Add(new DBParameter("@ShiftDate", ShiftDate));
            return _DBHelper.ExecuteDataSet("getStockforboothLanding", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet getBoothUserSales(int boothid, int userid, string ShiftDate, int brandid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@boothid", boothid));
            paramCollection.Add(new DBParameter("@userid", userid));
            paramCollection.Add(new DBParameter("@ShiftDate", ShiftDate));
            paramCollection.Add(new DBParameter("@brandid", brandid));
            return _DBHelper.ExecuteDataSet("getBoothUserSales", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet getEmployeeByUserId(int userid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            
            paramCollection.Add(new DBParameter("@userid", userid));
           
            return _DBHelper.ExecuteDataSet("sp_getEmployeeByUserId", paramCollection, CommandType.StoredProcedure);
        }
        public int EndBoothStockUser(int boothid, int userid, string shiftDate, string EndTime)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@boothid", boothid));
                paramCollection.Add(new DBParameter("@userid", userid));
                paramCollection.Add(new DBParameter("@shiftDate", shiftDate));
                paramCollection.Add(new DBParameter("@EndTime", EndTime));
                result = _DBHelper.ExecuteNonQuery("EndBoothStockUser", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();

            }
            return result;
        }
        public DataSet GenerateRoteSalesSummary(string StartDate, string EndDate, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@OrderEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_GetReportGenerateRoteSalesSummary", paramCollection, CommandType.StoredProcedure);
        }


        public DataSet GenrateBillForBoothByDate(string Date, int routeID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", Date));
            paramCollection.Add(new DBParameter("@routeID", routeID));
            //paramCollection.Add(new DBParameter("@salesEmpID", salesEmpID));

            return _DBHelper.ExecuteDataSet("sp_GenrateBIllForBooth", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet UpdatePrintedBillByDate(string Date, int routeID, int salesEmpID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", Date));
            paramCollection.Add(new DBParameter("@routeID", routeID));
            paramCollection.Add(new DBParameter("@salesEmpID", salesEmpID));

            return _DBHelper.ExecuteDataSet("sp_IsPrinted", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GenrateAgencyDuplicateBillByDate(string Date, int routeID, string StartBillNo, string EndBillNo)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@date", Date));
            paramCollection.Add(new DBParameter("@routeID", routeID));
            paramCollection.Add(new DBParameter("@StartBillNo", StartBillNo));
            paramCollection.Add(new DBParameter("@EndBillNo", EndBillNo));


            return _DBHelper.ExecuteDataSet("sp_GenratePreviousBIll", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GenrateRatewiseOrderSummaryByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@OrderEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_GetReportRatewiseOrderSummary", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet BoothItemwiseSalesSummaryByDate(string StartDate, string EndDate, int AgentID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", StartDate));
            paramCollection.Add(new DBParameter("@OrderEndDate", EndDate));
            paramCollection.Add(new DBParameter("@AgentID", AgentID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_getboothreportitemwisesalessummary", paramCollection, CommandType.StoredProcedure);
        }


        public DataSet BoothBillwiseSalesSummaryByDate(string StartDate, int boothid, int userid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@orderdate", StartDate));
            paramCollection.Add(new DBParameter("@boothid", boothid));
            paramCollection.Add(new DBParameter("@userid", userid));
            return _DBHelper.ExecuteDataSet("sp_BoothAgentEmployeeBillwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet BoothLocalBillwiseSalesSummaryByDate(string StartDate, int boothid, int userid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@orderdate", StartDate));
            paramCollection.Add(new DBParameter("@boothid", boothid));
            paramCollection.Add(new DBParameter("@userid", userid));
            return _DBHelper.ExecuteDataSet("sp_BoothLocalBillwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet BoothSalesAnalysisitemwiseByDate(string StartDate, string EndDate, int AgentID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@AgentID", AgentID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_BoothReportSalesAnalysisitemwise", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet BoothSalesAnalysisitemwise2ByDate(string StartDate, string EndDate, int AgentID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", StartDate));
            paramCollection.Add(new DBParameter("@OrderEndDate", EndDate));
            paramCollection.Add(new DBParameter("@AgentID", AgentID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_getreportforboothsalesanaliysis", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GenerateBoothRoteSalesSummary(string Date, int BoothId, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ShiftDate", Date));

            paramCollection.Add(new DBParameter("@boothid", BoothId));
            paramCollection.Add(new DBParameter("@Brand", BrandID));
            return _DBHelper.ExecuteDataSet("Sp_BoothSalesSummaryReport", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetSchemeAmountForBillwiseSalesSummary(dynamic BillNo,int flag)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@BillNo", BillNo));
            paramCollection.Add(new DBParameter("@flag", flag));
            return _DBHelper.ExecuteDataSet("Sp_GetSchemeAmountForBillwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetSchemeAmountForBoothBillwiseSalesSummary(dynamic BillNo)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@BillNo", BillNo));
            return _DBHelper.ExecuteDataSet("Sp_GetSchemeAmountForBoothBillwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }


        //Marketing Module-------


        public DataSet SalesComparisionreportbyDate(string StartDate, string EndDate, string Start2Date, string End2Date, int routeID, int BrandID, int TypeID, int CommodityID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDateBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@OrderEndDate", EndDate));
            paramCollection.Add(new DBParameter("@Order2DateBeginDate", Start2Date));
            paramCollection.Add(new DBParameter("@Order2EndDate", End2Date));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            paramCollection.Add(new DBParameter("@TypeID", TypeID));
            paramCollection.Add(new DBParameter("@CommodityID", CommodityID));
            return _DBHelper.ExecuteDataSet("sp_SalesComparisionReport", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet DespatchComparisionreportbyDate(string StartDate, string EndDate, string Start2Date, string End2Date, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Dispatch1BeginDate", StartDate));
            paramCollection.Add(new DBParameter("@Dispatch1EndDate", EndDate));
            paramCollection.Add(new DBParameter("@Dispatch2BeginDate", Start2Date));
            paramCollection.Add(new DBParameter("@Dispatch2EndDate", End2Date));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_DespatchComparisonReport", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet ReturnComparisionreportbyDate(string StartDate, string EndDate, string Start2Date, string End2Date, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Dispatch1BeginDate", StartDate));
            paramCollection.Add(new DBParameter("@Dispatch1EndDate", EndDate));
            paramCollection.Add(new DBParameter("@Dispatch2BeginDate", Start2Date));
            paramCollection.Add(new DBParameter("@Dispatch2EndDate", End2Date));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
       
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_ReturnComparisonReport", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet SpotDamageComparisionreportbyDate(string StartDate, string EndDate, string Start2Date, string End2Date, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Dispatch1BeginDate", StartDate));
            paramCollection.Add(new DBParameter("@Dispatch1EndDate", EndDate));
            paramCollection.Add(new DBParameter("@Dispatch2BeginDate", Start2Date));
            paramCollection.Add(new DBParameter("@Dispatch2EndDate", End2Date));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_SpotDamageComparisonReport", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet MarketingBillwiseSalesSummarybyDate(string StartDate, string EndDate, int RouteID,int AgentID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            paramCollection.Add(new DBParameter("@AgentID", AgentID));
            return _DBHelper.ExecuteDataSet("sp_GetMarketingReportBillwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet MarketingItemWiseSalesSummarybyDate(string StartDate, string EndDate, int RouteID,int AgentID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            paramCollection.Add(new DBParameter("@AgentID", AgentID));
            return _DBHelper.ExecuteDataSet("sp_GetMarketingReportItemwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet StaffAccountSalesSummarybyDate(string StartDate, string EndDate, string flag)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@Flag", flag));
            return _DBHelper.ExecuteDataSet("sp_StaffAccountSalesSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet PartywiseIncentiveSummary(string StartDate, string EndDate, int RouteID, int BrandID, int TypeID, int CommodityID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            paramCollection.Add(new DBParameter("@TypeID", TypeID));
            paramCollection.Add(new DBParameter("@CommodityID", CommodityID));
            return _DBHelper.ExecuteDataSet("sp_PartywiseIncentiveSummary", paramCollection, CommandType.StoredProcedure);
            //return _DBHelper.ExecuteDataSet("sp_MarketingPartywiseIncentiveSummary", paramCollection, CommandType.StoredProcedure);
        }


        public DataSet MarketingReportForSalesAnalysisitemwiseByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_MarketingReportForSalesAnalysisitemwise", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet ViewOrderQuantities(string OrderDate, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", OrderDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("SpViewOrderQuantities", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetOrdersForEdit(string OrderDate, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", OrderDate));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("SpGetOrdersForEdit", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetOrdersForCancel(string Date, int routeID, int flag)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", Date));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@OrderId", 0));
            paramCollection.Add(new DBParameter("@Flag", flag));
            return _DBHelper.ExecuteDataSet("SpOrdersCancel", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetOrdersbyOrderDetailsId(int id, int flag, double quantity)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@id", id));
            paramCollection.Add(new DBParameter("@flag", flag));
            paramCollection.Add(new DBParameter("@quantity", quantity));
            return _DBHelper.ExecuteDataSet("SpGetOrdersbyOrderDetailsId", paramCollection, CommandType.StoredProcedure);
        }
        public int EditOrders(int id, int flag, double quantity)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id", id));
                paramCollection.Add(new DBParameter("@flag", flag));
                paramCollection.Add(new DBParameter("@quantity", quantity));
                result = _DBHelper.ExecuteNonQuery("SpGetOrdersbyOrderDetailsId", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {


            }
            return result;
        }

        public int CancelOrderById(int id, int flag, int CancelBy, string flag2)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@OrderDate", flag2));
                paramCollection.Add(new DBParameter("@OrderId", id));
                paramCollection.Add(new DBParameter("@RouteId", CancelBy));
                paramCollection.Add(new DBParameter("@flag", flag));
                result = _DBHelper.ExecuteNonQuery("SpOrdersCancel", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return result;
        }

        public DataSet PartywiseDamageReturnSummary(string StartDate, string EndDate, int RouteID, int BrandID, int TypeID, int CommodityID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            paramCollection.Add(new DBParameter("@TypeID", TypeID));
            paramCollection.Add(new DBParameter("@CommodityID", CommodityID));
            return _DBHelper.ExecuteDataSet("sp_PartywiseDamageReturnSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GiftOtherComparisonReportbyDate(string StartDate, string EndDate, string Start2Date, string End2Date, int routeID, int BrandID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Dispatch1BeginDate", StartDate));
            paramCollection.Add(new DBParameter("@Dispatch1EndDate", EndDate));
            paramCollection.Add(new DBParameter("@Dispatch2BeginDate", Start2Date));
            paramCollection.Add(new DBParameter("@Dispatch2EndDate", End2Date));
            paramCollection.Add(new DBParameter("@RouteID", routeID));
            paramCollection.Add(new DBParameter("@BrandID", BrandID));
            return _DBHelper.ExecuteDataSet("sp_GiftOtherComparisonReport", paramCollection, CommandType.StoredProcedure);
        }

    }
}
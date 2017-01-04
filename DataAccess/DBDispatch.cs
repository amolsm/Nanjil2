using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAcess;
using System.Data;

namespace DataAccess
{
    public class DBDispatch
    {
        DBHelper _DBHelper = new DBHelper();

        public static void DispatchSceme(string id)
        {
            int result = 0;

            DBHelper _DBHelper = new DBHelper();
            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Id", id));
            //paramCollection.Add(new DBParameter("@DispatchDateTime", dispatch.DispatchDateTime));
            result = _DBHelper.ExecuteNonQuery("sp_DispatchSceme", paramCollection, CommandType.StoredProcedure);



        }
        public DataSet GetAllOrdersDetails()
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_getOrdersForDispatchAll", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetDispatchSearch(Dispatch dispatch)
        {
            DataSet DS = new DataSet();
            try
            {
                int result = 0;
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID", dispatch.RouteID));
                paramCollection.Add(new DBParameter("@OrderDate", dispatch.OrderDate));
                paramCollection.Add(new DBParameter("@CategoryId", dispatch.CategoryId));
                DS = _DBHelper.ExecuteDataSet("sp_getOrdersForDispatchDateRoute", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }

      

        public DataSet GetSalesManWiseReturnedTraysReport(string startdate, string enddate, int salesmanid,int flag)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DispatchBeginDate", startdate));
                paramCollection.Add(new DBParameter("@DispatchEndDate", enddate));
                paramCollection.Add(new DBParameter("@SalesmanId", salesmanid));
                paramCollection.Add(new DBParameter("@flag", flag));
                DS = _DBHelper.ExecuteDataSet("sp_SalesmanwiseReturnedTraysReport", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetCashier(string date, int routeid, int salesmanid)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID", routeid));
                paramCollection.Add(new DBParameter("@DispatchDate", date));
                paramCollection.Add(new DBParameter("@SalesmanId", salesmanid));

                DS = _DBHelper.ExecuteDataSet("sp_CashierRoutewiseSalesman", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetRoutewiseReturnTraysReport(string startdate, string enddate, int routeid,int flag)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DispatchBeginDate", startdate));
                paramCollection.Add(new DBParameter("@DispatchEndDate", enddate));
                paramCollection.Add(new DBParameter("@RouteID", routeid));
                paramCollection.Add(new DBParameter("@flag", flag));
                DS = _DBHelper.ExecuteDataSet("sp_GetRoutewiseReturnTraysReport", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetDispatchByAgentID(Dispatch dispatch)
        {
            DataSet DS = new DataSet();
            try
            {
                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID", dispatch.RouteID));
                paramCollection.Add(new DBParameter("@DispatchDate", dispatch.DispatchDate));
                paramCollection.Add(new DBParameter("@CategoryId", dispatch.CategoryId));
                paramCollection.Add(new DBParameter("@flag", dispatch.flag));
                DS = _DBHelper.ExecuteDataSet("sp_getDispatchByRoute", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet CashierGetDetails(Dispatch dispatch)
        {
            DataSet DS = new DataSet();
            try
            {
                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID", dispatch.RouteID));
                paramCollection.Add(new DBParameter("@OrderDate", dispatch.OrderDate));
                DS = _DBHelper.ExecuteDataSet("sp_CashierGetDetails", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        
        public DataSet GetDetailsForSettlement(Dispatch dispatch)
        {
            DataSet DS = new DataSet();
            try
            {
                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID", dispatch.RouteID));
                paramCollection.Add(new DBParameter("@DispatchDate", dispatch.DispatchDate));
                DS = _DBHelper.ExecuteDataSet("sp_GetDetailsForSettlement", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetStockFromDispatch(Dispatch dispatch)
        {
            DataSet DS = new DataSet();
            try
            {
                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID", dispatch.RouteID));
                paramCollection.Add(new DBParameter("@DispatchDate", dispatch.DispatchDate));
                DS = _DBHelper.ExecuteDataSet("sp_StockGetFromDispatch", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        
        public DataSet GenerateDispatchSummary(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                //int result = 0;
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DispatchId", id));

                DS = _DBHelper.ExecuteDataSet("sp_getDispatchSummary", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetDispatchLists(Dispatch disp)
        {
            DataSet DS = new DataSet();
            try
            {
                //int result = 0;
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DispatchDate", disp.DispatchDate));
                paramCollection.Add(new DBParameter("@RouteId", disp.RouteID));
                paramCollection.Add(new DBParameter("@BrandId", disp.CategoryId));
                DS = _DBHelper.ExecuteDataSet("Sp_GetDispatchByDate", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetDispatchListsUser(Dispatch disp)
        {
            DataSet DS = new DataSet();
            try
            {
                //int result = 0;
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DispatchDate", disp.DispatchDate));
                paramCollection.Add(new DBParameter("@UserId", disp.UserID));
                paramCollection.Add(new DBParameter("@BrandId", disp.CategoryId));
                DS = _DBHelper.ExecuteDataSet("Sp_GetDispatchByDateUser", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet getStock(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                //int result = 0;
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id", id));

                DS = _DBHelper.ExecuteDataSet("sp_StockGetDispatch", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet getDetailsbyDDid(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                //int result = 0;
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DispatchDetailsId", id));

                DS = _DBHelper.ExecuteDataSet("sp_getDetailsbyDespDetId", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet CashierGetDetailsId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                //int result = 0;
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@SettlementId", id));

                DS = _DBHelper.ExecuteDataSet("sp_CashierGetDetailsId", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        
        public DataSet GetDispatchByID(int id, string flag)
        {
            DataSet DS = new DataSet();
            try
            {
                //int result = 0;
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id", id));
                paramCollection.Add(new DBParameter("@flag", flag));
                DS = _DBHelper.ExecuteDataSet("sp_getDispatchbyid", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int AddDispatchInfo(Dispatch dispatch)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@DI_Id", dispatch.DispatchId));
                paramCollection.Add(new DBParameter("@DI_SalesmanFirstId", dispatch.SalesmanFirstId));
                paramCollection.Add(new DBParameter("@DI_SalesmanSecondId", dispatch.SalesmanSecondId));
                paramCollection.Add(new DBParameter("@DI_RouteId", dispatch.RouteID));
                paramCollection.Add(new DBParameter("@DI_DriverFirstId", dispatch.DriverFirstId));
                paramCollection.Add(new DBParameter("@DI_DriverSecondId", dispatch.DriverSecondId));
                paramCollection.Add(new DBParameter("@DI_VehicleId", dispatch.VehicleId));
                paramCollection.Add(new DBParameter("@TraysDispached", dispatch.Trays));
                paramCollection.Add(new DBParameter("@IceBoxDispached", dispatch.IceBox));
                paramCollection.Add(new DBParameter("@CartonsDispached", dispatch.Cartons));
                paramCollection.Add(new DBParameter("@OtherDispached", dispatch.OtherDisp));
                paramCollection.Add(new DBParameter("@DispatchDate", dispatch.DispatchDate));
                paramCollection.Add(new DBParameter("@DispatchBy", dispatch.UserID));
                paramCollection.Add(new DBParameter("@BrandId", dispatch.CategoryId));
                paramCollection.Add(new DBParameter("@ShiftId", dispatch.ShiftId));
                result = _DBHelper.ExecuteNonQuery("Sp_AddDispatchInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public int UpdateDispatch(Dispatch dispatch)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderDetailsId", dispatch.OrderDetailsId));


                result = _DBHelper.ExecuteNonQuery("sp_updateDispatch", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public int updateReturnItems(Dispatch dispatch)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@DDid", dispatch.DispatchId));
                paramCollection.Add(new DBParameter("@DD_ReturnSample", dispatch.ReturnSample));
                paramCollection.Add(new DBParameter("@DD_ReturnSpotDamaged", dispatch.ReturnSpotDamage));
                paramCollection.Add(new DBParameter("@DD_ReturnGoodQuality", dispatch.ReturnGoodQuality));

                result = _DBHelper.ExecuteNonQuery("sp_updateReturnItems", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public int CashierUpdate(Dispatch dispatch)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@SettlementId", dispatch.DispatchId));
                paramCollection.Add(new DBParameter("@ReceivedAmount", dispatch.Total));
                paramCollection.Add(new DBParameter("@ReceivedDate", dispatch.OrderDate));
                paramCollection.Add(new DBParameter("@ReceivedBy", dispatch.UserID));

                result = _DBHelper.ExecuteNonQuery("sp_CashierUpdate", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public int updateReturnTrays(Dispatch dispatch)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@DIid", dispatch.DispatchId));
                paramCollection.Add(new DBParameter("@TraysReturned", dispatch.Trays));
                paramCollection.Add(new DBParameter("@CartonsReturned", dispatch.Cartons));
                paramCollection.Add(new DBParameter("@IceBoxReturned", dispatch.IceBox));
                paramCollection.Add(new DBParameter("@OtherReturned", dispatch.OtherDisp));

                result = _DBHelper.ExecuteNonQuery("sp_updateReturnTrays", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public DataSet GetTransportDetails()
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Sp_GetAllTransportDetails", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public int AddTransportInfo(Dispatch dispatch)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                //paramCollection.Add(new DBParameter("@bankId", product.ID));
                paramCollection.Add(new DBParameter("@VehicleNo", dispatch.VehicleNo));
                paramCollection.Add(new DBParameter("@VehicleBrand", dispatch.VehicleBrand));
                paramCollection.Add(new DBParameter("@Veh_Model", dispatch.Veh_Model));
                paramCollection.Add(new DBParameter("@Veh_Year", dispatch.Veh_Year));
                paramCollection.Add(new DBParameter("@Veh_Type", dispatch.Veh_Type));
                paramCollection.Add(new DBParameter("@Veh_Reg", dispatch.Veh_Reg));
                paramCollection.Add(new DBParameter("@Veh_ChassisNo ", dispatch.Veh_ChassisNo));
                paramCollection.Add(new DBParameter("@Veh_EngineNo", dispatch.Veh_EngineNo));
                paramCollection.Add(new DBParameter("@Veh_InsProvider", dispatch.Veh_InsProvider));
                paramCollection.Add(new DBParameter("@Veh_InsPolicyNo", dispatch.Veh_InsPolicyNo));
                paramCollection.Add(new DBParameter("@Veh_InsStart", dispatch.Veh_InsStart));
                paramCollection.Add(new DBParameter("@Veh_InsLast", dispatch.Veh_InsLast));
                paramCollection.Add(new DBParameter("@Veh_InsAmount", dispatch.Veh_InsAmount));
                paramCollection.Add(new DBParameter("@Veh_OwnershipType", dispatch.Veh_OwnershipType));
                paramCollection.Add(new DBParameter("@Veh_OwnerName", dispatch.Veh_OwnerName));
                paramCollection.Add(new DBParameter("@Veh_ContactNo", dispatch.Veh_ContactNo));
                paramCollection.Add(new DBParameter("@Veh_OwnerAddress", dispatch.Veh_OwnerAddress));
                paramCollection.Add(new DBParameter("@Veh_FuelType", dispatch.Veh_FuelType));
                paramCollection.Add(new DBParameter("@BankId", dispatch.BankId));
                paramCollection.Add(new DBParameter("@BankAc", dispatch.BankAc));
                paramCollection.Add(new DBParameter("@Veh_Status", dispatch.IsActive));
                paramCollection.Add(new DBParameter("@Veh_CreateUser", dispatch.CreatedBy));
                paramCollection.Add(new DBParameter("@Veh_CreateUserDate", dispatch.Createddate));

                //paramCollection.Add(new DBParameter("@Flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddTransportDetails", paramCollection, CommandType.StoredProcedure);
                //result = _DBHelper.ExecuteNonQuery("Sp_AddBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public bool UpdateTransportInfo(Dispatch dispatch)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@TM_Id", dispatch.TM_Id));
                paramCollection.Add(new DBParameter("@VehicleNo", dispatch.VehicleNo));
                paramCollection.Add(new DBParameter("@VehicleBrand", dispatch.VehicleBrand));
                paramCollection.Add(new DBParameter("@Veh_Model", dispatch.Veh_Model));
                paramCollection.Add(new DBParameter("@Veh_Year", dispatch.Veh_Year));
                paramCollection.Add(new DBParameter("@Veh_Type", dispatch.Veh_Type));
                paramCollection.Add(new DBParameter("@Veh_Reg", dispatch.Veh_Reg));
                paramCollection.Add(new DBParameter("@Veh_ChassisNo ", dispatch.Veh_ChassisNo));
                paramCollection.Add(new DBParameter("@Veh_EngineNo", dispatch.Veh_EngineNo));
                paramCollection.Add(new DBParameter("@Veh_InsProvider", dispatch.Veh_InsProvider));
                paramCollection.Add(new DBParameter("@Veh_InsPolicyNo", dispatch.Veh_InsPolicyNo));
                paramCollection.Add(new DBParameter("@Veh_InsStart", dispatch.Veh_InsStart));
                paramCollection.Add(new DBParameter("@Veh_InsLast", dispatch.Veh_InsLast));
                paramCollection.Add(new DBParameter("@Veh_InsAmount", dispatch.Veh_InsAmount));
                paramCollection.Add(new DBParameter("@Veh_OwnershipType", dispatch.Veh_OwnershipType));
                paramCollection.Add(new DBParameter("@Veh_OwnerName", dispatch.Veh_OwnerName));
                paramCollection.Add(new DBParameter("@Veh_ContactNo", dispatch.Veh_ContactNo));
                paramCollection.Add(new DBParameter("@Veh_OwnerAddress", dispatch.Veh_OwnerAddress));
                paramCollection.Add(new DBParameter("@Veh_FuelType", dispatch.Veh_FuelType));
                paramCollection.Add(new DBParameter("@BankId", dispatch.BankId));
                paramCollection.Add(new DBParameter("@BankAc", dispatch.BankAc));
                paramCollection.Add(new DBParameter("@Veh_Status", dispatch.IsActive));
                paramCollection.Add(new DBParameter("@Veh_CreateUser", dispatch.CreatedBy));
                paramCollection.Add(new DBParameter("@Veh_CreateUserDate", dispatch.Createddate));
                //paramCollection.Add(new DBParameter("@Flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_UpdateTransportDetails", paramCollection, CommandType.StoredProcedure);
                //result = _DBHelper.ExecuteNonQuery("Sp_AddBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            if (result > 0)
                return true;
            return false;
        }
        public DataSet GetTransportDatabyId(int TM_Id)
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@TM_Id", TM_Id));
                DS = _DBHelper.ExecuteDataSet("sp_GetTransportDetailsbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public int DeleteTransportDetails(Dispatch dispatch)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@TM_Id ", dispatch.TM_Id));
            return _DBHelper.ExecuteNonQuery("Sp_DeleteTransportDetails", paramCollection, CommandType.StoredProcedure);

        }



        //Marketing Module...

        public DataSet GetAgentforIncentiveSetup(int RouteID, int BrandID, int typeid, int commodity)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID ", RouteID));
                paramCollection.Add(new DBParameter("@BrandID ", BrandID));
                paramCollection.Add(new DBParameter("@typeid ", typeid));
                paramCollection.Add(new DBParameter("@commodity ", commodity));
                DS = _DBHelper.ExecuteDataSet("Sp_GetAgentforIncentiveSetup", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public int AddAgentIncentive(string agentId, int routeid, int categoryid, int typeid, int commodityid, string incentive, bool isActive)
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
                paramCollection.Add(new DBParameter("@incentive", incentive));
                paramCollection.Add(new DBParameter("@isActive ", isActive));

                result = _DBHelper.ExecuteNonQuery("Sp_AddAgentforIncentiveSetup", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return result;

        }

        //test

        public DataSet GetProductforIncentiveSetup(int brandid, int typeid, int commodityid)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@brandid ", brandid));
                paramCollection.Add(new DBParameter("@typeid ", typeid));
                paramCollection.Add(new DBParameter("@commodityid ", commodityid));

                DS = _DBHelper.ExecuteDataSet("Sp_GetProductforIncentiveSetup", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public int AddProductIncentive(int productid, string incentive, bool isActive)
        {

            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@productid", productid));
                paramCollection.Add(new DBParameter("@incentive", incentive));
                paramCollection.Add(new DBParameter("@isActive ", isActive));

                result = _DBHelper.ExecuteNonQuery("Sp_AddProductIncentiveSetup", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return result;

        }


        public DataSet GetAgentPaymentIncentiveSummary(int AgentID)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID ", AgentID));
                DS = _DBHelper.ExecuteDataSet("sp_GetAgentPaymentIncentiveSummary", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }


        public DataSet GetAgentInfoForAgentCloser(int AgentID)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID ", AgentID));
                DS = _DBHelper.ExecuteDataSet("sp_GetAgentInfoForAgentCloser", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public int AgencyCloserbyAgentID(Dispatch d)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID", d.AgentID));
                paramCollection.Add(new DBParameter("@comment", d.comment));
                paramCollection.Add(new DBParameter("@closedby", d.closedby));
                paramCollection.Add(new DBParameter("@loanpaid", d.loanpaid));
                paramCollection.Add(new DBParameter("@shemepaid", d.shemepaid));
                paramCollection.Add(new DBParameter("@incentivepaid", d.incentivepaid));
                paramCollection.Add(new DBParameter("@depositrefund", d.depositrefund));
                paramCollection.Add(new DBParameter("@freezerreturn", d.freezerreturn));
                paramCollection.Add(new DBParameter("@Chillpad", d.Chillpad));
                paramCollection.Add(new DBParameter("@Trays", d.Traysreturn));
                paramCollection.Add(new DBParameter("@tokanid", d.tokanid));
                result = _DBHelper.ExecuteNonQuery("Sp_AgencyCloserbyAgentID", paramCollection, CommandType.StoredProcedure);


            }
            catch (Exception)
            {


            }
            return result;
        }

        public DataSet PrintAgencyCloserInfo(Dispatch d)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID", d.AgentID));
                paramCollection.Add(new DBParameter("@closedby", d.closedby));
                paramCollection.Add(new DBParameter("@tokanid", d.tokanid));
               
                DS = _DBHelper.ExecuteDataSet("mk_GetAgencyCloserforprint", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public DataSet GetDispatchUserShiftwise(Dispatch disp)
        {
            DataSet DS = new DataSet();
            try
            {
                //int result = 0;
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DispatchDate", disp.DispatchDate));
                paramCollection.Add(new DBParameter("@Dispatchby", disp.UserID));
                paramCollection.Add(new DBParameter("@BrandId", disp.CategoryId));
                DS = _DBHelper.ExecuteDataSet("sp_getDispatchUserShiftwiseSummary", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetAgentforDReplacementSetup(int RouteID, int BrandID, int typeid, int commodity)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID ", RouteID));
                paramCollection.Add(new DBParameter("@BrandID ", BrandID));
                paramCollection.Add(new DBParameter("@typeid ", typeid));
                paramCollection.Add(new DBParameter("@commodity ", commodity));
             
                DS = _DBHelper.ExecuteDataSet("Sp_GetAgentforDReplacementSetup", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }
    }
}
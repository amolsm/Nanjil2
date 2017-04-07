using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAcess;
using System.Data;

namespace DataAccess
{
    public class DBInvoice
    {
        DBHelper _DBHelper = new DBHelper();
        public bool InsertTempInvoiceItam(Invoice invoice)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
                paramCollection.Add(new DBParameter("@tokanID ", invoice.TokanId));
                paramCollection.Add(new DBParameter("@TypeId ", invoice.TypeID));
                paramCollection.Add(new DBParameter("@ProductID ", invoice.ProductID));
                paramCollection.Add(new DBParameter("@Qty", invoice.qty));
                paramCollection.Add(new DBParameter("@UnitCost", invoice.UnitCost));
                paramCollection.Add(new DBParameter("@Total", invoice.totalCoast));
                paramCollection.Add(new DBParameter("@SchemeAmount", invoice.SchemeAmount));
                paramCollection.Add(new DBParameter("@TotalSchemeAmount", invoice.TotalSchemeAmount));
                result = _DBHelper.ExecuteNonQuery("Sp_InsertTempInvoiceItam", paramCollection, CommandType.StoredProcedure);
                //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (result > 0)
                return true;
            else
                return false;
        }
        public bool CheckTempInvoiceItam(Invoice invoice, int flag)
        {
            DataSet ds = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
                paramCollection.Add(new DBParameter("@tokanID ", invoice.TokanId));
                paramCollection.Add(new DBParameter("@flag ", flag));
                paramCollection.Add(new DBParameter("@ProductID ", invoice.ProductID));
                //paramCollection.Add(new DBParameter("@Qty", invoice.qty));
                //paramCollection.Add(new DBParameter("@UnitCost", invoice.UnitCost));
                //paramCollection.Add(new DBParameter("@Total", invoice.totalCoast));
                //paramCollection.Add(new DBParameter("@SchemeAmount", invoice.SchemeAmount));
                //paramCollection.Add(new DBParameter("@TotalSchemeAmount", invoice.TotalSchemeAmount));
                //result = _DBHelper.ExecuteNonQuery("Sp_CheckTempInvoiceItam", paramCollection, CommandType.StoredProcedure);
                ds = _DBHelper.ExecuteDataSet("Sp_CheckTempInvoiceItam", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (!Comman.Comman.IsDataSetEmpty(ds))
                return true;
            else
                return false;
        }

        public bool AddSchemeOnRollback(int orderid)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@OrderId ", orderid));
                result = _DBHelper.ExecuteNonQuery("sp_AddSchemeOnRollback", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (result > 0)
                return true;
            else
                return false;
        }
       

        public bool InsertTempBulkItam(Invoice invoice)
        {
            int result = 0;
            try
            {

                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
                paramCollection.Add(new DBParameter("@tokanID ", invoice.TokanId));
                paramCollection.Add(new DBParameter("@AgentName ", invoice.AgentName));
                paramCollection.Add(new DBParameter("@TypeId ", invoice.TypeID));
                paramCollection.Add(new DBParameter("@ProductID ", invoice.ProductID));
                paramCollection.Add(new DBParameter("@Qty", invoice.qty));
                paramCollection.Add(new DBParameter("@UnitCost", invoice.UnitCost));
                paramCollection.Add(new DBParameter("@Total", invoice.totalCoast));
                paramCollection.Add(new DBParameter("@SchemeAmount", invoice.SchemeAmount));
                paramCollection.Add(new DBParameter("@TotalSchemeAmount", invoice.TotalSchemeAmount));
                paramCollection.Add(new DBParameter("@AgencyID", invoice.AgencyID));
                paramCollection.Add(new DBParameter("@orderid", invoice.orderid));
                paramCollection.Add(new DBParameter("@RouteID", invoice.ROuteID));
                paramCollection.Add(new DBParameter("@ShcemheApplied", invoice.ShecemeApplied));
                paramCollection.Add(new DBParameter("@AgentCode", invoice.AgentCode));
                paramCollection.Add(new DBParameter("@BillSeq", invoice.BillSeq));
                result = _DBHelper.ExecuteNonQuery("InsertTempBulkItam", paramCollection, CommandType.StoredProcedure);
                //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (result > 0)
                return true;
            else
                return false;
        }
        public bool DeleteBulkOrderItems(int id)
        {
            int result = 0;
            try
            {

                
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id", id));

                result = _DBHelper.ExecuteNonQuery("Sp_DeleteBulkOrderItems", paramCollection, CommandType.StoredProcedure);
                //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool returnSchemeAmount(int orderid, int returnBy)
        {
            int result = 0;
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@orderid", orderid));
                paramCollection.Add(new DBParameter("@ReturnBy", returnBy));
                result = _DBHelper.ExecuteNonQuery("Sp_returnSchemeAmount", paramCollection, CommandType.StoredProcedure);
                //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool UpdateOrderID(int ids, int newid)
        {
            int result = 0;
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id ", ids));
                paramCollection.Add(new DBParameter("@newid ", newid));
                result = _DBHelper.ExecuteNonQuery("sp_UpdateNewBulkOrderID", paramCollection, CommandType.StoredProcedure);
                //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (result > 0)
                return true;
            else
                return false;
        }
        public bool UpdateBulkOrderEditItem(Invoice inv)
        {
            int result = 0;
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id ", inv.ID));
                paramCollection.Add(new DBParameter("@Qty ", inv.qty));
                paramCollection.Add(new DBParameter("@total ", inv.totalCoast));
                result = _DBHelper.ExecuteNonQuery("Sp_UpdateBulkOrderEditItem", paramCollection, CommandType.StoredProcedure);
                //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (result > 0)
                return true;
            else
                return false;
        }
        
        public bool updateBillNo(int ids, string orderdate)
        {
            int result = 0;
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id ", ids));
                paramCollection.Add(new DBParameter("@OrderDate", orderdate));
                result = _DBHelper.ExecuteNonQuery("sp_UpdateNewBulkBillNo", paramCollection, CommandType.StoredProcedure);
                //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (result > 0)
                return true;
            else
                return false;
        }
        public bool updateAgentScheme(int ids)
        {
            int result = 0;
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id ", ids));

                result = _DBHelper.ExecuteNonQuery("sp_updateBulkAgentScheme", paramCollection, CommandType.StoredProcedure);
                //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
            if (result > 0)
                return true;
            else
                return false;
        }
        public DataSet chkScheme(Invoice invoice)
        {
           // DataSet DS = new DataSet();

            //int result = 0;
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", invoice.orderDate));
            paramCollection.Add(new DBParameter("@AgentID", invoice.AgencyID));
            paramCollection.Add(new DBParameter("@Userid", invoice.UserID));
            paramCollection.Add(new DBParameter("@TokanID", invoice.TokanId));
             return  _DBHelper.ExecuteDataSet("sp_getSchemeCount", paramCollection, CommandType.StoredProcedure);
          


           
        }
        public DataSet GetTempItam(Invoice invoice)
        {
             
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
            paramCollection.Add(new DBParameter("@tokanID ", invoice.TokanId));
            return _DBHelper.ExecuteDataSet("Sp_GetTempInvoiceItam", paramCollection, CommandType.StoredProcedure);
            //return _DBHelper.ExecuteDataSet("test2", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetBulkTempItam(Invoice invoice)
        {
            DataSet ds = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
                paramCollection.Add(new DBParameter("@tokanID ", invoice.TokanId));
                ds = _DBHelper.ExecuteDataSet("Sp_GetBulkTempInvoiceItam", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            { string e = ex.ToString(); }

            return ds;
        }
        public DataSet getBulkOrderDetailsForEdit(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id ", id));

                ds = _DBHelper.ExecuteDataSet("Sp_getBulkOrderDetailsForEdit", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            { string e = ex.ToString(); }

            return ds;
        }
        public int DeleteTempItems(Invoice invoice)
        {
             
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
            paramCollection.Add(new DBParameter("@tokanID ", invoice.TokanId));
            paramCollection.Add(new DBParameter("@Flag ", invoice.Country));
            return _DBHelper.ExecuteNonQuery("Sp_DeleteTempItems", paramCollection, CommandType.StoredProcedure);
            
        }
        public int InserOrder(Invoice invoice)
        {
            int result = 0;
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", invoice.orderDate));
            paramCollection.Add(new DBParameter("@AgentID", invoice.AgencyID)); 
            paramCollection.Add(new DBParameter("@TotalBill", invoice.totalCoast));
            paramCollection.Add(new DBParameter("@RouteID", invoice.ROuteID));
            paramCollection.Add(new DBParameter("@EmployeeID", invoice.EmployeeID));
            paramCollection.Add(new DBParameter("@CreatedBy", invoice.CreatedBy));
            paramCollection.Add(new DBParameter("@CreatedDate", invoice.CreatedDate));
            paramCollection.Add(new DBParameter("@TokanId", invoice.TokanId));
            paramCollection.Add(new DBParameter("@orderType", invoice.orderType));
            paramCollection.Add(new DBParameter("@SelesEmployeeId", invoice.SaleEmployeeId));
            paramCollection.Add(new DBParameter("@TotalSchemeAmount", invoice.TotalSchemeAmount));
            paramCollection.Add(new DBParameter("@ShcemheApplied", invoice.ShecemeApplied));
            paramCollection.Add(new DBParameter("@PrvOrderId", invoice.orderid));
            result = _DBHelper.ExecuteNonQuery("Sp_InsertOrder", paramCollection, CommandType.StoredProcedure);
           // result = _DBHelper.ExecuteNonQuery("test3", paramCollection, CommandType.StoredProcedure);
            return result;
        }

        public int TempDelete(int TempId, int prvOrdId)
        {
             
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TempId ", TempId));
            paramCollection.Add(new DBParameter("@prvOrdId ", prvOrdId));
            return _DBHelper.ExecuteNonQuery("Sp_DeleteTempItemsbyID", paramCollection, CommandType.StoredProcedure);
            
        }
        public DataSet GetUnitPriceBysablID(Invoice invoice)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@slabID ", invoice.SlabID));
            paramCollection.Add(new DBParameter("@peoductID ", invoice.ProductID));
            return _DBHelper.ExecuteDataSet("Sp_GetPriceBySbalID", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetPreviousDayOrder(Invoice invoice)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@AgentID", invoice.AgencyID));
            paramCollection.Add(new DBParameter("@tokanID", invoice.ProductID));
            paramCollection.Add(new DBParameter("@RouteID", invoice.ROuteID));
            paramCollection.Add(new DBParameter("@OrderDate", invoice.orderDate));
            return _DBHelper.ExecuteDataSet("sp_getPrvOrderDetails", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetPreviousDayOrderRouteWise(Invoice invoice)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@RouteID ", invoice.ROuteID));
            paramCollection.Add(new DBParameter("@OrderDate ", invoice.orderDate));
            return _DBHelper.ExecuteDataSet("GetPreviousDayOrderRouteWise", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetPreviousDayOrderRouteWiseEmp(Invoice invoice)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@RouteID ", invoice.ROuteID));
            paramCollection.Add(new DBParameter("@OrderDate ", invoice.orderDate));
            return _DBHelper.ExecuteDataSet("GetPreviousDayOrderRouteWiseEmp", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetDetailsforUpdateOrderID(Invoice invoice)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TokanId", invoice.TokanId));
            paramCollection.Add(new DBParameter("@userid ", invoice.UserID));
            return _DBHelper.ExecuteDataSet("sp_GetDetailsforUpdateOrderID", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetOrdersForSubmit(Invoice invoice)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TokanID", invoice.TokanId));
            paramCollection.Add(new DBParameter("@UserID ", invoice.UserID));
            return _DBHelper.ExecuteDataSet("sp_getBulkOrdersForSubmit", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetDetailsBulkBillNo()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();

            return _DBHelper.ExecuteDataSet("Sp_GetDetailsBulkBillNo", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetBulkSchemeDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();

            return _DBHelper.ExecuteDataSet("Sp_GetBulkSchemeDetails", paramCollection, CommandType.StoredProcedure);
        }
        
        public DataSet GetStock(int boothid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@boothid ", boothid));
            return _DBHelper.ExecuteDataSet("sp_getStock", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetStockAgent(int boothid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@boothid ", boothid));
            return _DBHelper.ExecuteDataSet("sp_getStockforagent", paramCollection, CommandType.StoredProcedure);
        }

        public bool Booth_InsertTempInvoiceItam(Invoice invoice)
        {
            int result = 0;
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
            paramCollection.Add(new DBParameter("@tokanID ", invoice.TokanId));
            paramCollection.Add(new DBParameter("@TypeId ", invoice.TypeID));
            paramCollection.Add(new DBParameter("@ProductID ", invoice.ProductID));
            paramCollection.Add(new DBParameter("@Qty", invoice.qty));
            paramCollection.Add(new DBParameter("@UnitCost", invoice.UnitCost));
            paramCollection.Add(new DBParameter("@Total", invoice.totalCoast));
            paramCollection.Add(new DBParameter("@SchemeAmount", invoice.SchemeAmount));
            paramCollection.Add(new DBParameter("@TotalSchemeAmount", invoice.TotalSchemeAmount));
            result = _DBHelper.ExecuteNonQuery("Sp_BoothInsertTempInvoiceItam", paramCollection, CommandType.StoredProcedure);
            //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);


            if (result > 0)
                return true;
            else
                return false;
        }
        public bool updateBulkFlag(int routeid, int types)
        {
            int result = 0;
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@RouteID ", routeid));
            paramCollection.Add(new DBParameter("@types ", types));
            result = _DBHelper.ExecuteNonQuery("Sp_updateBulkFlag", paramCollection, CommandType.StoredProcedure);
            //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);


            if (result > 0)
                return true;
            else
                return false;
        }
        
        public DataSet checkStock(Invoice invoice)
        {
           
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
            paramCollection.Add(new DBParameter("@ShiftDate ", invoice.orderDate));
            paramCollection.Add(new DBParameter("@TypeId ", invoice.TypeID));
            paramCollection.Add(new DBParameter("@ProductID ", invoice.ProductID));
            //paramCollection.Add(new DBParameter("@Qty", invoice.qty));
            paramCollection.Add(new DBParameter("@Boothid", invoice.CurrentBoothID));
           // paramCollection.Add(new DBParameter("@Total", invoice.totalCoast));
           // paramCollection.Add(new DBParameter("@SchemeAmount", invoice.SchemeAmount));
            //paramCollection.Add(new DBParameter("@TotalSchemeAmount", invoice.TotalSchemeAmount));
            return _DBHelper.ExecuteDataSet("Sp_checkStock", paramCollection, CommandType.StoredProcedure);
            //  result = _DBHelper.ExecuteNonQuery("test1", paramCollection, CommandType.StoredProcedure);


            
        }
        
        public int BoothLocalInserOrder(Invoice invoice)
        {
            int result = 0;
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", invoice.orderDate));
            paramCollection.Add(new DBParameter("@AgentID", invoice.AgencyID));
            paramCollection.Add(new DBParameter("@TotalBill", invoice.totalCoast));
            paramCollection.Add(new DBParameter("@RouteID", invoice.ROuteID));
            paramCollection.Add(new DBParameter("@EmployeeID", invoice.EmployeeID));
            paramCollection.Add(new DBParameter("@CreatedBy", invoice.CreatedBy));
            paramCollection.Add(new DBParameter("@CreatedDate", invoice.CreatedDate));
            paramCollection.Add(new DBParameter("@TokanId", invoice.TokanId));
            paramCollection.Add(new DBParameter("@orderType", invoice.orderType));
            paramCollection.Add(new DBParameter("@SelesEmployeeId", invoice.SaleEmployeeId));
            paramCollection.Add(new DBParameter("@TotalSchemeAmount", invoice.TotalSchemeAmount));
            paramCollection.Add(new DBParameter("@ShcemheApplied", invoice.ShecemeApplied));
            paramCollection.Add(new DBParameter("@CurrentBoothID", invoice.CurrentBoothID));
            result = _DBHelper.ExecuteNonQuery("Sp_LocalBooth_InsertOrder", paramCollection, CommandType.StoredProcedure);
            // result = _DBHelper.ExecuteNonQuery("test3", paramCollection, CommandType.StoredProcedure);
            return result;
        }

        public int BoothInserOrder(Invoice invoice)
        {
            int result = 0;
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", invoice.orderDate));
            paramCollection.Add(new DBParameter("@AgentID", invoice.AgencyID));
            paramCollection.Add(new DBParameter("@TotalBill", invoice.totalCoast));
            paramCollection.Add(new DBParameter("@RouteID", invoice.ROuteID));
            paramCollection.Add(new DBParameter("@EmployeeID", invoice.EmployeeID));
            paramCollection.Add(new DBParameter("@CreatedBy", invoice.CreatedBy));
            paramCollection.Add(new DBParameter("@CreatedDate", invoice.CreatedDate));
            paramCollection.Add(new DBParameter("@TokanId", invoice.TokanId));
            paramCollection.Add(new DBParameter("@orderType", invoice.orderType));
            paramCollection.Add(new DBParameter("@SelesEmployeeId", invoice.SaleEmployeeId));
            paramCollection.Add(new DBParameter("@TotalSchemeAmount", invoice.TotalSchemeAmount));
            paramCollection.Add(new DBParameter("@ShcemheApplied", invoice.ShecemeApplied));
            paramCollection.Add(new DBParameter("@CurrentBoothID", invoice.CurrentBoothID));
            paramCollection.Add(new DBParameter("@PaymentMode", invoice.PaymentMode));
            result = _DBHelper.ExecuteNonQuery("Sp_Booth_InsertOrder", paramCollection, CommandType.StoredProcedure);
            // result = _DBHelper.ExecuteNonQuery("test3", paramCollection, CommandType.StoredProcedure);
            return result;
        }
        public DataSet updateStockUser(int boothid, int userid)
        {
            
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@boothid", boothid));
            //paramCollection.Add(new DBParameter("@userid", userid));
            return _DBHelper.ExecuteDataSet("getStockforboothUser", paramCollection, CommandType.StoredProcedure);
           
            
        }
        public DataSet CheckBoothTemp(Invoice invoice, int chkflg)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CreatedBy", invoice.CreatedBy));
           paramCollection.Add(new DBParameter("@TokanId", invoice.TokanId));
            paramCollection.Add(new DBParameter("@Flag", chkflg));
            return _DBHelper.ExecuteDataSet("sp_checkBoothTemp", paramCollection, CommandType.StoredProcedure);


        }
        public int BoothTempDelete(int TempId)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TempId ", TempId));
            return _DBHelper.ExecuteNonQuery("Sp_DeleteBoothTempItemsByID", paramCollection, CommandType.StoredProcedure);

        }

        public int DeleteBoothTempItems(Invoice invoice)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
            paramCollection.Add(new DBParameter("@tokanID ", invoice.TokanId));
            return _DBHelper.ExecuteNonQuery("Sp_DeleteBoothTempItems", paramCollection, CommandType.StoredProcedure);

        }

        public DataSet GetBoothTempItam(Invoice invoice)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Userid ", invoice.UserID));
            paramCollection.Add(new DBParameter("@tokanID ", invoice.TokanId));
            return _DBHelper.ExecuteDataSet("Sp_Get_BoothTempInvoiceItam", paramCollection, CommandType.StoredProcedure);
            //return _DBHelper.ExecuteDataSet("test2", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetSlabID(Invoice invoice)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@slabname ", invoice.SlabName));

            return _DBHelper.ExecuteDataSet("GetSlabID", paramCollection, CommandType.StoredProcedure);
         
        }
        public DataSet getBillCount(string dates, int boothIds)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate ", dates));
            paramCollection.Add(new DBParameter("@boothId ", boothIds));
            return _DBHelper.ExecuteDataSet("Sp_GetLocalOrderCount", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet getBoothAgentBillCount(string dates, int boothIds)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate ", dates));
            paramCollection.Add(new DBParameter("@boothid ", boothIds));
            return _DBHelper.ExecuteDataSet("Sp_getBoothAgentBillCount", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet GetSchemeRoutewise(Invoice invoice)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate ", invoice.orderDate));
            paramCollection.Add(new DBParameter("@RouteId", invoice.ROuteID));
            return _DBHelper.ExecuteDataSet("Sp_GetSchemeRoutewise", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet getBulkEmpSlabPrice(Invoice invoice)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
           
            paramCollection.Add(new DBParameter("@ProductId", invoice.ProductID));
            return _DBHelper.ExecuteDataSet("Sp_getBulkEmpSlabPrice", paramCollection, CommandType.StoredProcedure);

        }

        public DataSet Checkempduplicateorder(Invoice invoice)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderDate", invoice.orderDate));
            paramCollection.Add(new DBParameter("@EmployeeID", invoice.EmployeeID));
            paramCollection.Add(new DBParameter("@RouteID", invoice.ROuteID));
            paramCollection.Add(new DBParameter("@OrderType", invoice.orderType));

            return _DBHelper.ExecuteDataSet("sp_Checkempduplicateorder", paramCollection, CommandType.StoredProcedure);


        }
    }
}
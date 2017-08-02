using DataAcess;
using Model.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBPurchase
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        #region Category
        public int CategoryDML(Category category)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", category.CategoryId));
                paramCollection.Add(new DBParameter("@name", category.CategoryName));
                paramCollection.Add(new DBParameter("@Description", category.Description));
                paramCollection.Add(new DBParameter("@IsActive", category.IsActive));
                paramCollection.Add(new DBParameter("@flag", category.Flag));
                result = _DBHelper.ExecuteNonQuery("SpPrchsCategoryDML", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {


            }
            return result;
        }

        public DataSet GetCategoryList(Category category)
        {
            DS = new DataSet();
            
           
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", category.CategoryId));
                paramCollection.Add(new DBParameter("@name", category.CategoryName));
                paramCollection.Add(new DBParameter("@Description", category.Description));
                paramCollection.Add(new DBParameter("@IsActive", category.IsActive));
                paramCollection.Add(new DBParameter("@flag", category.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsCategoryDML", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        #endregion

        #region Vendors
        public DataSet GetVendorsList(Vendor vendor)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", vendor.VendorId));
                paramCollection.Add(new DBParameter("@Vendorname", vendor.VendorName));
                paramCollection.Add(new DBParameter("@VendorCode", vendor.VendorCode));
                paramCollection.Add(new DBParameter("@Address", vendor.Address));
                paramCollection.Add(new DBParameter("@City", vendor.City));
                paramCollection.Add(new DBParameter("@State", vendor.State));
                paramCollection.Add(new DBParameter("@Mobile", vendor.Mobile));
                paramCollection.Add(new DBParameter("@Phone", vendor.Phone));
                paramCollection.Add(new DBParameter("@Email", vendor.Email));
                paramCollection.Add(new DBParameter("@IsActive", vendor.IsActive));
                paramCollection.Add(new DBParameter("@flag", vendor.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsVendorsDML", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int VendorDML(Vendor vendor)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", vendor.VendorId));
                paramCollection.Add(new DBParameter("@Vendorname", vendor.VendorName));
                paramCollection.Add(new DBParameter("@VendorCode", vendor.VendorCode));
                paramCollection.Add(new DBParameter("@Address", vendor.Address));
                paramCollection.Add(new DBParameter("@City", vendor.City));
                paramCollection.Add(new DBParameter("@State", vendor.State));
                paramCollection.Add(new DBParameter("@Mobile", vendor.Mobile));
                paramCollection.Add(new DBParameter("@Phone", vendor.Phone));
                paramCollection.Add(new DBParameter("@Email", vendor.Email));
                paramCollection.Add(new DBParameter("@IsActive", vendor.IsActive));
                paramCollection.Add(new DBParameter("@flag", vendor.Flag));
                result = _DBHelper.ExecuteNonQuery("SpPrchsVendorsDML", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {


            }
            return result;
        }
        #endregion

        #region Items
        public int ItemDML(Item item)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", item.ItemId));
                paramCollection.Add(new DBParameter("@name", item.ItemName));
                paramCollection.Add(new DBParameter("@Description", item.ItemDescription));
                paramCollection.Add(new DBParameter("@IsActive", item.IsActive));
                paramCollection.Add(new DBParameter("@flag", item.Flag));
                paramCollection.Add(new DBParameter("@CategoryId", item.CategoryId));
                paramCollection.Add(new DBParameter("@RackId", item.RackId));
                paramCollection.Add(new DBParameter("@RackSectionId", item.SectionId));
                result = _DBHelper.ExecuteNonQuery("SpPrchsItemDML", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {


            }
            return result;
        }

        public DataSet GetItemList(Item item)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", item.ItemId));
                paramCollection.Add(new DBParameter("@name", item.ItemName));
                paramCollection.Add(new DBParameter("@Description", item.ItemDescription));
                paramCollection.Add(new DBParameter("@IsActive", item.IsActive));
                paramCollection.Add(new DBParameter("@flag", item.Flag));
                paramCollection.Add(new DBParameter("@CategoryId", item.CategoryId));
                paramCollection.Add(new DBParameter("@RackId", item.RackId));
                paramCollection.Add(new DBParameter("@RackSectionId", item.SectionId));
                DS = _DBHelper.ExecuteDataSet("SpPrchsItemDML", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        #endregion

        #region ItemRates
        public int ItemRatesDML(ItemRate itemRate)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@ItemRateId", itemRate.ItemRatesId));
                paramCollection.Add(new DBParameter("@VendorId", itemRate.VendorId));
                paramCollection.Add(new DBParameter("@ItemId", itemRate.ItemId));
                paramCollection.Add(new DBParameter("@Quantity", itemRate.Quantity));
                paramCollection.Add(new DBParameter("@UnitId", itemRate.UnitId));
                paramCollection.Add(new DBParameter("@Price", itemRate.Price));
                paramCollection.Add(new DBParameter("@Shipping", itemRate.Shipping));
                paramCollection.Add(new DBParameter("@Excise", itemRate.Excise));
                paramCollection.Add(new DBParameter("@CST", itemRate.CST));
                paramCollection.Add(new DBParameter("@VAT", itemRate.VAT));
                paramCollection.Add(new DBParameter("@Insurance", itemRate.Insurance));
                paramCollection.Add(new DBParameter("@Freight", itemRate.Freight));
                paramCollection.Add(new DBParameter("@TotalPrice", itemRate.TotalPrice));
                paramCollection.Add(new DBParameter("@Flag", itemRate.Flag));
                result = _DBHelper.ExecuteNonQuery("SpPrchsItemRatesDML", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {


            }
            return result;
        }

        public DataSet GetItemRateList(ItemRate itemRate)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ItemRatesId", itemRate.ItemRatesId));
                paramCollection.Add(new DBParameter("@VendorId", itemRate.VendorId));
                paramCollection.Add(new DBParameter("@ItemId", itemRate.ItemId));
                paramCollection.Add(new DBParameter("@Flag", itemRate.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsItemRatesGet", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        #endregion

        #region IndentOrder
        public bool IndentCartDML(IndentCart ic)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", ic.IndentCartId));
                paramCollection.Add(new DBParameter("@Tokan",ic.Tokan ));
                paramCollection.Add(new DBParameter("@IndentBy", ic.IndentBy));
                paramCollection.Add(new DBParameter("@ItemId", ic.ItemId));
                paramCollection.Add(new DBParameter("@Quantity",ic.Quantity ));
                paramCollection.Add(new DBParameter("@Purpose", ic.Purpose));
                paramCollection.Add(new DBParameter("@flag",ic.Flag ));
                result = _DBHelper.ExecuteNonQuery("SpPrchsIndentCart", paramCollection, CommandType.StoredProcedure);
                

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

        public  DataSet GetIndentCartList(IndentCart ic)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", ic.IndentCartId));
                paramCollection.Add(new DBParameter("@Tokan", ic.Tokan));
                paramCollection.Add(new DBParameter("@IndentBy", ic.IndentBy));
                paramCollection.Add(new DBParameter("@ItemId", ic.ItemId));
                paramCollection.Add(new DBParameter("@Quantity", ic.Quantity));
                paramCollection.Add(new DBParameter("@Purpose", ic.Purpose));
                paramCollection.Add(new DBParameter("@flag", ic.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsIndentCart", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public bool SubmitIndent(Indent ic)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                
                //paramCollection.Add(new DBParameter("@IndentDate", ic.IndentDate));
                paramCollection.Add(new DBParameter("@TillDate", ic.TillDate));
                paramCollection.Add(new DBParameter("@IndentBy", ic.IndentByEmp));
                paramCollection.Add(new DBParameter("@Tokan", ic.Tokan));
                result = _DBHelper.ExecuteNonQuery("SpPrchsIndentOrder", paramCollection, CommandType.StoredProcedure);


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

        public DataSet GetIndentList(Indent indent)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                //paramCollection.Add(new DBParameter("@RequestId", req.RequestId));
                paramCollection.Add(new DBParameter("@IndentId", indent.IndentId));
                paramCollection.Add(new DBParameter("@Date", indent.IndentDate1));
                paramCollection.Add(new DBParameter("@Flag", indent.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsGetIndent", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public bool IndentStatus(Indent indent)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@IndentId", indent.IndentId));
                paramCollection.Add(new DBParameter("@Date", indent.IndentDate1));
                paramCollection.Add(new DBParameter("@Flag", indent.Flag));
                
                result = _DBHelper.ExecuteNonQuery("SpPrchsGetIndent", paramCollection, CommandType.StoredProcedure);


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
        #endregion

        #region PurchaseOrder
        public bool OrderCartDML(OrderCart ic)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", ic.OrderCartId));
                paramCollection.Add(new DBParameter("@Tokan", ic.Tokan));
                paramCollection.Add(new DBParameter("@CreatedBy", ic.CreatedBy));
                paramCollection.Add(new DBParameter("@RequestDetailsId", ic.RequestDetailsId));
                paramCollection.Add(new DBParameter("@VendorId", ic.VendorId));
                paramCollection.Add(new DBParameter("@Quantity", ic.Quantity));
                paramCollection.Add(new DBParameter("@Price", ic.Price));
                paramCollection.Add(new DBParameter("@Excise", ic.Excise));
                paramCollection.Add(new DBParameter("@Vat", ic.Vat));
                paramCollection.Add(new DBParameter("@cst", ic.cst));
                paramCollection.Add(new DBParameter("@Insurance", ic.Insurance));
                paramCollection.Add(new DBParameter("@Amt", ic.Amt));
                paramCollection.Add(new DBParameter("@flag", ic.Flag));
                result = _DBHelper.ExecuteNonQuery("SpPrchsOrderCart", paramCollection, CommandType.StoredProcedure);


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

        public DataSet GetOrderCartList(OrderCart ic)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", ic.OrderCartId));
                paramCollection.Add(new DBParameter("@Tokan", ic.Tokan));
                paramCollection.Add(new DBParameter("@CreatedBy", ic.CreatedBy));
                paramCollection.Add(new DBParameter("@RequestDetailsId", ic.RequestDetailsId));
                paramCollection.Add(new DBParameter("@VendorId", ic.VendorId));
                paramCollection.Add(new DBParameter("@Quantity", ic.Quantity));
                paramCollection.Add(new DBParameter("@Price", ic.Price));
                paramCollection.Add(new DBParameter("@Excise", ic.Excise));
                paramCollection.Add(new DBParameter("@Vat", ic.Vat));
                paramCollection.Add(new DBParameter("@cst", ic.cst));
                paramCollection.Add(new DBParameter("@Insurance", ic.Insurance));
                paramCollection.Add(new DBParameter("@Amt", ic.Amt));
                paramCollection.Add(new DBParameter("@flag", ic.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsOrderCart", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public bool SubmitOrder(Order ic)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@TillDate", ic.TillDate));
               
                paramCollection.Add(new DBParameter("@CreatedBy", ic.CreatedBy));
                paramCollection.Add(new DBParameter("@Frieght", ic.Frieght));
                paramCollection.Add(new DBParameter("@PaymentTerms", ic.PaymentTerms));
                paramCollection.Add(new DBParameter("@TransDamage", ic.TransDamage));
                paramCollection.Add(new DBParameter("@MDApproval", ic.MDApproval));
                paramCollection.Add(new DBParameter("@VendorId", ic.VendorId));
                paramCollection.Add(new DBParameter("@TotalAmt", ic.TotalAmt));
                paramCollection.Add(new DBParameter("@Warranty", ic.Warranty));
                paramCollection.Add(new DBParameter("@Tokan", ic.Tokan));
                result = _DBHelper.ExecuteNonQuery("SpPrchsOrder", paramCollection, CommandType.StoredProcedure);


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

        public DataSet GetOrderList(Order order)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                //paramCollection.Add(new DBParameter("@RequestId", req.RequestId));
                paramCollection.Add(new DBParameter("@OrderId", order.OrderId));
                paramCollection.Add(new DBParameter("@Date", order.OrderDate));
                paramCollection.Add(new DBParameter("@Flag", order.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsGetOrders", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        #endregion

        #region MRN
        public bool MrnDML(MRNDetails ic)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", ic.Id));
                paramCollection.Add(new DBParameter("@ItemId", ic.ItemId));
                paramCollection.Add(new DBParameter("@OrderDetailsId", ic.OrderDetailsId));
                paramCollection.Add(new DBParameter("@OrderedQty", ic.OrderedQty));
                paramCollection.Add(new DBParameter("@ReceivedQty", ic.ReceivedQty));
                paramCollection.Add(new DBParameter("@AcceptedQty", ic.AcceptedQty));
                paramCollection.Add(new DBParameter("@RejectedQty", ic.RejectedQty));
                paramCollection.Add(new DBParameter("@Price", ic.Price));
                paramCollection.Add(new DBParameter("@Excise", ic.Excise));
                paramCollection.Add(new DBParameter("@Cst", ic.Cst));
                paramCollection.Add(new DBParameter("@Vat", ic.Vat));
                paramCollection.Add(new DBParameter("@Amount", ic.Amount));
                paramCollection.Add(new DBParameter("@flag", ic.Flag));
                result = _DBHelper.ExecuteNonQuery("SpPrchsMrnDML", paramCollection, CommandType.StoredProcedure);


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

        public bool MrnDML2(MRN ic)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@CreatedBy", ic.CreatedBy));
                paramCollection.Add(new DBParameter("@VendorId", ic.VendorId));
                paramCollection.Add(new DBParameter("@PRNo", ic.PRNo));
                paramCollection.Add(new DBParameter("@OrderId", ic.OrderId));
                paramCollection.Add(new DBParameter("@BillNo", ic.BillNo));
                paramCollection.Add(new DBParameter("@BillDate", ic.BillDate));
                paramCollection.Add(new DBParameter("@RequiredFor", ic.RequiredFor));
                paramCollection.Add(new DBParameter("@Remarks", ic.Remarks));
                paramCollection.Add(new DBParameter("@ReceivedBy", ic.ReceivedBy));
                paramCollection.Add(new DBParameter("@QCBy", ic.QCBy));
                paramCollection.Add(new DBParameter("@FinMgr", ic.FinMgr));
                paramCollection.Add(new DBParameter("@ApprovedByEmpId", ic.ApprovedBy));
                paramCollection.Add(new DBParameter("@VehicleNo", ic.VehicleNo));
                paramCollection.Add(new DBParameter("@TotalAmt", ic.TotalAmt));
                result = _DBHelper.ExecuteNonQuery("SpPrchsMrnDML2", paramCollection, CommandType.StoredProcedure);


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
        #endregion

        #region PurchaseRequestOrder
        public bool RequestCartDML(RequestCart ic)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", ic.RequestCartId));
                paramCollection.Add(new DBParameter("@Tokan", ic.Tokan));
                paramCollection.Add(new DBParameter("@RequestBy", ic.RequestBy));
                paramCollection.Add(new DBParameter("@ItemId", ic.ItemId));
                //paramCollection.Add(new DBParameter("@VendorId", ic.VendorId));
                paramCollection.Add(new DBParameter("@Quantity", ic.Quantity));
                paramCollection.Add(new DBParameter("@UnitId", ic.UnitId));
                paramCollection.Add(new DBParameter("@Specification", ic.Specification));
                paramCollection.Add(new DBParameter("@Purpose", ic.Purpose));
                paramCollection.Add(new DBParameter("@Remark", ic.Remark));
                paramCollection.Add(new DBParameter("@flag", ic.Flag));
                result = _DBHelper.ExecuteNonQuery("SpPrchsRequestCart", paramCollection, CommandType.StoredProcedure);


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

        public DataSet GetIndentCartList(RequestCart ic)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", ic.RequestCartId));
                paramCollection.Add(new DBParameter("@Tokan", ic.Tokan));
                paramCollection.Add(new DBParameter("@RequestBy", ic.RequestBy));
                paramCollection.Add(new DBParameter("@ItemId", ic.ItemId));
                //paramCollection.Add(new DBParameter("@VendorId", ic.VendorId));
                paramCollection.Add(new DBParameter("@Quantity", ic.Quantity));
                paramCollection.Add(new DBParameter("@UnitId", ic.UnitId));
                paramCollection.Add(new DBParameter("@Specification", ic.Specification));
                paramCollection.Add(new DBParameter("@Purpose", ic.Purpose));
                paramCollection.Add(new DBParameter("@Remark", ic.Remark));
                paramCollection.Add(new DBParameter("@flag", ic.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsRequestCart", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public bool SubmitRequest(Request req)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                //paramCollection.Add(new DBParameter("@RequestCode", req.RequestCode));
                paramCollection.Add(new DBParameter("@CreatedBy", req.CreatedBy));
                paramCollection.Add(new DBParameter("@ReqStatus", req.ReqStatus));
                //paramCollection.Add(new DBParameter("@RequestDate", req.RequestDate));
                paramCollection.Add(new DBParameter("@Tokan", req.Tokan));
                result = _DBHelper.ExecuteNonQuery("SpPrchsRequestOrder", paramCollection, CommandType.StoredProcedure);


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

        public bool SubmitRequestStatus(Request req)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@RequestId", req.RequestId));
                paramCollection.Add(new DBParameter("@UserId", req.CreatedBy));
                paramCollection.Add(new DBParameter("@Status", req.ReqStatus));
                paramCollection.Add(new DBParameter("@Flag", req.Flag));
                result = _DBHelper.ExecuteNonQuery("SpPrchsGetRequest", paramCollection, CommandType.StoredProcedure);


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

        public DataSet GetRequestList(Request req)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RequestId", req.RequestId));
                paramCollection.Add(new DBParameter("@UserId", req.CreatedBy));
                paramCollection.Add(new DBParameter("@Date", req.ReqDate));
                paramCollection.Add(new DBParameter("@Flag", req.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsGetRequest", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        #endregion

        #region PurchaseDashboard

        public DataSet GetIndentList(int flag)
        {
            DS = new DataSet();
            
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@Flag", flag));
                paramCollection.Add(new DBParameter("@IndentId", 0));
                DS = _DBHelper.ExecuteDataSet("SpPrchsGetIndent", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        #endregion

        #region RackSections
        public int RacksDML(Rack rack)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", rack.RackId));
                paramCollection.Add(new DBParameter("@RackName", rack.RackName));
                paramCollection.Add(new DBParameter("@SecCount", rack.SecCount));
                paramCollection.Add(new DBParameter("@IsActive", rack.IsActive));
                paramCollection.Add(new DBParameter("@flag", rack.Flag));
                result = _DBHelper.ExecuteNonQuery("SpPrchsRacks", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return result;
        }

        public DataSet GetRackList(Rack rack)
        {
            DS = new DataSet();


            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", rack.RackId));
                paramCollection.Add(new DBParameter("@RackName", rack.RackName));
                paramCollection.Add(new DBParameter("@SecCount", rack.SecCount));
                paramCollection.Add(new DBParameter("@IsActive", rack.IsActive));
                paramCollection.Add(new DBParameter("@flag", rack.Flag));
                DS = _DBHelper.ExecuteDataSet("SpPrchsRacks", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        #endregion
    }
}
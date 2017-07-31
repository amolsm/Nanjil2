using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAccess;
using System.Data;
using Model.Purchase;

namespace Bussiness
{
    public class PurchaseData
    {
        DBPurchase dbPurchase;
        DataSet DS;

        //CategoryDML

        #region Category
        public int CategoryDML(Category category)
        {
            dbPurchase = new DBPurchase();
            int Result = 0;
            try
            {
                Result = dbPurchase.CategoryDML(category);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetCategoryList(Category category)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();
           
            try
            {
                DS = dbPurchase.GetCategoryList(category);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }


        #endregion

        #region Vendors
        public DataSet GetVendorsList(Vendor vendor)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetVendorsList(vendor);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int VendorDML(Vendor vendor)
        {
            dbPurchase = new DBPurchase();
            int Result = 0;
            try
            {
                Result = dbPurchase.VendorDML(vendor);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion

        #region Items
        public int ItemDML(Item item)
        {
            dbPurchase = new DBPurchase();
            int Result = 0;
            try
            {
                Result = dbPurchase.ItemDML(item);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetItemList(Item item)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetItemList(item);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion

        #region ItemRates
        public int ItemRatesDML(ItemRate itemRate)
        {
            dbPurchase = new DBPurchase();
            int Result = 0;
            try
            {
                Result = dbPurchase.ItemRatesDML(itemRate);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetItemRateList(ItemRate itemRate)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetItemRateList(itemRate);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion

        #region IndentOrder

        public bool IndentCartDML(IndentCart ic)
        {
            dbPurchase = new DBPurchase();
            return dbPurchase.IndentCartDML(ic);
        }

        public bool SubmitIndent(Indent ic)
        {
            dbPurchase = new DBPurchase();
            return dbPurchase.SubmitIndent(ic);
        }

        public DataSet GetIndentCartList(IndentCart ic)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetIndentCartList(ic);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public DataSet GetIndentList(Indent ic)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetIndentList(ic);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion

        #region PurchaseOrder

        public bool OrderCartDML(OrderCart ic)
        {
            dbPurchase = new DBPurchase();
            return dbPurchase.OrderCartDML(ic);
        }

        public bool SubmitOrder(Order ic)
        {
            dbPurchase = new DBPurchase();
            return dbPurchase.SubmitOrder(ic);
        }

        public DataSet GetOrderCartList(OrderCart ic)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetOrderCartList(ic);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetOrderList(Order ic)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetOrderList(ic);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion

        #region MRN
        public bool MrnDML(MRNDetails ic)
        {
            dbPurchase = new DBPurchase();
            return dbPurchase.MrnDML(ic);
        }
        public bool MrnDML2(MRN ic)
        {
            dbPurchase = new DBPurchase();
            return dbPurchase.MrnDML2(ic);
        }
        #endregion

        #region PurchaseRequestOrder

        public bool RequestCartDML(RequestCart ic)
        {
            dbPurchase = new DBPurchase();
            return dbPurchase.RequestCartDML(ic);
        }

        public bool SubmitRequest(Request ic)
        {
            dbPurchase = new DBPurchase();
            return dbPurchase.SubmitRequest(ic);
        }

        public bool SubmitRequestStatus(Request ic)
        {
            dbPurchase = new DBPurchase();
            return dbPurchase.SubmitRequestStatus(ic);
        }

        public DataSet GetRequestCartList(RequestCart ic)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetIndentCartList(ic);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetRequestList(Request ic)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetRequestList(ic);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion

        #region IndentDashboard

        public DataSet GetIndentList(int flag)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetIndentList(flag);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion

        #region RackSections
        public int RacksDML(Rack rack)
        {
            dbPurchase = new DBPurchase();
            int Result = 0;
            try
            {
                Result = dbPurchase.RacksDML(rack);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetRackList(Rack rack)
        {
            dbPurchase = new DBPurchase();
            DS = new DataSet();

            try
            {
                DS = dbPurchase.GetRackList(rack);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion
    }
}
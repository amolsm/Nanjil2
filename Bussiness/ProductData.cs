using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data;
using Comman;
using DataAccess;
namespace Bussiness
{
    public class ProductData
    {
        DBProduct dbproduct;
        DataSet DS;
        public int AddTypeInfo(Product product)
        {
            dbproduct = new DBProduct();
            int Result = 0;
            try
            {
                Result = dbproduct.AddTypeInfo(product);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public DataSet GetTypeInfo()
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetTypeInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public DataSet GetTypeInfobyID(int TypeID)
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetTypeInfobyID(TypeID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }



        public int AddCommodityInfo(Product product)
        {
            dbproduct = new DBProduct();
            int Result = 0;
            try
            {
                Result = dbproduct.AddCommodityInfo(product);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet BindCommodity()
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.BindCommodity();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetCommodityInfo()
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetCommodityInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetCommodityInfoByID(int CommodityID)
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetCommodityInfo(CommodityID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public DataSet GetBrandInfo()
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetBrandInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public DataSet GetBrandInfoByID(int BrandID)
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetBrandInfoByID(BrandID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public int AddBrandInfo(Product product)
        {
            dbproduct = new DBProduct();
            int Result = 0;
            try
            {
                Result = dbproduct.AddBrandInfo(product);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }




        public DataSet GetSlabInfo()
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetSlabInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public DataSet GetSlabInfoByID(int BrandID)
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetSlabInfoByID(BrandID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public int AddSlabInfo(Product product)
        {
            dbproduct = new DBProduct();
            int Result = 0;
            try
            {
                Result = dbproduct.AddSlabInfo(product);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        /// <summary>
        /// product
        /// </summary>
        /// <returns></returns>


        public int AddProductInfo(Product product)
        {
            dbproduct = new DBProduct();
            int Result = 0;
            try
            {
                Result = dbproduct.AddProductInfo(product);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public int UpdateProductInfo(Product product)
        {
            dbproduct = new DBProduct();
            int Result = 0;
            try
            {
                Result = dbproduct.UpdateProductInfo(product);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet BindProduct()
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.BindProduct();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetProductByID(int ProductID)
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetProductByID(ProductID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// BindSlabInfo
        /// </summary>
        /// <returns></returns>
        public DataSet BindSlabInfo()
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.BindSlabInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetBindSlabByID(int BindSlabID)
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetBindSlabByID(BindSlabID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public int AddBindSlab(Product product)
        {
            dbproduct = new DBProduct();
            int Result = 0;
            try
            {
                Result = dbproduct.AddBindSlab(product);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetSlabPriceOnAgentTypeProductIDs(Product product)
        {

            dbproduct = new DBProduct();
            return dbproduct.GetSlabPriceOnAgentTypeProductIDs(product);


        }
        public DataSet GetBankDetails()
        {
            dbproduct = new DBProduct();

            return dbproduct.GetBankDetails();
        }
        public DataSet GetStateDetails()
        {
            dbproduct = new DBProduct();

            return dbproduct.GetStateDetails();
        }
        public DataSet GetStateDetailsbyId(int Id)
        {
            dbproduct = new DBProduct();
            return dbproduct.GetStateDetailsbyId(Id);
        }
        public DataSet GetBillSequence(int Id)
        {
            dbproduct = new DBProduct();
            return dbproduct.GetBillSequence(Id);
        }
        public int AddStateDetails(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.AddStateDetails(product);
        }
        public int UpdateStateDetails(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.UpdateStateDetails(product);
        }
        public int AddBankInfo(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.AddBankInfo(product);
        }
        public int AddBillSequence(int id, int routeid, int flag)
        {
            dbproduct = new DBProduct();
            return dbproduct.AddBillSequence(id, routeid, flag);
        }
        public bool UpdateBankInfo(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.UpdateBankInfo(product);
        }
        public DataSet GetBankDatabyId(int ID)
        {
            dbproduct = new DBProduct();
            return dbproduct.GetBankDetailsbyID(ID);
        }
        public bool InsertState(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.InsertState(product);

        }
        public int DeleteLocation(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.DeleteLocation(product);
        }

        public int DeleteBankDetails(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.DeleteBankDetails(product);
        }
        public DataSet GetTotalCount(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.GetTotalCount(product);
        }


        public DataSet GetAgentSlabDetailsByAgentID(int AgentID)
        {
            dbproduct = new DBProduct();
            return dbproduct.GetAgentSlabDetailsByAgentID(AgentID);
        }

        public int AddDeptInfo(Product product)
        {
            dbproduct = new DBProduct();
            int Result = 0;
            try
            {
                Result = dbproduct.AddDeptInfo(product);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetDeptInfo()
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetDeptInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetDeptInfobyID(int DeptId)
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetDeptInfobyID(DeptId);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetDesigDetails()
        {
            dbproduct = new DBProduct();

            return dbproduct.GetDesigDetails();
        }
        public DataSet GetStockDetails( int boothid)
        {
            dbproduct = new DBProduct();

            return dbproduct.GetStockDetails(boothid);
        }
        public int UpdateStockUser(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.UpdateStockUser(product);
        }
        public DataSet GetDesigDetailsbyId(int Id)
        {
            dbproduct = new DBProduct();
            return dbproduct.GetDesigDetailsbyId(Id);
        }
        public int AddDesigDetails(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.AddDesigDetails(product);
        }
        public bool UpdateDesigDetails(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.UpdateDesigDetails(product);
        }
        public int DeleteDesigDetails(Product product)
        {
            dbproduct = new DBProduct();
            return dbproduct.DeleteDesigDetails(product);
        }




        public DataSet ReportsProductWiseSeals(string StarDate, string EndDate)
        {
            dbproduct = new DBProduct();
            return dbproduct.ReportsProductWiseSeals(StarDate, EndDate);
        }
        public DataSet ReportsBilss(string StarDate, string EndDate)
        {
            dbproduct = new DBProduct();
            return dbproduct.ReportsBilss(StarDate, EndDate);
        }

        public DataSet ReportsAgentSchemReports(string StarDate, string EndDate)
        {
            dbproduct = new DBProduct();
            return dbproduct.ReportsAgentSchemReports(StarDate, EndDate);
        }
        public DataSet PartyWiaseSchem(string StarDate, string EndDate)
        {
            dbproduct = new DBProduct();
            return dbproduct.PartyWiaseSchem(StarDate, EndDate);
        }
        public DataSet getStockbyId(int id)
        {
            dbproduct = new DBProduct();
            return dbproduct.getStockbyId(id);
        }
        public DataSet StaffACCSaleSummaryReports(string StarDate, string EndDate)
        {
            dbproduct = new DBProduct();
            return dbproduct.StaffACCSaleSummaryReports(StarDate, EndDate);
        }
        public DataSet GetAgentBindStatus(int Agent, int Type)
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetAgentBindStatus(Agent, Type);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetUnitInfo()
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetUnitInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetUnitInfobyID(int UnitID)
        {
            dbproduct = new DBProduct();
            DS = new DataSet();
            int Result = 0;
            try
            {
                DS = dbproduct.GetUnitInfobyID(UnitID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public int AddUnitInfo(Product product)
        {
            dbproduct = new DBProduct();
            int Result = 0;
            try
            {
                Result = dbproduct.AddUnitInfo(product);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
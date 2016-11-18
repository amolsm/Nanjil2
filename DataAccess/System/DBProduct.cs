using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data;
using Comman;
using DataAccess;
using DataAcess;

namespace DataAccess
{
    public class DBProduct
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        public int AddTypeInfo(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@TypeID", product.TypeID));
                paramCollection.Add(new DBParameter("@TypeName", product.TypeName));
                paramCollection.Add(new DBParameter("@ModifiedBy", product.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", product.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", product.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", product.Createddate));
                paramCollection.Add(new DBParameter("@flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddTypeInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }


        public DataSet GetTypeInfo()
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetTypeInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetTypeInfobyID(int TypeID)
        {
            DS = new DataSet();
          
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@TypeID", TypeID));
                DS = _DBHelper.ExecuteDataSet("sp_GetTypeInfobyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddCommodityInfo(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@TypeID", product.TypeID));
                paramCollection.Add(new DBParameter("@CommodityName", product.Commodity));
                paramCollection.Add(new DBParameter("@CommodityID", product.CommodityID));
                paramCollection.Add(new DBParameter("@ModifiedBy", product.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", product.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", product.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", product.Createddate));
                paramCollection.Add(new DBParameter("@flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddCommodityInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public DataSet BindCommodity()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_BindCommodity", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }



        public DataSet GetCommodityInfo()
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetCommodityInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetCommodityInfo(int CommodityID)
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@CommodityID", CommodityID));
                DS = _DBHelper.ExecuteDataSet("sp_GetCommodityInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetBrandInfo()
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetBrandInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetBrandInfoByID(int BrandID)
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@BrandID", BrandID));
                DS = _DBHelper.ExecuteDataSet("sp_GetBrandInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddBrandInfo(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@BrandID", product.BrandID));
                paramCollection.Add(new DBParameter("@BrandName", product.BrandName));
                paramCollection.Add(new DBParameter("@ModifiedBy", product.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", product.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", product.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", product.Createddate));
                paramCollection.Add(new DBParameter("@flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddBrandInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }


        public DataSet GetSlabInfo()
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetSlabInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetSlabInfoByID(int SlabID)
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@SlabID", SlabID));
                DS = _DBHelper.ExecuteDataSet("sp_GetSlabInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }



        public int AddSlabInfo(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@SlabID", product.SlabID));
                paramCollection.Add(new DBParameter("@slabName", product.SlabName));
                paramCollection.Add(new DBParameter("@ModifiedBy", product.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", product.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", product.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", product.Createddate));
                paramCollection.Add(new DBParameter("@flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddSlabInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public int AddProductInfo(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProductID", product.ProductID));
                //paramCollection.Add(new DBParameter("@ProductName", product.ProductName));

              
                paramCollection.Add(new DBParameter("@TypeID", product.TypeID));
                paramCollection.Add(new DBParameter("@CommodityID", product.CommodityID));
                paramCollection.Add(new DBParameter("@BrandID", product.BrandID));
                paramCollection.Add(new DBParameter("@StateID", product.StateID));
                paramCollection.Add(new DBParameter("@SlabID", product.SlabID));
                paramCollection.Add(new DBParameter("@Quantity", product.Quantity));
                paramCollection.Add(new DBParameter("@UnitID", product.UnitID   ));
                paramCollection.Add(new DBParameter("@Prize", product.Prize));
                paramCollection.Add(new DBParameter("@SlabCode", product.SlabCode));
                paramCollection.Add(new DBParameter("@Flag", product.flag));
                paramCollection.Add(new DBParameter("@ModifiedBy", product.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", product.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", product.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", product.Createddate));
                result = _DBHelper.ExecuteNonQuery("sp_AddProduct", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }


        public DataSet BindProduct()
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_BindProduct", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        public DataSet GetProductByID(int ProductID)
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ProductID", ProductID));
                DS = _DBHelper.ExecuteDataSet("sp_BindProductByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet BindSlabInfo()
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_BindSlabID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetBindSlabByID(int BindSlabID)
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@BindSlabID", BindSlabID)); 
                DS = _DBHelper.ExecuteDataSet("sp_BindSlabByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddBindSlab(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@BindSlabID", product.BindSlabID));
                paramCollection.Add(new DBParameter("@AgentID", product.AgencyID));
                paramCollection.Add(new DBParameter("@TypeID", product.TypeID));
                paramCollection.Add(new DBParameter("@SlabID", product.SlabID));
                paramCollection.Add(new DBParameter("@MonthelyCollection", product.MonthelyCollection));
                paramCollection.Add(new DBParameter("@TillDateCollection", product.TillDateColletion));
                paramCollection.Add(new DBParameter("@CreatedBy", product.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", product.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", product.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", product.ModifiedDate));

                paramCollection.Add(new DBParameter("@Flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddBindSlab", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

    }
}
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
                paramCollection.Add(new DBParameter("@CategoryId", product.CategoryId));
                paramCollection.Add(new DBParameter("@ModifiedBy", product.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", product.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", product.CreatedBy));
                paramCollection.Add(new DBParameter("@IsActive", product.IsActive));
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
                paramCollection.Add(new DBParameter("@Status", product.Status));
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
                paramCollection.Add(new DBParameter("@TINNumber", product.TINNumber));
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
                paramCollection.Add(new DBParameter("@SlabName", product.SlabName));
                paramCollection.Add(new DBParameter("@SlabDisc", product.SlabDisc));
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
                paramCollection.Add(new DBParameter("@ProductName1", product.ProductName));

                //paramCollection.Add(new DBParameter("@ProductCode", product.ProductCode));
                paramCollection.Add(new DBParameter("@TypeID", product.TypeID));
                paramCollection.Add(new DBParameter("@CommodityID", product.CommodityID));
                paramCollection.Add(new DBParameter("@BrandID", product.BrandID));
                paramCollection.Add(new DBParameter("@State", product.State));
                paramCollection.Add(new DBParameter("@SlabID", product.SlabID));
                paramCollection.Add(new DBParameter("@Quantity", product.Quantity));
                paramCollection.Add(new DBParameter("@UnitID", product.UnitID));
                paramCollection.Add(new DBParameter("@Prize", product.Prize));
                paramCollection.Add(new DBParameter("@SlabCode", product.SlabCode));
                paramCollection.Add(new DBParameter("@Flag", product.flag));
                paramCollection.Add(new DBParameter("@ModifiedBy", product.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", product.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", product.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", product.Createddate));
                result = _DBHelper.ExecuteNonQuery("sp_AddProduct", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                Comman.Comman.msg = ex.ToString();

            }
            return result;
        }
        public int UpdateProductInfo(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProductID", product.ProductID));
                paramCollection.Add(new DBParameter("@ProductName", product.ProductName));

                //paramCollection.Add(new DBParameter("@ProductCode", product.ProductCode));
                paramCollection.Add(new DBParameter("@TypeID", product.TypeID));
                paramCollection.Add(new DBParameter("@CommodityID", product.CommodityID));
                paramCollection.Add(new DBParameter("@BrandID", product.BrandID));
                paramCollection.Add(new DBParameter("@State", product.State));
                paramCollection.Add(new DBParameter("@SlabID", product.SlabID));
                paramCollection.Add(new DBParameter("@Quantity", product.Quantity));
                paramCollection.Add(new DBParameter("@UnitID", product.UnitID));
                paramCollection.Add(new DBParameter("@Prize", product.Prize));
                paramCollection.Add(new DBParameter("@SlabCode", product.SlabCode));
                paramCollection.Add(new DBParameter("@Flag", product.flag));
                paramCollection.Add(new DBParameter("@ModifiedBy", product.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", product.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", product.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", product.Createddate));
                result = _DBHelper.ExecuteNonQuery("sp_UpdatedProduct", paramCollection, CommandType.StoredProcedure);

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
        public DataSet GetSlabPriceOnAgentTypeProductIDs(Product product)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentId", product.AgencyID));
                paramCollection.Add(new DBParameter("@typeId", product.TypeID));
                paramCollection.Add(new DBParameter("@productID", product.ProductID));
                DS = _DBHelper.ExecuteDataSet("Sp_GetSlabPriceOnAgentTypeProductIDs", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddBankInfo(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                //paramCollection.Add(new DBParameter("@bankId", product.ID));
                paramCollection.Add(new DBParameter("@bankname", product.BankName));
                paramCollection.Add(new DBParameter("@branchname", product.BranchName));
                paramCollection.Add(new DBParameter("@branchAddress", product.BranchAddress));
                paramCollection.Add(new DBParameter("@IFSCcode", product.IFSCCode));
                //paramCollection.Add(new DBParameter("@Flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddBankDetails", paramCollection, CommandType.StoredProcedure);
                //result = _DBHelper.ExecuteNonQuery("Sp_AddBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public int AddBillSequence(int id, int routeid, int flag)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", id));
                paramCollection.Add(new DBParameter("@RouteId", routeid));
                paramCollection.Add(new DBParameter("@flag", flag));
                result = _DBHelper.ExecuteNonQuery("sp_AddBillSequence", paramCollection, CommandType.StoredProcedure);
                //result = _DBHelper.ExecuteNonQuery("Sp_AddBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public DataSet GetBillSequence(int Id)
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", 0));
                paramCollection.Add(new DBParameter("@RouteId", Id));
                paramCollection.Add(new DBParameter("@flag", 888));
                DS = _DBHelper.ExecuteDataSet("sp_AddBillSequence", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }
        public bool UpdateBankInfo(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@bankId", product.ID));
                paramCollection.Add(new DBParameter("@bankname", product.BankName));
                paramCollection.Add(new DBParameter("@branchname", product.BranchName));
                paramCollection.Add(new DBParameter("@branchAddress", product.BranchAddress));
                paramCollection.Add(new DBParameter("@IFSCcode", product.IFSCCode));
                //paramCollection.Add(new DBParameter("@Flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_UpdateBankDetails", paramCollection, CommandType.StoredProcedure);
                //result = _DBHelper.ExecuteNonQuery("Sp_AddBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            if (result > 0)
                return true;
            return false;
        }
        public DataSet GetBankDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_GetBankInformation", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetBankDetailsbyID(int ID)
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@bankId", ID));
                DS = _DBHelper.ExecuteDataSet("sp_GetBankDetailsbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public DataSet GetStateDetailsbyId(int Id)
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", Id));
                DS = _DBHelper.ExecuteDataSet("GetStateDetailsbyId", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

       


        public DataSet GetStateDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_GetStateInformation", paramCollection, CommandType.StoredProcedure);
        }

        public int AddStateDetails(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Country", product.Country));
                paramCollection.Add(new DBParameter("@State", product.State));
                paramCollection.Add(new DBParameter("@District", product.District));
                paramCollection.Add(new DBParameter("@City", product.City));
                //paramCollection.Add(new DBParameter("@Flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddStateDetails", paramCollection, CommandType.StoredProcedure);
                //result = _DBHelper.ExecuteNonQuery("Sp_AddBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public int UpdateStateDetails(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", product.LocId));
                paramCollection.Add(new DBParameter("@Country", product.Country));
                paramCollection.Add(new DBParameter("@State", product.State));
                paramCollection.Add(new DBParameter("@District", product.District));
                paramCollection.Add(new DBParameter("@City", product.City));
                //paramCollection.Add(new DBParameter("@Flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_UpdateStateDetails", paramCollection, CommandType.StoredProcedure);
                //result = _DBHelper.ExecuteNonQuery("Sp_AddBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public bool InsertState(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", product.LocId));
                paramCollection.Add(new DBParameter("@Country", product.Country));
                paramCollection.Add(new DBParameter("@State", product.State));
                paramCollection.Add(new DBParameter("@District", product.District));
                paramCollection.Add(new DBParameter("@City", product.City));
                //paramCollection.Add(new DBParameter("@Flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_UpdateStateDetails", paramCollection, CommandType.StoredProcedure);
                //result = _DBHelper.ExecuteNonQuery("Sp_AddBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            if (result > 0)
                return true;
            return false;
        }

        public int DeleteLocation(Product product)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@LocId ", product.LocId));
            return _DBHelper.ExecuteNonQuery("Sp_DeleteLocation", paramCollection, CommandType.StoredProcedure);

        }
        public int DeleteBankDetails(Product product)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ID ", product.ID));
            return _DBHelper.ExecuteNonQuery("Sp_DeleteBankDetails", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet GetTotalCount(Product product)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@EmployeeID", product.EmployeeId));
              //  paramCollection.Add(new DBParameter("@productID", product.ProductID));
                paramCollection.Add(new DBParameter("@date", product.orderDate));
                DS = _DBHelper.ExecuteDataSet("Sp_GetTotalCount", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        public DataSet GetAgentSlabDetailsByAgentID(int AgentID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@agentid", AgentID));
                DS = _DBHelper.ExecuteDataSet("Sp_GetAgentSlabDetailsByAgentID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        public int AddDeptInfo(Product product)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DeptId", product.DeptId));
                paramCollection.Add(new DBParameter("@Dept_Name", product.DeptName));
                paramCollection.Add(new DBParameter("@Dept_Head ", product.DeptHead));
                paramCollection.Add(new DBParameter("@Dept_CreatedBy", product.Dept_CreatedBy));
                paramCollection.Add(new DBParameter("@Dept_CreatedDate", product.Dept_CreatedDate));

                paramCollection.Add(new DBParameter("@flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddDepartment", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public DataSet GetDeptInfobyID(int DeptId)
        {

            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DeptId", DeptId));
                DS = _DBHelper.ExecuteDataSet("sp_GetDeptInfobyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetDeptInfo()
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetDeptInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;

        }


        public DataSet GetDesigDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("Sp_GetDesigInformation", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetStockDetails(int boothid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@boothid", boothid));
            return _DBHelper.ExecuteDataSet("Sp_GetStockDetails", paramCollection, CommandType.StoredProcedure);
        }
        public int UpdateStockUser(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", product.ID));
                paramCollection.Add(new DBParameter("@Return", product.Return));
                paramCollection.Add(new DBParameter("@Replace", product.Replace));
                paramCollection.Add(new DBParameter("@SpotDamage", product.SpotDamage));
                paramCollection.Add(new DBParameter("@Incentive", product.Incentive));
                paramCollection.Add(new DBParameter("@Other", product.Other));
                paramCollection.Add(new DBParameter("@UserID", product.UserID));


                result = _DBHelper.ExecuteNonQuery("UpdateStockUser", paramCollection, CommandType.StoredProcedure);


            }
            catch (Exception)
            {


            }
            return result;
        }
        public DataSet GetDesigDetailsbyId(int Id)
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DesigId", Id));
                DS = _DBHelper.ExecuteDataSet("Sp_GetDesigDetailsbyDesigId", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public int AddDesigDetails(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                //paramCollection.Add(new DBParameter("@DesigId", product.DesigId));
                paramCollection.Add(new DBParameter("@DesigName", product.DesigName));
                paramCollection.Add(new DBParameter("@Description", product.Descriptions));
                paramCollection.Add(new DBParameter("@Responsibility", product.Responsibility));

                result = _DBHelper.ExecuteNonQuery("Sp_AddDesigDetails", paramCollection, CommandType.StoredProcedure);


            }
            catch (Exception)
            {


            }
            return result;
        }

        public bool UpdateDesigDetails(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@DesigId", product.DesigId));
                paramCollection.Add(new DBParameter("@DesigName", product.DesigName));
                paramCollection.Add(new DBParameter("@Description", product.Descriptions));
                paramCollection.Add(new DBParameter("@Responsibility", product.Responsibility));


                result = _DBHelper.ExecuteNonQuery("Sp_UpdateDesigDetails", paramCollection, CommandType.StoredProcedure);


            }
            catch (Exception)
            {


            }
            if (result > 0)
                return true;
            return false;
        }

        public int DeleteDesigDetails(Product product)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DesigId", product.DesigId));
            return _DBHelper.ExecuteNonQuery("Sp_DeleteDesigDetails", paramCollection, CommandType.StoredProcedure);
        }


        public DataSet ReportsProductWiseSeals(string StarDate, string EndDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StarDate", StarDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            return _DBHelper.ExecuteDataSet("Reports_sp_productWiseSeals", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet ReportsBilss(string StarDate, string EndDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StarDate", StarDate));
            paramCollection.Add(new DBParameter("@EndDateEndDate", EndDate));
            return _DBHelper.ExecuteDataSet("Reports_Sp_BillsRepors", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet ReportsAgentSchemReports(string StarDate, string EndDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StarDate", StarDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            return _DBHelper.ExecuteDataSet("Reports_AgentSeameWiseReports", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet PartyWiaseSchem(string StarDate, string EndDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            //paramCollection.Add(new DBParameter("@StarDate", StarDate));
           // paramCollection.Add(new DBParameter("@EndDate", EndDate));
            return _DBHelper.ExecuteDataSet("Reports_PartywiseScheme", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet getStockbyId(int id)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
             paramCollection.Add(new DBParameter("@id", id));
            return _DBHelper.ExecuteDataSet("Sp_getStockDetailsbyId", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet StaffACCSaleSummaryReports(string StarDate, string EndDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StarDate", StarDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            return _DBHelper.ExecuteDataSet("Reports_StaffACCSaleSummary", paramCollection, CommandType.StoredProcedure);
        }



        public DataSet GetAgentBindStatus(int Agent, int Type)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID", Agent));
                paramCollection.Add(new DBParameter("@TypeID", Type));

                DS = _DBHelper.ExecuteDataSet("Sp_GetAgentBindStatus", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetUnitInfo()
        {
            DS = new DataSet();
            int Result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetUnitInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetUnitInfobyID(int UnitID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@UnitID", UnitID));
                DS = _DBHelper.ExecuteDataSet("sp_GetUnitInfobyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        public int AddUnitInfo(Product product)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@UnitID", product.UnitID));
                paramCollection.Add(new DBParameter("@UnitName", product.UnitName));
                paramCollection.Add(new DBParameter("@IsActive", product.IsActive));
                paramCollection.Add(new DBParameter("@flag", product.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddUnitInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
    }
}

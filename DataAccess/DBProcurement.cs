using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using System.Data;
using DataAcess;
using Model;

namespace DataAccess
{
    public class DBProcurement
    {
        DBHelper _DBHelper = new DBHelper();
        public int InsertMilkCenter(Procurement p)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@CenterID", p.CenterID));
                paramCollection.Add(new DBParameter("@CenterCode", p.CenterCode));
                paramCollection.Add(new DBParameter("@CenterName", p.CenterName));
                //paramCollection.Add(new DBParameter("@RouteID", p.RouteID));
                paramCollection.Add(new DBParameter("@Address1", p.Address1));
                paramCollection.Add(new DBParameter("@Address2", p.Address2));
                paramCollection.Add(new DBParameter("@Address3", p.Address3));
                paramCollection.Add(new DBParameter("@EmailID", p.EmailID));
                paramCollection.Add(new DBParameter("@PhoneNo", p.PhoneNo));
                paramCollection.Add(new DBParameter("@MobileNo", p.MobileNo));
                paramCollection.Add(new DBParameter("@City", p.City));
                paramCollection.Add(new DBParameter("@District", p.District));
                paramCollection.Add(new DBParameter("@State", p.State));
                paramCollection.Add(new DBParameter("@Country", p.Country));
                paramCollection.Add(new DBParameter("@ContactPerson", p.ContactPerson));
                paramCollection.Add(new DBParameter("@FreezerAvailable", p.FreezerAvailable));
                paramCollection.Add(new DBParameter("@FreezerModel", p.FreezerModel));
                paramCollection.Add(new DBParameter("@Quantity", p.Quantity));
                paramCollection.Add(new DBParameter("@BMC", p.BMC));
                paramCollection.Add(new DBParameter("@MilkCan", p.MilkCan));
                paramCollection.Add(new DBParameter("@Silo", p.Silo));
                paramCollection.Add(new DBParameter("@IBT", p.IBT));
                paramCollection.Add(new DBParameter("@ETP", p.ETP));
                paramCollection.Add(new DBParameter("@LAB", p.LAB));
                paramCollection.Add(new DBParameter("@Store", p.Store));
                paramCollection.Add(new DBParameter("@IsActive", p.IsActive));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertMilkCenter", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public DataSet MilkCollectionTransportBill(Procurement p)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@StartDate", p.FomDate));
                paramCollection.Add(new DBParameter("@EndDate", p.ToDate));
                paramCollection.Add(new DBParameter("@VehicalNo", p.VehicleNo));
                DS = _DBHelper.ExecuteDataSet("Proc_SP_MilkCollectionTransportBill", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception e)
            { string msg = e.ToString(); }

            return DS;
        }

        public DataSet MonthlyRawMilkPurchaseSummary(int CenterID, string StartDate, string EndDate, double tsStart, double tsEnd, int flag)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@CenterId", CenterID));
                paramCollection.Add(new DBParameter("@StartDate", StartDate));
                paramCollection.Add(new DBParameter("@EndDate", EndDate));
                paramCollection.Add(new DBParameter("@TSStart", tsStart));
                paramCollection.Add(new DBParameter("@TSEnd", tsEnd));
                paramCollection.Add(new DBParameter("@flag", flag));
                DS = _DBHelper.ExecuteDataSet("Proc_SP_MonthlyRawMilkPurchaseSummary", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
            return DS;
        }

        public DataSet GetTransactionDetails(Procurement p)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteId", p.RouteID));
                paramCollection.Add(new DBParameter("@fromdate", p.FomDate));
                paramCollection.Add(new DBParameter("@todate", p.ToDate));
                DS = _DBHelper.ExecuteDataSet("Proc_GetTransaction", paramCollection, CommandType.StoredProcedure);
            }
            catch { }
            return DS;
        }

        public DataSet GetIncentivetariff()
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_sp_GetIncentivetariff", paramCollection, CommandType.StoredProcedure);
            }
            catch { }
            return DS;
        }

        public DataSet ConsolidatePayementSummary(Procurement p)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@fromdate", p.FomDate));
                paramCollection.Add(new DBParameter("@todate", p.ToDate));
                paramCollection.Add(new DBParameter("@CenterId", p.CenterID));
                //paramCollection.Add(new DBParameter("@RouteId", p.RouteID));
                DS = _DBHelper.ExecuteDataSet("Proc_sp_ConsolidatePayementSummary", paramCollection, CommandType.StoredProcedure);
            }
            catch { }
            return DS;
        }

        public DataSet RawMilkPaymentListViaBank(Procurement p)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@fromdate", p.FomDate));
                paramCollection.Add(new DBParameter("@todate", p.ToDate));
                paramCollection.Add(new DBParameter("@Routeid", p.RouteID));
                paramCollection.Add(new DBParameter("@BankName", p.BankName));
                paramCollection.Add(new DBParameter("@IFSCCode", p.IFSCCode));
                DS = _DBHelper.ExecuteDataSet("Proc_sp_RawMilkPaymentListViaBank", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                string msg = ex.ToString();

            }
            return DS;
        }


        public DataSet SupplierWiseMilkqtyandQlty(Procurement p)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@fromdate", p.FomDate));
                paramCollection.Add(new DBParameter("@todate", p.ToDate));
                paramCollection.Add(new DBParameter("@Routeid", p.RouteID));
                DS = _DBHelper.ExecuteDataSet("Proc_sp_SupplierWiseMilkqtyandQlty", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int InsertReceiveandDisposeMaster(Procurement p)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", p.ID));
                paramCollection.Add(new DBParameter("@particular", p.particular));
                paramCollection.Add(new DBParameter("@purpose", p.purpose));
                paramCollection.Add(new DBParameter("@IsActive", p.IsActive));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertReceiveandDisposeMaster", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public DataSet GetReceiveDisposeHeadMasterId(int ID)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", ID));
                DS = _DBHelper.ExecuteDataSet("Proc_sp_GetReceiveDisposeHeadMasterId", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetBataandAmountOfVehicleonbasisofmodelid(int modelid, int vehicleno)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@modelid", modelid));
                paramCollection.Add(new DBParameter("@vehicleno", vehicleno));
                DS = _DBHelper.ExecuteDataSet("Proc_sp_GetBataandAmountOfVehicle", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                string msg = ex.ToString();
            }
            return DS;
        }

        public DataSet GetReceiveDisposeHeadMaster()
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_sp_GetReceiveDisposeHeadMaster", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int InsertVehicleType(Procurement p)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VehicleType", p.VehicleType));
                paramCollection.Add(new DBParameter("@VehicleTypeName", p.VehicleTypeName));
                paramCollection.Add(new DBParameter("@IsActive", p.IsActive));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertVehicleType", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return result;
        }

        public int AddTransaction(int SupplierID, int RouteID, string PaymentDateTime, DateTime FomDate, DateTime ToDate, double Amount, double Bonus, decimal Scheme, double RDAmount, double canloan, double casloan, double bankloan, double netamt)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@SupplierID", SupplierID));
                paramCollection.Add(new DBParameter("@RouteID", RouteID));
                paramCollection.Add(new DBParameter("@PaymentDateTime", PaymentDateTime));
                paramCollection.Add(new DBParameter("@FomDate", FomDate));
                paramCollection.Add(new DBParameter("@ToDate", ToDate));
                paramCollection.Add(new DBParameter("@Amount", Amount));
                paramCollection.Add(new DBParameter("@Bonus", Bonus));
                paramCollection.Add(new DBParameter("@Scheme", Scheme));
                paramCollection.Add(new DBParameter("@RDAmount", RDAmount));
                paramCollection.Add(new DBParameter("@canloan", canloan));
                paramCollection.Add(new DBParameter("@cashloan", casloan));
                paramCollection.Add(new DBParameter("@bankloan", bankloan));
                paramCollection.Add(new DBParameter("@netamt", netamt));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_AddTransaction", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                string msg = e.ToString();
            }
            return result;
        }

        public DataSet GetIncentiveTariffbyID(int incentivetariffid)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", incentivetariffid));
                DS = _DBHelper.ExecuteDataSet("Proc_sp_GetIncentivetariff", paramCollection, CommandType.StoredProcedure);
            }
            catch { }
            return DS;
        }

        public DataSet GetVehicleTypeById(int typeID)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VehicleType", typeID));
                DS = _DBHelper.ExecuteDataSet("Proc_sp_GetVehicleTypebyId", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetVehicleType()
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_sp_GetVehicleType", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetAllCenterDetails()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllCenterDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetRouteSchemeBonusbyroute(int routeID)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@routeID", routeID));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetRouteSchemeBonusbyroute", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetBatchWiseMilkCollection(int milkcollectionid, string flag)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@milkcollectionid", milkcollectionid));
                paramCollection.Add(new DBParameter("@flag", flag));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetBatchWiseMilkCollection", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;

        }

        public DataSet GetAllBatchWiseMilkCollectionDetail()
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllBatchWiseMilk", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetCenterDetailsByID(int CenterID)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@CenterID", CenterID));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetCenterDetailsByID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;

        }



        public int InsertSupplierPrfile(Procurement p)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@SupplierID", p.SupplierID));
                paramCollection.Add(new DBParameter("@SupplierCode", p.SupplierCode));
                paramCollection.Add(new DBParameter("@CenterID", p.CenterID));
                paramCollection.Add(new DBParameter("@RouteID", p.RouteID));
                paramCollection.Add(new DBParameter("@SupplierName", p.SupplierName));
                paramCollection.Add(new DBParameter("@SupplierAlias", p.SupplierAliasName));
                paramCollection.Add(new DBParameter("@JoiningDate", p.JoiningDate));
                paramCollection.Add(new DBParameter("@Address1", p.Address1));
                paramCollection.Add(new DBParameter("@Address2", p.Address2));
                paramCollection.Add(new DBParameter("@Address3", p.Address3));
                paramCollection.Add(new DBParameter("@EmailID", p.EmailID));
                paramCollection.Add(new DBParameter("@PhoneNo", p.PhoneNo));
                paramCollection.Add(new DBParameter("@MobileNo", p.MobileNo));
                paramCollection.Add(new DBParameter("@City", p.City));
                paramCollection.Add(new DBParameter("@District", p.District));
                paramCollection.Add(new DBParameter("@State", p.State));
                paramCollection.Add(new DBParameter("@Country", p.Country));
                //paramCollection.Add(new DBParameter("@BankDetailsID", p.BankDetailsID));
                paramCollection.Add(new DBParameter("@IncentivrTillDate", p.IncentiveTillDate));
                paramCollection.Add(new DBParameter("@ReccDeposit", p.ReccDeposit));
                paramCollection.Add(new DBParameter("@Bonus", p.Bonus));
                paramCollection.Add(new DBParameter("@AdvanceGiven", p.AdvaceGiven));
                paramCollection.Add(new DBParameter("@SchemeTillDate", p.SchemeAmount));
                paramCollection.Add(new DBParameter("@IsActive", p.IsActive));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@BankDetailID", p.BankDetailsID));
                paramCollection.Add(new DBParameter("@SupplierID1", p.SupplierID));
                paramCollection.Add(new DBParameter("@BankName", p.BankName));
                paramCollection.Add(new DBParameter("@AccountNo", p.AccounNumber));
                paramCollection.Add(new DBParameter("@AccountType", p.AccountType));
                paramCollection.Add(new DBParameter("@IFSCCode", p.IFSCCode));
                paramCollection.Add(new DBParameter("@BankAddress", p.BankAddress));
                paramCollection.Add(new DBParameter("@BranchName", p.BranchName));
                paramCollection.Add(new DBParameter("@AccountName", p.AccountName));
                paramCollection.Add(new DBParameter("@CreatedBy1", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate1", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy1", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate1", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertSupplierProfile", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {

                string msg = EX.Message.ToString();
            }
            return result;
        }

        public DataSet GetAllSupplierProfiles()
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllSupplierProfiles", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;

        }
        public DataSet GetSupplierProfilebyID(int SupplierID)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@SupplierID", SupplierID));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetSupplierProfilebyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int InsertSupplierBankDetails(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@BankDetailID", p.BankDetailsID));
                paramCollection.Add(new DBParameter("@SupplierID", p.SupplierID));
                paramCollection.Add(new DBParameter("@BankName", p.BankName));
                paramCollection.Add(new DBParameter("@AccountNo", p.AccounNumber));
                paramCollection.Add(new DBParameter("@AccountType", p.AccountType));
                paramCollection.Add(new DBParameter("@IFSCCode", p.IFSCCode));
                paramCollection.Add(new DBParameter("@BankAddress", p.BankAddress));
                paramCollection.Add(new DBParameter("@BranchName", p.BranchName));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertSupplierBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public DataSet GetAllSupplierBankDetails()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllSupplierBankDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetSupplierBankDetailsbyID(int BankDetailID)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@BankDetailID", BankDetailID));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetSupplierBankDetailsbyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int InsertSupplierLoanInfo(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@LoanID", p.LoanID));
                paramCollection.Add(new DBParameter("@SupplierID", p.SupplierID));
                paramCollection.Add(new DBParameter("@LoanAccountNo", p.AccounNumber));
                paramCollection.Add(new DBParameter("@LoanType", p.LoanType));
                paramCollection.Add(new DBParameter("@LoanAmount", p.LoanAmount));
                paramCollection.Add(new DBParameter("@LoanTakenDate", p.LoanTakenDate));
                paramCollection.Add(new DBParameter("@LoanDuration", p.LoanDuration));
                paramCollection.Add(new DBParameter("@LoanPaid", p.LoanPaid));
                paramCollection.Add(new DBParameter("@LoanBalance", p.LoanBalance));
                paramCollection.Add(new DBParameter("@LoanStatus", p.LoanStatus));
                paramCollection.Add(new DBParameter("@BankName", p.BankName));
                paramCollection.Add(new DBParameter("@BranchName", p.BranchName));
                paramCollection.Add(new DBParameter("@IFSCCode", p.IFSCCode));
                paramCollection.Add(new DBParameter("@Interest", p.Interest));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertSupplierLoanInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return result;
        }
        public DataSet GetAllSupplierLoanInfo()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllSupplierLoanInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetSupplierLoanInfobyID(int LoanID)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@LoanID", LoanID));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetSupplierLoanInfobyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int InsertSupplierAdvanceInfo(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AdvanceID", p.AdvanceID));
                paramCollection.Add(new DBParameter("@VehicalID", p.VehicleID));
                paramCollection.Add(new DBParameter("@AdvanceAmount", p.AdvanceAmount));
                paramCollection.Add(new DBParameter("@AdvanceDateTime", p.AdvanceDateTime));
                paramCollection.Add(new DBParameter("@AdvanceDeducted", p.AdvanceDeducted));
                paramCollection.Add(new DBParameter("@AdvanceBalance", p.AdvanceBalance));
                paramCollection.Add(new DBParameter("@DeductDateTime", p.DeductDateTime));
                paramCollection.Add(new DBParameter("@Interest", p.Interest));
                paramCollection.Add(new DBParameter("@Installments", p.Installments));
                paramCollection.Add(new DBParameter("@InstallmentAmt", p.InstallmentAmount));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertSupplierAdvanceInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public DataSet GetAllSupplierAdvanceInfo()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllSupplierAdvanceInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetSupplierAdvanceInfobyID(int AdvanceID)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AdvanceID", AdvanceID));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetSupplierAdvanceInfobyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int InsertSupplierRDInfo(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RDID", p.RDID));
                paramCollection.Add(new DBParameter("@RouteId", p.RouteID));
                paramCollection.Add(new DBParameter("@SupplierID", p.SupplierID));
                paramCollection.Add(new DBParameter("@RDStartDate", p.RDStartDate));
                paramCollection.Add(new DBParameter("@RDMaturityDate", p.RDMaturityDate));
                paramCollection.Add(new DBParameter("@RDAmount", p.RDAmount));
                paramCollection.Add(new DBParameter("@RDRepaymentAmount", p.RepaymentAmt));
                paramCollection.Add(new DBParameter("@RDStatus", p.RDStatus));
                paramCollection.Add(new DBParameter("@RDPaymentDateTime", p.RDPaymentDateTime));
                paramCollection.Add(new DBParameter("@BankName", p.BankName));
                paramCollection.Add(new DBParameter("@AccountNo", p.AccounNumber));
                paramCollection.Add(new DBParameter("@IFSCCode", p.IFSCCode));
                paramCollection.Add(new DBParameter("@BranchName", p.BranchName));
                paramCollection.Add(new DBParameter("@AccountName", p.AccountName));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertSupplierRDInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public DataSet GetAllSupplierRDInfo()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllSupplierRDInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetSupplierRDInfobyID(int RDID)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RDID", RDID));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetSupplierRDInfobyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public int InsertSupplierSchemeInfo(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@SchemeID", p.SchemeID));
                paramCollection.Add(new DBParameter("@SupplierID", p.SupplierID));
                paramCollection.Add(new DBParameter("@SchemeBonusYr", p.SchemeBonusYr));
                paramCollection.Add(new DBParameter("@SchemeAmount", p.SchemeAmount));
                paramCollection.Add(new DBParameter("@BonusAmount", p.BonusAmount));
                paramCollection.Add(new DBParameter("@PaymentStatus", p.PaymentStatus));
                paramCollection.Add(new DBParameter("@PaymentDateTime", p.PaymentDateTime));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertSupplierSchemeInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return result;
        }
        public DataSet GetAllSupplierSchemeInfo()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllSupplierSchemeInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetSupplierSchemeInfobyID(int SchemeID)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@SchemeID", SchemeID));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetSupplierSchemeInfobyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int InsertVehicleMaster(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VehicleID", p.VehicleID));
                //paramCollection.Add(new DBParameter("@SrNo", p.SrNo));
                paramCollection.Add(new DBParameter("@Vehicle", p.VehicleType));
                paramCollection.Add(new DBParameter("@Bata", p.Bata));
                paramCollection.Add(new DBParameter("@KMLow", p.KMLow));
                paramCollection.Add(new DBParameter("@KMHigh", p.KMHigh));
                paramCollection.Add(new DBParameter("@Amount", p.Amount));
                //paramCollection.Add(new DBParameter("@V251To300", p.V251To300));
                //paramCollection.Add(new DBParameter("@KMGreaterThan300", p.KMGreaterThan300));
                paramCollection.Add(new DBParameter("@Description", p.Discription));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertVehicleMaster", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return result;
        }
        public DataSet GetAllVehicleMasterDetails()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllVehicleMasterDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetVehicleMasterDetailsbyID(int vehicleid)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VehicleID", vehicleid));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetVehicleMasterDetailsbyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int InsertVehicleDetails(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VehicleMasterID", p.VehicleMasterID));
                //paramCollection.Add(new DBParameter("@VehicleName", p.VehicleName));
                paramCollection.Add(new DBParameter("@VehicleNo", p.VehicleNo));
                paramCollection.Add(new DBParameter("@VehicleID1", p.VehicleID1));
                paramCollection.Add(new DBParameter("@VehicleOwnerName", p.VehicleOwnerName));
                paramCollection.Add(new DBParameter("@OwnerEmail", p.OwnerEmail));
                paramCollection.Add(new DBParameter("@OwnerMobileNo", p.OwnerMobileNo));
                //paramCollection.Add(new DBParameter("@VehicleSrNo", p.VehicleSrNo));
                paramCollection.Add(new DBParameter("@VehicleType", p.VehicleType));
                paramCollection.Add(new DBParameter("@DriverName", p.DriverName));
                paramCollection.Add(new DBParameter("@DriverMobileNo", p.DriverMobileNo));
                paramCollection.Add(new DBParameter("@OwnerBankName", p.OwnerBankName));
                paramCollection.Add(new DBParameter("@IFSCCode", p.IFSCCode));
                paramCollection.Add(new DBParameter("@BranchName", p.BranchName));
                paramCollection.Add(new DBParameter("@AccountNo", p.AccountNo));
                //paramCollection.Add(new DBParameter("@Tax", p.Tax));
                paramCollection.Add(new DBParameter("@RouteID", p.RouteID));
                paramCollection.Add(new DBParameter("@tdspercentage", p.tdspercentage));
                paramCollection.Add(new DBParameter("@TransportType", p.TransportType));
                paramCollection.Add(new DBParameter("@IsActive", p.IsActive));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertVehicleDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public DataSet GetAllVehicleDetails()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllVehicleDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetVehicleDetailsbyID(int vehicleid)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VehicleID", vehicleid));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetVehicleDetailsbyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public int InsertRawMilkTarrif(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RawMilkTarrifID", p.RawMilkTarrifID));
                paramCollection.Add(new DBParameter("@Category", p.Category));
                paramCollection.Add(new DBParameter("@TSL", p.TSL));
                paramCollection.Add(new DBParameter("@TSH", p.TSH));
                paramCollection.Add(new DBParameter("@TSRATE", p.TSRATE));
                paramCollection.Add(new DBParameter("@TS_INCR", p.TS_INCR));
                paramCollection.Add(new DBParameter("@Incentive", p.Incentive));
                paramCollection.Add(new DBParameter("@IN_FAT", p.IN_FAT));

                paramCollection.Add(new DBParameter("@IN_SNF", p.IN_SNF));
                paramCollection.Add(new DBParameter("@IN_TS", p.IN_TS));
                paramCollection.Add(new DBParameter("@Scheme", p.Scheme));
                paramCollection.Add(new DBParameter("@Bonus", p.Bonus1));
                paramCollection.Add(new DBParameter("@Description", p.Description));
                paramCollection.Add(new DBParameter("@WEF_DATE", p.WEF_DATE));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertRawMilkTarrif", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public DataSet GetAllRawMilkTarrifDetails()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllRawMilkTarrifDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetRawMilkTarrifDetailsbyID(int rawid)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RawID", rawid));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetRawMilkTarrifDetailsbyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet CheckAvailability(Procurement p)
        {
            DataSet DS = new DataSet();
            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Category", p.Category));
            paramCollection.Add(new DBParameter("@TSL", p.TSL));
            paramCollection.Add(new DBParameter("@TSH", p.TSH));
            paramCollection.Add(new DBParameter("@WEF_DATE", p.WEF_DATE));
            DS = _DBHelper.ExecuteDataSet("Proc_Sp_CheckAvailability", paramCollection, CommandType.StoredProcedure);
            return DS;
        }

        public int InsertMilkCollectionDetails(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@CollectionID", p.MilkCollectionID));
                paramCollection.Add(new DBParameter("@Batch", p.Batch));
                paramCollection.Add(new DBParameter("@Session", p.Session));
                paramCollection.Add(new DBParameter("@Date", p.Date));
                paramCollection.Add(new DBParameter("@RouteID", p.RouteID));
                paramCollection.Add(new DBParameter("@SupplierID", p.SupplierID));
                paramCollection.Add(new DBParameter("@MilkInKG", p.MilkInKG));
                paramCollection.Add(new DBParameter("@MilkInLtr", p.MilkInLtr));
                paramCollection.Add(new DBParameter("@ActualMilkInLtr", p.ActualMilkInLtr));
                paramCollection.Add(new DBParameter("@FATPercentage", p.FATPercentage));
                paramCollection.Add(new DBParameter("@CLRReading", p.CLRReading));
                paramCollection.Add(new DBParameter("@FATInKG", p.FATInKG));

                paramCollection.Add(new DBParameter("@SNF", p.SNF));
                paramCollection.Add(new DBParameter("@SNFPercentage", p.SNFPercentage));
                paramCollection.Add(new DBParameter("@SNFInKG", p.SNFInKG));
                paramCollection.Add(new DBParameter("@TSPercentage", p.TSPercentage));
                paramCollection.Add(new DBParameter("@MilkCan", p.MilkCan));
                paramCollection.Add(new DBParameter("@TSInKg", p.TSInKg));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertMilkCollectionDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return result;
        }
        public DataSet GetAllMilkCollectionDetails()
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllMilkCollectionDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetMilkCollectionDetailsbyID(int milkcollectionid)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@MilkCollectionID", milkcollectionid));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetMilkCollectionDetailsbyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }


        public DataSet CalculateBill(Procurement p)
        {
            DataSet DS = new DataSet();
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@CenterID", p.CollectionID));
                paramCollection.Add(new DBParameter("@RouteID", p.RouteID));
                //paramCollection.Add(new DBParameter("@SupplierID", p.SupplierID));
                paramCollection.Add(new DBParameter("@FromDate", p.FomDate));
                paramCollection.Add(new DBParameter("@ToDate", p.ToDate));
                paramCollection.Add(new DBParameter("@Session", p.Session));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                DS = _DBHelper.ExecuteDataSet("Proc_SP_CalculateBill1", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return DS;
        }

        public int InsertBatchWiseMilkCollection(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@BatchWiseMilkCollectionID", p.BatchWiseMilkCollectionID));
                paramCollection.Add(new DBParameter("@BatchWiseMilkDisposalID", p.BatchWiseMilkDisposalID));
                paramCollection.Add(new DBParameter("@BatchNo", p.BatchNo));
                paramCollection.Add(new DBParameter("@Session", p.Session));
                paramCollection.Add(new DBParameter("@Date", p.Date));
                paramCollection.Add(new DBParameter("@MilkType", p.MilkType));
                paramCollection.Add(new DBParameter("@CenterID", p.CenterID));
                paramCollection.Add(new DBParameter("@MilkInKG", p.MilkInKG));
                paramCollection.Add(new DBParameter("@MilkInLtr", p.ActualMilkInLtr));
                paramCollection.Add(new DBParameter("@VehicalNo", p.VehicleNo));
                paramCollection.Add(new DBParameter("@Temp", p.Temp));
                paramCollection.Add(new DBParameter("@Acidity", p.Acidity));
                paramCollection.Add(new DBParameter("@SNFPercentage", p.SNFPercentage));
                paramCollection.Add(new DBParameter("@FATPercentage", p.FATPercentage));
                //paramCollection.Add(new DBParameter("@Time", p.Time));
                // paramCollection.Add(new DBParameter("@Disposal", p.Disposal));
                //paramCollection.Add(new DBParameter("@HandlingExcess", p.HandlingExcess));
                // paramCollection.Add(new DBParameter("@HandlingLoss", p.HandlingLoss));
                // paramCollection.Add(new DBParameter("@InternameConsumption", p.InternameConsumption));
                // paramCollection.Add(new DBParameter("@DamageMilk", p.DamageMilk));
                //  paramCollection.Add(new DBParameter("@Other", p.Other));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                paramCollection.Add(new DBParameter("@flag1", p.flag1));
                paramCollection.Add(new DBParameter("@flag2", p.flag2));
                paramCollection.Add(new DBParameter("@OpeningBalance", p.OpeningBalance));
                paramCollection.Add(new DBParameter("@ClosingBalance", p.ClosingBalance));
                paramCollection.Add(new DBParameter("@BalanceID", p.BalanceID));
                paramCollection.Add(new DBParameter("@Particularid", p.ID));
                result = _DBHelper.ExecuteNonQuery("Proc_SP_InsertBatchWiseMilkCollection", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                string msg = ex.ToString();
            }
            return result;
        }
        public DataSet GetAllBatchWiseMilkCollectionDetails(Procurement p)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Date", p.Date));
                paramCollection.Add(new DBParameter("@CenterID", p.CenterID));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllBatchWiseMilkCollectionDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return DS;
        }
        public DataSet GetBatchWiseMilkCollectionDetailsbyID(int milkcollectionid)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@MilkCollectionID", milkcollectionid));

                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetBatchWiseMilkCollectionDetailsbyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet GetOpeningClosingBal(DateTime date, int centerid)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Date", date));
                paramCollection.Add(new DBParameter("@CenterID", centerid));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetOpeningClosingBal", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {
            }
            return DS;
        }

        public int InsertMilkCollectionTransportDetails(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@MilkCollectionTransportID", p.MilkCollectionTransportID));
                paramCollection.Add(new DBParameter("@Date", p.Date));
                paramCollection.Add(new DBParameter("@VehicalNo", p.VehicleNo));
                paramCollection.Add(new DBParameter("@RouteID", p.RouteID));
                paramCollection.Add(new DBParameter("@MorningKM", p.MorningKM));
                paramCollection.Add(new DBParameter("@EveningKM", p.EveningKM));
                paramCollection.Add(new DBParameter("@Amount", p.InstallmentAmount));
                paramCollection.Add(new DBParameter("@Bata", p.Bata));
                paramCollection.Add(new DBParameter("@MorningInTime", p.MorningInTime));
                paramCollection.Add(new DBParameter("@MorningOutTime", p.MorningOutTime));
                paramCollection.Add(new DBParameter("@MorningInCan", p.MorningInCan));
                paramCollection.Add(new DBParameter("@MorningOutCan", p.MorningOutCan));
                paramCollection.Add(new DBParameter("@EveningInTime", p.EveningInTime));
                paramCollection.Add(new DBParameter("@EveningOutTime", p.EveningOutTime));
                paramCollection.Add(new DBParameter("@EveningInCan", p.EveningInCan));
                paramCollection.Add(new DBParameter("@EveningOutCan", p.EveningOutCan));
                paramCollection.Add(new DBParameter("@DriverName", p.DriverName));
                paramCollection.Add(new DBParameter("@Remarks", p.Remarks));
                paramCollection.Add(new DBParameter("@CreatedBy", p.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", p.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", p.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", p.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_sp_MilkCollectionTransport", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return result;
        }
        public DataSet GetAllMilkCollectionTransportDetails(Procurement p)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Date", p.Date));
                paramCollection.Add(new DBParameter("@VehicalNo", p.VehicleNo));
                paramCollection.Add(new DBParameter("@RouteID", p.RouteID));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetAllMilkCollectionTransportDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetMilkCollectionTransportDetailsbyID(int milkcollectionid)
        {

            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@MilkCollectionTransportID", milkcollectionid));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetMilkCollectionTransportDetailsbyID", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return DS;
        }

        public DataSet ViewMilkCollectionDetails(Procurement p)
        {
            DataSet DS = new DataSet();

            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Date", p.Date));
                paramCollection.Add(new DBParameter("@RouteID", p.RouteID));
                paramCollection.Add(new DBParameter("@Session", p.Session));

                DS = _DBHelper.ExecuteDataSet("Proc_SP_ViewMilkCollectionDetails", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return DS;
        }


        public DataSet PaymentSummary(Procurement p)
        {
            DataSet DS = new DataSet();

            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@fromdate", p.FomDate));
                paramCollection.Add(new DBParameter("@todate", p.ToDate));
                paramCollection.Add(new DBParameter("@Routeid", p.RouteID));

                DS = _DBHelper.ExecuteDataSet("Proc_SP_PaymentSummary", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string msg = ex.ToString();

            }
            return DS;
        }

        public int AllIncentiveTariff(Procurement p)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", p.ID));
                paramCollection.Add(new DBParameter("@QCat", p.QCat));
                paramCollection.Add(new DBParameter("@QLow", p.QLow));
                paramCollection.Add(new DBParameter("@QHigh", p.QHigh));
                paramCollection.Add(new DBParameter("@QIncentive", p.QIncentive));
                paramCollection.Add(new DBParameter("@Description", p.Description));
                paramCollection.Add(new DBParameter("@IsActive", p.IsActive));
                paramCollection.Add(new DBParameter("@flag", p.flag));

                result = _DBHelper.ExecuteNonQuery("Proc_sp_AllIncentiveTariff", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
            return result;

        }

        public DataSet GetExistingData(Procurement p1)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Date", p1.Date));
                paramCollection.Add(new DBParameter("@Session", p1.Session));
                paramCollection.Add(new DBParameter("@SupplierID", p1.SupplierID));
                DS = _DBHelper.ExecuteDataSet("SP_MilkCollectionExistData", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
            return DS;
        }
        public DataSet ClosingStock(Procurement p)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Date", p.ToDate));
                paramCollection.Add(new DBParameter("@Date1", p.ToDate1));
                paramCollection.Add(new DBParameter("@Date2", p.ToDate2));
                paramCollection.Add(new DBParameter("@flag", p.flag1));
                DS = _DBHelper.ExecuteDataSet("Proc_Sp_GetStock", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
            return DS;
        }

        public int UpdateStock(Procurement p)
        {

            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Date", p.ToDate));
                paramCollection.Add(new DBParameter("@abjust", p.abjust));
                result = _DBHelper.ExecuteNonQuery("Proc_CloseUpdateStock", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                string msg = ex.ToString();
            }
            return result;
        }
        public DataSet RawMilkPaymentListViaBankExcel(Procurement p)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@fromdate", p.FomDate));
                paramCollection.Add(new DBParameter("@todate", p.ToDate));
                paramCollection.Add(new DBParameter("@Routeid", p.RouteID));
                paramCollection.Add(new DBParameter("@BankName", p.BankName));
                paramCollection.Add(new DBParameter("@IFSCCode", p.IFSCCode));
                paramCollection.Add(new DBParameter("@flag", p.flag));
                DS = _DBHelper.ExecuteDataSet("Proc_sp_RawMilkPaymentListViaBankExcel", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                string msg = ex.ToString();

            }
            return DS;
        }
        public DataSet RawMilkPurchaseBillSummary(Procurement p)
        {
            DataSet DS = new DataSet();
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@fromdate", p.FomDate));
                paramCollection.Add(new DBParameter("@todate", p.ToDate));
                paramCollection.Add(new DBParameter("@Routeid", p.RouteID));
                paramCollection.Add(new DBParameter("@Supplierid", p.SupplierID));
                DS = _DBHelper.ExecuteDataSet("Proc_SP_RawMilkPurchaseBillSummary", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
            return DS;

        }
        public DataSet GetExistingData(int supplyierid, int routeid, string date1, string date2, string date3)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DataAcess.DBParameterCollection();
                paramcollection.Add(new DBParameter("@SupplierID", supplyierid));
                paramcollection.Add(new DBParameter("@RouteId", routeid));
                paramcollection.Add(new DBParameter("@date1", date1));
                paramcollection.Add(new DBParameter("@date2", date2));
                paramcollection.Add(new DBParameter("@date3", date3));
                DS = _DBHelper.ExecuteDataSet("proc_GetExistingData", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
            return DS;
        }
        public DataSet VehiclewiseOperationStatementReport(Procurement p)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@StartDate", p.FomDate));
                paramCollection.Add(new DBParameter("@EndDate", p.ToDate));
                paramCollection.Add(new DBParameter("@VehicalNo", p.VehicleNo));
                DS = _DBHelper.ExecuteDataSet("Proc_SP_VehiclewiseOperationReport", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception e)
            { string msg = e.ToString(); }

            return DS;

        }
        public DataSet GetExistingQcategory(string Qcategory)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Qcategory", Qcategory));
                DS = _DBHelper.ExecuteDataSet("sp_Proc_GetExistingQcategory", paramCollection, CommandType.StoredProcedure);

            }
            catch { }
            return DS;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using System.Data;
using Model;

namespace Bussiness
{
    public class ProcurementData
    {
        DBProcurement pdb = new DBProcurement();
        public int InsertMilkCenter(Procurement p)
        {

            return pdb.InsertMilkCenter(p);
        }

        public DataSet GetAllCenterDetails()
        {

            return pdb.GetAllCenterDetails();
        }
        public DataSet GetCenterDetailsByID(int CenterID)
        {

            return pdb.GetCenterDetailsByID(CenterID);
        }


        public int InsertSupplierPrfile(Procurement p)
        {

            return pdb.InsertSupplierPrfile(p);
        }
        public DataSet GetAllSupplierProfiles()
        {

            return pdb.GetAllSupplierProfiles();
        }

        public DataSet GetIncentivetariff()
        {
            return pdb.GetIncentivetariff();
        }

        public DataSet GetReceiveDisposeHeadMaster()
        {
            return pdb.GetReceiveDisposeHeadMaster();
        }

        public DataSet GetSupplierProfilebyID(int SupplierID)
        {

            return pdb.GetSupplierProfilebyID(SupplierID);
        }

        public DataSet GetVehicleType()
        {
            return pdb.GetVehicleType();
        }

        public int AllIncentiveTariff(Procurement p)
        {
            return pdb.AllIncentiveTariff(p);
        }

        public DataSet MilkCollectionTransportBill(Procurement p)
        {
            return pdb.MilkCollectionTransportBill(p);
        }

        public int InsertSupplierBankDetails(Procurement p)
        {

            return pdb.InsertSupplierBankDetails(p);
        }

        public DataSet MonthlyRawMilkPurchaseSummary(Procurement p)
        {
            return pdb.MonthlyRawMilkPurchaseSummary(p);
         }

        public DataSet GetTransactionDetails(Procurement p)
        {
            return pdb.GetTransactionDetails(p);

        }

        public int InsertReceiveandDisposeMaster(Procurement p)
        {
            return pdb.InsertReceiveandDisposeMaster(p);
        }

        public DataSet ConsolidatePayementSummary(Procurement p)
        {
            return pdb.ConsolidatePayementSummary(p);
        }

        public DataSet RawMilkPaymentListViaBank(Procurement p)
        {
            return pdb.RawMilkPaymentListViaBank(p);
        }

        public DataSet SupplierWiseMilkqtyandQlty(Procurement p)
        {
            return pdb.SupplierWiseMilkqtyandQlty(p);
        }

        public DataSet PaymentSummary(Procurement p)
        {
            return pdb.PaymentSummary(p);
        }

        public DataSet GetReceiveDisposeHeadMasterId(int ID)
        {
            return pdb.GetReceiveDisposeHeadMasterId(ID);
        }
        public int InsertVehicleType(Procurement p)
        {
            return pdb.InsertVehicleType(p);
        }

        public DataSet GetAllSupplierBankDetails()
        {

            return pdb.GetAllSupplierBankDetails();
        }
        public DataSet GetSupplierBankDetailsbyID(int SupplierID)
        {

            return pdb.GetSupplierBankDetailsbyID(SupplierID);
        }

        public int InsertSupplierLoanInfo(Procurement p)
        {

            return pdb.InsertSupplierLoanInfo(p);
        }
        public DataSet GetAllSupplierLoanInfo()
        {

            return pdb.GetAllSupplierLoanInfo();
        }
        public DataSet GetSupplierLoanInfobyID(int LoanID)
        {

            return pdb.GetSupplierLoanInfobyID(LoanID);
        }
        public int InsertSupplierAdvanceInfo(Procurement p)
        {

            return pdb.InsertSupplierAdvanceInfo(p);
        }
        public DataSet GetAllSupplierAdvanceInfo()
        {

            return pdb.GetAllSupplierAdvanceInfo();
        }
        public DataSet GetSupplierAdvanceInfobyID(int AdvanceID)
        {

            return pdb.GetSupplierAdvanceInfobyID(AdvanceID);
        }
        public int InsertSupplierRDInfo(Procurement p)
        {

            return pdb.InsertSupplierRDInfo(p);
        }
        public DataSet GetAllSupplierRDInfo()
        {

            return pdb.GetAllSupplierRDInfo();
        }
        public DataSet GetSupplierRDInfobyID(int RDID)
        {

            return pdb.GetSupplierRDInfobyID(RDID);
        }
        public int InsertSupplierSchemeInfo(Procurement p)
        {

            return pdb.InsertSupplierSchemeInfo(p);
        }
        public DataSet GetAllSupplierSchemeInfo()
        {

            return pdb.GetAllSupplierSchemeInfo();
        }
        public DataSet GetSupplierSchemeInfobyID(int SchemeID)
        {

            return pdb.GetSupplierSchemeInfobyID(SchemeID);
        }

        public int InsertVehicleMaster(Procurement p)
        {

            return pdb.InsertVehicleMaster(p);
        }
        public DataSet GetAllVehicleMasterDetails()
        {

            return pdb.GetAllVehicleMasterDetails();
        }
        public DataSet GetVehicleMasterDetailsbyID(int vehicleid)
        {

            return pdb.GetVehicleMasterDetailsbyID(vehicleid);
        }

        public DataSet GetVehicleTypeById(int typeID)
        {
            return pdb.GetVehicleTypeById(typeID);
        }

        public int InsertVehicleDetails(Procurement p)
        {

            return pdb.InsertVehicleDetails(p);
        }
        public DataSet GetAllVehicleDetails()
        {

            return pdb.GetAllVehicleDetails();
        }
        public DataSet GetVehicleDetailsbyID(int vehicleid)
        {

            return pdb.GetVehicleDetailsbyID(vehicleid);
        }

        public int InsertRawMilkTarrif(Procurement p)
        {

            return pdb.InsertRawMilkTarrif(p);
        }
        public DataSet GetAllRawMilkTarrifDetails()
        {

            return pdb.GetAllRawMilkTarrifDetails();
        }
        public DataSet GetRawMilkTarrifDetailsbyID(int vehicleid)
        {

            return pdb.GetRawMilkTarrifDetailsbyID(vehicleid);
        }
        public DataSet CheckAvailability(Procurement p)
        {
            return pdb.CheckAvailability(p);
        }

        public int InsertMilkCollectionDetails(Procurement p)
        {

            return pdb.InsertMilkCollectionDetails(p);
        }
        public DataSet GetAllMilkCollectionDetails()
        {

            return pdb.GetAllMilkCollectionDetails();
        }
        public DataSet GetMilkCollectionDetailsbyID(int milkcollectionid)
        {

            return pdb.GetMilkCollectionDetailsbyID(milkcollectionid);
        }

        public DataSet CalculateBill(Procurement p)
        {

            return pdb.CalculateBill(p);
        }

        public int InsertBatchWiseMilkCollection(Procurement p)
        {

            return pdb.InsertBatchWiseMilkCollection(p);
        }
        public DataSet GetAllBatchWiseMilkCollectionDetails(Procurement p)
        {

            return pdb.GetAllBatchWiseMilkCollectionDetails(p);
        }
        public DataSet GetBatchWiseMilkCollectionDetailsbyID(int milkcollectionid)
        {

            return pdb.GetBatchWiseMilkCollectionDetailsbyID(milkcollectionid);
        }

        public DataSet GetOpeningClosingBal(DateTime date, int centerid)
        {
            return pdb.GetOpeningClosingBal(date, centerid);
        }

        public int InsertMilkCollectionTransportDetails(Procurement p)
        {

            return pdb.InsertMilkCollectionTransportDetails(p);
        }
        public DataSet GetAllMilkCollectionTransportDetails()
        {

            return pdb.GetAllMilkCollectionTransportDetails();
        }
        public DataSet GetMilkCollectionTransportDetailsbyID(int milkcollectionid)
        {

            return pdb.GetMilkCollectionTransportDetailsbyID(milkcollectionid);
        }

        public DataSet ViewMilkCollectionDetails(Procurement p)
        {
            return pdb.ViewMilkCollectionDetails(p);
        }

        public DataSet GetIncentiveTariffbyID(int incentivetariffid)
        {
            return pdb.GetIncentiveTariffbyID(incentivetariffid);
        }

        public DataSet GetAllBatchWiseMilkCollectionDetail()
        {
            return pdb.GetAllBatchWiseMilkCollectionDetail();
        }

        public DataSet GetRouteSchemeBonusbyroute(int routeID)
        {
            return pdb.GetRouteSchemeBonusbyroute(routeID);
        }

        public DataSet GetBatchWiseMilkCollection(int milkcollectionid, string flag)
        {
            return pdb.GetBatchWiseMilkCollection(milkcollectionid, flag);
        }

        public int AddTransaction(int SupplierID, int RouteID, string PaymentDateTime, DateTime FomDate, DateTime ToDate, double Amount, double Bonus, decimal Scheme, double RDAmount, double canloan, double casloan, double bankloan, double netamt)
        {
            return pdb.AddTransaction(SupplierID, RouteID, PaymentDateTime, FomDate, ToDate, Amount, Bonus, Scheme, RDAmount, canloan, casloan, bankloan, netamt);
        }

        public DataSet GetBataandAmountOfVehicleonbasisofmodelid(int modelid,int vehicleno)
        {
            return pdb.GetBataandAmountOfVehicleonbasisofmodelid(modelid, vehicleno);
        }
    }
}
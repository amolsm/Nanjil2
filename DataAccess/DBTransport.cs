using DataAcess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class DBTransport
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        public DataSet GetTransportBrandInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetTansportBrandInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetTransportBrandInfoByID(int trBrandID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@trBrandID", trBrandID));
                DS = _DBHelper.ExecuteDataSet("GetTransportBrandInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddTransportBrandInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@trBrandID", transport.trBrandID));
                paramCollection.Add(new DBParameter("@trBrandName", transport.trBrandName));
                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_Add_TransportBrandInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public int AddTransportModelInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@trModelID", transport.trModelID));
                paramCollection.Add(new DBParameter("@trModelName", transport.trModelName));
                paramCollection.Add(new DBParameter("@trBrandID", transport.trBrandID));
                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_Add_TransportModelInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (SqlException ex)
            {
                int expectioncode = 2627;
                if (ex.Number == expectioncode)
                {
                    result -= expectioncode;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        public DataSet GetTransportModelInfoByID(int trModelID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@trModelID", trModelID));
                DS = _DBHelper.ExecuteDataSet("GetTransportModelInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetTransportModelInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetTansportModelInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetConfigInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetConfigInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetConfigInfoByID(int ID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", ID));
                DS = _DBHelper.ExecuteDataSet("sp_GetConfigInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddConfigInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", transport.ID));
                paramCollection.Add(new DBParameter("@configname", transport.configname));
                paramCollection.Add(new DBParameter("@configkey", transport.configkey));
                paramCollection.Add(new DBParameter("@configvalue", transport.configvalue));
                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddConfigInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (SqlException ex)
            {
                int expectioncode = 2627;
                if (ex.Number == expectioncode)
                {
                    result -= expectioncode;
                }
                else
                {
                    result = 0;
                }

            }
            return result;
        }

        public int AddVehicleRouteMapInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@trVRMID", transport.trVRMID));
                paramCollection.Add(new DBParameter("@trVehicleNo", transport.trVehicleNo));
                paramCollection.Add(new DBParameter("@trRouteID", transport.trRouteID));
                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddVehicleRouteMapInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }

        public DataSet GetVehicleRouteMapInfoByID(int trVRMID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@trVRMID", trVRMID));
                DS = _DBHelper.ExecuteDataSet("Sp_GetVehicleRouteMapInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetVehicleRouteMapInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleRouteMapInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public int AddVehicleTariffInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@V_TrfID", transport.V_TrfID));
                paramCollection.Add(new DBParameter("@tr_model_Id", transport.trModelID));
                paramCollection.Add(new DBParameter("@tr_option", transport.troption));
                paramCollection.Add(new DBParameter("@amt", transport.tariffamt));
                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddVehicleTariffInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }


        public DataSet GetVehicleTariffInfoByID(int V_TrfID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@V_TrfID", V_TrfID));
                DS = _DBHelper.ExecuteDataSet("Sp_GetVehicleTariffInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetVehicleTariffInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleTariffInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public int AddVehicleOperationInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VOp", transport.VOp));
                paramCollection.Add(new DBParameter("@TM_Id", transport.TM_Id));
                paramCollection.Add(new DBParameter("@StartDate", transport.StartDate));
                paramCollection.Add(new DBParameter("@StartTime", transport.StartTime));
            
                paramCollection.Add(new DBParameter("@RouteID", transport.RouteID));
                paramCollection.Add(new DBParameter("@StartKm", transport.StartKm));
             
                paramCollection.Add(new DBParameter("@FirstDriver", transport.FirstDriver));
                paramCollection.Add(new DBParameter("@SecondDriver", transport.SecondDriver));
                paramCollection.Add(new DBParameter("@OperationType", transport.operationtype));

                paramCollection.Add(new DBParameter("@Bata", transport.bata));
                paramCollection.Add(new DBParameter("@SalesBata", transport.salesbata));
             
                paramCollection.Add(new DBParameter("@SalesmanId", transport.SalesmanId));
                paramCollection.Add(new DBParameter("@SecondSalesmanId", transport.SecondSalesmanId));
              
                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));


                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddVehicleOperationInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }

        public DataSet GetVehicleOperationInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleOperationInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetVehicleOperationInfoByID(int V_TrfID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VOp", V_TrfID));
                DS = _DBHelper.ExecuteDataSet("Sp_GetVehicleOperationInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public int AddVehicleFuelDetailsInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Tr_FuelID", transport.Tr_FuelID));
                paramCollection.Add(new DBParameter("@TM_Id", transport.TM_Id));
                paramCollection.Add(new DBParameter("@FuelRefielDate", transport.FuelRefielDate));
                paramCollection.Add(new DBParameter("@FuelRefielTime", transport.Time));
                paramCollection.Add(new DBParameter("@FuelType", transport.FuelType));
                paramCollection.Add(new DBParameter("@FuelQty", transport.FuelQty));
                paramCollection.Add(new DBParameter("@UnitType", transport.UnitType));
                paramCollection.Add(new DBParameter("@RegisterdPump", transport.Registerpump));
                paramCollection.Add(new DBParameter("@Nonregisterpump", transport.NonRegisterpump));
                paramCollection.Add(new DBParameter("@FuelCostprice", transport.fuelcostprice));
                paramCollection.Add(new DBParameter("@Amount", transport.amount));
                paramCollection.Add(new DBParameter("@ReceiptNo", transport.receiptno));

                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                //paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddVehicleFuelDetailsInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }

        public DataSet GetVehicleFuelDetailsInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleFuelDetailsInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        public DataSet GetVehicleFuelDetailsInfoByID(int Tr_FuelID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Tr_FuelID", Tr_FuelID));
                DS = _DBHelper.ExecuteDataSet("Sp_GetVehicleFuelDetailsInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public int AddFuelPumpMasterInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", transport.ID));
                paramCollection.Add(new DBParameter("@fuelpumpname", transport.fuelpumpname));
                paramCollection.Add(new DBParameter("@pumpaddress", transport.pumpaddress));
                paramCollection.Add(new DBParameter("@routeId", transport.RouteID));

                paramCollection.Add(new DBParameter("@contractstartdate", transport.contractstartdate));
                paramCollection.Add(new DBParameter("@contractenddate", transport.contractenddate));
                paramCollection.Add(new DBParameter("@registrationno", transport.NonRegisterpump));
                paramCollection.Add(new DBParameter("@contractamt", transport.contractamt));
                paramCollection.Add(new DBParameter("@fuelcompanyId", transport.fuelcompanyId));

                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddFuelPumpMasterInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }

        public DataSet GetFuelPumpDetailsInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetFuelPumpDetailsInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }
        public DataSet GetFuelPumpDetailsInfoByID(int Tr_FuelID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", Tr_FuelID));
                DS = _DBHelper.ExecuteDataSet("GetFuelPumpDetailsInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public int AddVehicleMaintenanceDetailsInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", transport.ID));
                paramCollection.Add(new DBParameter("@TM_Id", transport.TM_Id));
                paramCollection.Add(new DBParameter("@MaintenanceType", transport.MaintenanceType));
                paramCollection.Add(new DBParameter("@M_Description", transport.M_Description));
                paramCollection.Add(new DBParameter("@DateGiven", transport.DateGiven));
                paramCollection.Add(new DBParameter("@Datereceived", transport.datereceived));
                paramCollection.Add(new DBParameter("@NextMaintainenceDate", transport.datereceived));

                paramCollection.Add(new DBParameter("@MaintanceCost", transport.maintenanceamt));
                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddVehicleMaintenanceDetailsInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }


        public DataSet GetVehicleMaintenanceInfoByID(int ID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", ID));
                DS = _DBHelper.ExecuteDataSet("GetVehicleMaintenanceInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetVehicleMaintenanceInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleMaintenanceInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddVehiclePUCDetailsInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", transport.ID));
                paramCollection.Add(new DBParameter("@TM_Id", transport.TM_Id));

                paramCollection.Add(new DBParameter("@PUCDate", transport.pucdate));

                paramCollection.Add(new DBParameter("@NextPucDate", transport.pucenddate));



                paramCollection.Add(new DBParameter("@PucAmt", transport.pucamt));

                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddVehicle_PUCDetailsInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }


        public DataSet GetVehiclePUCInfoByID(int ID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", ID));
                DS = _DBHelper.ExecuteDataSet("GetVehiclePUCInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetVehiclePUCInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehiclePUCInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddVehicleInsuanceDetailsInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", transport.ID));
                paramCollection.Add(new DBParameter("@TM_Id", transport.TM_Id));



                paramCollection.Add(new DBParameter("@Insprovider", transport.InsProvider));
                paramCollection.Add(new DBParameter("@Inspolicyno", transport.InsPolicyNo));
                paramCollection.Add(new DBParameter("@Inspaiddate", transport.InspaidDate));
                paramCollection.Add(new DBParameter("Insnextduedate", transport.Insnextduedate));

                paramCollection.Add(new DBParameter("@InsuranceAmt", transport.insuranceamt));

                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddVehicle_InsuanceDetailsInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }


        public DataSet GetVehicleInsuranceInfoByID(int ID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", ID));
                DS = _DBHelper.ExecuteDataSet("GetVehicleInsuranceInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public DataSet GetVehicleInsuranceInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleInsuranceInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }



        //Transport Reports

        public DataSet FuelListDateWise(string StartDate, string EndDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@FuelRefielStartDate", StartDate));
            paramCollection.Add(new DBParameter("@FuelRefielEndDate", EndDate));

            return _DBHelper.ExecuteDataSet("sp_TransportReportFuelListDatewise", paramCollection, CommandType.StoredProcedure);
        }


        public DataSet VehicleReportRoutewise(string StartDate, string EndDate, int routeId)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));
            paramCollection.Add(new DBParameter("@routeId", routeId));

            return _DBHelper.ExecuteDataSet("Sp_TransportVehicleReportRoutewise", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet VehicleRouteOperationSummary(string StartDate, string EndDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));


            return _DBHelper.ExecuteDataSet("Sp_VehicleRouteOperationSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet InternalReportOfVehicleSection(string StartDate, string EndDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@StartDate", StartDate));
            paramCollection.Add(new DBParameter("@EndDate", EndDate));


            return _DBHelper.ExecuteDataSet("Sp_InternalReportOfVehicleSection", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetScheduleInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetTransportRouteScheduleInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetScheduleByID(int ID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", ID));
                DS = _DBHelper.ExecuteDataSet("sp_GetTransportScheduleByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddTransportScheduleInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", transport.ID));
                paramCollection.Add(new DBParameter("@RouteID", transport.RouteID));
                paramCollection.Add(new DBParameter("@scheduleOuttime", transport.scheduleOuttime));
                paramCollection.Add(new DBParameter("@scheduleIntime", transport.scheduleIntime));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddTransportScheduleInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (SqlException ex)
            {
                int expectioncode = 2627;
                if (ex.Number == expectioncode)
                {
                    result -= expectioncode;
                }
                else
                {
                    result = 0;
                }

            }
            return result;
        }

        public DataSet GetVehicleJOBCardInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleJOBCardInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetJOBCardInfoByID(int ID)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", ID));
                DS = _DBHelper.ExecuteDataSet("Sp_GetJOBCardInfoByID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


        public int AddVehicleJOBCardInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ID", transport.ID));
                paramCollection.Add(new DBParameter("@VOp", transport.VOp));
                paramCollection.Add(new DBParameter("@BreakeComp", transport.Brake));
                paramCollection.Add(new DBParameter("@LightsComp", transport.Light));
                paramCollection.Add(new DBParameter("@TyreConComp", transport.TyreCon));
                paramCollection.Add(new DBParameter("@DamagesComp", transport.damage));
                paramCollection.Add(new DBParameter("@OthersComp", transport.other));

                paramCollection.Add(new DBParameter("@oillevel", transport.oillevel));
                paramCollection.Add(new DBParameter("@battery", transport.battery));
                paramCollection.Add(new DBParameter("@crownjointsound", transport.crownjointsound));
                paramCollection.Add(new DBParameter("@clutchcon", transport.clutchcon));
                paramCollection.Add(new DBParameter("@stearingvobling", transport.stearingvobling));
                paramCollection.Add(new DBParameter("@suspension", transport.suspension));
                paramCollection.Add(new DBParameter("@gearbox", transport.gearbox));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddJOBCardInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }

        public DataSet GetOutOperationDetailsbyVechileId(int routeid, int Vehicleid)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteId", routeid));
                paramCollection.Add(new DBParameter("@VechicleId", Vehicleid));
                DS = _DBHelper.ExecuteDataSet("sp_GetOutOperationProductSupply", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }

        public DataSet GetVehicleProductOutOperationInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleProductOutOperationInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddVehicleProductOutOperationInfo(Transports transport)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VOp", transport.VOp));
                //paramCollection.Add(new DBParameter("@TM_Id", transport.TM_Id));
                paramCollection.Add(new DBParameter("@StartDate", transport.StartDate));
                paramCollection.Add(new DBParameter("@StartTime", transport.StartTime));
               
                //paramCollection.Add(new DBParameter("@RouteID", transport.RouteID));
                paramCollection.Add(new DBParameter("@StartKm", transport.StartKm));
                paramCollection.Add(new DBParameter("@ScheduleOutTime", transport.scheduleOuttime));
                paramCollection.Add(new DBParameter("@ScheduleInTime", transport.scheduleIntime));
                paramCollection.Add(new DBParameter("@FirstDriver", transport.FirstDriver));
                paramCollection.Add(new DBParameter("@SecondDriver", transport.SecondDriver));
                paramCollection.Add(new DBParameter("@OperationType", transport.operationtype));

                paramCollection.Add(new DBParameter("@Bata", transport.bata));
                paramCollection.Add(new DBParameter("@SalesBata", transport.salesbata));
               
                paramCollection.Add(new DBParameter("@SalesmanId", transport.SalesmanId));
                paramCollection.Add(new DBParameter("@SecondSalesmanId", transport.SecondSalesmanId));
                paramCollection.Add(new DBParameter("@DispatchId", transport.dispatchId));
                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", transport.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", transport.Createddate));
                paramCollection.Add(new DBParameter("@IsActive", transport.IsActive));

              
                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_AddVehicleForProductOutOperationInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }


        public DataSet GetVehicleOperationforproductbyId(int VOp)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VOp", VOp));
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleOperationforproductbyId", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetINOperationDetailsbyVechileId(int Vehicleid)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
             
                paramCollection.Add(new DBParameter("@VechicleId", Vehicleid));
                DS = _DBHelper.ExecuteDataSet("sp_GetINOperationDetailsbyVechileId", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }

        public DataSet GetVehicleInOperationInfo()
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleInOperationInfo", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public DataSet GetVehicleInOperationforbyId(int VOp)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VOp", VOp));
                DS = _DBHelper.ExecuteDataSet("sp_GetVehicleInOperationforbyId", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddVehicleInOperationInfo(Transports transport)
        {
          
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@VOp", transport.VOp));
                paramCollection.Add(new DBParameter("@EndDate", transport.EndDate));
                paramCollection.Add(new DBParameter("@EndTime", transport.EndTime));
             
                paramCollection.Add(new DBParameter("@EndKm", transport.EndKm));
                paramCollection.Add(new DBParameter("@TollPaid", transport.tollpaid));
             
                paramCollection.Add(new DBParameter("@ModifiedBy", transport.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", transport.ModifiedDate));
               

                paramCollection.Add(new DBParameter("@FuelTypeId", transport.FuelType));
                paramCollection.Add(new DBParameter("@FuelLtr", transport.FuelQty));
                paramCollection.Add(new DBParameter("@fuelprice", transport.fuelprice));
               
                paramCollection.Add(new DBParameter("@fuelamt", transport.fuelamt));
                paramCollection.Add(new DBParameter("@fuelBillNo", transport.fuelBillNo));
                paramCollection.Add(new DBParameter("@Registerpump", transport.Registerpump));

                paramCollection.Add(new DBParameter("@flag", transport.flag));
                result = _DBHelper.ExecuteNonQuery("sp_AddVehicleInOperationInfo", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }

        public DataSet FuelDailyUses(string StartDate, string EndDate)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@FuelRefielStartDate", StartDate));
            paramCollection.Add(new DBParameter("@FuelRefielEndDate", EndDate));

            return _DBHelper.ExecuteDataSet("sp_TransportReportFuelTotal", paramCollection, CommandType.StoredProcedure);
        }
    }
}
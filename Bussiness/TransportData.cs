using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class TransportData
    {
        DBTransport dbtransport;
        DataSet DS;
        public DataSet GetTransportBrandInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetTransportBrandInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public int AddTransportBrandInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddTransportBrandInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetTransportBrandInfoByID(int trBrandID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetTransportBrandInfoByID(trBrandID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public int AddTransportModelInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddTransportModelInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetTransportModelInfoByID(int trModelID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetTransportModelInfoByID(trModelID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet GetTransportModelInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetTransportModelInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetConfigInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetConfigInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetConfigInfoByID(int ID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetConfigInfoByID(ID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int AddConfigInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddConfigInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int AddVehicleRouteMapInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehicleRouteMapInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetVehicleRouteMapInfoByID(int trVRMID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleRouteMapInfoByID(trVRMID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet GetVehicleRouteMapInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleRouteMapInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int AddVehicleTariffInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehicleTariffInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetVehicleTariffInfoByID(int V_TrfID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleTariffInfoByID(V_TrfID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet GetVehicleTariffInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleTariffInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int AddVehicleOperationInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehicleOperationInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetVehicleOperationInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleOperationInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetVehicleOperationInfoByID(int trVRMID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleOperationInfoByID(trVRMID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddVehicleFuelDetailsInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehicleFuelDetailsInfo(transport);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public DataSet GetVehicleFuelDetailsInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleFuelDetailsInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetVehicleFuelDetailsInfoByID(int Tr_FuelID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleFuelDetailsInfoByID(Tr_FuelID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public int AddFuelPumpMasterInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddFuelPumpMasterInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetFuelPumpDetailsInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetFuelPumpDetailsInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataSet GetFuelPumpDetailsInfoByID(int Tr_FuelID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetFuelPumpDetailsInfoByID(Tr_FuelID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddVehicleMaintenanceDetailsInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehicleMaintenanceDetailsInfo(transport);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public DataSet GetVehicleMaintenanceInfoByID(int ID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleMaintenanceInfoByID(ID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet GetVehicleMaintenanceInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleMaintenanceInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public int AddVehiclePUCDetailsInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehiclePUCDetailsInfo(transport);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public DataSet GetVehiclePUCInfoByID(int ID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehiclePUCInfoByID(ID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet GetVehiclePUCInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehiclePUCInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public int AddVehicleInsuanceDetailsInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehicleInsuanceDetailsInfo(transport);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public DataSet GetVehicleInsuranceInfoByID(int ID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleInsuranceInfoByID(ID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet GetVehicleInsuranceInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleInsuranceInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Transport reports

        public DataSet FuelListDateWise(string StartDate, string EndDate)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.FuelListDateWise(StartDate, EndDate);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataSet VehicleReportRoutewise(string StartDate, string EndDate, int routeId)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.VehicleReportRoutewise(StartDate, EndDate, routeId);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataSet VehicleRouteOperationSummary(string StartDate, string EndDate)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.VehicleRouteOperationSummary(StartDate, EndDate);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataSet InternalReportOfVehicleSection(string StartDate, string EndDate)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.InternalReportOfVehicleSection(StartDate, EndDate);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataSet GetScheduleInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetScheduleInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetScheduleByID(int ID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetScheduleByID(ID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int AddTransportScheduleInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddTransportScheduleInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetVehicleJOBCardInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleJOBCardInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetJOBCardInfoByID(int ID)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetJOBCardInfoByID(ID);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddVehicleJOBCardInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehicleJOBCardInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetOutOperationDetailsbyVechileId(int routeid, int Vehicleid)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetOutOperationDetailsbyVechileId(routeid, Vehicleid);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet GetVehicleProductOutOperationInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleProductOutOperationInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int AddVehicleProductOutOperationInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehicleProductOutOperationInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetVehicleOperationforproductbyId(int VOp)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleOperationforproductbyId(VOp);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet GetINOperationDetailsbyVechileId(int Vehicleid)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetINOperationDetailsbyVechileId(Vehicleid);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet GetVehicleInOperationInfo()
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleInOperationInfo();
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet GetVehicleInOperationforbyId(int VOp)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.GetVehicleInOperationforbyId(VOp);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddVehicleInOperationInfo(Transports transport)
        {
            dbtransport = new DBTransport();
            int Result = 0;
            try
            {
                Result = dbtransport.AddVehicleInOperationInfo(transport);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet FuelDailyUses(string StartDate, string EndDate)
        {
            dbtransport = new DBTransport();
            DS = new DataSet();

            try
            {
                DS = dbtransport.FuelDailyUses(StartDate, EndDate);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
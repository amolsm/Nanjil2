using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Transports
    {
        public int trBrandID { get; set; }

        public string trBrandName { get; set; }

        public int CreatedBy { get; set; }

        public string Createddate { get; set; }

        public int ModifiedBy { get; set; }

        public string ModifiedDate { get; set; }

        public string flag { get; set; }

        public bool IsActive { get; set; }



        public int trModelID { get; set; }
        public string trModelName { get; set; }


        public int ID { get; set; }
        public string configname { get; set; }
        public string configkey { get; set; }
        public string configvalue { get; set; }

        public int trVRMID { get; set; }

        public int trVehicleNo { get; set; }

        public int trRouteID { get; set; }

        public int V_TrfID { get; set; }

        public double tariffamt { get; set; }

        public int VOp { get; set; }

        public int TM_Id { get; set; }

        public string StartDate { get; set; }

        public string StartTime { get; set; }

        public string EndDate { get; set; }

        public string EndTime { get; set; }

        public int RouteID { get; set; }

        public decimal StartKm { get; set; }

        public decimal EndKm { get; set; }

        public int FirstDriver { get; set; }

        public int SecondDriver { get; set; }

        public int operationtype { get; set; }

        public decimal bata { get; set; }

        public double tollpaid { get; set; }

        public int Tr_FuelID { get; set; }

        public string FuelRefielDate { get; set; }

        public string Time { get; set; }

        public double FuelQty { get; set; }

        public int UnitType { get; set; }

        public int Registerpump { get; set; }

        public string NonRegisterpump { get; set; }

        public double amount { get; set; }

        public string receiptno { get; set; }

        public int FuelType { get; set; }

        public string fuelpumpname { get; set; }

        public string contractstartdate { get; set; }

        public string contractenddate { get; set; }

        public string pumpaddress { get; set; }

        public double contractamt { get; set; }

        public decimal fuelcostprice { get; set; }

        public int MaintenanceType { get; set; }

        public string M_Description { get; set; }

        public string DateGiven { get; set; }

        public string datereceived { get; set; }

        public string pucdate { get; set; }

        public string pucenddate { get; set; }

        public double insuranceamt { get; set; }

        public double pucamt { get; set; }

        public double maintenanceamt { get; set; }

        public int InsProvider { get; set; }

        public string InsPolicyNo { get; set; }

        public string InspaidDate { get; set; }

        public string Insnextduedate { get; set; }

        public int fuelcompanyId { get; set; }

        public int troption { get; set; }

        public int SalesmanId { get; set; }

        public string Brake { get; set; }

        public string Light { get; set; }

        public string TyreCon { get; set; }

        public string damage { get; set; }

        public int dispatchId { get; set; }

        public string other { get; set; }

        public string oillevel { get; set; }

        public string battery { get; set; }

        public string crownjointsound { get; set; }

        public string clutchcon { get; set; }

        public string stearingvobling { get; set; }

        public string suspension { get; set; }

        public string gearbox { get; set; }

        public decimal salesbata { get; set; }

        public string scheduleIntime { get; set; }
        public string scheduleOuttime { get; set; }

        public double fuelamt { get; set; }

        public int fuelBillNo { get; set; }

        public int SecondSalesmanId { get; set; }

        public decimal fuelprice { get; set; }
    }
}
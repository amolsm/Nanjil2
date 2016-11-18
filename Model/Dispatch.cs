using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Dispatch : User
    {
        public int OrderId { get; set; }
        public int OrderDetailsId { get; set; }
        public int CategoryId { get; set; }
        public string DispatchDate { get; set; }
        public DateTime DispatchDateTime { get; set; }
        public int RouteID { get; set; }
        public string RouteName { get; set; }
        public string OrderDate { get; set; }
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public string ProductName { get; set; }
        public string CommodityName { get; set; }
        public double Quantity { get; set; }
        public double UnitCost { get; set; }
        public double Total { get; set; }

        public double ReturnSample { get; set; }
        public double ReturnSpotDamage { get; set; }
        public double ReturnGoodQuality { get; set; }

        public int DispatchId { get; set; }
        public int SalesmanFirstId { get; set; }
        public int SalesmanSecondId { get; set; }
        public int DriverFirstId { get; set; }
        public int DriverSecondId { get; set; }
        public int VehicleId { get; set; }

        public int Trays { get; set; }
        public int IceBox { get; set; }
        public int Cartons { get; set; }
        public int OtherDisp { get; set; }


        public int TM_Id { get; set; }
        public string VehicleNo { get; set; }
        public int VehicleBrand { get; set; }
        public int Veh_Model { get; set; }
        public string Veh_Year { get; set; }
        public string Veh_Type { get; set; }
        public string Veh_Reg { get; set; }
        public string Veh_ChassisNo { get; set; }
        public string Veh_EngineNo { get; set; }
        public int Veh_InsProvider { get; set; }
        public string Veh_InsPolicyNo { get; set; }
        public string Veh_InsDue { get; set; }
        public string Veh_PUSDue { get; set; }
        public string Veh_OwnershipType { get; set; }
        public string Veh_OwnerName { get; set; }
        public string Veh_ContactNo { get; set; }
        public string Veh_OwnerAddress { get; set; }
        public int Veh_FuelType { get; set; }

        public string Veh_InsStart { get; set; }

        public string Veh_InsLast { get; set; }

        public double Veh_InsAmount { get; set; }

        public int BankId { get; set; }

        public string BankAc { get; set; }

        public string comment { get; set; }

        public bool loanpaid { get; set; }

        public bool shemepaid { get; set; }

        public bool incentivepaid { get; set; }

        public bool depositrefund { get; set; }

        public bool freezerreturn { get; set; }

        public bool Chillpad { get; set; }

        public bool Traysreturn { get; set; }

        public int closedby { get; set; }

        public string tokanid { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Invoice:Product
    {
        public int orderid { get; set; }

        public int BillSeq { get; set; }
        private string  _tokanId;
        private double  _qty;
        private double _unitCost;
        private double _totalCoast;
        private string _orderDate;
        private bool _ShecemeApplied;
        private string _CreatedDate;
        private int _ROuteID;
        private int _EmployeeID;
        private int _SaleEmployeeId;
       

        private double _SchemeAmount;
        private double _TotalSchemeAmount;

        public string AgentCode { get; set; }
        public int SaleEmployeeId
        {
            get { return _SaleEmployeeId; }
            set { _SaleEmployeeId = value; }
        }
        public string TokanId
        {
            get { return _tokanId; }
            set { _tokanId = value; }
        }
        public double qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public double UnitCost
        {
            get { return _unitCost; }
            set { _unitCost = value; }

        }
        public double SchemeAmount
        {
            get { return _SchemeAmount; }
            set { _SchemeAmount = value; }

        }
        public double TotalSchemeAmount
        {
            get { return _TotalSchemeAmount; }
            set { _TotalSchemeAmount = value; }

        }
        public double totalCoast
        {
            get { return _totalCoast; }
            set { _totalCoast = value; }
        }
        public string orderDate
        {
            
            get { return _orderDate; }
            set { _orderDate = value; }
 
        }
        public bool ShecemeApplied
        {
            get { return _ShecemeApplied; }
            set { _ShecemeApplied = value; } 
        }
        public string CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; } 
 
        }
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        public int ROuteID
        {
            get { return _ROuteID; }
            set { _ROuteID = value; }
        }

        public int SlabID { get; set; }

        public int CurrentBoothID { get; set; }

        public string PaymentMode { get; set; }
    }
}
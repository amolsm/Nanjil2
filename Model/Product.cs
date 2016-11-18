using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Product : User
    {
        private string _TypeName;
        private int _TypeID;
        private string _Commodity;
        private int _CommodityID;
        private int _BrandID;
        private string _BrandName;

        private int _SlabID;
        private string _SlabName;

        private double _Quantity;
        private double _Prize;
        private int _productID;
        private string _ProductName;
        private string _ProductCode;
        private string _SlabCode;
        private int _StateID;

        private int _UnitID;
        private int _AgencyID;
        public string AgentName { get; set; }
        private string _MonthelyCollection;
        private string _TillDateColletion;
        private int _BindSlabID;
        private int _orderType;


        private string _BankName;
        private string _BranchName;
        private string _BranchAddress;
        private string _IFSCCode;
        public string flag;
        private int _Id;

        private string _Country;
        private string _State;
        private string _District;
        private string _City;
        private int _LocId;
        private int _EmployeeId;
        private string _orderDate;

        private int _DesigId;
        private string _DesigName;
        private string _Descriptions;
        private string _Responsibility;

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public double Return { get; set; }
        public double Replace { get; set; }
        public double SpotDamage { get; set; }
        public double Incentive { get; set; }
        public double Other { get; set; }


        public string MonthelyCollection
        {
            get
            {
                return _MonthelyCollection;
            }
            set
            {
                _MonthelyCollection = value;
            }
        }
        public string TillDateColletion
        {
            get
            {
                return _TillDateColletion;
            }
            set
            {
                _TillDateColletion = value;
            }
        }

        public int BindSlabID
        {
            get
            {
                return _BindSlabID;
            }
            set
            {
                _BindSlabID = value;
            }
        }
        public int ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
            }
        }
        public int AgencyID
        {
            get
            {
                return _AgencyID;
            }
            set
            {
                _AgencyID = value;
            }
        }
        public int UnitID
        {
            get
            {
                return _UnitID;
            }
            set
            {
                _UnitID = value;
            }
        }


        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
            }
        }
        public string SlabCode
        {
            get
            {
                return _SlabCode;
            }
            set
            {
                _SlabCode = value;
            }
        }
        public string ProductCode
        {
            get
            {
                return _ProductCode;
            }
            set
            {
                _ProductCode = value;
            }
        }
        public int StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }
        public string TypeName
        {
            get
            {
                return _TypeName;
            }
            set
            {
                _TypeName = value;
            }
        }
        public int TypeID
        {
            get
            {
                return _TypeID;
            }
            set
            {
                _TypeID = value;
            }
        }
        public string Commodity
        {
            get
            {
                return _Commodity;
            }
            set
            {
                _Commodity = value;
            }
        }
        public int CommodityID
        {
            get
            {
                return _CommodityID;
            }
            set
            {
                _CommodityID = value;
            }
        }

        public int BrandID
        {
            get
            {
                return _BrandID;
            }
            set
            {
                _BrandID = value;
            }
        }
        public string BrandName
        {
            get
            {
                return _BrandName;
            }
            set
            {
                _BrandName = value;
            }
        }

        public int SlabID
        {
            get
            {
                return _SlabID;
            }
            set
            {
                _SlabID = value;
            }
        }
        public string SlabName
        {
            get
            {
                return _SlabName;
            }
            set
            {
                _SlabName = value;
            }
        }

        public double Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }

        public double Prize
        {
            get
            {
                return _Prize;
            }
            set
            {
                _Prize = value;
            }
        }
        public int orderType
        {
            get
            {
                return _orderType;
            }
            set
            {
                _orderType = value;
            }
        }

        public string BankName
        {
            get
            {
                return _BankName;
            }
            set
            {
                _BankName = value;
            }
        }
        public string BranchName
        {
            get
            {
                return _BranchName;
            }
            set
            {
                _BranchName = value;
            }
        }

        public string BranchAddress
        {
            get
            {
                return _BranchAddress;
            }
            set
            {
                _BranchAddress = value;
            }
        }
        public string IFSCCode
        {
            get
            {
                return _IFSCCode;
            }
            set
            {
                _IFSCCode = value;
            }
        }
        public int ID
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }


        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }
        public string District
        {
            get
            {
                return _District;
            }
            set
            {
                _District = value;
            }
        }
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        public int LocId
        {
            get
            {
                return _LocId;
            }
            set
            {
                _LocId = value;
            }
        }
        public int EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                _EmployeeId = value;
            }
        }
        public string orderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
            }
        }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptHead { get; set; }
        public int Dept_CreatedBy { get; set; }
        public string Dept_CreatedDate { get; set; }

        public int Tax_Id { get; set; }
        public string CommodityName { get; set; }
        public string Tax_Percentage { get; set; }


        public int DesigId
        {
            get
            {
                return _DesigId;
            }
            set
            {
                _DesigId = value;
            }
        }
        public string DesigName
        {
            get
            {
                return _DesigName;
            }
            set
            {
                _DesigName = value;
            }
        }

        public string Descriptions
        {
            get
            {
                return _Descriptions;
            }
            set
            {
                _Descriptions = value;
            }
        }

        public string Responsibility
        {
            get
            {
                return _Responsibility;
            }
            set
            {
                _Responsibility = value;
            }
        }
        public string SlabDisc { get; set; }

        public bool Status { get; set; }
        public string UnitName { get; set; }

        public string TINNumber { get; set; }
    }
}
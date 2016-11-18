using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class AgentInfo : Route
    {


        private int _AgentID;
        private string _AgentCode;
        private string _AgentName;
        private string _DateofJoining;
        private string _AppriveBy;
        private bool _Status;
        private int _EmployeeID;
        private string _Agensytype;
        private string _Address1;
        private string _Address2;
        private string _Address3;
        private string _Email;
        private string _TelephoneNo;
        private string _MobileNo;
        private string _City;
        public string _Districk;
        private string _State;
        private string _Country;
        private string _BillingMethod;
        private string _PaymentType;
        private double _DepositAmount;
        private string _BankName;
        private string _AccounNo;
        private string _AccountType;
        private string _IFSCCode;
        private string _Volume;
        private int _NoofTrays;
        private bool _DoortoDoor;
        private bool _FreezerAvailable;
        private bool _FreezerRestrun;
        private string _Deactivedate;
        private string _DeactiveReason;
        private double _AmountReturned;
        private int _TraysReturned;
        private double _SchemeAmount;
        private double _Catoagery;


        public int AgentID
        {
            get
            {
                return _AgentID;
            }
            set
            {
                _AgentID = value;
            }
        }
        public string AgentCode
        {
            get
            {
                return _AgentCode;
            }
            set
            {
                _AgentCode = value;
            }
        }
        public string AgentName
        {
            get
            {
                return _AgentName;
            }
            set
            {
                _AgentName = value;
            }
        }
        
        public string DateofJoining
        {
            get
            {
                return _DateofJoining;
            }
            set
            {
                _DateofJoining = value;
            }
        }
        public string AppriveBy
        {
            get
            {
                return _AppriveBy;
            }
            set
            {
                _AppriveBy = value;
            }
        }
        public bool Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }
        public string Agensytype
        {
            get
            {
                return _Agensytype;
            }
            set
            {
                _Agensytype = value;
            }
        }
        public string Address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                _Address1 = value;
            }
        }
        public string Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                _Address2 = value;
            }
        }
        public string Address3
        {
            get
            {
                return _Address3;
            }
            set
            {
                _Address3 = value;
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        public string TelephoneNo
        {
            get
            {
                return _TelephoneNo;
            }
            set
            {
                _TelephoneNo = value;
            }
        }
        public string MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
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
        public string Districk
        {
            get
            {
                return _Districk;
            }
            set
            {
                _Districk = value;
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
        public string BillingMethod
        {
            get
            {
                return _BillingMethod;
            }
            set
            {
                _BillingMethod = value;
            }
        }
        public string PaymentType
        {
            get
            {
                return _PaymentType;
            }
            set
            {
                _PaymentType = value;
            }
        }
        public double DepositAmount
        {
            get
            {
                return _DepositAmount;
            }
            set
            {
                _DepositAmount = value;
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
        public string AccounNo
        {
            get
            {
                return _AccounNo;
            }
            set
            {
                _AccounNo = value;
            }
        }
        public string AccountType
        {
            get
            {
                return _AccountType;
            }
            set
            {
                _AccountType = value;
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
        public string Volume
        {
            get
            {
                return _Volume;
            }
            set
            {
                _Volume = value;
            }
        }
        public int NoofTrays
        {
            get
            {
                return _NoofTrays;
            }
            set
            {
                _NoofTrays = value;
            }
        }
        public bool DoortoDoor
        {
            get
            {
                return _DoortoDoor;
            }
            set
            {
                _DoortoDoor = value;
            }
        }
        public bool FreezerAvailable
        {
            get
            {
                return _FreezerAvailable;
            }
            set
            {
                _FreezerAvailable = value;
            }
        }
        public bool FreezerRestrun
        {
            get
            {
                return _FreezerRestrun;
            }
            set
            {
                _FreezerRestrun = value;
            }
        }
        public string Deactivedate
        {
            get
            {
                return _Deactivedate;
            }
            set
            {
                _Deactivedate = value;
            }
        }
        public string DeactiveReason
        {
            get
            {
                return _DeactiveReason;
            }
            set
            {
                _DeactiveReason = value;
            }
        }
        public double AmountReturned
        {
            get
            {
                return _AmountReturned;
            }
            set
            {
                _AmountReturned = value;
            }
        }
        public int TraysReturned
        {
            get
            {
                return _TraysReturned;
            }
            set
            {
                _TraysReturned = value;
            }
        }
        public double SchemeAmount
        {
            get
            {
                return _SchemeAmount;
            }
            set
            {
                _SchemeAmount = value;
            }
        }
        public double SchemeTotalAmount
        {
            get
            {
                return _Catoagery;
            }
            set
            {
                _Catoagery = value;
            }
        }

    }
}
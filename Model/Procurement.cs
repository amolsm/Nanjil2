using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Procurement : User
    {
        private int _CenterID;
        private string _CenterCode;
        private string _CenterName;
        private int _RouteID;
        private string _PhoneNo;
        private string _MobileNo;
        private string _Address1;
        private string _Address2;
        private string _Address3;
        private string _City;
        private string _District;
        private string _State;
        private string _Country;
        private string _RouteCode;
        private string _RouteName;
        private string _RouteDescription;
        private string _ASOID;
        private int _SupplierID;
        private string _SupplierCode;
        private int _MilkCollectionID;
        private string _SupplierName;
        private string _JoiningDate;
        private int _BankDetailsID;
        private int _LoanID;
        private double _LoanAmount;
        private string _LoanTakenDate;
        private string _LoanDuration;
        private double _LoanPaid;
        private double _LoanBalance;
        private string _LoanStatus;
        private string _BankName;
        private string _AccountNumber;
        private string _AccountType;
        private string _IFSCCode;
        private string _BankAddress;
        private string _BranchName;
        private string _RouteDesc;
        private string _Discription;
        private string _flag;
        private int _ContactPerson;
        private bool _FreezerAvailable;
        private string _FreezerModel;
        private int _Quantity;
        private bool _IsActive;
        private string _SupplierAliasName;
        private double _IncentiveTillDate;
        private double _ReccDeposit;
        private double _Bonus;
        private double _AdvaceGiven;
        private string _LoanType;
        private int _SchemeID;
        private string _SchemeBonusYr;
        private double _SchemeAmount;
        private double _BonusAmount;
        private string _PaymentStatus;
        private string _PaymentDateTime;
        private int _AdvanceID;
        private double _AdvanceAmount;
        private string _AdvanceDateTime;
        private double _AdvanceDeducted;
        private double _AdvanceBalance;
        private string _DeductDateTime;
        private int _RDID;
        private string _RDStartDate;
        private string _RDMaturityDate;
        private double _RDAmount;
        private string _RDAmountDate;
        private string _RDStatus;
        private string _RDPaymentDateTime;
        private int _VehicleID;
        private string _SrNo;
        private string _Vehicle;
        private double _Bata;
        private double _KMLow;
        private double _KMHigh;
        private double _Amount;
        private double _251To300;
        private double _KMGreaterThan300;
        private DateTime _FomDate;
        private DateTime _ToDate;
        private string _flag1;
        private string _flag2;
        private decimal _OpeningBalance;
        private decimal _ClosingBalance;
        private int _BalanceID;
        private int _BMC { get; set; }
        private int _MilkCan { get; set; }
        private int _Silo { get; set; }
        private bool _IBT { get; set; }
        private bool _ETP { get; set; }
        private bool _LAB { get; set; }
        private bool _Store { get; set; }
        private double _Interest { get; set; }
        private int _Installments { get; set; }
        private decimal _TSInKg { get; set; }
        private double _InstallmentAmount;
        private double _Tax { get; set; }
        private string _MilkType { get; set; }
        private double _MorningKM { get; set; }
        private double _EveningKM { get; set; }
        private int _MilkCollectionTransportID { get; set; }
        private string _Time { get; set; }
        private string _Disposal { get; set; }
        private decimal _HandlingExcess { get; set; }
        private decimal _HandlingLoss { get; set; }
        private decimal _InternameConsumption { get; set; }
        private decimal _DamageMilk { get; set; }
        private decimal _Other { get; set; }
        public string Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public string Disposal
        {
            get { return _Disposal; }
            set { _Disposal = value; }
        }
        public decimal HandlingExcess
        {
            get { return _HandlingExcess; }
            set { _HandlingExcess = value; }
        }
        public decimal HandlingLoss
        {
            get { return _HandlingLoss; }
            set { _HandlingLoss = value; }
        }
        public decimal InternameConsumption
        {
            get { return _InternameConsumption; }
            set { _InternameConsumption = value; }
        }
        public decimal DamageMilk
        {
            get { return _DamageMilk; }
            set { _DamageMilk = value; }
        }
        public decimal Other
        {
            get { return _Other; }
            set { _Other = value; }
        }
        public int MilkCollectionTransportID
        {
            get { return _MilkCollectionTransportID; }
            set { _MilkCollectionTransportID = value; }
        }
        public double MorningKM
        {
            get { return _MorningKM; }
            set { _MorningKM = value; }
        }
        public double EveningKM
        {
            get { return _EveningKM; }
            set { _EveningKM = value; }
        }
        public string MilkType
        {
            get { return _MilkType; }
            set { _MilkType = value; }
        }
        public double Tax
        {
            get { return _Tax; }
            set { _Tax = value; }
        }
        public double InstallmentAmount
        {
            get { return _InstallmentAmount; }
            set { _InstallmentAmount = value; }
        }
        public decimal TSInKg
        {
            get { return _TSInKg; }
            set { _TSInKg = value; }
        }
        public int Installments
        {
            get { return _Installments; }
            set { _Installments = value; }
        }
        public double Interest
        {
            get { return _Interest; }
            set { _Interest = value; }
        }
        public int BMC
        {
            get { return _BMC; }
            set { _BMC = value; }
        }
        public int MilkCan
        {
            get { return _MilkCan; }
            set { _MilkCan = value; }
        }
        public int Silo
        {
            get { return _Silo; }
            set { _Silo = value; }
        }
        public bool IBT
        {
            get { return _IBT; }
            set { _IBT = value; }
        }
        public bool ETP
        {
            get { return _ETP; }
            set { _ETP = value; }
        }
        public bool LAB
        {
            get { return _LAB; }
            set { _LAB = value; }
        }
        public bool Store
        {
            get { return _Store; }
            set { _Store = value; }
        }
        public int BalanceID
        {
            get { return _BalanceID; }
            set { _BalanceID = value; }
        }
        public decimal OpeningBalance
        {
            get { return _OpeningBalance; }
            set { _OpeningBalance = value; }
        }
        public decimal ClosingBalance
        {
            get { return _ClosingBalance; }
            set { _ClosingBalance = value; }
        }
        public string flag1
        {
            get { return _flag1; }
            set { _flag1 = value; }
        }
        public string flag2
        {
            get { return _flag2; }
            set { _flag2 = value; }
        }
        public DateTime FomDate
        {
            get { return _FomDate; }
            set { _FomDate = value; }
        }
        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        public int BatchWiseMilkDisposalID
        {
            get { return _BatchWiseMilkDisposalID; }
            set { _BatchWiseMilkDisposalID = value; }
        }
        private int _BatchWiseMilkDisposalID;
        public int BatchWiseMilkCollectionID
        {
            get { return _BatchWiseMilkCollectionID; }
            set { _BatchWiseMilkCollectionID = value; }
        }
        private int _BatchWiseMilkCollectionID;
        public decimal Temp
        {
            get { return _Temp; }
            set { _Temp = value; }
        }
        private decimal _Temp;

        public decimal Acidity
        {
            get { return _Acidity; }
            set { _Acidity = value; }
        }
        private decimal _Acidity;

        public string BatchNo
        {
            get { return _BatchNo; }
            set { _BatchNo = value; }
        }
        private string _BatchNo;
        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }
        private string _AccountName;

        public int CollectionID
        {
            get { return _CollectionID; }
            set { _CollectionID = value; }
        }
        private int _CollectionID;


        public decimal MilkInKG
        {
            get { return _MilkInKG; }
            set { _MilkInKG = value; }
        }
        private decimal _MilkInKG;



        public decimal MilkInLtr
        {
            get { return _MilkInLtr; }
            set { _MilkInLtr = value; }
        }
        private decimal _MilkInLtr;

        public decimal ActualMilkInLtr
        {
            get { return _ActualMilkInLtr; }
            set { _ActualMilkInLtr = value; }
        }
        private decimal _ActualMilkInLtr;


        public decimal FATPercentage
        {
            get { return _FATPercentage; }
            set { _FATPercentage = value; }
        }
        private decimal _FATPercentage;



        public decimal CLRReading
        {
            get { return _CLRReading; }
            set { _CLRReading = value; }
        }
        private decimal _CLRReading;



        public decimal FATInKG
        {
            get { return _FATInKG; }
            set { _FATInKG = value; }
        }
        private decimal _FATInKG;


        public decimal SNF
        {
            get { return _SNF; }
            set { _SNF = value; }
        }
        private decimal _SNF;


        public decimal SNFPercentage
        {
            get { return _SNFPercentage; }
            set { _SNFPercentage = value; }
        }
        private decimal _SNFPercentage;



        public decimal SNFInKG
        {
            get { return _SNFInKG; }
            set { _SNFInKG = value; }
        }
        private decimal _SNFInKG;


        public decimal TSPercentage
        {
            get { return _TSPercentage; }
            set { _TSPercentage = value; }
        }
        private decimal _TSPercentage;

        public string Batch
        {
            get { return _Batch; }
            set { _Batch = value; }
        }
        private string _Batch;

        public string Session
        {
            get { return _Session; }
            set { _Session = value; }
        }
        private string _Session;

        public DateTime Date { get; set; }

        public int VehicleMasterID
        {
            get { return _VehicleMasterID; }
            set { _VehicleMasterID = value; }
        }
        private int _VehicleMasterID;

        public string VehicleName
        {
            get { return _VehicleName; }
            set { _VehicleName = value; }
        }
        private string _VehicleName;

        public string VehicleNo
        {
            get { return _VehicleNo; }
            set { _VehicleNo = value; }
        }
        private string _VehicleNo;


        public string VehicleID1
        {
            get { return _VehicleID1; }
            set { _VehicleID1 = value; }
        }
        private string _VehicleID1;


        public string VehicleOwnerName
        {
            get { return _VehicleOwnerName; }
            set { _VehicleOwnerName = value; }
        }
        private string _VehicleOwnerName;


        public string OwnerEmail
        {
            get { return _OwnerEmail; }
            set { _OwnerEmail = value; }
        }
        private string _OwnerEmail;


        public string OwnerMobileNo
        {
            get { return _OwnerMobileNo; }
            set { _OwnerMobileNo = value; }
        }
        private string _OwnerMobileNo;


        public string VehicleSrNo
        {
            get { return _VehicleSrNo; }
            set { _VehicleSrNo = value; }
        }
        private string _VehicleSrNo;

        public int VehicleType
        {
            get { return _VehicleType; }
            set { _VehicleType = value; }
        }
        private int _VehicleType;



        public string DriverName
        {
            get { return _DriverName; }
            set { _DriverName = value; }
        }
        private string _DriverName;



        public string DriverMobileNo
        {
            get { return _DriverMobileNo; }
            set { _DriverMobileNo = value; }
        }
        private string _DriverMobileNo;


        public string OwnerBankName
        {
            get { return _OwnerBankName; }
            set { _OwnerBankName = value; }
        }
        private string _OwnerBankName;


        public string AccountNo
        {
            get { return _AccountNo; }
            set { _AccountNo = value; }
        }
        private string _AccountNo;

        public int RawMilkTarrifID
        {
            get { return _RawMilkTarrifID; }
            set { _RawMilkTarrifID = value; }
        }
        private int _RawMilkTarrifID;

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        private string _Category;

        public decimal TSL
        {
            get { return _TSL; }
            set { _TSL = value; }
        }
        private decimal _TSL;



        public decimal TSH
        {
            get { return _TSH; }
            set { _TSH = value; }
        }
        private decimal _TSH;



        public decimal TSRATE
        {
            get { return _TSRATE; }
            set { _TSRATE = value; }
        }
        private decimal _TSRATE;



        public int TS_INCR
        {
            get { return _TS_INCR; }
            set { _TS_INCR = value; }
        }
        private int _TS_INCR;



        public int Incentive
        {
            get { return _Incentive; }
            set { _Incentive = value; }
        }
        private int _Incentive;



        public int IN_FAT
        {
            get { return _IN_FAT; }
            set { _IN_FAT = value; }
        }
        private int _IN_FAT;



        public int IN_SNF
        {
            get { return _IN_SNF; }
            set { _IN_SNF = value; }
        }
        private int _IN_SNF;



        public int IN_TS
        {
            get { return _IN_TS; }
            set { _IN_TS = value; }
        }
        private int _IN_TS;



        public decimal Scheme
        {
            get { return _Scheme; }
            set { _Scheme = value; }
        }
        private decimal _Scheme;



        public decimal Bonus1
        {
            get { return _Bonus1; }
            set { _Bonus1 = value; }
        }
        private decimal _Bonus1;



        public DateTime WEF_DATE
        {
            get { return _WEF_DATE; }
            set { _WEF_DATE = value; }
        }
        private DateTime _WEF_DATE;

        public int VehicleID
        {
            get
            {
                return _VehicleID;
            }
            set
            {
                _VehicleID = value;
            }
        }
        public string SrNo
        {
            get
            {
                return _SrNo;
            }
            set
            {
                _SrNo = value;
            }
        }
        public double Bata
        {
            get
            {
                return _Bata;
            }
            set
            {
                _Bata = value;
            }
        }
        public string Vehicle
        {
            get
            {
                return _Vehicle;
            }
            set
            {
                _Vehicle = value;
            }
        }
        public double KMLow
        {
            get
            {
                return _KMLow;
            }
            set
            {
                _KMLow = value;
            }
        }
        public double KMHigh
        {
            get
            {
                return _KMHigh;
            }
            set
            {
                _KMHigh = value;
            }
        }
        public double V201To250
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }
        public double Amount
        {
            get
            {
                return _251To300;
            }
            set
            {
                _251To300 = value;
            }
        }
        public double KMGreaterThan300
        {
            get
            {
                return _KMGreaterThan300;
            }
            set
            {
                _KMGreaterThan300 = value;
            }
        }
        public int RDID
        {
            get
            {
                return _RDID;
            }
            set
            {
                _RDID = value;
            }
        }
        public string RDStartDate
        {
            get
            {
                return _RDStartDate;
            }
            set
            {
                _RDStartDate = value;
            }
        }
        public string RDMaturityDate
        {
            get
            {
                return _RDMaturityDate;
            }
            set
            {
                _RDMaturityDate = value;
            }
        }
        public double RDAmount
        {
            get
            {
                return _RDAmount;
            }
            set
            {
                _RDAmount = value;
            }
        }
        public string RDAmountDate
        {
            get
            {
                return _RDAmountDate;
            }
            set
            {
                _RDAmountDate = value;
            }
        }
        public string RDStatus
        {
            get
            {
                return _RDStatus;
            }
            set
            {
                _RDStatus = value;
            }
        }
        public string RDPaymentDateTime
        {
            get
            {
                return _RDPaymentDateTime;
            }
            set
            {
                _RDPaymentDateTime = value;
            }
        }
        public int SchemeID
        {
            get
            {
                return _SchemeID;
            }
            set
            {
                _SchemeID = value;
            }
        }
        public string SchemeBonusYr
        {
            get
            {
                return _SchemeBonusYr;
            }
            set
            {
                _SchemeBonusYr = value;
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
        public double BonusAmount
        {
            get
            {
                return _BonusAmount;
            }
            set
            {
                _BonusAmount = value;
            }
        }
        public string PaymentStatus
        {
            get
            {
                return _PaymentStatus;
            }
            set
            {
                _PaymentStatus = value;
            }
        }
        public string PaymentDateTime
        {
            get
            {
                return _PaymentDateTime;
            }
            set
            {
                _PaymentDateTime = value;
            }
        }
        public int AdvanceID
        {
            get
            {
                return _AdvanceID;
            }
            set
            {
                _AdvanceID = value;
            }
        }
        public double AdvanceAmount
        {
            get
            {
                return _AdvanceAmount;
            }
            set
            {
                _AdvanceAmount = value;
            }
        }
        public string AdvanceDateTime
        {
            get
            {
                return _AdvanceDateTime;
            }
            set
            {
                _AdvanceDateTime = value;
            }
        }
        public double AdvanceDeducted
        {
            get
            {
                return _AdvanceDeducted;
            }
            set
            {
                _AdvanceDeducted = value;
            }
        }
        public double AdvanceBalance
        {
            get
            {
                return _AdvanceBalance;
            }
            set
            {
                _AdvanceBalance = value;
            }
        }
        public string DeductDateTime
        {
            get
            {
                return _DeductDateTime;
            }
            set
            {
                _DeductDateTime = value;
            }
        }
        public double LoanBalance
        {
            get
            {
                return _LoanBalance;
            }
            set
            {
                _LoanBalance = value;
            }
        }
        public string LoanType
        {
            get
            {
                return _LoanType;
            }
            set
            {
                _LoanType = value;
            }
        }
        public double IncentiveTillDate
        {
            get
            {
                return _IncentiveTillDate;
            }
            set
            {
                _IncentiveTillDate = value;
            }
        }
        public double ReccDeposit
        {
            get
            {
                return _ReccDeposit;
            }
            set
            {
                _ReccDeposit = value;
            }
        }
        public double Bonus
        {
            get
            {
                return _Bonus;
            }
            set
            {
                _Bonus = value;
            }
        }
        public double AdvaceGiven
        {
            get
            {
                return _AdvaceGiven;
            }
            set
            {
                _AdvaceGiven = value;
            }
        }
        public string SupplierAliasName
        {
            get
            {
                return _SupplierAliasName;
            }
            set
            {
                _SupplierAliasName = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
        public int ContactPerson
        {
            get
            {
                return _ContactPerson;
            }
            set
            {
                _ContactPerson = value;
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
        public string FreezerModel
        {
            get
            {
                return _FreezerModel;
            }
            set
            {
                _FreezerModel = value;
            }
        }
        public int Quantity
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
        public string flag
        {
            get
            {
                return _flag;
            }
            set
            {
                _flag = value;
            }
        }
        public string RouteDesc
        {
            get
            {
                return _RouteDesc;
            }
            set
            {
                _RouteDesc = value;
            }
        }
        public string Discription
        {
            get
            {
                return _Discription;
            }
            set
            {
                _Discription = value;
            }
        }
        public int CenterID
        {
            get
            {
                return _CenterID;
            }
            set
            {
                _CenterID = value;
            }
        }
        public string CenterCode
        {
            get
            {
                return _CenterCode;
            }
            set
            {
                _CenterCode = value;
            }
        }
        public string CenterName
        {
            get
            {
                return _CenterName;
            }
            set
            {
                _CenterName = value;
            }
        }
        public int RouteID
        {
            get
            {
                return _RouteID;
            }
            set
            {
                _RouteID = value;
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
        public string PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
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
        public string AccounNumber
        {
            get
            {
                return _AccountNumber;
            }
            set
            {
                _AccountNumber = value;
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
        public string RouteCode
        {
            get
            {
                return _RouteCode;
            }
            set
            {
                _RouteCode = value;
            }
        }
        public string RouteName
        {
            get
            {
                return _RouteName;
            }
            set
            {
                _RouteName = value;
            }
        }
        public string RouteDescription
        {
            get
            {
                return _RouteDescription;
            }
            set
            {
                _RouteDescription = value;
            }
        }
        public string ASOID
        {
            get
            {
                return _ASOID;
            }
            set
            {
                _ASOID = value;
            }
        }
        public int SupplierID
        {
            get
            {
                return _SupplierID;
            }
            set
            {
                _SupplierID = value;
            }
        }
        public string SupplierCode
        {
            get
            {
                return _SupplierCode;
            }
            set
            {
                _SupplierCode = value;
            }
        }
        public string SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
            }
        }
        public int MilkCollectionID
        {
            get
            {
                return _MilkCollectionID;
            }
            set
            {
                _MilkCollectionID = value;
            }
        }
        public string JoiningDate
        {
            get
            {
                return _JoiningDate;
            }
            set
            {
                _JoiningDate = value;
            }
        }
        public int BankDetailsID
        {
            get
            {
                return _BankDetailsID;
            }
            set
            {
                _BankDetailsID = value;
            }
        }
        public int LoanID
        {
            get
            {
                return _LoanID;
            }
            set
            {
                _LoanID = value;
            }
        }
        public double LoanAmount
        {
            get
            {
                return _LoanAmount;
            }
            set
            {
                _LoanAmount = value;
            }
        }
        public string LoanDuration
        {
            get
            {
                return _LoanDuration;
            }
            set
            {
                _LoanDuration = value;
            }
        }
        public double LoanPaid
        {
            get
            {
                return _LoanPaid;
            }
            set
            {
                _LoanPaid = value;
            }
        }
        public string LoanStatus
        {
            get
            {
                return _LoanStatus;
            }
            set
            {
                _LoanStatus = value;
            }
        }
        public string LoanTakenDate
        {
            get
            {
                return _LoanTakenDate;
            }
            set
            {
                _LoanTakenDate = value;
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
        public string BankAddress
        {
            get
            {
                return _BankAddress;
            }
            set
            {
                _BankAddress = value;
            }
        }
        public string VehicleTypeName { get; set; }
        public int ID { get; set; }
        public string particular { get; set; }
        public string purpose { get; set; }
        public string QCat { get; set; }
        public decimal QLow { get; set; }
        public decimal QHigh { get; set; }
        public decimal QIncentive { get; set; }
        public double RepaymentAmt { get; set; }
        public string TransportType { get; set; }
        public double tdspercentage { get; set; }
        public string MorningInTime { get; set; }
        public string MorningOutTime { get; set; }
        public string EveningOutTime { get; set; }
        public string EveningInTime { get; set; }
        public string MorningInCan { get; set; }
        public string MorningOutCan { get; set; }
        public string Remarks { get; set; }
        public double canloan { get; set; }
        public double casloan { get; set; }
        public double bankloan { get; set; }
        public double netamt { get; set; }
        public decimal TSStartPercentage
        {
            get { return _TSStartPercentage; }
            set { _TSStartPercentage = value; }
        }
        private decimal _TSStartPercentage;
        public decimal TSEndPercentage
        {
            get { return _TSEndPercentage; }
            set { _TSEndPercentage = value; }
        }

        public string EveningInCan { get; set; }
        public string EveningOutCan { get; set; }

        private decimal _TSEndPercentage;
        public int BankId { get; set; }
        public DateTime ToDate1 { get; set; }
        public DateTime ToDate2 { get; set; }
        public string Description { get; set; }
        public string abjust { get; set; }



    }
}
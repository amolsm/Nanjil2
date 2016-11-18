using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Employee:Route
    {



       
private string _MobileNumber;
private string _DateofJoining;
private string _ContactNumber;
private string _Address1;
private string _Address2;
private string _Address3;
private string _City;
private string _Districk ;
private string _State;
private string _Country;
private string _BankName;
private string _AccounNo;      
private string _IFSCCode;

private int _EmployeeID;
private string _EmployeeCode;
private string _EmployeeName;
private string _FatherName;
private string _PFNO;
	 
 
 
private string _ActiveFrom;
private string _Designation;
private string _SuperViser;

 
 
        private string _PermanentCity;
        private string _EmergincyContact;
        private string _BloodGroup;
        private string _UserImagePath;
        private string _JoinDate;
        private string _DateOfBirth;

        public string Department { get; set; }

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
        public string MobileNumber
        {
            get
            {
                return _MobileNumber;
            }
            set
            {
                _MobileNumber = value;
            }
        }
        public string ContactNumber
        {
            get
            {
                return _ContactNumber;
            }
            set
            {
                _ContactNumber = value;
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
        public string PermanentCity
        {
            get
            {
                return _PermanentCity;
            }
            set
            {
                _PermanentCity = value;
            }
        }
        public string EmergincyContact
        {
            get
            {
                return _EmergincyContact;
            }
            set
            {
                _EmergincyContact = value;
            }
        }
        public string BloodGroup
        {
            get
            {
                return _BloodGroup;
            }
            set
            {
                _BloodGroup = value;
            }
        }
        public string UserImagePath
        {
            get
            {
                return _UserImagePath;
            }
            set
            {
                _UserImagePath = value;
            }
        }
        public string JoinDate
        {
            get
            {
                return _JoinDate;
            }
            set
            {
                _JoinDate = value;
            }
        }
        public string DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                _DateOfBirth = value;
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
        public string EmployeeCode
            {
            get
            {
                return _EmployeeCode;
            }
            set
            {
                _EmployeeCode = value;
            }
        }
        public string EmployeeName 
            {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        public string FatherName
            {
            get
            {
                return _FatherName;
            }
            set
            {
                _FatherName = value;
            }
        }
        public string PFNO
            {
            get
            {
                return _PFNO;
            }
            set
            {
                _PFNO = value;
            }
        }



        public string ActiveFrom
            {
            get
            {
                return _ActiveFrom;
            }
            set
            {
                _ActiveFrom = value;
            }
        }
        public string Designation
            {
            get
            {
                return _Designation;
            }
            set
            {
                _Designation = value;
            }
        }
        public string SuperViser
            {
            get
            {
                return _SuperViser;
            }
            set
            {
                _SuperViser = value;
            }
        }
    }
}
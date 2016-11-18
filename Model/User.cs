using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Model
{
    public class User
    {
        public int EmployeeId { get; set; }

        private int _UserID;
        private string _Name;
        private string _UserName;
        private string _PassWord;
        private string _OldPassword;
        private string _EmailID;
       
        private string _LastLogin;
        private int _FailedLoginAttempts;
        private string _RoleID;
        private int _privilege;
        private bool _IsActive;


        private int _CreatedBy;
        private string _Createddate;
        private int _ModifiedBy;
        private string _ModifiedDate;
        private string _flag; 

        public int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        public string PassWord
        {
            get
            {
                return _PassWord;
            }
            set
            {
                _PassWord = value;
            }
        }
        public string OldPassword
        {
            get
            {
                return _OldPassword;
            }
            set
            {
                _OldPassword = value;
            }
        }
        public string EmailID
        {
            get
            {
                return _EmailID;
            }
            set
            {
                _EmailID = value;
            }
        }
      
        public string LastLogin
        {
            get
            {
                return _LastLogin;
            }
            set
            {
                _LastLogin = value;
            }
        }
        public int FailedLoginAttempts
        {
            get
            {
                return _FailedLoginAttempts;
            }
            set
            {
                _FailedLoginAttempts = value;
            }
        }
        public string RoleID
        {
            get
            {
                return _RoleID;
            }
            set
            {
                _RoleID = value;
            }
        }
        public int privilege
        {
            get
            {
                return _privilege;
            }
            set
            {
                _privilege = value;
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
        public int CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }
        public string Createddate
        {
            get
            {
                return _Createddate;
            }
            set
            {
                _Createddate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return _ModifiedBy;
            }
            set
            {
                _ModifiedBy = value;
            }
        }
        public string ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
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

        


    }
}
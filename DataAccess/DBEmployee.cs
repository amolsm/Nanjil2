using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAcess;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class DBEmployee
    {
        DBHelper _DBHelper = new DBHelper();
        public bool InsertEmployee(Employee employee)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@EmployeeID", employee.EmployeeID));
                paramCollection.Add(new DBParameter("@EmployeeCode", employee.EmployeeCode));
                paramCollection.Add(new DBParameter("@EmployeeName", employee.EmployeeName));
                paramCollection.Add(new DBParameter("@FatherName", employee.FatherName));
                paramCollection.Add(new DBParameter("@PFNO", employee.PFNO));
                paramCollection.Add(new DBParameter("@JoingingDate", employee.DateofJoining));
                paramCollection.Add(new DBParameter("@IsActive", employee.IsActive));
                paramCollection.Add(new DBParameter("@Address1", employee.Address1));
                paramCollection.Add(new DBParameter("@Address2", employee.Address2));
                paramCollection.Add(new DBParameter("@Address3", employee.Address3));
                paramCollection.Add(new DBParameter("@Email", employee.EmailID));
                paramCollection.Add(new DBParameter("@mobile", employee.MobileNumber));
                paramCollection.Add(new DBParameter("@Phone", employee.ContactNumber));
                paramCollection.Add(new DBParameter("@City", employee.City));
                paramCollection.Add(new DBParameter("@Districk", employee.Districk));
                paramCollection.Add(new DBParameter("@State", employee.State));
                paramCollection.Add(new DBParameter("@Country", employee.Country));
                paramCollection.Add(new DBParameter("@BankName", employee.BankName));
                paramCollection.Add(new DBParameter("@AccountNo", employee.AccounNo));
                paramCollection.Add(new DBParameter("@IFCCODE", employee.IFSCCode));
                paramCollection.Add(new DBParameter("@RouteID", employee.RouteID));
                paramCollection.Add(new DBParameter("@ActiveFrom", employee.ActiveFrom));
                paramCollection.Add(new DBParameter("@Department", employee.Department));

                paramCollection.Add(new DBParameter("@Designation", employee.Designation));
                paramCollection.Add(new DBParameter("@SuperViser", employee.SuperViser));
                paramCollection.Add(new DBParameter("@IsArchive", employee.IsArchive));
                paramCollection.Add(new DBParameter("@Createdby", employee.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", employee.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", employee.ModifiedBy));
                paramCollection.Add(new DBParameter("@MOdifiedDate", employee.ModifiedDate));
                paramCollection.Add(new DBParameter("@flag", employee.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_InsertEmployee", paramCollection, CommandType.StoredProcedure);

            }
            catch (SqlException ex)
            {
                // Comman.Comman.msg = ex.ToString();

                if (ex.Message.Contains("UNIQUE KEY constraint"))
                {
                    Comman.Comman.msg = "DUPLICATE EMPLOYEE CODE : Employee Code Should be Unique";
                }

            }
            if (result > 0)
                return true;
            return false;
        }
        public DataSet GetAllEmployeeDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_GetAllEmployeeDetails", paramCollection, CommandType.StoredProcedure);

        }
        public DataSet GetEmployeeID(int EmployeeId)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@EmployeeID", EmployeeId));
            return _DBHelper.ExecuteDataSet("sp_GetEmployeeID", paramCollection, CommandType.StoredProcedure);

        }

    }

}
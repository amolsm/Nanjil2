using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bussiness;
using Model;
using DataAccess;
using System.Data;

namespace Bussiness
{
    public class EmployeeData
    {
        DBEmployee dbemployee = new DBEmployee();
        public bool InserEmployee(Employee employee)
        {
            return dbemployee.InsertEmployee(employee);

        }
        public DataSet GetAllEmployeeDetails()
        {
            return dbemployee.GetAllEmployeeDetails();

        }
        public DataSet GetEmployeeID(int EmployeeID)
        {
            return dbemployee.GetEmployeeID(EmployeeID);
        }
    }
}
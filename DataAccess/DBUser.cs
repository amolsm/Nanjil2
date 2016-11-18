using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Model;
using DataAcess; 

namespace DataAccess
{
    public class DBUser
    {
        DBHelper _DBHelper = new DBHelper();

        public DataSet Isauthenticat(User authentication)
        {

            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@UserName", authentication.UserName));
            paramCollection.Add(new DBParameter("@PassWord", authentication.PassWord));
            return _DBHelper.ExecuteDataSet("Sp_IsUserAuthenticat", paramCollection, CommandType.StoredProcedure);
        }

        public bool InsertUser(User user)
        {
            int result = 0;
            try
            {

               
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Userid", user.UserID));
                paramCollection.Add(new DBParameter("@Name", user.Name));
                paramCollection.Add(new DBParameter("@UserName", user.UserName));
                paramCollection.Add(new DBParameter("@PassWord", user.PassWord));
                paramCollection.Add(new DBParameter("@roleID", user.RoleID)); 
                paramCollection.Add(new DBParameter("@IsActive", user.IsActive));
                paramCollection.Add(new DBParameter("@privilege", user.privilege));
                paramCollection.Add(new DBParameter("@CreatedBy", user.CreatedBy));
                paramCollection.Add(new DBParameter("@Createddate", user.Createddate));
                paramCollection.Add(new DBParameter("@ModifiedBy", user.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", user.ModifiedDate));
                paramCollection.Add(new DBParameter("@EmployeeId", user.EmployeeId));
                paramCollection.Add(new DBParameter("@flag", user.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_InsertUser", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {

                throw;
            }
            if (result > 0)
                return true;
            return false;
        }
        public DataSet GetAllUsers()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();            
            return _DBHelper.ExecuteDataSet("Sp_GetAllUserList", paramCollection, CommandType.StoredProcedure);
        }
        public DataSet GetuserDetailsByUserid(int Userid)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@userid", Userid));
            return _DBHelper.ExecuteDataSet("Sp_GetUserDetailsByID", paramCollection, CommandType.StoredProcedure);
        }
    }
}
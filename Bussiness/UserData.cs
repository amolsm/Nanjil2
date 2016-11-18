using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data;
using Comman;
using DataAccess;
namespace Bussiness
{
    public class UserData
    {
        DBUser dbuser = new DBUser();
        public void  InsertUserInfo()
        {
 
        }
        public bool Isauthenticat(User user)
        {
            DataSet DS = new DataSet();
            DS = dbuser.Isauthenticat(user);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
     
               
                user.UserID = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["UserID"].ToString()) ? 0 : (Comman.Comman.IsValidInteger(DS.Tables[0].Rows[0]["UserID"].ToString()) ? Convert.ToInt32(DS.Tables[0].Rows[0]["UserID"].ToString()) : 0);
                user.RoleID = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RoleName"].ToString()) ? "Unknown" : DS.Tables[0].Rows[0]["RoleName"].ToString();
                user.privilege = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Privilege"].ToString()) ? 0 : (Comman.Comman.IsValidInteger(DS.Tables[0].Rows[0]["Privilege"].ToString()) ? Convert.ToInt32(DS.Tables[0].Rows[0]["Privilege"].ToString()) : 0);
                user.LastLogin = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["LastLogin"].ToString()) ? "" :DS.Tables[0].Rows[0]["LastLogin"].ToString();
                return true;
            }
            return false;


        }
        public bool InsertUser(User user)
        {
           return dbuser.InsertUser(user);

        }
        public DataSet GetAllUsers()
        {
            return dbuser.GetAllUsers();
        }
        public DataSet GetuserDetailsByUserid(int Userid)
        {
            return dbuser.GetuserDetailsByUserid(Userid);
        }
    }
}
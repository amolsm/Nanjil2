using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Dairy.App_code
{
    public class GlobalInfo
    {
        
        public static int Userid
        {

            get
            {
                try
                {

                    FormsIdentity id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = id.Ticket;
                    string userData = ticket.UserData;
                    string[] arrStr = userData.Split(new Char[] { ';' });
                    return Convert.ToInt32(arrStr[0]);
                    //  return 1;

                }
                catch (Exception)
                {
                    return 0;
                    throw;
                }
            }

        }
        public static string UserRole
        {

            get
            {
                try
                {

                    FormsIdentity id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = id.Ticket;
                    string userData = ticket.UserData;
                    string[] arrStr = userData.Split(new Char[] { ';' });
                    return arrStr[1].ToString();


                }
                catch (Exception)
                {
                    return "Unknow";
                    throw;
                }
            }

        }
        public static string UserName
        {

            get
            {
                try
                {

                    FormsIdentity id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = id.Ticket;
                    string userData = ticket.UserData;
                    string[] arrStr = userData.Split(new Char[] { ';' });
                    return arrStr[2].Contains('@') ? arrStr[2].Split('@')[0] : UserName;


                }
                catch (Exception)
                {
                    return "Unknow";
                    throw;
                }
            }

        }
        public static int Privilege
        {

            get
            {
                try
                {

                    FormsIdentity id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = id.Ticket;
                    string userData = ticket.UserData;
                    string[] arrStr = userData.Split(new Char[] { ';' });
                    return Convert.ToInt32(arrStr[3]);
                    //  return 1;

                }
                catch (Exception)
                {
                    return 0;
                    throw;
                }
            }

        }
        public static string LlastLogin
        {
            get
            {
                try
                {

                    FormsIdentity id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = id.Ticket;
                    string userData = ticket.UserData;
                    string[] arrStr = userData.Split(new Char[] { ';' });
                    return arrStr[4].ToString();


                }
                catch (Exception)
                {
                    return "Unknow";
                    throw;
                }
            }
        }
        public static int CurrentbothID
        {

            get
            {
                try
                {

                    FormsIdentity id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = id.Ticket;
                    string userData = ticket.UserData;
                    string[] arrStr = userData.Split(new Char[] { ';' });
                    return string.IsNullOrEmpty(arrStr[5]) ? 0 : Convert.ToInt32(arrStr[5].ToString());

                }
                catch (Exception)
                {
                    return 0;
                    throw;
                }
            }
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Dairy
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            Application["UsersLoggedIn"] = new System.Collections.Generic.List<string>();
            Application["BoothLoggedIn"] = new System.Collections.Generic.List<string>();
            Application["PrvOrderId"] = new Int32();


        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                if (Request.IsAuthenticated == true)
                {
                    FormsIdentity id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = id.Ticket;
                    string userData = ticket.UserData;
                    string[] arrStr = userData.Split(new Char[] { ';' });
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, arrStr);
                }

            }
            catch (Exception)
            {
                // ExceptionManager.HandleException("Error", ex, "Application_AuthenticateRequest", -1);
            }
        }
        void Session_Start(object sender, EventArgs e)
        {
           

        }
        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

            string userLoggedIn =  (string)Session["UserLoggedIn"];
            if (userLoggedIn.Length > 0)
            {
                System.Collections.Generic.List<string> d = Application["UsersLoggedIn"]
                    as System.Collections.Generic.List<string>;
                if (d != null)
                {
                    lock (d)
                    {
                        d.Remove(userLoggedIn);
                    }
                }

            }
            string BoothLoggedIn = (string)Session["BoothLoggedIn"];
            if (BoothLoggedIn.Length > 0)
            {
                System.Collections.Generic.List<string> b = Application["BoothLoggedIn"]
                    as System.Collections.Generic.List<string>;
                if (b != null)
                {
                    lock (b)
                    {
                        b.Remove(BoothLoggedIn);
                    }
                }

            }
        }
    }
}

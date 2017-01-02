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

            // Get the exception object.
            Exception exc = Server.GetLastError();

            // Handle HTTP errors
            if (exc.GetType() == typeof(HttpException))
            {
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                Server.Transfer("~/ErrorPages/Oops.aspx");
            }

            // For other kinds of errors give the user some information
            // but stay on the default page
            //Response.Write("<h2>Global Page Error</h2>\n");
            //Response.Write(
            //    "<p>" + exc.Message + "</p>\n");
            //Response.Write("Return to the <a href='/Authentication/LoginT.aspx'>" +
            //    "Default Page</a>\n");
           

            //// Log the exception and notify system operators
            //ExceptionUtility.LogException(exc, "DefaultPage");
            //ExceptionUtility.NotifySystemOps(exc);

            // Clear the error from the server
            Server.ClearError();

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Bussiness;
using System.Data;
using Comman;
using System.Text;
using Model;
using Dairy.App_code;
namespace Dairy.WebService
{
    /// <summary>
    /// Summary description for BindAgentSlab
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
   [System.Web.Script.Services.ScriptService]
    public class BindAgentSlab : System.Web.Services.WebService
    {
        ProductData productdata;
        Product product;
        [WebMethod]
        public string GetAgentSlabDetailsByAgentID(string id)
        {
            string result = string.Empty;
            DataSet DS=new DataSet();
            StringBuilder sb = new StringBuilder();
            ProductData productdata=new ProductData();
            DS = productdata.GetAgentSlabDetailsByAgentID(Convert.ToInt32(id));
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                sb.Append("<div class='col-md-12'>");
                sb.Append("<div class='col-md-5'>");
                sb.Append("TypeName");
                sb.Append("</div>");
                sb.Append("<div class='col-md-5'>");
                sb.Append("slabName");
                sb.Append("</div>");
                
                sb.Append("<hr>");
                foreach (DataRow row in DS.Tables[0].Rows)
                {

                    sb.Append("<div class='col-md-5'>");
                    sb.Append( row["typeName"].ToString());
                    sb.Append("</div>");
           
                    sb.Append("<div class='col-md-5'>");
                   sb.Append(  row["slabName"].ToString());
                    sb.Append("</div>");

                    

                     
                }
                 sb.Append("</div>");
                 result = sb.ToString();
            }

            return result;
        }

        [WebMethod]
        public string AddagentSlab(string type,string slabID,string agentID,string MC,string TDC )
        {
            int Result = 0;
            if (type!="0" && slabID !="0")
            {
                productdata = new ProductData();
                product = new Product();
                product.BindSlabID = 0;
                product.MonthelyCollection = string.IsNullOrEmpty(MC) ? string.Empty : Convert.ToString(MC);
                product.TillDateColletion = string.IsNullOrEmpty(TDC) ? string.Empty : Convert.ToString(TDC);
                product.TypeID = string.IsNullOrEmpty(type) ? 0 : Convert.ToInt32(type);
                product.SlabID = string.IsNullOrEmpty(slabID) ? 0 : Convert.ToInt32(slabID);
                product.AgencyID = string.IsNullOrEmpty(agentID) ? 0 : Convert.ToInt32(agentID);
                product.CreatedBy = GlobalInfo.Userid;
                product.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
                product.ModifiedBy = GlobalInfo.Userid;
                product.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
                product.flag = "Insert";
                
                Result = productdata.AddBindSlab(product);
            }
            if (Result > 0)
            {
                return Result.ToString();
            }
            else
            {

                return Result.ToString();

            }
        }
    }
}

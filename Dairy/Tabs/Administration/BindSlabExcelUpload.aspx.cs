using Dairy.App_code;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Administration
{
    public partial class BindSlabExcelUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void btnDownoadSheet_Click(object sender, EventArgs e)
        {
            //Get the data from database into datatable
            string strQuery = "Select b.AgentID, a.AgentCode,a.AgentName, b.TypeID, t.TypeName, b.SlabID, s.SlabName " +
                " from BindSlab b join AgentMaster a on a.AgentID = b.AgentID join TypeMaster t on t.TypeID = b.TypeID join SlabMaster s on s.SlabID = b.SlabID";
            SqlCommand cmd = new SqlCommand(strQuery);
            DataTable dt = GetData(cmd);

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=BindSlabSheet.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //Apply text style to each Row
                GridView1.Rows[i].Attributes.Add("class", "textmode");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        private DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager.
                 ConnectionStrings["projectconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Upload and save the file
            string excelPath = Server.MapPath("~/Tabs/Dispatch/") + Path.GetFileName(FileUpload1.PostedFile.FileName);

            FileUpload1.SaveAs(excelPath);

            string conString = string.Empty;
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07 or higher
                    conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                    break;

            }
            conString = string.Format(conString, excelPath);
            using (OleDbConnection excel_con = new OleDbConnection(conString))
            {
                excel_con.Open();
                string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                DataTable dtExcelData = new DataTable();

                //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                dtExcelData.Columns.AddRange(new DataColumn[3] { new DataColumn("AgentID", typeof(int)),
                new DataColumn("TypeID", typeof(string)),
                new DataColumn("SlabID",typeof(string)) });

                using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                {
                    oda.Fill(dtExcelData);
                }
                excel_con.Close();

                dtExcelData.Columns.Add("CreatedBy", typeof(int));
                for (int i = 0; i <= dtExcelData.Rows.Count - 1; i++)
                {
                    dtExcelData.Rows[i]["CreatedBy"] = GlobalInfo.Userid;
                }
                dtExcelData.Columns.Add("CreatedDate", typeof(string));
                for (int i = 0; i <= dtExcelData.Rows.Count - 1; i++)
                {
                    dtExcelData.Rows[i]["CreatedDate"] = DateTime.Now.ToString("dd-MM-yyyy");
                }
                dtExcelData.Columns.Add("IsArchive", typeof(bool));
                for (int i = 0; i <= dtExcelData.Rows.Count - 1; i++)
                {
                    dtExcelData.Rows[i]["IsArchive"] = false;
                }

                DBRoute dbr = new DBRoute();
                dbr.ClearBindSlab();

                string consString = ConfigurationManager.ConnectionStrings["projectconnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.BindSlab";

                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("AgentID", "AgentID");
                        sqlBulkCopy.ColumnMappings.Add("TypeID", "TypeID");
                        sqlBulkCopy.ColumnMappings.Add("SlabID", "SlabID");
                        sqlBulkCopy.ColumnMappings.Add("CreatedBy", "CreatedBy");
                        sqlBulkCopy.ColumnMappings.Add("CreatedDate", "CreatedDate");
                        sqlBulkCopy.ColumnMappings.Add("IsArchive", "IsArchive");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dtExcelData);
                        con.Close();
                    }
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bindslab completed successfully')", true);
            }
        }
    }
}
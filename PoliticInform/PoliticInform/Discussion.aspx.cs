using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using jsLibrary;

namespace PoliticInform
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sds = SqlDataSource1;
        }

        string sql = "";
        object sds = new object();
        static string ConnStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baemung\Documents\KOSTA_Project\Produce300\miniProject2.mdf;Integrated Security=True;Connect Timeout=30";
        SQLDB db = new SQLDB(ConnStr);

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            search();           
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            search();
        }

        protected void search()
        {
            if (tbSearch.Text == "")
            {
                GridView1.DataSourceID = "";
                sds = SqlDataSource1;
                GridView1.DataSource = sds;
                GridView1.DataBind();
            }
            else
            {
                sql = $"select bill_no, bill_name, proposer, detail_link, committee, propose_dt, proc_result from proposition where {ddlist.SelectedValue} like N'%{tbSearch.Text.Trim()}%'";
                GridView1.DataSourceID = "";
                sds = db.Run(sql);
                GridView1.DataSource = sds;
                GridView1.DataBind();
            }
        }
    }
}
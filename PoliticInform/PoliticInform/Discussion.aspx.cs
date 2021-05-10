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
    public partial class Discussion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sds = SqlDataSource;
            GridView1.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        string sql = "";
        object sds = new object();
        SQLDB db = new SQLDB(SiteMaster.ConnStr);

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
                sds = SqlDataSource;
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

        protected void gdv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lnk = (HyperLink)e.Row.FindControl("BILL_NAME");
                lnk.Text = "[상세 링크]";
                lnk.NavigateUrl = db.Get($"select detail_link from proposition where bill_name = N'{((DataRowView)e.Row.DataItem)["BILL_NAME"].ToString().Trim()}'").ToString().Trim();
            }
        }
    }
}
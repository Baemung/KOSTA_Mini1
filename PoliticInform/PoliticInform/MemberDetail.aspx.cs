using jsLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoliticInform
{
    public partial class MemberDetail : System.Web.UI.Page
    {
        protected string id = "";
        string sql = "";
        SQLDB db = new SQLDB(SiteMaster.ConnStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
            }
            if (Request["id"] != null)
            {
                id = Request["id"].ToString();
            }

            sql = $"select jpgLink from totalInfo where deptCd = '{id}'";
            img.ImageUrl = db.Get(sql).ToString();
            dv.DataSourceID = "";
            sql = $"select empNm, hjNm, engNm, polyNm, origNm, reeleGbnNm, bthDate, shrtNm, assemTel, assemEmail, assemHomep, memTitle  from totalInfo where deptCd = '{id}'";
            dv.DataSource = db.Run(sql);
            ViewState["dt"] = db.Run($"select uid, comment from userComment");
            dv.DataBind();
            BindGrid();
        }

        protected void BindGrid()
        {
            GridView1.DataSourceID = "";
            sql = $"select uid, comment from userComment";
            GridView1.DataSource = db.Run(sql);
            GridView1.DataBind();
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {

        }

        protected void btnDislike_Click(object sender, EventArgs e)
        {

        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            sql = $"insert into userComment(uid, deptCd, comment) values (N'{Session["uid"]}',N'{id}',N'{tbComment.Text}')";
            db.Run(sql);
            tbComment.Text = "";
            Response.Redirect($"~/MemberDetail.aspx?id={id}");
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = Convert.ToInt32(e.Row.RowIndex);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete ?')){ return false; };";
                    }
                }
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dt"] as DataTable;
            sql= $"delete from usercomment where uid = N'{dt.Rows[index][0].ToString().Trim()}' and comment = N'{dt.Rows[index][1].ToString().Trim()}'";
            db.Run(sql);
            BindGrid();
        }
    }
}
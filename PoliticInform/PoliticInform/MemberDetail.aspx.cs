using jsLibrary;
using PoliticInform.AppCode;
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
            ViewState["dt"] = db.Run($"select uid, comment from userComment where deptCd = '{id}'");
            dv.DataBind();
            BindGrid();

            sql = $"select [Like] from UserLike where uid = N'{Session["uid"]}' and deptCd = N'{id}'";
            if (db.Get(sql) != null)
            {
                string like = db.Get(sql).ToString().Trim();
                if (like == "1") // Like
                {
                    imgbtnLike.ImageUrl = "Content/Enable_Like.png";
                }
                else if (like == "-1") // Dislike
                {
                    imgbtnDislike.ImageUrl = "Content/Enable_Dislike.png";
                }
            }
            Showlike();
        }

        protected void BindGrid()
        {
            GridView1.DataSourceID = "";
            sql = $"select uid, comment from userComment where deptCd = '{id}'";
            GridView1.DataSource = db.Run(sql);
            GridView1.DataBind();
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            sql = $"select count(*) from usercomment where uid = N'{Session["uid"]}' and deptCd = N'{id}'";
            int ret = (int)db.Get(sql);
            if(ret != 0)
            {
                MessageBox.Show("해당 국회의원에게 코멘트는 1개만 남길 수 있습니다.", this.Page);
            }
            else if(ret == 0)
            {
                sql = $"insert into userComment(uid, deptCd, comment) values (N'{Session["uid"]}',N'{id}',N'{tbComment.Text}')";
                db.Run(sql);
                tbComment.Text = "";
                BindGrid();
            }            
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
            if(dt.Rows[index][0].ToString().Trim() == (string)Session["uid"])
            {
                sql = $"delete from usercomment where uid = N'{dt.Rows[index][0].ToString().Trim()}' and comment = N'{dt.Rows[index][1].ToString().Trim()}'";
                db.Run(sql);
                BindGrid();
            }
            else
            {
                MessageBox.Show("삭제할 수 있는 권한이 없습니다.",this.Page);
            }
        }

        protected void imgbtnLike_Click(object sender, ImageClickEventArgs e)
        {
            sql = $"select [Like] from UserLike where uid = N'{Session["uid"]}' and deptCd = N'{id}'";
            string like = "";
            if (db.Get(sql) == null)
            {
                sql = $"insert into UserLike(uid, deptCd, [Like]) values(N'{Session["uid"]}', N'{id}', '1')";
                db.Run(sql);
                imgbtnLike.ImageUrl = "Content/Enable_Like.png";
            }
            else 
            {
                like = db.Get(sql).ToString().Trim();
                if (like == "0") // No like and No Dislike
                {
                    sql = $"update UserLike set [like] = '1' where uid = '{Session["uid"]}' and deptCd = '{id}'"; // Like
                    imgbtnLike.ImageUrl = "Content/Enable_Like.png";
                }
                else if (like == "1") // Like
                {
                    sql = $"update UserLike set [like] = '0' where uid = '{Session["uid"]}' and deptCd = '{id}'"; // No like and No Dislike
                    imgbtnLike.ImageUrl = "Content/Disable_Like.png";
                }
                else if (like == "-1") // Dislike
                {
                    sql = $"update UserLike set [like] = '1' where uid = '{Session["uid"]}' and deptCd = '{id}'"; // Like
                    imgbtnDislike.ImageUrl = "Content/Disable_Dislike.png";
                    imgbtnLike.ImageUrl = "Content/Enable_Like.png";
                }
                db.Run(sql);
            }
            Showlike();
        }

        protected void imgbtnDislike_Click(object sender, ImageClickEventArgs e)
        {
            sql = $"select [like] from UserLike where uid = '{Session["uid"]}' and deptCd = '{id}'";
            string like = "";
            if (db.Get(sql) == null)
            {
                sql = $"insert into UserLike(uid, deptCd, [like]) values('{Session["uid"]}', '{id}', '-1')";
                db.Run(sql);
                imgbtnDislike.ImageUrl = "Content/Enable_Dislike.png";
            }
            else
            {
                like = db.Get(sql).ToString().Trim();
                if (like == "0") // No like and No Dislike
                {
                    sql = $"update UserLike set [like] = '-1' where uid = '{Session["uid"]}' and deptCd = '{id}'"; // Dislike
                    imgbtnDislike.ImageUrl = "Content/Enable_Dislike.png";
                }
                else if (like == "1") // Like
                {
                    sql = $"update UserLike set [like] = '-1' where uid = '{Session["uid"]}' and deptCd = '{id}'"; // Dislike
                    imgbtnDislike.ImageUrl = "Content/Enable_Dislike.png";
                    imgbtnLike.ImageUrl = "Content/Disable_Like.png";
                }
                else if (like == "-1") // Dislike
                {
                    sql = $"update UserLike set [like] = '0' where uid = '{Session["uid"]}' and deptCd = '{id}'"; // No like and No Dislike
                    imgbtnDislike.ImageUrl = "Content/Disable_Dislike.png";
                }
                db.Run(sql);
            }
            Showlike();
        }

        protected void Showlike()
        {
            sql = $"select count(*) from userlike where deptCd ='{id}' and [like] = '1'";
            lbLike.Text = db.Get(sql).ToString();
            sql = $"select count(*) from userlike where deptCd ='{id}' and [like] = '-1'";
            lbDislike.Text = db.Get(sql).ToString();
        }
    }
}
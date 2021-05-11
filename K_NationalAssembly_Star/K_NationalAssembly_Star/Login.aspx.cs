using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsLibrary;
using Microsoft.SharePoint.Client;
using K_NationalAssembly_Star.AppCode;
using static System.Net.Mime.MediaTypeNames;

namespace K_NationalAssembly_Star
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static public bool isLogin = false;

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uid = tbLoginID.Text;
            string pwd = tbLoginPassword.Text;
            SQLDB db = new SQLDB(SiteMaster.ConnStr);
            string sql = $"select password from userinformation where uid='{uid}'";
            if(db.Get(sql) == null) 
                MessageBox.Show("등록되지 않은 사용자입니다.", this.Page);
            else
            {
                if (db.Get(sql).ToString().Trim() == Register.GetEncrypt(pwd))
                {
                    isLogin = true;
                    Session["uid"] = uid;
                    Response.Redirect("~/Default");
                }
                else 
                    MessageBox.Show("사용자 ID와 비밀번호가 맞지 않습니다.", this.Page);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register");
        }
    }
}
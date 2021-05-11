using K_NationalAssembly_Star.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace K_NationalAssembly_Star
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login.isLogin = false;
            Session["Login"] = Login.isLogin;
            Session["uid"] = null;
            Response.Redirect("~/Default");
        }
    }
}
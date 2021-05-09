using jsLibrary;
using System;
using System.Collections.Generic;
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
            dv.DataBind();
        }
    }
}
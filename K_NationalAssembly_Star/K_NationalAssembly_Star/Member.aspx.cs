using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsLibrary;

namespace K_NationalAssembly_Star
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string sql = "";
        object sds = new object();
        SQLDB db = new SQLDB(SiteMaster.ConnStr);

        protected void MemberSearch(object sender, EventArgs e)
        {
            string name = tbMemberName.Text;
            if (name != null)
            {
                DataList1.DataSourceID = "";
                sql = $"select jpgLink, empNm, origNm, polyNm, shrtNm, reeleGbnNm, deptCd from totalInfo where empNm like N'%{name}%'";
                sds = db.Run(sql);
                DataList1.DataSource = sds;
                DataList1.DataBind();
            }
        }

        //검색하여 db에서 찾아주기 membercurrstate와 memberdetailinfo 두개의 db를 사용함
        protected void btnMemberClick(object sender, EventArgs e)
        {
            string nm = tbMemberName.Text;
            string party = MemberParty.Text;
            string area = MemberArea.Text;
            string committ = MemberCommittee.Text;
            string times = MemberElectedTimes.Text;

            if (party == "전체") party = "";
            if (area == "전체") area = "";
            if (committ == "전체") committ = "";
            if (times == "전체") times = "";

            DataList1.DataSourceID = "";
            sql = $"select jpgLink, empNm, origNm, polyNm, shrtNm, reeleGbnNm, deptCd from totalInfo where empNm like N'%{nm}%' and reeleGbnNm like N'%{times}%' and origNm like N'%{area}%' and polyNm like N'%{party}%' and shrtNm like N'%{committ}%'";
            sds = db.Run(sql);
            DataList1.DataSource = sds;
            DataList1.DataBind();
        }

        protected void MemberReset_Click(object sender, EventArgs e)
        {
            tbMemberName.Text = "";
            MemberParty.Text = "전체";
            MemberArea.Text = "전체";
            MemberCommittee.Text = "전체";
            MemberElectedTimes.Text = "전체";
            DataList1.DataSourceID = "";
            sql = $"select jpgLink, empNm, origNm, polyNm, shrtNm, reeleGbnNm, deptCd from totalInfo";
            sds = db.Run(sql);
            DataList1.DataSource = sds;
            DataList1.DataBind();
        }
    }
}
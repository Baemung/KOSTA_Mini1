using jsLibrary;
using K_NationalAssembly_Star.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace K_NationalAssembly_Star
{
    public partial class UserInfo : System.Web.UI.Page
    {
        string sql = "";
        object sds = new object();
        SQLDB db = new SQLDB(SiteMaster.ConnStr);
        string nam = "";
        string bthDay = "";
        string gend = "";
        string phone = "";
        string mail = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            sql = $"select name, bthday, gender, phone, email from Userinformation where uid = N'{Session["uid"]}'";
            DataTable dt = (DataTable)db.Run(sql);
            nam = Convert.ToString(dt.Rows[0][0]).Trim();
            bthDay = Convert.ToString(dt.Rows[0][1]).Trim();
            gend = Convert.ToString(dt.Rows[0][2]).Trim();
            phone = Convert.ToString(dt.Rows[0][3]).Trim();
            mail = Convert.ToString(dt.Rows[0][4]).Trim();
            if(tbUserName.Text == "" && tbUserbday.Text == "" && tbUserEmail.Text == "" && UserPhoneSecond.Text == "" && UserPhoneThird.Text == "")
            {
                tbUserName.Text = nam;
                tbUserbday.Text = bthDay;
                UserGender.Text = gend;
                UserPhoneFirst.Text = phone.Substring(0, 3);
                UserPhoneSecond.Text = phone.Substring(3, 4);
                UserPhoneThird.Text = phone.Substring(7, 4);
                tbUserEmail.Text = mail;
            }

            DataList1.DataSourceID = "";
            sql = $"select I.jpgLink, I.empNm, I.origNm,I. polyNm, I.shrtNm, I.reeleGbnNm, I.deptCd from totalInfo I, userlike U where U.uid = N'{Session["uid"]}' and U.deptCd = I.deptcd and U.[like] = '1'";
            sds = db.Run(sql);
            DataList1.DataSource = sds;
            DataList1.DataBind();

            DataList2.DataSourceID = "";
            sql = $"select I.jpgLink, I.empNm, I.origNm,I. polyNm, I.shrtNm, I.reeleGbnNm, I.deptCd from totalInfo I, userlike U where U.uid = N'{Session["uid"]}' and U.deptCd = I.deptcd and U.[like] = '-1'";
            sds = db.Run(sql);
            DataList2.DataSource = sds;
            DataList2.DataBind();

            DataList3.DataSourceID = "";
            sql = $"select I.jpgLink, I.empNm, I.origNm,I. polyNm, I.shrtNm, I.reeleGbnNm, I.deptCd from totalInfo I, userComment U where U.uid = N'{Session["uid"]}' and U.deptCd = I.deptcd";
            sds = db.Run(sql);
            DataList3.DataSource = sds;
            DataList3.DataBind();
        }

        protected void btnChangeClick(object sender, EventArgs e)
        {
            nam = tbUserName.Text;
            bthDay = tbUserbday.Text;
            gend = UserGender.SelectedValue.ToString();
            mail = tbUserEmail.Text;
            phone = UserPhoneFirst.Text + UserPhoneSecond.Text + UserPhoneThird.Text;
            if (tbUserName.Text == "" || tbUserbday.Text.Length != 8 || UserGender.Text == "" || phone.Length != 11 || !tbUserEmail.Text.Contains("@") || !tbUserEmail.Text.Contains(".")) MessageBox.Show("수정 할 회원 정보를 올바르게 입력해주세요.", this.Page);
            else
            {
                string sql = $"update userinformation set name = N'{nam}', bthday = '{bthDay}', gender = N'{gend}', phone = '{phone}', email = '{mail}' where uid = N'{Session["uid"]}'";
                db.Run(sql);
                MessageBox.Show("정보가 수정되었습니다.", this.Page);
            }
        }
    }
}
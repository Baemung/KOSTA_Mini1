using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsLibrary;
using PoliticInform.AppCode;

namespace PoliticInform
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        SQLDB db = new SQLDB(SiteMaster.ConnStr);
        static bool idcheck = false;

        protected void RegisterUser(object sender, EventArgs e)
        {
            string uid = RegisterID.Text;
            string pwd = RegisterPassword.Text;
            string cpwd = ConfirmPassword.Text;
            string nam = RegisterName.Text;
            string bthDay = RegisterBthDay.Text;
            string gend = RegisterGender.Text;
            string phone = RegisterPhoneFirst.Text;
            phone += RegisterPhoneSecond.Text;
            phone += RegisterPhoneThird.Text;
            string mail = RegisterEmail.Text;

            if (!idcheck) MessageBox.Show("ID 중복체크를 확인해주세요.", this.Page);
            else if (cpwd != pwd || pwd.Length < 8) MessageBox.Show("비밀번호를 다시 확인해주세요.", this.Page);
            else if (nam == "" || bthDay.Length != 8 || gend == "" || phone.Length != 11 || !mail.Contains("@") || !mail.Contains(".")) MessageBox.Show("회원 정보를 올바르게 입력해주세요.", this.Page);
            else
            {
                pwd = GetEncrypt(pwd);
                string sql = $"insert into userinformation values ('{uid}', '{pwd}', N'{nam}', '{bthDay}', N'{gend}', '{phone}', '{mail}')";
                db.Run(sql);
                Session["uid"] = uid;
                Login.isLogin = true;
                Response.Redirect("~/default");
            }
        }

        protected void btnIDcheck_Click(object sender, EventArgs e)
        {
            if(db.Get($"select count(*) from userinformation where uid = N'{RegisterID.Text}'").ToString() == "0" && RegisterID.Text.Length>= 6)
            {
                idcheck = true;
                MessageBox.Show("사용 가능한 ID 입니다.", this.Page);
            }
            else
            {
                idcheck = false;
                MessageBox.Show("사용 불가능한 ID 입니다.", this.Page);
            }
        }

        public static string GetEncrypt(string originmsg)
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] bArr = md.ComputeHash(Encoding.Default.GetBytes(originmsg));
            string retS = "";
            for (int i = 0; i < bArr.Length; i++)
            {
                retS += $"{bArr[i]:x2}";
            }

            return retS;
        }
    }
}
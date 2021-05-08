using System;
using System.Collections.Generic;
using System.Linq;
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
        static string ConnStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baemung\Documents\KOSTA_Project\Produce300\miniProject2.mdf;Integrated Security=True;Connect Timeout=30";
        SQLDB db = new SQLDB(ConnStr);
        static bool idcheck = false;
        //protected void PwdConfirm(object sender, EventArgs e)
        //{
        //    string pwd1 = RegisterPassword.Text;
        //    string pwd2 = ConfirmPassword.Text;
        //    if (pwd1 == pwd2)
        //    {
        //        RegisterPassword.Text = pwd1;
        //        ConfirmPassword.Text = pwd2;
        //        Label1.Text = "두 비밀번호가 서로 일치합니다";
        //    }
        //    else
        //    {
        //        Label1.Text = "두 비밀번호가 일치하는지 다시 확인해주세요.";
        //    }
        //}
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
                string sql = $"insert into userinformation values ('{uid}', '{pwd}', N'{nam}', '{bthDay}', N'{gend}', '{phone}', '{mail}')";
                db.Run(sql);
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
    }
}
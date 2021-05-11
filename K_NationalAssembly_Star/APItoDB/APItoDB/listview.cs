using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using jsLibrary;

namespace APItoDB
{
    class listview
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            //int idx = 1;
            //string url = "https://open.assembly.go.kr/portal/openapi/nzmimeepazxkubdpn";
            //url += "?KEY=56b2e7226ed44493bb044c9e79d94613"; // Service Key
            //url += "&AGE=21";
            //url += "&pSize=1000";
            //url += $"&pIndex={idx}";

            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";

            //string results = string.Empty;
            //HttpWebResponse response;
            //using (response = request.GetResponse() as HttpWebResponse)
            //{
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    results = reader.ReadToEnd();
            //}
            SQLDB db = new SQLDB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baemung\Documents\KOSTA\Cs\ASP.NET\miniProject2.mdf;Integrated Security=True;Connect Timeout=30");

            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\Baemung\Documents\KOSTA_Project\Produce300\api.xml");
            XmlNodeList xnlist = xml.GetElementsByTagName("row");
            foreach (XmlNode xn in xnlist)
            {
                string BILL_NO = "", BILL_NAME = "", COMMITTEE = "", PROPOSE_DT = "", PROC_RESULT = "", AGE = "", 
                       DETAIL_LINK = "", PROPOSER = "", MEMBER_LIST = "", RST_PROPOSER = "", PUBL_PROPOSER = "";

                if (xn["BILL_NO"] != null)
                {
                    BILL_NO = xn["BILL_NO"].InnerText;
                }
                if (xn["BILL_NAME"] != null)
                {
                    BILL_NAME = xn["BILL_NAME"].InnerText;
                }
                if (xn["COMMITTEE"] != null)
                {
                    COMMITTEE = xn["COMMITTEE"].InnerText;
                }
                if (xn["PROPOSE_DT"] != null)
                {
                    PROPOSE_DT = xn["PROPOSE_DT"].InnerText;
                }
                if (xn["PROC_RESULT"] != null)
                {
                    PROC_RESULT = xn["PROC_RESULT"].InnerText;
                }
                if (xn["AGE"] != null)
                {
                    AGE = xn["AGE"].InnerText;
                }
                if (xn["DETAIL_LINK"] != null)
                {
                    DETAIL_LINK = xn["DETAIL_LINK"].InnerText;
                }
                if (xn["PROPOSER"] != null)
                {
                    PROPOSER = xn["PROPOSER"].InnerText;
                }
                if (xn["MEMBER_LIST"] != null)
                {
                    MEMBER_LIST = xn["MEMBER_LIST"].InnerText;
                }
                if (xn["RST_PROPOSER"] != null)
                {
                    RST_PROPOSER = xn["RST_PROPOSER"].InnerText;
                }
                if (xn["PUBL_PROPOSER"] != null)
                {
                    PUBL_PROPOSER = xn["PUBL_PROPOSER"].InnerText;
                }
                db.Run($"insert into Proposition values (N'{BILL_NO}',  N'{AGE}', N'{BILL_NAME}', N'{PROPOSER}', N'{RST_PROPOSER}', N'{PUBL_PROPOSER}', " +
                    $"N'{DETAIL_LINK}', N'{COMMITTEE}', N'{PROPOSE_DT}', N'{PROC_RESULT}', N'{MEMBER_LIST}')");
            }
        }
        public class SQLDB
        {
            //  클래스 변수 정의
            SqlConnection sqlConn = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand();
            string ConnStr;

            //  클래스 생성자 정의 - 클래스 명과 동일
            public SQLDB(string s) // s : connection string 연결 문자열
            {
                ConnStr = s;
                sqlConn.ConnectionString = ConnStr;
                sqlConn.Open();
                sqlCmd.Connection = sqlConn;
            }

            //  클래스 함수(메쏘드) 정의 
            public object Run(string sql)
            {
                sqlCmd.CommandText = sql;   // "  select * from fstatus    "
                if (jslib.GetToken(0, sql.Trim(), ' ').ToUpper() == "SELECT") // "[SELECT] count(*) from fstatus"
                {
                    SqlDataReader sr = sqlCmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sr);
                    sr.Close();

                    return dt;
                }
                else
                {
                    return sqlCmd.ExecuteNonQuery();  // insert, update, delete, create, alter 등 조회결과가 없는 SQL문 처리
                }
            }
            public object Get(string sql)   // 단일 필드 데이터 반환
            {
                sqlCmd.CommandText = sql;   // "  select count(*) from fstatus    "
                if (jslib.GetToken(0, sql.Trim(), ' ').ToUpper() == "SELECT") // "[SELECT] count(*) from fstatus"
                {
                    return sqlCmd.ExecuteScalar();
                }
                return null;
            }
        }
    }
}

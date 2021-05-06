using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Xml;
using jsLibrary;
using System.Data.SqlClient;
using System.Data;

namespace APItoDB
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main1(string[] args)
        {
            SQLDB db = new SQLDB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anvo9\KOSTA\Cs\ASP.NET\miniProject2.mdf;Integrated Security=True;Connect Timeout=30");
            for (int i = 1; i < 5000; i++)
            {
                if(db.Get($"select empNm from MemberCurrState where num = '{i}'") == null)
                {
                    continue;
                }
                string name = db.Get($"select deptCd from MemberCurrState where num = '{i}'").ToString().Trim();

                string url1 = "http://apis.data.go.kr/9710000/NationalAssemblyInfoService/getPressAticle";
                url1 += "?ServiceKey=3ALdT05j7OIH13Yqz5elfARolLZV9VbO3HL0jtidu7Jdbjn64g%2BTosh%2Bm0zMjXwwHbmRnPCc8lwPc5uU1vgobg%3D%3D"; // Service Key
                url1 += $"&hg_nm={name}";

                var request = (HttpWebRequest)WebRequest.Create(url1);
                request.Method = "GET";

                string results = string.Empty;
                HttpWebResponse response;
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    results = reader.ReadToEnd();
                }

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(results);
                XmlNodeList xnlist = xml.GetElementsByTagName("item");
                foreach (XmlNode xn in xnlist)
                {
                    string title = "", url = "", regdate = "";

                    if (xn["title"] != null)
                    {
                        title = xn["title"].InnerText;
                    }
                    if (xn["url"] != null)
                    {
                        url = xn["url"].InnerText;
                    }
                    if (xn["regdate"] != null)
                    {
                        regdate = xn["regdate"].InnerText;
                    }
                    Console.WriteLine(title, url, regdate);        
                    //db.Run($"insert into MemberDetailInfo values (N'{title}', N'{url}', N'{regdate}', N'{name}')");
                }
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
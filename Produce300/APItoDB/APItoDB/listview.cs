using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Data;

namespace APItoDB
{
    class listview
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            int idx = 1;
            string url = "https://open.assembly.go.kr/portal/openapi/nzmimeepazxkubdpn";
            url += "?KEY=56b2e7226ed44493bb044c9e79d94613"; // Service Key
            url += "&AGE=21";
            url += "&pSize=1000";
            url += $"&pIndex={idx}";

            var request = (HttpWebRequest)WebRequest.Create(url);
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
            XmlNodeList xnlist = xml.GetElementsByTagName("row");
            foreach (XmlNode xn in xnlist)
            {
                string BILL_ID = "", BILL_NO = "", BILL_NAME = "", COMMITTEE = "", PROPOSE_DT = "", PROC_RESULT = "", AGE = "", 
                       DETAIL_LINK = "", PROPOSER = "", MEMBER_LIST = "", RST_PROPOSER = "", PUBL_PROPOSER = "", COMMITTEE_ID = "";

                if (xn["BILL_ID"] != null)
                {
                    BILL_ID = xn["BILL_ID"].InnerText;
                }
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
                if (xn["COMMITTEE_ID"] != null)
                {
                    COMMITTEE_ID = xn["COMMITTEE_ID"].InnerText;
                }

                Console.WriteLine(BILL_ID, BILL_NO, BILL_NAME, COMMITTEE, PROPOSE_DT, PROC_RESULT, AGE, DETAIL_LINK, PROPOSER, MEMBER_LIST, RST_PROPOSER, PUBL_PROPOSER, COMMITTEE_ID);
            }
        }
    }
}

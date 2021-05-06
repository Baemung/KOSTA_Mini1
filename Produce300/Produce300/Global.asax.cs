using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System;
using System.Net;
using System.Net.Http;
using System.IO;

namespace Produce300
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        static HttpClient client = new HttpClient();
        public static string ret;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string url = "http://apis.data.go.kr/9710000/NationalAssemblyInfoService/getMemberCurrStateList"; // URL
            url += "?ServiceKey=" + "3ALdT05j7OIH13Yqz5elfARolLZV9VbO3HL0jtidu7Jdbjn64g%2BTosh%2Bm0zMjXwwHbmRnPCc8lwPc5uU1vgobg%3D%3D"; // Service Key
            url += "&numOfRows=10";
            url += "&pageNo=1";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
            ret = results;
        }
    }
}

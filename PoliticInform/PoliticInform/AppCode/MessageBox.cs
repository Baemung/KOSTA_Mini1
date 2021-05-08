using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PoliticInform.AppCode
{
   public static class MessageBox
   {
       public static void Show(string message, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "MessageBox", "alert(\"" + message.Replace(@"\", @"\\") + "\");", true);
        }
    }
}
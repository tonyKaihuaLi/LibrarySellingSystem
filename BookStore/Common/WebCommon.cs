using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class WebCommon
    {
        public static bool CheckValidateCode(string validateCode)
        {
            bool isSuccess = false;
            if (HttpContext.Current.Session["Vcode"] != null)
            {
                
                string sysCode = HttpContext.Current.Session["Vcode"].ToString();
                if (sysCode.Equals(validateCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    isSuccess = true;
                    HttpContext.Current.Session["vCode"] = null;
                }
            }

            return isSuccess;
        }
    }
}

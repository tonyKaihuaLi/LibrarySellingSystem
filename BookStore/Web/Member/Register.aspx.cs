using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
//using BookStore.Model;
using Web.Enum;

namespace Web.Member
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (CheckSession())
                {
                    AddUserInfo();
                }
            }
        }

        protected bool CheckSession()
        {
            bool isSuccess = false;
            if (Session["vCode"] != null)
            {
                string txtCode = Request["txtCode"];
                string sysCode = Session["vCode"].ToString();
                if (sysCode.Equals(txtCode, StringComparison.InvariantCulture))
                {
                    isSuccess = true;
                    Session["vCode"] = null;
                }
            }

            return isSuccess;
        }

        protected void AddUserInfo()
        {
            Model.User userInfo=new User();
            userInfo.Address = Request["txtAddress"];
            userInfo.LoginId = Request["txtName"];
            userInfo.LoginPwd = Request["txtPwd"];
            userInfo.Mail = Request["txtEmail"];
            userInfo.Name = Request["txtRealName"];
            userInfo.Phone = Request["txtPhone"];
            userInfo.UserState.Id = Convert.ToInt32(UserStateEnum.NormalState);
            

        }
    }
}
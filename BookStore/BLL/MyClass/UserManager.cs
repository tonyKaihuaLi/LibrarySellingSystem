using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class UserManager
    {
        public int Add(Model.User model, out string msg)
        {
            int isSuccess = -1;
            if (ValidateUserName(model.LoginId))
            {
                msg = "Username has been registered";
                return isSuccess;
            }
            else
            {
                isSuccess= dal.Add(model);
                msg = "Success";
                return isSuccess;
            }
        }

        public bool ValidateUserName(string userName)
        {
            return dal.GetModel(userName) != null ? true : false;
        }

        public bool CheckUserMail(string mail)
        {
            return dal.CheckUserMail(mail) > 0 ? true : false;
        }


    }
}

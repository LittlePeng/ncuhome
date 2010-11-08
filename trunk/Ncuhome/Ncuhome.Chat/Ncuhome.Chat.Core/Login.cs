using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using Ncuhome.Chat.Model;


namespace Ncuhome.Chat.Core
{
    public class Login:SingltonObject<Login>
    {
        public bool CheckLogin(string userName, string password)
        {
            FormsAuthentication.SetAuthCookie(userName, false);
            return true;
        }
        public void CheckLogOut()
        {
            FormsAuthentication.SignOut();
        }

        public bool CheckLogin()
        {
            return HttpContext.Current.Request.IsAuthenticated;
        }

        public UserModel GetLoginUserInfo()
        {
            return new UserModel();
        }

        public int GetLoginUserId()
        {
            return 1;
        }
    }
}

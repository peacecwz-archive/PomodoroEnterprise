using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PomodoroEnterprise.API
{
    public class UserHelper
    {
        public static string GetUsername()
        {
            var username = HttpContext.Current.Request.GetOwinContext().Authentication.User.Claims.FirstOrDefault(p => p.Type == "username");
            return username.Value;
        }

        public static Guid GetUserId()
        {
            var userid = HttpContext.Current.Request.GetOwinContext().Authentication.User.Claims.FirstOrDefault(p => p.Type == "userid");
            return Guid.Parse(userid.Value);
        }
    }
}
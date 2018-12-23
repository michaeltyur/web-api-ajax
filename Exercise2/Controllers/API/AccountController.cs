using Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Exercise2.Controllers
{
    [RoutePrefix("logApi")]
    public class AccountController : ApiController
    {

        // GET: api/Account/5
        [Route("login")]
        public User Login([FromBody] User user)
        {

            User _user = new User();

            using (MyAppContext context = new MyAppContext())
            {
                _user = context.Users.FirstOrDefault(u => u.UserName == user.UserName&&u.Password==user.Password);
                if (_user!=null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                }
            }
            return _user;
        }

        [Route("logout")]
        public User Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
              

                var resp = new HttpResponseMessage();

                // clear authentication cookie

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                cookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext current = HttpContext.Current;
                current.Response.Cookies.Add(cookie);

            }
            return null;
        }
    }
}

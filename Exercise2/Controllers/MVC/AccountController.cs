using Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Exercise2.Controllers.MVC
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (MyAppContext context = new MyAppContext())
            {
                User _user = context.Users.FirstOrDefault(u => u.UserName == model.UserName);
                if (_user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User does not exist");
                    return View(model);
                }
            }

        }
        public ActionResult Logout()
        {
            if(User.Identity.IsAuthenticated)
            {
               FormsAuthentication.SignOut();
               
               HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
               {
                   Expires = DateTime.Now.AddYears(-1)
               };
               Response.Cookies.Add(cookie);

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
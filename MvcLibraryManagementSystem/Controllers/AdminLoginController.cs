using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN p)
        {
            var values = db.TBLADMIN.FirstOrDefault(x => x.AdminUser == p.AdminUser && x.AdminPassword == p.AdminPassword);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.AdminUser, false);
                Session["AdminUser"] = values.AdminUser.ToString();
                return RedirectToAction("Index", "Statistics");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AdminLogin");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;
using System.Web.Security;

namespace MvcLibraryManagementSystem.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(TBLMEMBER p)
        {
            var values = db.TBLMEMBER.FirstOrDefault(x => x.MemberMail == p.MemberMail && x.MemberPassword == p.MemberPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.MemberMail, false);
                Session["Mail"] = values.MemberMail.ToString();
                return RedirectToAction("Index", "MyPanel");
            }
            else
            {
                return View();
            }           
        }
    }
}
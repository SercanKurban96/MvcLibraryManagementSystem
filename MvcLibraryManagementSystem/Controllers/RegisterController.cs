using MvcLibraryManagementSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryManagementSystem.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        DbLibraryEntities db = new DbLibraryEntities();
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(TBLMEMBER p)
        {
            if (!ModelState.IsValid)
            {
                return View("SignUp");
            }
            db.TBLMEMBER.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}
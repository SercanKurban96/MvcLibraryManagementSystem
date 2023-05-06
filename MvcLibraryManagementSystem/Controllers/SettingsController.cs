using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var users = db.TBLADMIN.ToList();
            return View(users);
        }
        public ActionResult Index2()
        {
            var users = db.TBLADMIN.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult NewAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(TBLADMIN p)
        {
            db.TBLADMIN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminDelete(int id)
        {
            var find = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(find);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            var admin = db.TBLADMIN.Find(id);
            return View("AdminEdit", admin);
        }
        [HttpPost]
        public ActionResult AdminEdit(TBLADMIN t)
        {
            var adm = db.TBLADMIN.Find(t.AdminID);
            adm.AdminUser = t.AdminUser;
            adm.AdminPassword = t.AdminPassword;
            adm.Authority = t.Authority;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}
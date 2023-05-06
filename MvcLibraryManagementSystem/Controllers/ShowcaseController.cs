using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;
using MvcLibraryManagementSystem.Models.Classes;

namespace MvcLibraryManagementSystem.Controllers
{
    [AllowAnonymous]
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        DbLibraryEntities db = new DbLibraryEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.value1 = db.TBLBOOK.ToList();
            cs.value2 = db.TBLABOUTUS.ToList();
            //var values = db.TBLBOOK.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLCONTACT t)
        {
            db.TBLCONTACT.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
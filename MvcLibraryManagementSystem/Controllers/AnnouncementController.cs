using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var values = db.TBLANNOUNCEMENTS.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AnnouncementAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AnnouncementAdd(TBLANNOUNCEMENTS t)
        {
            db.TBLANNOUNCEMENTS.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AnnouncementDelete(int id)
        {
            var find = db.TBLANNOUNCEMENTS.Find(id);
            db.TBLANNOUNCEMENTS.Remove(find);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AnnouncementDetail(int id)
        {
            var ann = db.TBLANNOUNCEMENTS.Find(id);
            return View("AnnouncementDetail", ann);
        }
        public ActionResult AnnouncementEdit(TBLANNOUNCEMENTS t)
        {
            var ann = db.TBLANNOUNCEMENTS.Find(t.AnnouncementID);
            ann.AnnouncementCategory = t.AnnouncementCategory;
            ann.AnnouncementContent = t.AnnouncementContent;
            ann.AnnouncementDate = t.AnnouncementDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
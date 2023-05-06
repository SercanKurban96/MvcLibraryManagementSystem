using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var value1 = db.TBLMEMBER.Count();
            var value2 = db.TBLBOOK.Count();
            var value3 = db.TBLBOOK.Where(x => x.Status == false).Count();
            var value4 = db.TBLPENAL.Sum(x => x.Cash);
            ViewBag.val1 = value1;
            ViewBag.val2 = value2;
            ViewBag.val3 = value3;
            ViewBag.val4 = value4;
            return View();
        }
        public ActionResult Weather()
        {
            return View();
        }
        public ActionResult WeatherCard()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase fileBase)
        {
            if (fileBase.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/web2/gallery/"), Path.GetFileName(fileBase.FileName));
                fileBase.SaveAs(filePath);
            }
            return RedirectToAction("Gallery");
        }
        public ActionResult LinqCard()
        {
            var value1 = db.TBLBOOK.Count();
            var value2 = db.TBLMEMBER.Count();
            var value3 = db.TBLPENAL.Sum(x => x.Cash);
            var value4 = db.TBLBOOK.Where(x => x.Status == false).Count();
            var value5 = db.TBLCATEGORY.Count();
            var value6 = db.MostActiveMember().FirstOrDefault();
            var value7 = db.MostReadBook().FirstOrDefault();
            var value8 = db.MostBookAuthor().FirstOrDefault();
            var value9 = db.TBLBOOK.GroupBy(x => x.PublishingHouse).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var value10 = db.MostSuccessfulEmployee().FirstOrDefault();
            var value11 = db.TBLCONTACT.Count();
            var value12 = db.TBLACTING.Where(x => x.AcquisitionDate == DateTime.Today).Select(z => z.Book).Count();

            ViewBag.val1 = value1;
            ViewBag.val2 = value2;
            ViewBag.val3 = value3;
            ViewBag.val4 = value4;
            ViewBag.val5 = value5;
            ViewBag.val6 = value6;
            ViewBag.val7 = value7;
            ViewBag.val8 = value8;
            ViewBag.val9 = value9;
            ViewBag.val10 = value10;
            ViewBag.val11 = value11;
            ViewBag.val12 = value12;
            return View();
        }
    }
}
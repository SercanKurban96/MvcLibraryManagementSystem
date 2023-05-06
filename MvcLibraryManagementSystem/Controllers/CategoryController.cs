using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcLibraryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index(int page = 1)
        {
            var values = db.TBLCATEGORY.Where(x=>x.CategoryStatus == true).ToList().ToPagedList(page, 5);
            return View(values);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(TBLCATEGORY category)
        {
            db.TBLCATEGORY.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var ctg = db.TBLCATEGORY.Find(id);
            //db.TBLCATEGORY.Remove(ctg);
            ctg.CategoryStatus = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int id)
        {
            var ctg = db.TBLCATEGORY.Find(id);
            return View("CategoryBring", ctg);
        }
        public ActionResult CategoryEdit(TBLCATEGORY category)
        {
            var cat = db.TBLCATEGORY.Find(category.CategoryID);
            cat.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
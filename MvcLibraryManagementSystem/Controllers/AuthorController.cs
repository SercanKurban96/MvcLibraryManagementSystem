using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var values = db.TBLAUTHOR.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AuthorAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorAdd(TBLAUTHOR author)
        {
            if (!ModelState.IsValid)
            {
                return View("AuthorAdd");
            }
            db.TBLAUTHOR.Add(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorDelete(int id)
        {
            var find = db.TBLAUTHOR.Find(id);
            db.TBLAUTHOR.Remove(find);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBring(int id)
        {
            var author = db.TBLAUTHOR.Find(id);
            return View("AuthorBring", author);
        }
        public ActionResult AuthorEdit(TBLAUTHOR author)
        {
            var aut = db.TBLAUTHOR.Find(author.AuthorID);
            aut.AuthorName = author.AuthorName;
            aut.AuthorSurname = author.AuthorSurname;
            aut.AuthorDetail = author.AuthorDetail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBooks(int id)
        {
            var author = db.TBLBOOK.Where(x => x.Author == id).ToList();
            var authorname = db.TBLAUTHOR.Where(y => y.AuthorID == id).Select(z => z.AuthorName + " " + z.AuthorSurname).FirstOrDefault();
            ViewBag.a1 = authorname;
            return View(author);
        }
    }
}
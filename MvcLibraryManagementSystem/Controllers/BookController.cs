using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index(string p)
        {
            //var books = db.TBLBOOK.ToList();
            var books = from x in db.TBLBOOK.ToList() select x;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(x => x.BookName.Contains(p));
            }
            return View(books.ToList());
        }

        [HttpGet]
        public ActionResult BookAdd()
        {
            List<SelectListItem> value1 = (from x in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName + " " + x.AuthorSurname,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            ViewBag.vl2 = value2;
            return View();
        }
        [HttpPost]
        public ActionResult BookAdd(TBLBOOK book)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                book.BookPhoto = "/Image/" + fileName + extension;
            }

            var ctg = db.TBLCATEGORY.Where(x=>x.CategoryID == book.TBLCATEGORY.CategoryID).FirstOrDefault();
            var aut = db.TBLAUTHOR.Where(x=>x.AuthorID == book.TBLAUTHOR.AuthorID).FirstOrDefault();
            book.TBLCATEGORY = ctg;
            book.TBLAUTHOR = aut;
            db.TBLBOOK.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookDelete(int id)
        {
            var find = db.TBLBOOK.Find(id);
            db.TBLBOOK.Remove(find);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookBring(int id)
        {
            var bk = db.TBLBOOK.Find(id);
            List<SelectListItem> value1 = (from x in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName + " " + x.AuthorSurname,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            ViewBag.vl2 = value2;
            return View("BookBring", bk);
        }
        public ActionResult BookEdit(TBLBOOK p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.BookPhoto = "/Image/" + fileName + extension;
            }

            var book = db.TBLBOOK.Find(p.BookID);
            book.BookName = p.BookName;
            book.PublicationYear = p.PublicationYear;
            book.Page = p.Page;
            book.PublishingHouse = p.PublishingHouse;
            book.Status = true;
            var ctg = db.TBLCATEGORY.Where(x => x.CategoryID == p.TBLCATEGORY.CategoryID).FirstOrDefault();
            var aut = db.TBLAUTHOR.Where(x => x.AuthorID == p.TBLAUTHOR.AuthorID).FirstOrDefault();
            book.Category = ctg.CategoryID;
            book.Author = aut.AuthorID;
            book.BookPhoto = p.BookPhoto;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
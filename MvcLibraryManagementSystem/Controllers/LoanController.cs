using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        DbLibraryEntities db = new DbLibraryEntities();
        [Authorize(Roles = "A")]

        //Ödünç Alma İşlemi
        public ActionResult Index()
        {
            var values = db.TBLACTING.Where(x => x.TransactionStatus == false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Lender()
        {
            List<SelectListItem> value1 = (from x in db.TBLMEMBER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.MemberName + " " + x.MemberSurname,
                                               Value = x.MemberID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in db.TBLBOOK.Where(x=>x.Status == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BookName,
                                               Value = x.BookID.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in db.TBLEMPLOYEE.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.val1 = value1;
            ViewBag.val2 = value2;
            ViewBag.val3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult Lender(TBLACTING acting)
        {
            var v1 = db.TBLMEMBER.Where(x => x.MemberID == acting.TBLMEMBER.MemberID).FirstOrDefault();
            var v2 = db.TBLBOOK.Where(y => y.BookID == acting.TBLBOOK.BookID).FirstOrDefault();
            var v3 = db.TBLEMPLOYEE.Where(z => z.EmployeeID == acting.TBLEMPLOYEE.EmployeeID).FirstOrDefault();
            acting.TBLMEMBER = v1;
            acting.TBLBOOK = v2;
            acting.TBLEMPLOYEE = v3;
            db.TBLACTING.Add(acting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LoanReturn(int id)
        {
            var loan = db.TBLACTING.Find(id);
            // Bu kısımda hata alıyorum.
            DateTime d1 = DateTime.Parse(loan.ReturnDate.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.val = d3.TotalDays;
            return View("LoanReturn", loan);

            //var loan = db.TBLACTING.Find(id);
            //return View("LoanReturn", loan);
        }
        public ActionResult LoanEdit(TBLACTING p)
        {
            var act = db.TBLACTING.Find(p.ActingID);
            act.BringMemberDate = p.BringMemberDate;
            act.TransactionStatus = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
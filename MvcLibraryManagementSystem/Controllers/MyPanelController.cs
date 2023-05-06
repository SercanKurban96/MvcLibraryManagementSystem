using MvcLibraryManagementSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibraryManagementSystem.Controllers
{
    [Authorize]
    public class MyPanelController : Controller
    {
        // GET: MyPanel
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var membermail = (string)Session["Mail"];
            //var values = db.TBLMEMBER.FirstOrDefault(z => z.MemberMail == membermail);
            var values = db.TBLANNOUNCEMENTS.ToList();

            var v1 = db.TBLMEMBER.Where(x => x.MemberMail == membermail).Select(y => y.MemberName).FirstOrDefault();
            ViewBag.v1 = v1;

            var v2 = db.TBLMEMBER.Where(x => x.MemberMail == membermail).Select(y => y.MemberSurname).FirstOrDefault();
            ViewBag.v2 = v2;

            var v3 = db.TBLMEMBER.Where(x => x.MemberMail == membermail).Select(y => y.MemberPhotoUrl).FirstOrDefault();
            ViewBag.v3 = v3;

            var v4 = db.TBLMEMBER.Where(x => x.MemberMail == membermail).Select(y => y.MemberUsername).FirstOrDefault();
            ViewBag.v4 = v4;

            var v5 = db.TBLMEMBER.Where(x => x.MemberMail == membermail).Select(y => y.MemberSchool).FirstOrDefault();
            ViewBag.v5 = v5;

            var v6 = db.TBLMEMBER.Where(x => x.MemberMail == membermail).Select(y => y.MemberTelephone).FirstOrDefault();
            ViewBag.v6 = v6;

            var v7 = db.TBLMEMBER.Where(x => x.MemberMail == membermail).Select(y => y.MemberMail).FirstOrDefault();
            ViewBag.v7 = v7;

            var memberid = db.TBLMEMBER.Where(x => x.MemberMail == membermail).Select(y => y.MemberID).FirstOrDefault();
            var v8 = db.TBLACTING.Where(x => x.Member == memberid).Count();
            ViewBag.v8 = v8;

            var v9 = db.TBLMESSAGES.Where(x => x.Receiver == membermail).Count();
            ViewBag.v9 = v9;

            var v10 = db.TBLANNOUNCEMENTS.Count();
            ViewBag.v10 = v10;

            return View(values);
        }
        [HttpPost]
        public ActionResult Index2(TBLMEMBER p)
        {
            var username = (string)Session["Mail"];
            var member = db.TBLMEMBER.FirstOrDefault(x => x.MemberMail == username);
            member.MemberPassword = p.MemberPassword;
            member.MemberName = p.MemberName;
            member.MemberPhotoUrl = p.MemberPhotoUrl;
            member.MemberSchool = p.MemberSchool;
            member.MemberUsername = p.MemberUsername;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MyBooks()
        {
            var username = (string)Session["Mail"];
            var id = db.TBLMEMBER.Where(x => x.MemberMail == username.ToString()).Select(z => z.MemberID).FirstOrDefault();
            var values = db.TBLACTING.Where(x => x.Member == id).ToList();
            return View(values);
        }
        public ActionResult Announcement()
        {
            var annlist = db.TBLANNOUNCEMENTS.ToList();
            return View(annlist);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn", "Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var user = (string)Session["Mail"];
            var id = db.TBLMEMBER.Where(x => x.MemberMail == user).Select(y => y.MemberID).FirstOrDefault();
            var findmember = db.TBLMEMBER.Find(id);
            return PartialView("Partial2", findmember);
        }
    }
}
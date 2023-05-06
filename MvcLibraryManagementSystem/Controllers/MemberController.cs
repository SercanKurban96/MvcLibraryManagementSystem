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
    public class MemberController : Controller
    {
        // GET: Member
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index(int page = 1)
        {
            var members = db.TBLMEMBER.ToList().ToPagedList(page, 5);
            return View(members);
        }
        [HttpGet]
        public ActionResult MemberAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MemberAdd(TBLMEMBER member)
        {
            if (!ModelState.IsValid)
            {
                return View("MemberAdd");
            }
            db.TBLMEMBER.Add(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberDelete(int id)
        {
            var mem = db.TBLMEMBER.Find(id);
            db.TBLMEMBER.Remove(mem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberBring(int id)
        {
            var ctg = db.TBLMEMBER.Find(id);
            return View("MemberBring", ctg);
        }
        public ActionResult MemberEdit(TBLMEMBER member)
        {
            var mem = db.TBLMEMBER.Find(member.MemberID);
            mem.MemberName = member.MemberName;
            mem.MemberSurname = member.MemberSurname;
            mem.MemberMail = member.MemberMail;
            mem.MemberUsername = member.MemberUsername;
            mem.MemberPassword = member.MemberPassword;
            mem.MemberPhotoUrl = member.MemberPhotoUrl;
            mem.MemberTelephone = member.MemberTelephone;
            mem.MemberSchool = member.MemberSchool;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberBookHistory(int id)
        {
            var bookhis = db.TBLACTING.Where(x=>x.Member==id).ToList();
            var membernamesurname = db.TBLMEMBER.Where(x => x.MemberID == id).Select(y => y.MemberName + " " + y.MemberSurname).FirstOrDefault();
            ViewBag.m1 = membernamesurname;
            return View(bookhis);
        }
    }
}
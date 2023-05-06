using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var membermail = (string)Session["Mail"].ToString();
            var messages = db.TBLMESSAGES.Where(x => x.Receiver == membermail.ToString()).ToList();
            return View(messages);
        }

        public ActionResult OutgoingMessages()
        {
            var membermail = (string)Session["Mail"].ToString();
            var messages = db.TBLMESSAGES.Where(x => x.Sender == membermail.ToString()).ToList();
            return View(messages);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(TBLMESSAGES t)
        {
            var membermail = (string)Session["Mail"].ToString();
            t.Sender = membermail.ToString();
            t.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESSAGES.Add(t);
            db.SaveChanges();
            return RedirectToAction("OutgoingMessages","Messages");
        }
        public PartialViewResult Partial1()
        {
            var membermail = (string)Session["Mail"].ToString();
            var inmesscount = db.TBLMESSAGES.Where(x => x.Receiver == membermail).Count();
            ViewBag.v1 = inmesscount;

            var outmesscount = db.TBLMESSAGES.Where(x => x.Sender == membermail).Count();
            ViewBag.v2 = outmesscount;

            return PartialView();
        }
    }
}
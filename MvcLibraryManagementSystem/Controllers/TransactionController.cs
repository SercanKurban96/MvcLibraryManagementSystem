using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var values = db.TBLACTING.Where(x => x.TransactionStatus == true).ToList();
            return View(values);
        }
    }
}
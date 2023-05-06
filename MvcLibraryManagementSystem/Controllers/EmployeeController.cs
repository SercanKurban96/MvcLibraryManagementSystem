using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models.Entity;

namespace MvcLibraryManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var employees = db.TBLEMPLOYEE.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(TBLEMPLOYEE employee)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeAdd");
            }
            db.TBLEMPLOYEE.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeDelete(int id)
        {
            var emp = db.TBLEMPLOYEE.Find(id);
            db.TBLEMPLOYEE.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeBring(int id)
        {
            var emp = db.TBLEMPLOYEE.Find(id);
            return View("CategoryBring", emp);
        }
        public ActionResult EmployeeEdit(TBLEMPLOYEE employee)
        {
            var emp = db.TBLEMPLOYEE.Find(employee.EmployeeID);
            emp.EmployeeName = employee.EmployeeName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
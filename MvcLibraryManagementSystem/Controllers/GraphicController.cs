using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagementSystem.Models;

namespace MvcLibraryManagementSystem.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeBookResult()
        {
            return Json(list());
        }
        public List<Graph> list()
        {
            List<Graph> graphs = new List<Graph>();
            graphs.Add(new Graph()
            {
                publishinghouse = "Güneş",
                count = 7
            });
            graphs.Add(new Graph()
            {
                publishinghouse = "Mars",
                count = 4
            });
            graphs.Add(new Graph()
            {
                publishinghouse = "Jüpiter",
                count = 6
            });
            return graphs;
        }
    }
}
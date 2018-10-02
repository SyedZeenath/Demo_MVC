using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class ViewDataDemoController : Controller
    {
        // GET: ViewDataDemo
        public ActionResult Index()
        {
            ViewData["Messgae"] = "Hello WOrld!";
            ViewData["Count"] = 1;
            return View();
        }

        public ActionResult Demo2b()
        {
            ViewData["Count"] = (int)ViewData["Count"] + 1;//ViewBag n ViewData is destroyed here
            return View();
        }
    }
}
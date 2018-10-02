using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class ViewBagDemoController : Controller
    {
        // GET: ViewBagDemo
        public ActionResult Index()
        {
            ViewBag.Message = "Hello World from Index()";
            ViewBag.Count = 1;
            return View();
        }

        public ActionResult Demo2()
        {
            ViewBag.Number = 10;
            return RedirectToAction("Demo2b");     //viewBag is destroyed
        }

        public ActionResult Demo2b()
        {
            ViewBag.Number++;    //will crash  bcz  ViewBag.Number=null
            return View();
        }
    }
}
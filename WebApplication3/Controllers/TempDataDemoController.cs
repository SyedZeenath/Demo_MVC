using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class TempDataDemoController : Controller
    {
        // GET: TempDataDemo
        public ActionResult Index()
        {
            TempData["Counter"] = 10;
            return RedirectToAction("Demo2");
        }

        public ActionResult Demo2()
        {
            TempData["Counter"] = (int)TempData["Counter"] + 1;    //unbox before using
            return View("Demo3");
        }
         
        public ActionResult Demo3()
        {
            TempData["Counter"] = (int)TempData["Counter"] + 1;
            return View("Index");
        }

        public ActionResult PostBack()
        {
            TempData["Counter"] = (int)TempData["Counter"] + 1;
            return View("Index");
        }
    }
}
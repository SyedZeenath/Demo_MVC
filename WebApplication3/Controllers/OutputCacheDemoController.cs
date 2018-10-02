using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class OutputCacheDemoController : Controller
    {
        // GET: OutputCacheDemo
        [OutputCache(Duration = 20)]
        public ActionResult Index()
        {
            var dt = System.DateTime.Now;
            var mesg = $" update on {dt.ToLongDateString()} {dt.ToLongTimeString()}";
            ViewBag.UpdatedOn = mesg;

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CompanyName()
        {
            return Content("Kongsberg");
            //return Content("body{font-family: Vardana: font-size:8pt}", "text/css");
            //return Content("body{font-family: Vardana: font-size:8pt}", "text/css", charset:utf-8);
        }

        public ActionResult getCSS()
        {
            return Content("body{font-family: Verdana; font-size: 18pt; color: #f00}", "text/css", System.Text.Encoding.UTF8);
        }

        public ActionResult getJSON()
        {
            return Content("{ id:1, Name: \"Zee\"}", "application/json", System.Text.Encoding.UTF8);
            
        }
        public ActionResult GetJsonObject()
        {
            var obj = new { ID = 10, Name = "hello world" };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return Content(json);
        }
        //GET  /home/GetAbout?userid=demo&password=demo
        //GET  /home/GetAbout?userid=demo&password=xyz
        //GET  /home/GetAbout
        public ActionResult GetAbout(string userId, string password)
        {
            if(userId == "demo" && password == "demo")
            {
                return View("About");
            }
            else
            {
                return new HttpStatusCodeResult(statusCode: System.Net.HttpStatusCode.Unauthorized, statusDescription: "Invalid credentials!!");
            }
        }

        public ActionResult GetJsonProduct()
        {
            var product = new Models.Product { ID = 10, Name = "first product" };
            //return Json(product);
            return Json(product, JsonRequestBehavior.AllowGet);
        }
    }
}
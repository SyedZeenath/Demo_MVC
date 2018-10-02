using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewBagDemo()
        {
            ViewBag.i = 10;
            return View("Demo");//the Demo file name is different with the actionresult name,
            //we pass the name of file here, hence here the viewbagdemo runs demo.cshtml
        }
        public ActionResult ModelDemo()
        {
            WebApplication1.Models.EmployeeModel emp = new WebApplication1.Models.EmployeeModel()
            {
                ID = 10,
                Name = "first Employee",
                City = "bangalore"
            };
            //ViewBag.Employee = emp;
            return View(emp);
        }
    }

    
}
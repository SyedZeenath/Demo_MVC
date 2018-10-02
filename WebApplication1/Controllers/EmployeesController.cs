using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class EmployeesController : Controller
    {
        WebApplication1.Models.EmployeeModel emp;
        // GET: Employees
        [HttpGet]
        public ActionResult Index()
        {
            this.emp = new Models.EmployeeModel()
            {
                ID = 10,
                Name = "first Employee",
                City = "bangalore"
            };
            return View(this.emp);
        }
        [HttpPost]
        public ActionResult Index(Models.EmployeeModel employee)
        {

            return View("Details", employee);
        }
    }
}
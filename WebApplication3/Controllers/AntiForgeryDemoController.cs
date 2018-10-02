using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

    public class AntiForgeryDemoController : Controller
    {
        private Product product;
        // GET: AntiForgeryDemo
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            Product product = new Product() { ID = 10, Name = "Simple Product" };
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            this.product = product;
            ViewBag.Message = "Your data is saved";
            return View("Index", product);
        }
    }
    
}
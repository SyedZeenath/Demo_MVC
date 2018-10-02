using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PartialViewDemoController : Controller
    {
        private Product product;
        public PartialViewDemoController()
        {
            this.product = new Product { ID = 10, Name = "iPhone XS" };
        }
        // GET: PartialViewDemo/index
        public ActionResult Index()
        {
            
            return View(this.product);
        }
        //GET: partialviewdemo/edit
        public ActionResult Edit(int id)
        {
            return View(this.product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            this.product = product;
            return View("Index", this.product);
        }
    }
}
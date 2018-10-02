using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AnotherPartialViewDemoController : Controller
    {
        // GET: AnotherPartialViewDemo
        public ActionResult Index()
        {
            MyNorthwindViewModel vm;
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var customer = db.Customers
                    .Where(c => c.CustomerID == "ANTON")
                    .SingleOrDefault();         //fires immediately
                var order = customer.Orders
                    .Where(o => o.OrderID == 10573)
                    .SingleOrDefault();         //fires immediately
                var orderdetails = order.Order_Details.Where(od => od.OrderID == 10573);

                vm = new MyNorthwindViewModel()
                {
                    TheCustomer = customer,
                    TheOrder = order,
                    TheOrderDetails = orderdetails
                };
            }
                return View(vm);
        }
    }
}
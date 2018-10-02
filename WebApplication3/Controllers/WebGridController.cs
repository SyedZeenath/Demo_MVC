using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    using WebApplication3.Models;

    //public class custVIewModel
    //{
    //    public string CustomerID { get; set; }
    //    public string CompanyName { get; set; }
    //    public string City { get; set; }
    //    public string Country { get; set; }
        
    //}  //this is one way of populating data using this method for anonymous query
    public class WebGridController : Controller
    {
        
        // GET: WebGrid
        public ActionResult Index()
        {
            using(NorthwindEntities db = new NorthwindEntities())
            {
                var query = from cust in db.Customers
                            select new
                            {
                                cust.CustomerID,
                                cust.CompanyName,
                                cust.City,
                                cust.Country
                            };

                ViewBag.data = query.ToList();
                return View(query);
            }
           
        }
    }
}
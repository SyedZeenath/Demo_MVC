using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class MyNorthwindViewModel
    {
        public Customer TheCustomer { get; set; }
        public Order TheOrder { get; set; }
        public IEnumerable<Order_Detail> TheOrderDetails { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short QuantityOnHand { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsInStock { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {


        // private ProductViewModel productViewModel;
        private List<ProductViewModel> products;

        public ProductController()
        {
            this.products = new List<ProductViewModel>
            { 

                new ProductViewModel()
                {
                    ProductID = 10,
                    Name = "My first product",
                    Price = 5000M,
                    IsInStock = true,
                    ExpiresOn = new DateTime(2020, 12, 31)
                },
                new ProductViewModel()
                {
                    ProductID = 20,
                    Name = "My second product",
                    Price = 1000M,
                    IsInStock = true,
                    ExpiresOn = new DateTime(2020, 12, 21)
                },
                new ProductViewModel()
                {
                    ProductID = 30,
                    Name = "My third product",
                    Price = 2000M,
                    IsInStock = true,
                    ExpiresOn = new DateTime(2020, 12, 11)
                },
                new ProductViewModel()
                {
                    ProductID = 40,
                    Name = "My fourth product",
                    Price = 3000M,
                    IsInStock = true,
                    ExpiresOn = new DateTime(2020, 12, 01)
                },
                new ProductViewModel()
                {
                    ProductID = 50,
                    Name = "My fifth product",
                    Price = 4000M,
                    IsInStock = true,
                    ExpiresOn = new DateTime(2020, 12, 22)
                }
            };
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(this.products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var prod = this.products.SingleOrDefault(p => p.ProductID == id);
            return View(prod);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View(this.products);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(WebApplication5.ViewModels.ProductViewModel product)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    //var p = this.items.SingleOrDefault(p => p.Email == person.Email)
                    bool found = this.products.Any(p => p.ProductID == product.ProductID);
                    if (found)
                    {
                        this.ModelState.AddModelError("Insert", "Product already exists!");
                        return View(product);
                    }
                    else
                    {
                        product.ProductID = this.products.Max(p => p.ProductID) + 1;
                        this.products.Add(product);
                        return View("Index", this.products);

                        // TODO: Add insert logic here
                    }

                }
                catch
                {
                    return View(product);
                }
            }
            else
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = this.products.SingleOrDefault(p => p.ProductID == id);
            return View(prod);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductViewModel productView)
        {
            try
            {
                // check if data is valid
                if (this.ModelState.IsValid)
                {
                    //TODO: save the changes
                    var prod = this.products.SingleOrDefault(p => p.ProductID == id);
                    prod.Name = productView.Name;
                    prod.ProductID = productView.ProductID;
                    prod.IsInStock = productView.IsInStock;
                    prod.ExpiresOn = productView.ExpiresOn;
                    //TODO: save the changes to database

                    //redirect to the listing page
                    //return RedirectToAction("Index"); //this works when we save the data to database
                    return View("Index", this.products);
                }
                else
                {
                    return View(productView);
                }
            }
            catch
            {
                return View(productView);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var prod = this.products.SingleOrDefault(p => p.ProductID == id);
            if (prod != null)
            {
                return View(prod);
            }
            else
            {
                return HttpNotFound("Such product does not exist");
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var prod = this.products.SingleOrDefault(p => p.ProductID == id);
            if (prod != null)
            {
                try
                {
                    //Add delete logic here
                    this.products.Remove(prod);
                    //TODO: delete data from database
                    //return RedirectToAction("Index");
                    return View("Index", this.products);
                }
                catch
                {
                    return View(prod);
                }
            }
            else
            {
                return HttpNotFound("Such product does not exist");
            }
        }
    }
}

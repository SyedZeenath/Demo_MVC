using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class PersonsController : Controller
    {
        List<ViewModels.PersonViewModel> items;
        public PersonsController()
        {
            items = new List<ViewModels.PersonViewModel>()
            {
                new ViewModels.PersonViewModel()
                {
                    ID=1,
                    Name ="first person",
                    Gender =ViewModels.GenderTypes.Male,
                    DateOfBirth = new DateTime(2010, 11, 15),
                    Email="first@demo.com"
                },
                new ViewModels.PersonViewModel()
                {
                    ID=2,
                    Name ="second person",
                    Gender =ViewModels.GenderTypes.Male,
                    DateOfBirth = new DateTime(2010, 12, 30),
                    Email="second@demo.com"
                },
                new ViewModels.PersonViewModel()
                {
                    ID=3,
                    Name ="third person",
                    Gender =ViewModels.GenderTypes.Female,
                    DateOfBirth = new DateTime(2011, 10, 25),
                    Email="third@demo.com"
                },
                new ViewModels.PersonViewModel()
                {
                    ID=4,
                    Name ="fourth person",
                    Gender =ViewModels.GenderTypes.Female,
                    DateOfBirth = new DateTime(2012, 09, 20)
                    
                },
                new ViewModels.PersonViewModel()
                {
                    ID=5,
                    Name ="fifth person",
                    Gender =ViewModels.GenderTypes.Male,
                    DateOfBirth = new DateTime(2012, 05, 01),
                    Email="fifth@demo.com"
                }
            };
        }
        // GET: Persons
        public ActionResult Index()
        {
            return View(this.items);
        }

        // GET: Persons/Details/5
        public ActionResult Details(int id)
        {
            //version 1: using LINQ
            //var emp = (from p in this.items
            //          where p.ID == id
            //          select p).SingleOrDefault(); //.FirstOrDefault();
            //return View(emp);

            //version 2: using LAMBDA
            var emp = this.items.SingleOrDefault(e => e.ID == id);
            return View(emp);
        }

        // GET: Persons/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Persons/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(WebApplication1.ViewModels.PersonViewModel person)
        {
            try
            {
                
                if (this.ModelState.IsValid)
                {
                    bool found = this.items.Any(p => p.Email == person.Email);
                    if (found)
                    {
                        this.ModelState.AddModelError("insert", "email address found!. Change it");
                        return View(person);
                    }
                    else
                    {
                        //Add insert logic here
                        person.ID = this.items.Max(p => p.ID) + 1; //not count here bcz, if any item is deleted then count will have
                                                                   //2  items with the same ID
                        this.items.Add(person);
                        //return RedirectToAction("Index");
                        return View("Index", this.items);
                    }
                                       
                }
                else
                {
                    return View(person);
                }
            }
            catch
            {
                return View(person);
            }
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = this.items.SingleOrDefault(e => e.ID == id);
            return View(emp);
        }

        // POST: Persons/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, 
        //   [Bind(Include ="ID, Name, DateOfBirth, Gender, Email")]FormCollection collection)
        //bind is to avoid data getting hacked to some level but still the hacker can put textarea and
        //manipulate the data, so we validate on entire model
        public ActionResult Edit(int id, ViewModels.PersonViewModel person)
        {
            try
            {
                // check if data is valid
                if (this.ModelState.IsValid)
                {
                    //TODO: save the changes
                    var emp = this.items.SingleOrDefault(e => e.ID == id);
                    emp.Name = person.Name;
                    emp.Email = person.Email;
                    emp.DateOfBirth = person.DateOfBirth;
                    emp.Gender = person.Gender;
                    //TODO: save the changes to database

                    //redirect to the listing page
                    //return RedirectToAction("Index"); //this works when we save the data to database
                    return View("Index", this.items);
                }
                else
                {
                    return View(person);
                }
            }
            catch
            {
                return View(person);
            }
        }

        // GET: Persons/Delete/5
        public ActionResult Delete(int id)
        {
            var person = this.items.SingleOrDefault(p => p.ID == id);
            if (person != null)
            {
                return View(person);
            }
            else
            {
                return HttpNotFound("Such person does not exist");
            }
        }

        // POST: Persons/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var person = this.items.SingleOrDefault(p => p.ID == id);
            if (person != null)
            {
                try
                {
                    //Add delete logic here
                    this.items.Remove(person);
                    //TODO: delete data from database
                    //return RedirectToAction("Index");
                    return View("Index", this.items);
                }
                catch
                {
                    return View(person);
                }
            }
            else
            {
                return HttpNotFound("Such person does not exist");
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models.Model;
using WebApplication6.ViewModel;

namespace WebApplication6.Controllers
{
    public class DemoController : Controller
    {

        private KongsbergEFDemoDbContext DbContext;

        public DemoController()
        {
            this.DbContext = new KongsbergEFDemoDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                this.DbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Demo
        public ActionResult Index()
        {
            DemoViewModel vm = new DemoViewModel()
            {
                Countries = new List<SelectListItem>()
            };

            var query = from country in DbContext.Countries
                        select new SelectListItem
                        {
                            Text = country.CountryName,
                            Value = country.CountryId.ToString()
                        };
            foreach(var item in query)
            {
                vm.Countries.Add(item);
            }
            return View(vm);
        }

        [HttpPost]
        public ActionResult GetStates(int? countryId)
        {
            DemoViewModel vm = new DemoViewModel()
            {
                States = new List<SelectListItem>()
            };
            if (countryId.HasValue)
            {
                var query = from state in DbContext.States
                            where state.CountryId == countryId.Value
                            select new SelectListItem
                            {
                                Text = state.StateName,
                                Value = state.StateId.ToString()
                            };
                foreach(var item in query)
                {
                    vm.States.Add(item);
                }
            }
            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCities(int? stateId)
        {
            DemoViewModel vm = new DemoViewModel()
            {
                Cities = new List<SelectListItem>()
            };
            var query = from city in DbContext.Cities
                        where city.StateId == stateId.Value
                        select new SelectListItem
                        {
                            Text = city.CityName,
                            Value = city.CityId.ToString()
                        };
            foreach (var item in query)
            {
                vm.Cities.Add(item);
            }

            return Json(vm, JsonRequestBehavior.AllowGet);



        }


    }
}
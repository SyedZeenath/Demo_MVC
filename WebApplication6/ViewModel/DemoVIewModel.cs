using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.ViewModel
{
    public class DemoViewModel
    {
        public IList<SelectListItem> Countries { get; set; }
        public IList<SelectListItem> States { get; set; }
        public IList<SelectListItem> Cities { get; set; }

    }
}
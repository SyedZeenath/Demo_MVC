using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class ErrorDemoController : Controller
    {
        /// <remarks>
        /// 
        ///         in the web.config,
        ///         <system.web>
        ///         
        /// </system.web>
        /// ...
        /// <customErrors mode = "On"/>
        /// </summary>
        /// <returns></returns>
        // GET: ErrorDemo
        [HandleError]
        public ActionResult Index()
        {
            throw new DivideByZeroException("You tried to divide by zero");
        }
    }
}
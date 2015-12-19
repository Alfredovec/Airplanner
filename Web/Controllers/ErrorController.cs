using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controller responsible for operating with errors.
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Returns page representing default error.
        /// </summary>
        public ViewResult UnknownError()
        {
            ViewBag.Error = "Airplanner has encountered a problem.";
            return View("Error");
        }
        /// <summary>
        /// Returns page resresenting server respond 404: Not found.
        /// </summary>
        public ViewResult NotFound()
        {
            ViewBag.Error = "I'm sorry, this page cannot be found.";
            return View("Error");
        }
    }
}
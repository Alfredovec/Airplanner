using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Managers;
using Microsoft.Practices.Unity;
using Models.Entities;
using Models.Enums;
using Web.Builders.View;
using Web.Models.View;

namespace Web.Controllers
{
    /// <summary>
    /// Controller responsible for operating with flights.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class RequestController : Controller
    {
        private readonly IAirplannerManager _manager;

        public RequestController(IAirplannerManager manager)
        {
            _manager = manager;
        }

        public ActionResult List()
        {
            FlightViewModelBuilder builder = new FlightViewModelBuilder(_manager);
            try
            {
                IEnumerable<FlightViewModel> list = builder.BuildList(FlightStatus.Active);
                return View(list);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("UnknownError", "Error");
            }
        }

        /// <summary>
        /// Performs applying admin flight decision into database.
        /// </summary>
        public ActionResult Decide(int id, FlightStatus status)
        {
            try
            {
                Flight flight = _manager.GetFlightById(id);
                _manager.SetFlightStatus(flight, status);
                FlightViewModelBuilder builder = new FlightViewModelBuilder(_manager);
                IEnumerable<FlightViewModel> list = builder.BuildList(FlightStatus.Active);
                return View("List", list);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("UnknownError", "Error");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Helpers;
using BLL.Managers;
using Microsoft.Practices.Unity;
using Models;
using Models.Entities;
using Models.Enums;
using Web.Builders.View;
using Web.Extensions;
using Web.Mappers.View;
using Web.Models.View;

namespace Web.Controllers
{
    /// <summary>
    /// Controller responsible for operating with flights.
    /// </summary>
    [Authorize]
    public class FlightController : Controller
    {
        private readonly IAirplannerManager _manager;

        public FlightController(IAirplannerManager manager)
        {
            _manager = manager;
        }

        public ActionResult List()
        {
            FlightViewModelBuilder builder = new FlightViewModelBuilder(_manager);
            IEnumerable<FlightViewModel> list = builder.BuildList(FlightStatus.Accepted);
            FlightListViewModel model = new FlightListViewModel()
            {
                FlightsTableViewModel = new FlightsTableViewModel()
                {
                    Flights = list,
                    Order = SortOrder.Asc,
                    SortField = FlightSortField.Number
                },
                SearchViewModel = new FlightSearchViewModel()
            };
            TempData["flights"] = model.FlightsTableViewModel.Flights;
            return View(model);
        }

        public PartialViewResult _GetCitiesList()
        {
            return PartialView("_GetCitiesList", _manager.GetAllCities());
        }

        [HttpPost]
        public PartialViewResult _GetFlightsList(FlightSearchViewModel model)
        {
            FlightViewModelBuilder builder = new FlightViewModelBuilder(_manager);
            IEnumerable<Flight> list = _manager.GetFlights(model.Number, model.OutcomeCity, model.DestinationCity);
            IEnumerable<FlightViewModel> viewList = builder.BuildList(FlightStatus.Accepted, list);
            TempData["flights"] = viewList;
            FlightsTableViewModel viewModel = new FlightsTableViewModel()
            {
                Flights = viewList,
                Order = SortOrder.Asc,
                SortField = FlightSortField.Number
            };
            return PartialView("_GetTable", viewModel);
        }

        /// <summary>
        /// Performs sorting the flights table.
        /// </summary>
        /// <param name="sortField">Sorting field</param>
        /// <param name="order">Sorting order</param>
        public PartialViewResult _SortFlightsList(FlightSortField sortField, SortOrder order)
        {
            IEnumerable<FlightViewModel> flights = (IEnumerable<FlightViewModel>)TempData["flights"];
            //flights =_manager.SortFlights(flights, sortField, order);s
            flights = flights.SortFlights(sortField, order);
            TempData["flights"] = flights;
            FlightsTableViewModel viewModel = new FlightsTableViewModel()
            {
                Flights = flights,
                Order = order,
                SortField = sortField
            };
            return PartialView("_GetTable", viewModel);
        }

        public ActionResult Details(int id)
        {
            FlightViewModelBuilder builder = new FlightViewModelBuilder(_manager);
            try
            {
                Flight flight = _manager.GetFlightById(id);
                return View(builder.Build(flight));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("UnknownError", "Error");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            FlightViewModelBuilder builder = new FlightViewModelBuilder(_manager);
            try
            {
                Flight flight = _manager.GetFlightById(id);
                TempData["Number"] = flight.FlightNumber;
                return View(builder.Build(flight));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("UnknownError", "Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(FlightViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.FlightNumber.Equals(TempData["Number"]) || _manager.CheckNumberUniqueness(model.FlightNumber))
                {
                    FlightViewModelMapper mapper = new FlightViewModelMapper(_manager);
                    Flight flight = mapper.Map(model);
                    List<Worker> newWorkers = mapper.MapWorkers(model);
                    _manager.EditFlight(flight, newWorkers);
                    return RedirectToAction("List");
                }
                ModelState.AddModelError("", "Sorry, but this flight number already exists.");
            }
            model.DropDownLists = (new FlightViewModelBuilder(_manager)).BuildEmpty().DropDownLists;
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            FlightViewModelBuilder builder = new FlightViewModelBuilder(_manager);
            try
            {
                Flight flight = _manager.GetFlightById(id);
                return View(builder.Build(flight));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("UnknownError", "Error");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult PerformDelete(int id)
        {
            try
            {
                _manager.DeleteFlight(id);
            }
            catch (InvalidOperationException e)
            {
                LoggerHelper.WriteError(e.StackTrace);
                return RedirectToAction("UnknownError", "Error");
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        [Authorize(Roles = "Dispecher")]
        public ActionResult Create()
        {
            FlightViewModelBuilder builder = new FlightViewModelBuilder(_manager);
            return View(builder.BuildEmpty());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dispecher")]
        public ActionResult Create(FlightViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_manager.CheckNumberUniqueness(model.FlightNumber))
                {
                    FlightViewModelMapper mapper = new FlightViewModelMapper(_manager);
                    Flight flight = mapper.Map(model, true);
                    List<Worker> newWorkers = mapper.MapWorkers(model);
                    _manager.CreateFlight(flight, newWorkers);
                    return RedirectToAction("List");
                }
                ModelState.AddModelError("", "Sorry, but this flight number already exists.");
            }
            model.DropDownLists = (new FlightViewModelBuilder(_manager)).BuildEmpty().DropDownLists;
            return View(model);
        }

        public ActionResult GetReport()
        {
            ReportViewModelBuilder builder = new ReportViewModelBuilder(_manager);
            return View(builder.BuildList());
        }
    }
}
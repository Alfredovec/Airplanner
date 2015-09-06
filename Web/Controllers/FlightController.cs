using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Models.View;
using DAL.Managers;
using Web.Builders.View;

namespace Web.Controllers
{
    public class FlightController : Controller
    {
        public ActionResult List()
        {
            FlightListModelBuilder builder = new FlightListModelBuilder(new AirplannerManager());
            List<FlightViewModel> list = builder.Build();
            return View(list);
        }
    }
}
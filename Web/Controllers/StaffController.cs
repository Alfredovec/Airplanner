using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Managers;
using Microsoft.Practices.Unity;
using Models;
using Models.Entities;
using Web.Builders.View;
using Web.Mappers.View;
using Web.Models.View;

namespace Web.Controllers
{
    /// <summary>
    /// Controller responsible for operating with staff.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        private readonly IAirplannerManager _manager;
        
        public StaffController(IAirplannerManager staffManager)
        {
            _manager = staffManager;
        }

        public ActionResult List()
        {
            try
            {
                WorkerViewModelBuilder builder = new WorkerViewModelBuilder(_manager);
                IEnumerable<WorkerViewModel> list = builder.BuildList();
                return View(list);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("UnknownError", "Error");
            }
        }

        public ActionResult Details(int id)
        {
            WorkerViewModelBuilder builder = new WorkerViewModelBuilder(_manager);
            try
            {
                Worker worker = _manager.GetWorkerById(id);
                return View(builder.Build(worker));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("UnknownError", "Error");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                WorkerViewModelBuilder builder = new WorkerViewModelBuilder(_manager);
                Worker worker = _manager.GetWorkerById(id);
                return View(builder.Build(worker));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("UnknownError", "Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkerViewModel model)
        {
            if (ModelState.IsValid)
            {
                WorkerViewModelMapper mapper = new WorkerViewModelMapper(_manager);
                try
                {
                    Worker worker = mapper.Map(model);
                    _manager.EditWorker(worker);
                    return RedirectToAction("List");
                }
                catch (InvalidOperationException)
                {
                    return RedirectToAction("UnknownError", "Error");
                }
            }
            model.DropDownLists = (new WorkerViewModelBuilder(_manager)).BuildEmpty().DropDownLists;
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            WorkerViewModelBuilder builder = new WorkerViewModelBuilder(_manager);
            try
            {
                Worker worker = _manager.GetWorkerById(id);
                return View(builder.Build(worker));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("UnknownError", "Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult PerformDelete(int id)
        {
            _manager.DeleteWorker(id);
            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult Create()
        {
            WorkerViewModelBuilder builder = new WorkerViewModelBuilder(_manager);
            return View(builder.BuildEmpty());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkerViewModel model)
        {
            if (ModelState.IsValid)
            {
                WorkerViewModelMapper mapper = new WorkerViewModelMapper(_manager);
                try
                {
                    Worker worker = mapper.Map(model, true);
                    _manager.CreateWorker(worker);
                    return RedirectToAction("List");
                }
                catch (InvalidOperationException)
                {
                    return RedirectToAction("UnknownError", "Error");
                }
            }
            model.DropDownLists = (new WorkerViewModelBuilder(_manager)).BuildEmpty().DropDownLists;
            return View(model);
        }
    }
}
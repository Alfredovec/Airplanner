using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.Managers;
using Models;
using Models.Entities;
using Web.Models.View;

namespace Web.Builders.View
{
    /// <summary>
    /// Performing building opeartion from Worker to WorkerViewModel. 
    /// </summary>
    public class WorkerViewModelBuilder
    {
        private readonly IAirplannerManager _manager;

        public WorkerViewModelBuilder(IAirplannerManager manager)
        {
            _manager = manager;
        }

        public WorkerViewModel BuildEmpty()
        {
            WorkerViewModel model = new WorkerViewModel
            {
                Age = 20,
                DropDownLists = new Dictionary<string, List<SelectListItem>>()
                {
                    {
                        "Positions",
                        _manager.GetPositionNames()
                            .Select((name) => new SelectListItem() {Text = name, Value = name})
                            .ToList()
                    }
                }
            };
            return model;
        }

        public WorkerViewModel Build(Worker worker)
        {
            WorkerViewModel model = new WorkerViewModel
            {
                Id = worker.WorkerId,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Age = worker.Age,
                PositionName = _manager.GetPositionFor(worker).PositionName,
                DropDownLists = new Dictionary<string, List<SelectListItem>>()
                {
                    {
                        "Positions",
                        _manager.GetPositionNames()
                            .Select((name) => new SelectListItem() {Text = name, Value = name})
                            .ToList()
                    }
                }
            };
            return model;
        }

        public IEnumerable<WorkerViewModel> BuildList()
        {
            return BuildList(_manager.GetWorkers(true));
        }

        public IEnumerable<WorkerViewModel> BuildList(IEnumerable<Worker> workers)
        {
            return workers.Select(Build);
        }
    }
}

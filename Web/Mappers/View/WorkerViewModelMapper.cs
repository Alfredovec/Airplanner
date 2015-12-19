using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Managers;
using Models;
using Models.Entities;
using Web.Models.View;

namespace Web.Mappers.View
{
    /// <summary>
    /// Performing mapping opeartion from WorkerViewModel to Worker. 
    /// </summary>
    public class WorkerViewModelMapper
    {
        private readonly IAirplannerManager _manager;

        public WorkerViewModelMapper(IAirplannerManager manager)
        {
            _manager = manager;
        }

        public Worker Map(WorkerViewModel model, bool newWorker = false)
        {
            Worker worker = newWorker? new Worker() : _manager.GetWorkerById(model.Id);
            worker.FirstName = model.FirstName;
            worker.LastName = model.LastName;
            worker.Age = model.Age;
            worker.Position = _manager.GetPositionByName(model.PositionName);
            return worker;
        }
    }
}

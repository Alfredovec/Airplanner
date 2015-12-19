using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Managers;
using Models.Enums;
using Web.Models.View;

namespace Web.Builders.View
{
    /// <summary>
    /// Performing building opeartion from Flight to FlightViewModel. 
    /// </summary>
    public class ReportViewModelBuilder
    {
        private readonly IAirplannerManager _manager;

        public ReportViewModelBuilder(IAirplannerManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<ReportViewModel> BuildList()
        {
            List<ReportViewModel> result = new List<ReportViewModel>();
            foreach (var pilot in _manager.GetWorkersByPosition(WorkerPosition.FirstPilot))
            {
                result.Add(new ReportViewModel()
                {
                    PilotFirstName = pilot.FirstName,
                    PilotLastName = pilot.LastName,
                    MinutesFlown = _manager.GetMinutesFlownForWorker(pilot),
                    Routes = _manager.GetRoutesForWorker(pilot)
                });
            }
            return result;
        }
    }
}

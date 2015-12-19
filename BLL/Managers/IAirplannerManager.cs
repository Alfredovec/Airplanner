using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using Models.Enums;

namespace BLL.Managers
{
    public interface IAirplannerManager
    {
        #region Flights
        IEnumerable<Flight> GetFlights(bool defaultSort = false);
        IEnumerable<Flight> GetFlights(IEnumerable<Flight> flights, FlightStatus status);
        IEnumerable<Flight> GetFlights(string number, string outcomeCity, string destinationCity);

        string GetDestinationCityName(Flight flight);

        string GetOutcomeCityName(Flight flight);

        Flight GetFlightById(int id);

        void EditFlight(Flight flight, List<Worker> workers);

        void CreateFlight(Flight flight, List<Worker> workers);

        void DeleteFlight(int id);

        void SetFlightStatus(Flight flight, FlightStatus status);

        string GetWorkerOnFlight(Flight flight, WorkerPosition position, int index = 1);

        bool CheckNumberUniqueness(int number);

        int GetMaxFlightNumber();
        #endregion

        #region Routes
        IEnumerable<City> GetAllCities();

        IEnumerable<string> GetCitiesNames();

        Route GetOrCreateRoute(string outcomeCity, string destinationCity);
        #endregion

        #region Workers
        IEnumerable<Worker> GetWorkers(bool sort = false);

        Worker GetWorkerById(int id);

        void CreateWorker(Worker worker);

        void EditWorker(Worker worker);

        void DeleteWorker(int id);

        Position GetPositionFor(Worker worker);

        Position GetPositionByName(string name);

        IEnumerable<string> GetWorkersNameByPosition(WorkerPosition position);

        IEnumerable<string> GetPositionNames();

        Worker GetWorkerByName(string workerName, WorkerPosition position);

        IEnumerable<Worker> GetWorkersByPosition(WorkerPosition position);

        int GetMinutesFlownForWorker(Worker worker);

        IEnumerable<Route> GetRoutesForWorker(Worker worker);

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Models.Entities;
using Models.Enums;

namespace BLL.Managers
{
    /// <summary>
    /// Operates with repository and perform business logic operations.
    /// </summary>
    public class AirplannerManager : IAirplannerManager
    {
        private readonly IAirplannerRepository _repository;

        [InjectionConstructor]
        public AirplannerManager(IAirplannerRepository repository)
        {
            _repository = repository;
        }

        #region Flights
        public IEnumerable<Flight> GetFlights(bool defaultSort = false)
        {
            return defaultSort
                ? _repository.FindFlightsBy(f => f.IsActive).OrderBy(f => f.DepartureTime).ToList()
                : _repository.FindFlightsBy(f => f.IsActive).ToList();

        }

        public IEnumerable<Flight> GetFlights(IEnumerable<Flight> flights, FlightStatus status)
        {
            return flights.Where(f => f.Status.StatusName.Equals(status.ToString()) && f.ArrivalTime > DateTime.Now);
        }

        public IEnumerable<Flight> GetFlights(string number, string outcomeCity, string destinationCity)
        {
            IEnumerable<Flight> result = GetFlights();

            if (number != null)
            {
                result = result.Where(f => f.FlightNumber.ToString().Contains(number));
            }

            if (outcomeCity != null)
            {
                result = result.Where(f => f.Route.OutcomeCity.CityName.Equals(outcomeCity));
            }

            if (destinationCity != null)
            {
                result = result.Where(f => f.Route.DestinationCity.CityName.Equals(destinationCity));
            }

            return result;
        }

        public string GetDestinationCityName(Flight flight)
        {
            return _repository
                .FindFlightsBy(f => f.FlightId.Equals(flight.FlightId))
                .Single().Route.DestinationCity.CityName;
        }

        public string GetOutcomeCityName(Flight flight)
        {
            return _repository
                .FindFlightsBy(f => f.FlightId.Equals(flight.FlightId))
                .Single().Route.OutcomeCity.CityName;
        }

        public Flight GetFlightById(int id)
        {
            return _repository.FindFlightsBy(flight => flight.FlightId.Equals(id))
                .Single();
        }

        public void EditFlight(Flight flight, List<Worker> workers)
        {
            flight.Workers.Clear();
            flight.Workers = workers;
            _repository.Edit(flight);
            _repository.Save();
        }

        public void CreateFlight(Flight flight, List<Worker> workers)
        {
            flight.Workers = workers;
            flight.Status = _repository.FindStatusesBy(s => s.StatusName.Equals(FlightStatus.Active.ToString())).Single();
            _repository.Add(flight);
            _repository.Save();
        }

        public void DeleteFlight(int id)
        {
            Flight flight = GetFlightById(id);
            flight.IsActive = false;
            _repository.Edit(flight);
            _repository.Save();
        }


        public void SetFlightStatus(Flight flight, FlightStatus status)
        {
            flight.Status = _repository.FindStatusesBy(s => s.StatusName.Equals(status.ToString())).Single();
            _repository.Edit(flight);
            _repository.Save();
        }

        /// <summary>
        /// Get especial worker on certain flight.
        /// </summary>
        /// <param name="index">Index in list if there are several matches.</param>
        public string GetWorkerOnFlight(Flight flight, WorkerPosition position, int index = 1)
        {
            List<Worker> workers = _repository.FindFlightsBy(f => f.FlightId.Equals(flight.FlightId))
                .Single().Workers.Where(w => w.Position.PositionName.Equals(position.ToFriendlyString())).ToList();
            Worker worker = workers.ElementAt(index - 1);
            return string.Format("{0} {1}", worker.FirstName, worker.LastName);
        }

        /// <summary>
        /// Checks whether flight's number is unique in database.
        /// </summary>
        public bool CheckNumberUniqueness(int number)
        {
            return !_repository.FindFlightsBy(f => f.FlightNumber.Equals(number)).Any();
        }

        /// <summary>
        /// Gets max value of flights numbers in database.
        /// </summary>
        public int GetMaxFlightNumber()
        {
            int num = _repository.GetFlights().Max(f => f.FlightNumber);
            return num == Int16.MaxValue ? 0 : num;
        }
        #endregion

        #region Routes

        public IEnumerable<City> GetAllCities()
        {
            return _repository.GetCities();
        }


        public IEnumerable<string> GetCitiesNames()
        {
            return _repository.GetCities().Select(c => c.CityName);   
        }

        /// <summary>
        /// Gets route by outcome and destination points and creates it if there is no such route in database.
        /// </summary>
        /// <param name="outcomeCity"></param>
        /// <param name="destinationCity"></param>
        /// <returns></returns>
        public Route GetOrCreateRoute(string outcomeCity, string destinationCity)
        {
            if (_repository.FindRoutesBy(r => r.DestinationCity.CityName.Equals(destinationCity) && r.OutcomeCity.CityName.Equals(outcomeCity))
                .SingleOrDefault(route => route.DestinationCity.CityName.Equals(destinationCity)
                                                 && route.OutcomeCity.CityName.Equals(outcomeCity)) == null)
            {
                _repository.Add(new Route()
                {
                    OutcomeCity = _repository.FindCitiesBy(city => city.CityName.Equals(outcomeCity)).Single(),
                    DestinationCity = _repository.FindCitiesBy(city => city.CityName.Equals(destinationCity)).Single()
                });
                _repository.Save();
            }
            return _repository.FindRoutesBy(r => r.DestinationCity.CityName.Equals(destinationCity)
                                 && r.OutcomeCity.CityName.Equals(outcomeCity)).Single();
        }
        #endregion

        #region Workers
        public IEnumerable<Worker> GetWorkers(bool defaultSort = false)
        {
            return defaultSort
                ? _repository.FindWorkersBy(w => w.IsActive).OrderBy(w => w.Age).ToList()
                : _repository.FindWorkersBy(w => w.IsActive).ToList();
        }

        public Worker GetWorkerById(int id)
        {
            return _repository.FindWorkersBy(w => w.IsActive && w.WorkerId.Equals(id)).Single();
        }

        public void CreateWorker(Worker worker)
        {
            _repository.Add(worker);
            _repository.Save();
        }

        public void EditWorker(Worker worker)
        {
            _repository.Edit(worker);
            _repository.Save();
        }

        public void DeleteWorker(int id)
        {
            Worker worker = GetWorkerById(id);
            worker.IsActive = false;
            worker.Flights.ForEach(w => SetFlightStatus(w, FlightStatus.Denied));
            _repository.Edit(worker);
            _repository.Save();
        }

        /// <summary>
        /// Returns position of especial worker.
        /// </summary>
        public Position GetPositionFor(Worker worker)
        {
            return _repository.FindWorkersBy(w => w.WorkerId.Equals(worker.WorkerId)).Single().Position;
        }

        /// <summary>
        /// Returns position in database by name and throws exception if there are no such position.
        /// </summary>
        public Position GetPositionByName(string name)
        {
            return _repository.FindPositionsBy(p => p.PositionName.Equals(name)).Single();
        }

        /// <summary>
        /// Returns sequence of workers in database with especial position.
        /// </summary>
        public IEnumerable<string> GetWorkersNameByPosition(WorkerPosition position)
        {
            string positionString = position.ToFriendlyString();
            return _repository
                        .FindWorkersBy(w => w.Position.PositionName.Equals(positionString))
                        .Select(w => w.FirstName + " " + w.LastName);
        }

        /// <summary>
        /// Returns position names from database.
        /// </summary>
        public IEnumerable<string> GetPositionNames()
        {
            return _repository.GetPositions().Select(p => p.PositionName);
        }

        /// <summary>
        /// Returns especial worker in database by worker name and position. 
        /// </summary>
        /// <param name="workerName"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public Worker GetWorkerByName(string workerName, WorkerPosition position)
        {
            string[] names = workerName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstName = names[0];
            string lastName = names.SkipWhile((a, i) => i < 1).Aggregate((seed, next) => seed + " " + next);
            string positionString = position.ToFriendlyString();
            return _repository.FindWorkersBy(w => w.FirstName.Equals(firstName)
                                              && w.LastName.Equals(lastName)
                                              && w.Position.PositionName.Equals(positionString))
                    .First();
        }

        public IEnumerable<Worker> GetWorkersByPosition(WorkerPosition position)
        {
            string positionString = position.ToFriendlyString();
            return _repository.FindWorkersBy(w => w.Position.PositionName.Equals(positionString));
        }

        public int GetMinutesFlownForWorker(Worker worker)
        {
            IEnumerable<int> times = _repository.FindWorkersBy(w => w.WorkerId.Equals(worker.WorkerId))
                    .Single().Flights.Select(f => (int)(f.ArrivalTime - f.DepartureTime).TotalMinutes).ToList();
            return !times.Any() ? 0 : times.Aggregate((i, i1) => i + i1);
        }

        public IEnumerable<Route> GetRoutesForWorker(Worker worker)
        {
            return _repository.FindWorkersBy(w => w.WorkerId.Equals(worker.WorkerId)).Single().Flights.Select(f => f.Route);
        }

        #endregion
    }
}

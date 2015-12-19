using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace DAL
{
    /// <summary>
    /// Operates with database context andn performs CRUD operations.
    /// </summary>
    public class AirplannerRepository : IAirplannerRepository
    {
        private AirplannerContext  _entities =  new AirplannerContext();
        
        public AirplannerContext Context
        {
            get { return _entities?? (_entities = new AirplannerContext()); }
            set { _entities = value; }
        }

        public IQueryable<Flight> GetFlights()
        {
            return _entities.Flights;
        }
        public IQueryable<Route> GetRoutes()
        {
            return _entities.Routes;
        }
        public IQueryable<Worker> GetWorkers()
        {
            return _entities.Workers;
        }
        public IQueryable<Position> GetPositions()
        {
            return _entities.Positions;
        }
        public IQueryable<City> GetCities()
        {
            return _entities.Cities;
        }


        public IQueryable<Flight> FindFlightsBy(Expression<Func<Flight, bool>> predicate)
        {
            return _entities.Flights.Where(predicate);
        }
        public IQueryable<Route> FindRoutesBy(Expression<Func<Route, bool>> predicate)
        {
            return _entities.Routes.Where(predicate);
        }
        public IQueryable<Worker> FindWorkersBy(Expression<Func<Worker, bool>> predicate)
        {
            return _entities.Workers.Where(predicate);
        }
        public IQueryable<Status> FindStatusesBy(Expression<Func<Status, bool>> predicate)
        {
            return _entities.Statuses.Where(predicate);
        }
        public IQueryable<Position> FindPositionsBy(Expression<Func<Position, bool>> predicate)
        {
            return _entities.Positions.Where(predicate);
        }
        public IQueryable<City> FindCitiesBy(Expression<Func<City, bool>> predicate)
        {
            return _entities.Cities.Where(predicate);
        }

        public void Add(Flight entity)
        {
            _entities.Entry(entity).State = EntityState.Added;
        }
        public void Add(Route entity)
        {
            _entities.Entry(entity).State = EntityState.Added;
        }
        public void Add(Worker entity)
        {
            _entities.Entry(entity).State = EntityState.Added;
        }

        public void Delete(Flight entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
        }
        public void Delete(Route entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
        }
        public void Delete(Worker entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
        }

        public void Edit(Flight entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }
        public void Edit(Route entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }
        public void Edit(Worker entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}

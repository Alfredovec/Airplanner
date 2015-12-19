using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace DAL
{
    public interface IAirplannerRepository
    {
        IQueryable<Flight> GetFlights();
        IQueryable<Route> GetRoutes();
        IQueryable<Worker> GetWorkers();
        IQueryable<Position> GetPositions();
        IQueryable<City> GetCities();

        IQueryable<Flight> FindFlightsBy(Expression<Func<Flight, bool>>  predicate);
        IQueryable<Route> FindRoutesBy(Expression<Func<Route, bool>> predicate);
        IQueryable<Worker> FindWorkersBy(Expression<Func<Worker, bool>> predicate);
        IQueryable<Status> FindStatusesBy(Expression<Func<Status, bool>> predicate);
        IQueryable<Position> FindPositionsBy(Expression<Func<Position, bool>> predicate);
        IQueryable<City> FindCitiesBy(Expression<Func<City, bool>> predicate);

        void Add(Flight entity);
        void Add(Route entity);
        void Add(Worker entity);

        void Delete(Flight entity);
        void Delete(Route entity);
        void Delete(Worker entity);

        void Edit(Flight entity);
        void Edit(Route entity);
        void Edit(Worker entity);

        void Save();
    }
}

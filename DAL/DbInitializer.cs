using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;
using Models.Entities;

namespace DAL
{
    /// <summary>
    /// Initializes database with default values when model changes.
    /// </summary>
    public class DbInitializer : DropCreateDatabaseAlways<AirplannerContext>
    {
        protected override void Seed(AirplannerContext context)
        {
            context.Cities.AddRange(
                new City[] {
                new City() { CityName = "Kharkiv" },
                new City() { CityName = "Kyiv" },
                new City() { CityName = "Odesa" },
                new City() { CityName = "Lviv" },
                new City() { CityName = "Moscow" },
                new City() { CityName = "Berlin" },
                new City() { CityName = "Paris" },
                new City() { CityName = "Rome" },
                new City() { CityName = "Milan" },
                new City() { CityName = "Krakow" },
                new City() { CityName = "Vienna" },
                new City() { CityName = "London" }
                });

            context.Positions.AddRange(
                new Position[]
                {
                    new Position() { PositionName = "First pilot" },
                    new Position() { PositionName = "Second pilot" },
                    new Position() { PositionName = "Navigator" },
                    new Position() { PositionName = "Radioman" },
                    new Position() { PositionName = "Steward" },
                });

            context.Statuses.AddRange(
                new Status[]
                {
                    new Status() { StatusName = "Active" },
                    new Status() { StatusName = "Accepted" },
                    new Status() { StatusName = "Denied" }
                });

            context.SaveChanges();

            for (int i = 1; i <= context.Cities.Count(); i++)
            {
                City outcome = context.Cities.Find(i);
                for (int j = 1; j <= context.Cities.Count(); j++)
                {
                    context.Routes.Add(new Route()
                    {
                        OutcomeCity = outcome,
                        DestinationCity = context.Cities.Find(j)
                    });
                }
            }

            context.SaveChanges();

            string[] names = new string[]
            {
                "Sergey", "Nikita", "Roman", "Vasiliy", "Oleg", "Stanislav", "Arkadiy", "Gleb", "Yan",
                "Yegor", "Maxim", "Dmitry", "Vladimir", "Yevheniy", "Yuriy", "Kirill", "Leonid",
                "Denys", "Elena", "Olga", "Svetlana", "Maria", "Kate", "Anna", "Alyse", "Yulia"
            };

            string[] surnames = new string[]
            {
                "Buffon", "Neto", "Rubinho", "Audero", "Chiellini", "Bonucci", "Lichtsteiner",
                "Caceres", "Sandro", "Pogba", "Dybala", "Morata", "Khedira", "Mandzukic", "Zaza",
                "Cuardado", "Rugani", "Pereyra", "Vadala", "Sturaro", "Evra", "Asamoah", "Barzagli",
                "Padoin", "Hernanes", "Lemina"
            };

            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                context.Workers.Add(
                    new Worker()
                    {
                        FirstName = names[random.Next(names.Length)],
                        LastName = surnames[random.Next(surnames.Length)],
                        Age = random.Next(20,55),
                        Position = context.Positions.Find(random.Next(context.Positions.Count())+1)
                    });
            }

            context.SaveChanges();

            List<Worker> firstPilots = context.Workers.Where(w => w.Position.PositionName.Equals("First pilot")).ToList();
            List<Worker> secondPilots = context.Workers.Where(w => w.Position.PositionName.Equals("Second pilot")).ToList();
            List<Worker> radiomans = context.Workers.Where(w => w.Position.PositionName.Equals("Radioman")).ToList();
            List<Worker> stewards = context.Workers.Where(w => w.Position.PositionName.Equals("Steward")).ToList();
            List<Worker> navigators = context.Workers.Where(w => w.Position.PositionName.Equals("Navigator")).ToList();
            for (int i = 0; i < 20; i++)
            {
                Status status = i > 15
                    ? context.Statuses.First(s => s.StatusName.Equals("Active"))
                    : context.Statuses.First(s => s.StatusName.Equals("Accepted"));
                DateTime departure = DateTime.Now.AddMinutes(random.Next(1000, 10000));
                DateTime arrival = departure.AddMinutes(random.Next(60, 1000));
                var stewardsUnique = Enumerable.Range(0, stewards.Count()).OrderBy(x => random.Next()).ToArray();
                context.Flights.Add(new Flight()
                {
                    FlightNumber = i+1001,
                    DepartureTime = departure,
                    ArrivalTime = arrival,
                    Route = context.Routes.Find(random.Next(context.Routes.Count())+1),
                    Status = status,
                    Workers = new List<Worker>()
                    {
                        firstPilots.ElementAt(random.Next(firstPilots.Count())),
                        secondPilots.ElementAt(random.Next(secondPilots.Count())),
                        radiomans.ElementAt(random.Next(radiomans.Count())),
                        navigators.ElementAt(random.Next(navigators.Count())),
                        stewards.ElementAt(stewardsUnique[0]),
                        stewards.ElementAt(stewardsUnique[1]),
                        stewards.ElementAt(stewardsUnique[2])
                    }
                });
            }

            context.SaveChanges();
        }
    }
}

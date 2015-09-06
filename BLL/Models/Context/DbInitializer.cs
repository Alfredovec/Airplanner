using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Entities;

namespace BLL.Models.Context
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AirplannerContext>
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
                    new Position() { PositionName = "First Pilot" },
                    new Position() { PositionName = "Second Pilot" },
                    new Position() { PositionName = "Navigator" },
                    new Position() { PositionName = "Radioman" },
                    new Position() { PositionName = "Steward" },
                });

            context.Statuses.AddRange(
                new Status[]
                {
                    new Status() { StatusName = "Active" },
                    new Status() { StatusName = "Accepted" },
                    new Status() { StatusName = "Refused" }
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
                        Position = context.Positions.Find(random.Next(context.Positions.Count())+1)
                    });
            }

            context.SaveChanges();

            for (int i = 0; i < 50; i++)
            {
                DateTime departure = DateTime.Now.AddMinutes(random.Next(1000, 10000));
                DateTime arrival = departure.AddMinutes(random.Next(60, 1000));
                context.Flights.Add(new Flight()
                {
                    DepartureTime = departure,
                    ArrivalTime = arrival,
                    Route = context.Routes.Find(random.Next(context.Routes.Count())+1),
                    Status = context.Statuses.First(status => status.StatusName.Equals("Active"))
                });
            }

            context.SaveChanges();
        }
    }
}

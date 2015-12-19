using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models.Entities;
using Models.Enums;
using Web.Models.View;

namespace Web.Extensions
{
    /// <summary>
    /// Container for extension methods assosiated with flights sorting.
    /// </summary>
    public static class SortExtensions
    {
        /// <summary>
        /// Recognizing needed sort order for item.
        /// </summary>
        /// <param name="needSwitch">Whether current sort order and sort order on page coincide with each other.</param>
        public static SortOrder FigureOrder(this UrlHelper url, SortOrder order, bool needSwitch)
        {
            return needSwitch && order == SortOrder.Asc ? SortOrder.Desc : SortOrder.Asc;
        }
        
        /// <summary>
        /// Sorting flights by a specific field and order.
        /// </summary>
        /// <returns>Sorted flights sequence.s</returns>
        public static IEnumerable<FlightViewModel> SortFlights(this IEnumerable<FlightViewModel> flights,
            FlightSortField sortField, SortOrder order)
        {
            switch (sortField)
            {
                case FlightSortField.Arrival:
                    return order == SortOrder.Asc
                        ? flights.OrderBy(f => f.ArrivalTime)
                        : flights.OrderByDescending(f => f.ArrivalTime);
                case FlightSortField.Departure:
                    return order == SortOrder.Asc
                        ? flights.OrderBy(f => f.DepartureTime)
                        : flights.OrderByDescending(f => f.DepartureTime);
                case FlightSortField.From:
                    return order == SortOrder.Asc
                        ? flights.OrderBy(f => f.OutcomeCityName)
                        : flights.OrderByDescending(f => f.OutcomeCityName);
                case FlightSortField.Number:
                    return order == SortOrder.Asc
                        ? flights.OrderBy(f => f.FlightNumber)
                        : flights.OrderByDescending(f => f.FlightNumber);
                case FlightSortField.To:
                    return order == SortOrder.Asc
                        ? flights.OrderBy(f => f.DestinationCityName)
                        : flights.OrderByDescending(f => f.DestinationCityName);
            }
            return flights;
        }
    }
}

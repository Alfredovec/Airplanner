using System.ComponentModel.DataAnnotations;
using Web.Models.View;

namespace Web.Models.Attributes
{
    /// <summary>
    /// Validating whether departure time is less than arrival.
    /// </summary>
    public class TimeCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            FlightViewModel model = value as FlightViewModel;
            return model != null && model.DepartureTime < model.ArrivalTime;
        }
    }
}

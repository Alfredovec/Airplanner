using System.ComponentModel.DataAnnotations;
using Web.Models.View;

namespace Web.Models.Attributes
{
    /// <summary>
    /// Validating whether outcome and destination cities don't coincide with each other.
    /// </summary>
    public class RouteCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = value as FlightViewModel;
            return model?.OutcomeCityName != null
                   && model.DestinationCityName != null
                   && model.OutcomeCityName != model.DestinationCityName;
        }
    }
}
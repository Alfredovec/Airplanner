using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Web.Models.Attributes;

namespace Web.Models.View
{
    /// <summary>
    /// Model representing dealing with flight options.
    /// </summary>
    [RouteCheck(ErrorMessage = "Outcome and destination points should be different.")]
    [TimeCheck(ErrorMessage = "Flight's departure time shoud be less than arrival time. ")]
    public class FlightViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should specify flight number.")]
        [Display(Name = "Flight number")]
        [Range(1, Int16.MaxValue, ErrorMessage = "Number should be between 1 and 32767")]
        public int FlightNumber { get; set; }

        [Required(ErrorMessage = "You should specify departure time.")]
        [Display(Name = "Departure time")]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "You should specify arrival time.")]
        [Display(Name = "Arrival time")]
        public DateTime ArrivalTime { get; set; }

        [Required(ErrorMessage = "You should specify outcome city.")]
        [Display(Name = "Outcome city")]
        public string OutcomeCityName { get; set; }

        [Required(ErrorMessage = "You should specify destination city.")]
        [Display(Name = "Destination city")]
        public string DestinationCityName { get; set; }

        [Required(ErrorMessage = "You should specify first pilot name.")]
        [Display(Name = "First pilot")]
        public string FirstPilotName { get; set; }

        [Required(ErrorMessage = "You should specify second pilot name.")]
        [Display(Name = "Second pilot")]
        public string SecondPilotName { get; set; }

        [Required(ErrorMessage = "You should specify radioman name.")]
        [Display(Name = "Radioman")]
        public string RadiomanName { get; set; }

        [Required(ErrorMessage = "You should specify navigator name.")]
        [Display(Name = "Navigator")]
        public string NavigatorName { get; set; }

        [Required(ErrorMessage = "You should specify steward name.")]
        [Display(Name = "Steward")]
        public string FirstSteward { get; set; }

        [Required(ErrorMessage = "You should specify steward name.")]
        [Display(Name = "Steward")]
        public string SecondSteward { get; set; }

        [Required(ErrorMessage = "You should specify steward name.")]
        [Display(Name = "Steward")]
        public string ThirdSteward { get; set; }
        
        public Dictionary<string, List<SelectListItem>> DropDownLists { get; set; }
    }
}

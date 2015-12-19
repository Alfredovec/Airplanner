using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models.View
{
    /// <summary>
    /// Model representing dealing with worker options.
    /// </summary>
    public class WorkerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You should specify first name.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should specify last name.")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You should specify age.")]
        [Display(Name = "Age")]
        [Range(20, 55, ErrorMessage = "Worker's age should be between 20 and 55.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "You should specify position.")]
        [Display(Name = "Position name")]
        public string PositionName { get; set; }

        public Dictionary<string, List<SelectListItem>> DropDownLists { get; set; }
    }
}

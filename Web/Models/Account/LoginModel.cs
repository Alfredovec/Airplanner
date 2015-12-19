﻿using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
    /// <summary>
    /// Representing view model for authentication.
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

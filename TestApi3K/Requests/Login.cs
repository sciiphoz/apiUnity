﻿using System.ComponentModel.DataAnnotations;

namespace TestApi3K.Requests
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

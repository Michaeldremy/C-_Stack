using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The_Wall.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Please enter your email!")]
        [Display(Name = "Email")]
        public string Email {get;set;}
        [Required(ErrorMessage = "Please enter your Password!")]
        [Display(Name = "Password")]
        public string Password {get;set;}
    }
}
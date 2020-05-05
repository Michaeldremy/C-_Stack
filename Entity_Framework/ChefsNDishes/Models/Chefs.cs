using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required(ErrorMessage="Please enter a first name.")]
        [Display(Name = "First Name")]
        public string ChefFirstName {get;set;}
        [Required(ErrorMessage="Please enter a last name.")]
        [Display(Name = "Last Name")]
        public string ChefLastName {get;set;}
        [Required(ErrorMessage="Please enter a date of birth")]
        [Display(Name = "Date of Birth")]
        public DateTime Birthday {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Dish> CreatedDishes {get;set;}

        // Code below is for converting a date entry into a int.
        public int Age 
        {
            get { return DateTime.Now.Year - Birthday.Year; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required(ErrorMessage = "Please enter a dish.")]
        [Display(Name = "Name of Dish")]
        public string Name {get;set;}
        [Required]
        [Range(0,5000, ErrorMessage = "Calories cannot exceed 5000.")]
        public int Calories {get;set;}
        [Required]
        [Range(1,5)]
        public int Tastiness {get;set;}
        [Required(ErrorMessage = "Please enter a description")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        [Display(Name = "Chef")]
        public int ChefId {get;set;}
        public Chef Creator {get;set;}
    }
}
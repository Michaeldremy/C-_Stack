using System;
using System.ComponentModel.DataAnnotations;

namespace Dojo_Survey.Models
{
    public class DojoSurvey
    {
        // The two lines ↓ are Validations for C# / ASP.NET Framework
        [Required(ErrorMessage="Please enter a name!")]
        [MinLength(2, ErrorMessage="The name entered must be atleast 2 characters long.")]
        // Line ↓ is what will display next to the required enter box
        [Display(Name = "Your Name:")]
        public string Name {get;set;}

        [Required(ErrorMessage="Please choose a location!")]
        [Display(Name = "Dojo Location:")]
        public string Location {get;set;}

        [Required(ErrorMessage="Please choose a language!")]
        [Display(Name = "Coding Language:")]
        public string Language {get;set;}

        [MaxLength(50, ErrorMessage="Your comment cannot be longer than 50 characters!")]
        [Display(Name = "Comment (Optional)")]
        public string Comment {get;set;}
    }
}
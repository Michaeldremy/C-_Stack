using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}
        [Required]
        [Display(Name = "Bride")]
        public string Wedder_One {get;set;}
        [Required]
        [Display(Name = "Groom")]
        public string Wedder_Two {get;set;}
        [Required]
        public DateTime Date {get;set;}
        [Required]
        [Display(Name = "Address")]
        public string Wedding_Address {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public int UserId {get;set;}
        public User User {get;set;}
        
        // This is the navigation property
        public List<Association> AllUsers {get;set;}
    }
}
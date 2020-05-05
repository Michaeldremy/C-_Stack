using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belt_exam.Models
{
    public class Sport
    {
        [Key]
        public int SportId {get;set;}
        [Required]
        public string Title {get;set;}
        [Required]
        public DateTime Time {get;set;}
        [Required]
        public DateTime Date {get;set;}
        [Required]
        public string DurationType {get;set;}
        public int Duration {get;set;}
        [Required]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public int UserId {get;set;}
        public User User {get;set;}
        public List<Association> AllAssociations {get;set;}
    }
}
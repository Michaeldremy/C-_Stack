using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// the project is lowecase "b" as im belt2_exam
namespace belt2_exam.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public int UserId {get;set;}
        public User User {get;set;}
        public List<Association> AllAssociations {get;set;}
        public int ProficiencyId {get;set;}
        public Proficiency Proficiency {get;set;}
    }
}

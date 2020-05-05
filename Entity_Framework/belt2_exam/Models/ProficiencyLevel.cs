using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace belt2_exam.Models
{
    public class Proficiency
    {
        [Key]
        public int ProficiencyId {get;set;}
        public string ProficiencyLevel {get;set;}
        public User User {get;set;}
        public List<Hobby> AllHobbies {get;set;}
        public List<Association> AllTheAssociations {get;set;}
    }
}
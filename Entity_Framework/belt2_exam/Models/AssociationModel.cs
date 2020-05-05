using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// the project is lowecase "b" as im belt2_exam
namespace belt2_exam.Models
{
    public class Association
    {
        [Key]
        public int AssociationId {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        public int HobbyId {get;set;}
        public Hobby Hobby {get;set;}
        public int ProficiencyId {get;set;}
        public Proficiency Proficiency {get;set;}
    }
}
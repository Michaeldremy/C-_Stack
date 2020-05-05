using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace belt2_exam.Models
{
    public class BeltWrapper
    {
        public User User {get;set;}
        public List<User> AllUsers {get;set;}
        public Association Association {get;set;}
        public Hobby Hobby {get;set;}
        public List<Hobby> Hobbies {get;set;}
        public Proficiency Proficiency {get;set;}
        public List<Proficiency> Proficiencies {get;set;}
    }
}
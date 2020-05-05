using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belt_exam.Models
{
    public class BeltWrapper
    {
        public Sport Sport {get;set;}
        public List<Sport> AllSports {get;set;}
        public Association Association {get;set;}
        public User User {get;set;}
        public List<User> AllUsers {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Belt_exam.Models
{
    public class Association
    {
        public int AssociationId {get;set;}
        public int SportId {get;set;}
        public Sport Sport {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
    }
}

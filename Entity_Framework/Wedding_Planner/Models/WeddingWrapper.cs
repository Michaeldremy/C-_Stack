using System;
using System.Collections.Generic;

namespace Wedding_Planner.Models
{
    public class WeddingWrapper
    {
        public Wedding Wedding {get;set;}
        public List<Wedding> Weddings {get;set;}
        public Association Association {get;set;}
        public User User {get;set;}
        public List<User> Users {get;set;}
    }
}
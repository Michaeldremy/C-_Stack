using System;
using System.Collections.Generic;
namespace WeddingPlanner.Models
{
    public class ThisWrapper
    {
        public User ThisUser {get;set;}
        public LoginUser ThisLoginUser {get;set;}
        public Wedding ThisWedding {get;set;}
        public List<User> Guests {get;set;}
        public List<Wedding> AllWeddings {get;set;}
        public Association Association {get; set;}
    }
}
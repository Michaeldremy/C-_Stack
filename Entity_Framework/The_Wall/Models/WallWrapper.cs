using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_Wall.Models
{
    public class WallWrapper
    {
        public User User {get;set;}
        public List<User> AllUsers {get;set;}
        public Message Message {get;set;}
        public List<Message> AllMessages {get;set;}
        public Comment Comment {get;set;}
        public List<Comment> AllComments {get;set;}

    }
}
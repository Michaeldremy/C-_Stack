using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_Wall.Models
{
    public class Message
    {
        [Key]
        public int MessageId {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        [Required(ErrorMessage = "Please enter a Message!")]
        [MaxLength(100, ErrorMessage = "Message cannot exceed 100 characters.")]
        public string Msg {get;set;}
        public List<Comment> AllComments {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;
    }
}
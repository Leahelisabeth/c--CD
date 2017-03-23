using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace UserDb.Models

{
    public class Comment : BaseEntity
    {
        [Key]
        public int CommentId { get; set; }
        public string Content {get; set;}
        public User User { get; set; }
        public int UserId { get; set; }//person who made comment
        public Post Post {get; set;}//post belongs to
        public int PosterId {get; set;}
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDb.Models

{
    public class Post : BaseEntity
    {
        [Key]
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        [InversePropertyAttribute("PostsSent")]
        public User Creator { get; set; }//person who made the post
        [ForeignKey("UserId")]
        public int CreatorId { get; set; }//person who actually made the post
        [InversePropertyAttribute("PostsGot")]
        public User Recipient { get; set; }//person whose profile the post was made on/post is for.
        [ForeignKey("UserId")]
        public int RecipientId { get; set; }//person who post is for
        public List<Comment> Comments { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
            Creator = new User();
            Recipient = new User();
        }
    }

}
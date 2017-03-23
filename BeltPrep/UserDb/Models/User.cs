using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDb.Models

{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Desc { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Boolean UserLevel { get; set; }
        [InverseProperty("Creator")]
        public List<Post> PostsSent { get; set; }
        [InverseProperty("Recipient")]
        public List<Post> PostsGot { get; set; }
        public List<Comment> Comments { get; set; }

        public User()
        {
            PostsSent = new List<Post>();
            PostsGot = new List<Post>();
            Comments = new List<Comment>();
        }
    }
}
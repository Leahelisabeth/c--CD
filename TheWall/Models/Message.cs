using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Message : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MinLengthAttribute(2)]
        public string content { get; set; }

        [Required]
        public int users_id { get; set; }
        public User user { get; set; }
        public List<Comment> comments { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }

}
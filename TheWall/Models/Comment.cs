using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MinLengthAttribute(2)]
        public string commentbody { get; set; }
        public int users_id { get; set; }
        public int messages_id { get; set; }
        public User user { get; set; }
        public Message message { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }

}
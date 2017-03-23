using System;
using System.ComponentModel.DataAnnotations;

namespace quotingDojo.Models
{
    public class Quote : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string user { get; set; }

        [Required]
        public string content { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // public Quote()
        // {
        //     CreatedAt = DateTime.Now;
        //     UpdatedAt = DateTime.Now;
        //     Likes = 0;
        // }
    }
}
//schema names MUST MATCH MODEL CATEGORIES!!! this caused me major issues on front end parsing.
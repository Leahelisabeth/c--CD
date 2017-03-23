using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST.Models

{
    public class Reviews
    {
        [Key]
        public int id { get; set; }

        [RequiredAttribute]
        [MinLengthAttribute(2)]
        public string Content { get; set; }

        [RequiredAttribute]
        [InThePast]
        public DateTime DateVisit { get; set; }
        [RequiredAttribute]
        public int Rating { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Userid { get; set; }
        public int Restarid { get; set; }
    }
}
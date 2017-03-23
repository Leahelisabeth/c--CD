using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST.Models

{
    public class Restar
    {
        [Key]
        public int id { get; set; }

        [RequiredAttribute]
        [MinLengthAttribute(2)]
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public ICollection<Reviews> Reviews {get; set;}

    }
}
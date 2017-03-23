using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Woods.Models
{
    public class Trail : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MinLengthAttribute(2)]
        public string Name { get; set; }

        [Required]
        [MinLengthAttribute(2)]
        public string Desc { get; set; }
        [Required]
        public float Length { get; set; }
        [Required]
        public double Elevation { get; set; }
        [Required]
        public double Long { get; set; }
        [Required]
        public double Lat { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }

}
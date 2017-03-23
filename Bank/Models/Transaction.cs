using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Bank.Models

{
    public class Transaction : BaseEntity
    {
        [Key]
        public int id { get; set; }
        [RequiredAttribute]
        public Double AddTake { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
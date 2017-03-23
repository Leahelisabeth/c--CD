using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Bank.Models

{
    public class User: BaseEntity
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public Double Balance {get; set;}
        public List<Transaction> Transactions {get; set;}

        public User(){
            Transactions = new List<Transaction>();
        }
    }
}
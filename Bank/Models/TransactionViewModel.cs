using System;
using System.ComponentModel.DataAnnotations;



namespace Bank.Models

{
    public class TransactionViewModel : BaseEntity
    {
        [RequiredAttribute]
        public Double AddTake { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
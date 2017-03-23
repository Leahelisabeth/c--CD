using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitySetup.Models

{
    public class Person : IValidatableObject
    {
        [Key]
        public int PersonId { get; set; }

        [RequiredAttribute]
        [MinLengthAttribute(2)]
        public string Name { get; set; }
        [RequiredAttribute]
        [MinLengthAttribute(2)]
        public EmailAddressAttribute Email { get; set; }
        [RequiredAttribute]
        [MinLengthAttribute(6)]
        public string Password { get; set; }

        [RequiredAttribute]
        public int Age { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace wedding.Models

{
    public class GuestViewModel : BaseEntity
    {

        [RequiredAttribute]
        [MinLength(2, ErrorMessage="Name field must be minimum of two characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Name cannnot contain numerical or special characters")]
        public string Name { get; set; }

        [RequiredAttribute]
        public string GuestOf {get; set;}

    }
}
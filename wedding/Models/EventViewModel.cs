using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace wedding.Models

{
    public class EventViewModel : BaseEntity
    {

        [RequiredAttribute]
        [MinLength(2, ErrorMessage="Name field must be minimum of two characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Name cannnot contain numerical or special characters")]
        public string Spouse { get; set; }

        [RequiredAttribute]
        public string SpouseTitle { get; set; }
        //could be user, or could be planned by third party and not be a user
        [RequiredAttribute]
        [MinLength(2, ErrorMessage="Name field must be minimum of two characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Name cannnot contain numerical or special characters")]
        public string SndSpouse {get; set;}

        [RequiredAttribute]
        public string SndSpouseTitle { get; set; }

        [RequiredAttribute]
        [InTheFuture]
        public DateTime WedDay { get; set; }

    }
}
